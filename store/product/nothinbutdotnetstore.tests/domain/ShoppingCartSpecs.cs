using System.Collections.Generic;
using System.Linq;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.core.extensions;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.domain;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.domain
{
    public class ShoppingCartSpecs
    {
        public abstract class concern : observations_for_a_sut_without_a_contract<ShoppingCart>
        {
            context c = () =>
            {
                shopping_cart_items = new List<ShoppingCartItem>();
                cart_item_factory = the_dependency<ShoppingCartItemFactory>();
                provide_a_basic_sut_constructor_argument(shopping_cart_items);
            };

            static protected IList<ShoppingCartItem> shopping_cart_items;
            static protected ShoppingCartItemFactory cart_item_factory;
        }

        [Concern(typeof (ShoppingCart))]
        public class when_adding_an_item_to_the_shopping_cart : concern
        {
            context c = () =>
            {
                item_for_pepsi = new ShoppingCartItem();
                can_of_pepsi = an<Product>();

                cart_item_factory.Stub(factory => factory.create_from(can_of_pepsi)).Return(item_for_pepsi);
            };

            because b = () =>
            {
                sut.add(can_of_pepsi);
            };


            it the_item_should_be_stored_in_the_list_of_shopping_cart_items = () =>
            {
                shopping_cart_items.should_contain(item_for_pepsi);
            };

            static ShoppingCartItem item_for_pepsi;
            static Product can_of_pepsi;
        }

        public abstract class concern_for_a_cart_with_a_can_of_pepsi_in_it : concern
        {
            context c = () =>
            {
                item_for_pepsi = an<ShoppingCartItem>();
                can_of_pepsi = an<Product>();
                item_for_pepsi.Stub(item => item.is_item_for(can_of_pepsi)).Return(true);
                shopping_cart_items.Add(item_for_pepsi);
            };

            static protected ShoppingCartItem item_for_pepsi;
            static protected Product can_of_pepsi;
        }

        [Concern(typeof (ShoppingCart))]
        public class when_adding_an_product_that_is_already_in_the_cart : concern_for_a_cart_with_a_can_of_pepsi_in_it
        {
            because b = () =>
            {
                sut.add(can_of_pepsi);
            };

            it should_increment_the_quantity_of_the_item_for_the_product = () =>
            {
                item_for_pepsi.received(item => item.increment_quantity());
            };
        }

        [Concern(typeof (ShoppingCart))]
        public class when_adding_a_bag_of_chips_to_a_cart_that_only_contains_a_can_of_pepsi : concern_for_a_cart_with_a_can_of_pepsi_in_it
        {
            context c = () =>
            {
                item_for_pringles = an<ShoppingCartItem>();
                pringles = an<Product>();
                cart_item_factory.Stub(factory => factory.create_from(pringles)).Return(item_for_pringles);
            };

            because b = () =>
            {
                sut.add(pringles);
            };

            it should_store_the_bag_of_chips = () =>
            {
                shopping_cart_items.Count.should_be_equal_to(2);
                shopping_cart_items.should_contain(item_for_pringles);
            };

            static Product pringles;
            static ShoppingCartItem item_for_pringles;
        }

        [Concern(typeof (ShoppingCart))]
        public class when_removing_an_item_from_the_shopping_cart : concern_for_a_cart_with_a_can_of_pepsi_in_it
        {
            because b = () =>
            {
                sut.remove(can_of_pepsi);
            };

            it the_item_should_no_longer_be_in_the_list_of_shopping_cart_items = () =>
            {
                shopping_cart_items.Count.should_be_equal_to(0);
            };
        }

        [Concern(typeof (ShoppingCart))]
        public class when_attempting_to_remove_an_product_that_it_does_not_contain : concern_for_a_cart_with_a_can_of_pepsi_in_it
        {
            context c = () =>
            {
                product_not_in_the_cart = an<Product>();
            };

            because b = () =>
            {
                sut.remove(product_not_in_the_cart);
            };

            it should_not_do_anything = () =>
            {
                shopping_cart_items.Count.should_be_equal_to(1);
            };

            static Product product_not_in_the_cart;
        }

        [Concern(typeof (ShoppingCart))]
        public class when_emptying_the_shopping_cart : concern
        {
            context c = () =>
            {
                Enumerable.Range(1, 100).each(i => shopping_cart_items.Add(an<ShoppingCartItem>()));
            };

            because b = () =>
            {
                sut.empty();
            };

            it should_not_have_any_items_in_the_cart = () =>
            {
                shopping_cart_items.Count.should_be_zero();
            };
        }


        [Concern(typeof (ShoppingCart))]
        public class when_modifying_the_quantity_of_an_item_in_the_cart : concern_for_a_cart_with_a_can_of_pepsi_in_it
        {
            context c = () =>
            {
                updated_quantity = 2;
            };

            because b = () =>
            {
                sut.change_quantity(can_of_pepsi, updated_quantity);
            };

            it should_update_the_quantity_of_the_item_to_the_new_quantity = () =>
            {
                item_for_pepsi.received(item => item.change_quantity_to(updated_quantity));
            };

            static int updated_quantity;
        }

        [Concern(typeof (ShoppingCart))]
        public class when_changing_the_quantity_of_a_product_causes_the_item_to_be_empty : concern_for_a_cart_with_a_can_of_pepsi_in_it
        {
            context c = () =>
            {
                item_for_pepsi.Stub(item => item.is_empty()).Return(true);
            };

            because b = () =>
            {
                sut.change_quantity(can_of_pepsi, 0);
            };

            it should_be_removed_from_the_cart = () =>
            {
                shopping_cart_items.should_not_contain(item_for_pepsi);
            };

        }
    }
}