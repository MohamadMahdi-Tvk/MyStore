using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;

namespace MyStore.Application.Services.Users.Commands.UserStatusChange
{
    public class UserStatusChangeService : IUserStatusChangeService
    {
        private readonly IDataBaseContext _context;
        public UserStatusChangeService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long userId)
        {
            var user = _context.Users.Find(userId);

            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.IsActive = !user.IsActive;
            _context.SaveChanges();

            string userState = user.IsActive == true ? "فعال" : "غیرفعال";

            return new ResultDto
            {
                IsSuccess = true,
                Message = $"کاربر {userState} شد"
            };
        }
    }
}
