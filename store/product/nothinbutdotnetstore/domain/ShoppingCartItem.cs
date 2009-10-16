using System;

namespace nothinbutdotnetstore.domain
{
    public class ShoppingCartItem
    {
        public virtual bool is_item_for(Product product)
        {
            throw new NotImplementedException();
        }

        public virtual void increment_quantity()
        {
            throw new NotImplementedException();
        }

        public virtual void change_quantity_to(int updated_quantity)
        {
            throw new NotImplementedException();
        }

        public virtual bool is_empty()
        {
            throw new NotImplementedException();
        }
    }
}