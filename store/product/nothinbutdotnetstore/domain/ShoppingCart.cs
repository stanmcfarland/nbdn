using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using developwithpassion.bdd.core.extensions;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.domain
{
    public class ShoppingCart
    {
        IList<ShoppingCartItem> shopping_cart_items;

        public ShoppingCart(IList<ShoppingCartItem> shopping_cart_items)
        {
            this.shopping_cart_items = shopping_cart_items;
        }

        public IEnumerable<ShoppingCartItem> all_items
        {
            get { return new ReadOnlyCollection<ShoppingCartItem>(shopping_cart_items).one_at_a_time(); }
        }

        public decimal total_cost
        {
            get { return shopping_cart_items.Sum(x => x.amount); }
        }

        public void add_item(ShoppingCartItem item)
        {
           shopping_cart_items.Add(item);
        }

        public void remove_item(ShoppingCartItem item)
        {
            shopping_cart_items.Remove(item);
        }

        public void empty_the_cart()
        {
           shopping_cart_items.Clear();
        }

        public void update_quantity(ShoppingCartItem item_to_update, int quantity)
        {
            shopping_cart_items[shopping_cart_items.IndexOf(item_to_update)].quantity = quantity;
        }

        public IEnumerable<IGrouping<Property, ShoppingCartItem>> group_by<Property>(Func<ShoppingCartItem, Property> property_accessor)
        {
            return shopping_cart_items.GroupBy(property_accessor).Select(x => x);
        }
    }
}