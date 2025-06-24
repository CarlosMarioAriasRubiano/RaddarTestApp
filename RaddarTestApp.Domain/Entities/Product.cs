using RaddarTestApp.Domain.Entities.Base;
using RaddarTestApp.Domain.Exceptions;

namespace RaddarTestApp.Domain.Entities
{
    public class Product : EntityBase<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreateDate { get; set; }

        public void ValidatePriceGreatherThanZero()
        {
            if (!(Price > 0))
            {
                throw new AppException(MessagesExceptions.PriceGreatherThanZero);
            }
        }

        public void ValidateStockGreatherThanZero()
        {
            if (!(Stock > 0))
            {
                throw new AppException(MessagesExceptions.StockGreatherThanZero);
            }
        }
    }
}
