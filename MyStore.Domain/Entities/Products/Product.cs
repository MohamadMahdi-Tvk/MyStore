using MyStore.Domain.Entities.Commons;

namespace MyStore.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }

        public virtual Category Category { get; set; }
        public long CategoryId { get; set; }

        public ICollection<ProductImages> ProductImages { get; set; }

        public ICollection<ProductFeatures> ProductFeatures { get; set; }

    }
}
