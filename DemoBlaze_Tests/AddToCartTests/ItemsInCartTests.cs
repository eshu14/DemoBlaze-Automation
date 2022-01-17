using DemoBlaze.Automation.CustomAttributes;
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
       
        [Theory]
        [JsonData(@"DataSet\ItemList\ItemLists.items.json", "Two Items in the Basket")]
        public void Verify_items_added_to_the_cart_can_be_removed(string item1, string item2, int itemPositionToDelete) 
        {
            demoBlazeStorePage.AddItem(item1,item2);
            output.WriteLine("Sony added");
            demoBlazeStorePage.CartMenu.Click();
            viewBasketPage.DeleteTheItemAndConfirm(itemPositionToDelete).Should().BeTrue();
        }

        [Fact]
        public void Verify_clicking_place_order_button_displays_contact_details_popup() { }

        [Fact]
        public void Verify_items_added_to_the_basket_displays_delete_link() { }


    }

}
