using DataProvider.Frontend.DataObjects;

namespace TestCases.Frontend
{
    public class SmokeTest : TestBase
    {
        [Fact]
        public void PageSmokeTest()
        {
            Keywords.GoToUrl(TestData.Url);
            Keywords.GetPageTitle().Should().Be("undefined");
        }
    }
}