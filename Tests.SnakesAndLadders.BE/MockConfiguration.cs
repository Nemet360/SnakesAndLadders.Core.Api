using Microsoft.Extensions.Configuration;

namespace Tests.SnakesAndLadders.BE
{
    internal class MockConfigurationProvider
    {
        private readonly Dictionary<string, string> _data;
        public MockConfigurationProvider(Dictionary<string, string> data)
        {
            _data = data;
        }

        public IConfiguration Build()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(_data)
            .Build();

            return configuration;
        }

        
    }
}
