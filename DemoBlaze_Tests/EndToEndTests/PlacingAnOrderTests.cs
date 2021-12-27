using Xunit;
using Xunit.Abstractions;
using FluentAssertions;
using DemoBlaze_Automation.Base;
using System.Threading;

namespace Demo_blaze_Tests.EndToEndTests
{
    public class PlacingAnOrderTests : Test
    {
        public PlacingAnOrderTests(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void Verify_adding_items_to_cart_and_complete_the_order()
        {
            LaunchService();
            demoBlazeStorePage.AddItemsToBasket();
            demoBlazeStorePage.CartMenu.Click();
            placeOrderPage.PlaceOrderButton.Click();
            paymentDetailsPage.EnterAndConfirmPaymentDetails().Contains("Thank you for your purchase!");
            paymentDetailsPage.ThankyouMessageCheckAndReturn().Should().Contain("/index.html");
        }
    }
}
