namespace nothinbutdotnetstore.domain
{
    public class ShoppingCartItem
    {
        Product product;
        public int quantity { get; private set; }

        public ShoppingCartItem() {}

        public ShoppingCartItem(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }

        public virtual bool is_item_for(Product product)
        {
            return this.product.Equals(product);
        }

        public virtual void increment_quantity()
        {
            quantity++;
        }

        public virtual void change_quantity_to(int updated_quantity)
        {
            quantity = updated_quantity;
        }

        public virtual bool is_empty()
        {
            return quantity <= 0;
        }
    }
}