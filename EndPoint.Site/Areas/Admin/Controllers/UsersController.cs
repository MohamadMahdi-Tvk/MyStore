using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyStore.Application.Interfaces.FacadPattern;
using MyStore.Application.Services.Users.Commands.EditUser;
using MyStore.Application.Services.Users.Commands.RegisterUser;
using MyStore.Application.Services.Users.Queries.GetUsers;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserFacad _userFacad;

        public UsersController(IUserFacad userFacad)
        {
            _userFacad = userFacad;
        }

        public IActionResult Index(string searchKey, int page = 1)
        {
            return View(_userFacad.GetUsersService.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = searchKey,
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_userFacad.GetRolesService.Execute().Data, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _userFacad.RegisterUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                Roles = new List<RolesInRegisterUserDto>()
                   {
                        new RolesInRegisterUserDto
                        {
                             Id= RoleId
                        }
                   },
                Password = Password,
                RePasword = RePassword,
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long userId)
        {
            return Json(_userFacad.RemoveUserService.Execute(userId));
        }

        [HttpPost]
        public IActionResult UserSatusChange(long UserId)
        {
            return Json(_userFacad.UserStatusChangeService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(long UserId, string FullName)
        {
            return Json(_userFacad.EditUserService.Execute(new RequestEditUserDto
            {
                FullName = FullName,
                UserId = UserId
            }));
        }
    }
}
