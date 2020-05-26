using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PalTrackerTests
{
    [Collection("Integration")]
    public class EnvIntegrationTest
    {
        private readonly HttpClient _testClient;

        public EnvIntegrationTest()
        {
            Environment.SetEnvironmentVariable("PORT", "8801");
            Environment.SetEnvironmentVariable("MEMORY_LIMIT", "512M");
            Environment.SetEnvironmentVariable("CF_INSTANCE_INDEX", "1");
            Environment.SetEnvironmentVariable("CF_INSTANCE_ADDR", "127.0.0.1");

            _testClient = IntegrationTestServer.Start().CreateClient();
        }

        [Fact]
        public async Task ReturnsCloudFoundryEnv()
        {
            var response = await _testClient.GetAsync("/env");
            response.EnsureSuccessStatusCode();

            var expectedResponse =
                @"{""port"":""8801"",""memoryLimit"":""1024M"",""cfInstanceIndex"":""1"",""cfInstanceAddr"":""127.0.0.1""}";
            var actualResponse = await response.Content.ReadAsStringAsync();

            Assert.Equal(expectedResponse, actualResponse);
        }
    }
}

