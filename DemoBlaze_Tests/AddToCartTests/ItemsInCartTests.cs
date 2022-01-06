using DemoBlaze_Automation.Base;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Demo_blaze_Tests.AddToCartTests
{
    public class ItemsInCartTests : Test
    {
        public ItemsInCartTests(ITestOutputHelper output) : base(output) 
        {
            LaunchService();
        }
       
        [Fact]
        public void Verify_items_added_to_the_cart_can_be_removed() 
        {
            demoBlazeStorePage.AddItemsToBasket("Sony vaio i7");
            output.WriteLine("Sony added");
            demoBlazeStorePage.AddItemsToBasket("ASUS Full HD");
            output.WriteLine("Asus added");
            demoBlazeStorePage.CartMenu.Click();
            viewBasketPage.DeleteTheItemAndConfirm().Should().BeTrue();
        }

        [Fact]
        public void Verify_clicking_place_order_button_displays_contact_details_popup() { }

        [Fact]
        public void Verify_items_added_to_the_basket_displays_delete_link() { }


    }

}
