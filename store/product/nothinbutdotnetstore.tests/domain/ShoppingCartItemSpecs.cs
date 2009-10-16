using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.domain;

namespace nothinbutdotnetstore.tests.domain
{
    public class ShoppingCartItemSpecs
    {
        public abstract class concern : observations_for_a_sut_without_a_contract<ShoppingCartItem>
        {
            context c = () =>
            {
                product = an<Product>();
                provide_a_basic_sut_constructor_argument(product);
                initial_quantity = 1;
            };

            public override ShoppingCartItem create_sut()
            {
                return new ShoppingCartItem(product, initial_quantity);
            }

            static protected Product product;
            static protected int initial_quantity;
        }

        [Concern(typeof (ShoppingCartItem))]
        public class when_determining_if_it_is_the_item_for_a_product : concern
        {
            context c = () =>
            {
                different_product = new Product();
            };


            it should_base_the_decision_on_whether_the_product_is_what_it_represents = () =>
            {
                sut.is_item_for(product).should_be_true();
                sut.is_item_for(different_product).should_be_false();
            };

            static bool result;
            static Product different_product;
        }

        [Concern(typeof (ShoppingCartItem))]
        public class when_incrementing_the_quantity_of_an_item : concern
        {

            because b = () =>
            {
                sut.increment_quantity();
            };


            it should_add_1_to_the_initial_quantity = () =>
            {
                sut.quantity.should_be_equal_to(initial_quantity + 1);
            };

        }

        [Concern(typeof (ShoppingCartItem))]
        public class when_changing_the_quantity_of_an_item : concern
        {
            context c = () =>
            {
                new_quantity = 25;
            };

            because b = () =>
            {
                sut.change_quantity_to(new_quantity);
            };


            it should_set_the_quantity_to_the_new_quantity = () =>
            {
                sut.quantity.should_be_equal_to(new_quantity);
            };

            static int new_quantity;
        }

        [Concern(typeof (ShoppingCartItem))]
        public class when_checking_to_see_if_an_item_is_empty_and_it_is : concern
        {
            context c = () =>
            {
                initial_quantity = 0;
            };

            because b = () =>
            {
                result = sut.is_empty();
            };


            it should_return_true = () =>
            {
                result.should_be_equal_to(true);
            };

            static bool result;
        }

        [Concern(typeof (ShoppingCartItem))]
        public class when_checking_to_see_if_an_item_is_empty_and_it_is_not : concern
        {

            because b = () =>
            {
                result = sut.is_empty();
            };


            it should_return_false = () =>
            {
                result.should_be_equal_to(false);
            };

            static bool result;
        }
    }
}