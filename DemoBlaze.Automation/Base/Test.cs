using Xunit.Abstractions;

namespace DemoBlaze_Automation.Base
{
    public class Test : TestBase
    {
        public Test(ITestOutputHelper output): base(output) { }

        public void LaunchService()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com");
        }
    }
}
