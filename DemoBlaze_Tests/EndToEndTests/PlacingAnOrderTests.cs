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
            demoBlazeStorePage.AddItem("Sony vaio i7");
            demoBlazeStorePage.AddItem("ASUS Full HD");
            demoBlazeStorePage.CartMenu.Click();
            viewBasketPage.PlaceOrderButton.Click();
            paymentDetailsPage.EnterAndConfirmPaymentDetails().Contains("Thank you for your purchase!");
            paymentDetailsPage.ThankyouMessageCheckAndReturn();
            driver.Url.Should().Contain("/index.html");
        }
    }
}
