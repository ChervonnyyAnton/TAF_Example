using Keywords.Backend;

namespace TestCases.Backend
{
    public class PingPongTest : TestBase
    {
        [Fact]
        public async Task PingPongCallTest()
        {
            RestResponse response = await Endpoint.PingAsync();
            response.Content.Should().Be("pong;");
        }
    }
}