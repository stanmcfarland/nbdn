using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.domain
{
    public class ShoppingCartItem
    {
        public ShoppingCartItem()
        {
            this.quantity = 1;
        }

        public decimal amount
        {
            get { return quantity * unit_price; }
        }

        public decimal unit_price
        {
            get; set;
        }

        public int quantity
        {
            get; set;
        }

        public Department department
        {
            get; set;
        }
    }
}