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
        
         }

         [Concern(typeof(ShoppingCartItem))]
         public class when_checking_if_the_item_is_for_a_product_and_it_is : concern
         {
             context c = () =>
                             {
                                 product = new Product();
                                 provide_a_basic_sut_constructor_argument(product);
                             };

             because b = () =>
                             {
                                 result = sut.is_item_for(product);
                             };

        
             it should_return_true = () =>
                        {
                            result.should_be_equal_to(true);
            
            
                        };

             private static Product product;
             private static bool result;
         }
         
         [Concern(typeof(ShoppingCartItem))]
         public class when_checking_if_the_item_is_for_a_product_and_it_not : concern
         {
             context c = () =>
             {
                 product_for_constructor = new Product();
                 product_for_checking = new Product();
                 provide_a_basic_sut_constructor_argument(product_for_constructor);
             };

             because b = () =>
             {
                 result = sut.is_item_for(product_for_checking);
             };


             it should_return_false = () =>
             {
                 result.should_be_equal_to(false);


             };

             private static Product product_for_constructor;
             private static Product product_for_checking;
             private static bool result;
         }

         [Concern(typeof(ShoppingCartItem))]
         public class when_incrementing_the_quantity_of_an_item : concern
         {
             context c = () =>
             {
                 initial_quantity = 1;
                 product = new Product();
                 provide_a_basic_sut_constructor_argument(product);
                 provide_a_basic_sut_constructor_argument(initial_quantity);
             };

             because b = () =>
             {
                 sut.increment_quantity();
             };


             it should_add_1_to_the_initial_quantity = () =>
             {
                 sut.quantity.should_be_equal_to(initial_quantity + 1);


             };

             private static Product product;
             private static int initial_quantity;
         }

         [Concern(typeof(ShoppingCartItem))]
         public class when_changing_the_quantity_of_an_item : concern
         {
             context c = () =>
             {
                 initial_quantity = 1;
                 new_quantity = 25;
                 product = new Product();
                 provide_a_basic_sut_constructor_argument(product);
                 provide_a_basic_sut_constructor_argument(initial_quantity);
             };

             because b = () =>
             {
                 sut.change_quantity_to(new_quantity);
             };


             it should_set_the_quantity_to_the_new_quantity = () =>
             {
                 sut.quantity.should_be_equal_to(new_quantity);


             };

             private static Product product;
             private static int initial_quantity;
             private static int new_quantity;
         }

         [Concern(typeof(ShoppingCartItem))]
         public class when_checking_to_see_if_an_item_is_empty_and_it_is : concern
         {
             context c = () =>
             {
                 quantity = 0;
                 product = new Product();
                 provide_a_basic_sut_constructor_argument(product);
                 provide_a_basic_sut_constructor_argument(quantity);
             };

             because b = () =>
             {
                 result = sut.is_empty();
             };


             it should_return_true = () =>
             {
                 result.should_be_equal_to(true);


             };

             private static Product product;
             private static int quantity;
             private static bool result;
         }

         [Concern(typeof(ShoppingCartItem))]
         public class when_checking_to_see_if_an_item_is_empty_and_it_is_not : concern
         {
             context c = () =>
             {
                 quantity = 1;
                 product = new Product();
                 provide_a_basic_sut_constructor_argument(product);
                 provide_a_basic_sut_constructor_argument(quantity);
             };

             because b = () =>
             {
                 result = sut.is_empty();
             };


             it should_return_false = () =>
             {
                 result.should_be_equal_to(false);


             };

             private static Product product;
             private static int quantity;
             private static bool result;
         }
     }
 }
