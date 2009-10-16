 using System.Collections.Generic;
 using System.Linq;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.domain;
 using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tests.domain
 {   
     public class ShoppingCartSpecs
     {
         public abstract class concern : observations_for_a_sut_without_a_contract<ShoppingCart>
         {
        
         }

         [Concern(typeof(ShoppingCart))]
         public class when_adding_an_item_to_the_shopping_cart : concern
         {
             context c = () =>
             {
                 item_to_add = new ShoppingCartItem();
                 shopping_cart_items = new List<ShoppingCartItem>();
                 provide_a_basic_sut_constructor_argument(shopping_cart_items);
             };

             because b = () =>
             {
                 sut.add_item(item_to_add);
             };

        
             it the_item_should_be_stored_in_the_list_of_shopping_cart_items = () =>
             {
                 sut.all_items.should_contain(item_to_add);
             };

             static IList<ShoppingCartItem> shopping_cart_items;
             static ShoppingCartItem item_to_add;
         }

         [Concern(typeof(ShoppingCart))]
         public class when_removing_an_item_from_the_shopping_cart : concern
         {
             context c = () =>
             {
                 item_to_remove = new ShoppingCartItem();
                 shopping_cart_items = new List<ShoppingCartItem>();
                 provide_a_basic_sut_constructor_argument(shopping_cart_items);
             };

             because b = () =>
             {
                 sut.remove_item(item_to_remove);
             };

             it the_item_should_no_longer_be_in_the_list_of_shopping_cart_items = () =>
             {
                 sut.all_items.should_not_contain(item_to_remove);
             };

             static IList<ShoppingCartItem> shopping_cart_items;
             static ShoppingCartItem item_to_remove;
         }

         [Concern(typeof(ShoppingCart))]
         public class when_emptying_the_shopping_cart : concern
         {
             context c = () =>
             {
                 shopping_cart_items = new List<ShoppingCartItem>()
                                           {
                                               {new ShoppingCartItem()},
                                               {new ShoppingCartItem()}
                                           };

                 provide_a_basic_sut_constructor_argument(shopping_cart_items);
             };

             because b = () =>
             {
                 sut.empty_the_cart();
             };

             it should_not_have_any_items_in_the_cart = () =>
             {
                 sut.all_items.Count().should_be_equal_to(0);
             };

             static IList<ShoppingCartItem> shopping_cart_items;
             static ShoppingCartItem item_to_remove;
         }

         [Concern(typeof(ShoppingCart))]
         public class when_viewing_the_total_cost_of_the_shopping_cart : concern
         {
             context c = () =>             
             {
                 expected_total_cost = 150.25M;
                 shopping_cart_items = new List<ShoppingCartItem>()
                                           {
                                               {new ShoppingCartItem() {unit_price = 100.00M}},
                                               {new ShoppingCartItem() {unit_price = 50.25M}}
                                           };
                 
                 provide_a_basic_sut_constructor_argument(shopping_cart_items);
             };

             because b = () =>
             {
                 actual_total_cost = sut.total_cost;
             };

             it should_return_the_sum_of_the_cost_of_all_shopping_cart_items_in_the_shopping_cart = () =>
             {
                 actual_total_cost.should_be_equal_to(expected_total_cost);
             };

             static IList<ShoppingCartItem> shopping_cart_items;
             static decimal actual_total_cost;
             static decimal expected_total_cost;
         }

         [Concern(typeof(ShoppingCart))]
         public class when_modifying_the_quantity_of_an_item_in_the_cart : concern
         {
             context c = () =>             
             {
                 updated_quantity = 3;
                 item_to_update = new ShoppingCartItem() {quantity = 1};
                 shopping_cart_items = new List<ShoppingCartItem>() { item_to_update };
                 
                 provide_a_basic_sut_constructor_argument(shopping_cart_items);
             };

             because b = () =>
             {
                 sut.update_quantity(item_to_update, updated_quantity);
             };

             it should_update_the_quantity_of_the_item_to_the_new_quantity = () =>
             {
                 sut.all_items.should_contain_item_matching(x => x.quantity == updated_quantity);
             };

             static IList<ShoppingCartItem> shopping_cart_items;
             static int updated_quantity;
             static ShoppingCartItem item_to_update;
         }

         [Concern(typeof(ShoppingCart))]
         public class when_getting_a_departmental_breakdown_of_items_in_the_shopping_cart : concern
         {
             context c = () =>
             {
                 shopping_cart_items = new List<ShoppingCartItem>() 
                 { 
                     {new ShoppingCartItem(){ unit_price = 25M, department = bakery, quantity = 2 }},
                     {new ShoppingCartItem(){ unit_price = 10M, department = bakery, quantity = 1 }},
                     {new ShoppingCartItem(){ unit_price = 5M, department = pharmacy, quantity = 1 }},
                     {new ShoppingCartItem(){ unit_price = 15M, department = pharmacy, quantity = 2 }},
                     {new ShoppingCartItem(){ unit_price = 3.5M, department = pharmacy, quantity = 3 }}
                 };

                 provide_a_basic_sut_constructor_argument(shopping_cart_items);
             };

             because b = () =>
             {
                 results = sut.group_by(x => x.department);
             };

             it should_return_a_list_of_items_grouped_by_department = () =>
             {
                 results.Where(x => x.Key == bakery).Count().should_be_equal_to(2);
                 results.Where(x => x.Key == pharmacy).Count().should_be_equal_to(3);
             };

             static IList<ShoppingCartItem> shopping_cart_items;
             static IEnumerable<IGrouping<Department, ShoppingCartItem>> results;
         }

         static Department bakery = new Department() {department_name = "Bakery"};
         static Department pharmacy = new Department() {department_name = "Pharmacy"};
     }
 }