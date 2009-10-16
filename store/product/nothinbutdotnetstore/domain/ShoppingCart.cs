using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.domain
{
    public class ShoppingCart
    {
        IList<ShoppingCartItem> shopping_cart_items;
        ShoppingCartItemFactory cart_item_factory;

        public ShoppingCart(IList<ShoppingCartItem> shopping_cart_items, ShoppingCartItemFactory cart_item_factory)
        {
            this.shopping_cart_items = shopping_cart_items;
            this.cart_item_factory = cart_item_factory;
        }

        public void add(Product product)
        {
            if (already_contains_item_for(product))
            {
                get_item_for(product).increment_quantity();
                return;
            }
            shopping_cart_items.Add(cart_item_factory.create_from(product));
        }

        ShoppingCartItem get_item_for(Product product)
        {
            return shopping_cart_items.FirstOrDefault(item => item.is_item_for(product)) ?? new MissingCartItem();
        }

        bool already_contains_item_for(Product product)
        {
            return shopping_cart_items.Any(item => item.is_item_for(product));
        }

        public void remove(Product product)
        {
            shopping_cart_items.Remove(get_item_for(product));
        }

        public void empty()
        {
            shopping_cart_items.Clear();
        }

        public void change_quantity(Product product, int new_quantity)
        {
            var item = get_item_for(product);
            item.change_quantity_to(new_quantity);
            if (item.is_empty()) shopping_cart_items.Remove(item);
        }

        class MissingCartItem : ShoppingCartItem
        {
            public override bool is_item_for(Product product)
            {
                return false;
            }

            public override void increment_quantity() {}

            public override void change_quantity_to(int updated_quantity) {}

            public override bool is_empty()
            {
                return true;
            }
        }
    }
}