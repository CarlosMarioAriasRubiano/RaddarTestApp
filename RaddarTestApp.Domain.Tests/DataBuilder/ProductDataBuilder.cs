using RaddarTestApp.Domain.Entities;

namespace RaddarTestApp.Domain.Tests.DataBuilder
{
    public class ProductDataBuilder
    {
        private int Id;
        private string Name;
        private string Description;
        private decimal Price;
        private int Stock;
        private DateTime CreateDate;

        public ProductDataBuilder()
        {
            Id = 1;
            Name = "Test Name";
            Description = "Test Description";
            Price = 15;
            Stock = 10;
            CreateDate = DateTime.Now;
        }

        public ProductDataBuilder WithId(int id)
        {
            Id = id;
            return this;
        }

        public ProductDataBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public ProductDataBuilder WithDescription(string description)
        {
            Description = description;
            return this;
        }

        public ProductDataBuilder WithPrice(decimal price)
        {
            Price = price;
            return this;
        }

        public ProductDataBuilder WithStock(int stock)
        {
            Stock = stock;
            return this;
        }

        public ProductDataBuilder WithCreateDate(DateTime createDate)
        {
            CreateDate = createDate;
            return this;
        }

        public Product Build()
        {
            return new()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Price = Price,
                Stock = Stock,
                CreateDate = CreateDate
            };
        }
    }
}
