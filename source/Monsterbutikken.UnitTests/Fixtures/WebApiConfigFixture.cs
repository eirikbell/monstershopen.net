using System;
using System.Net.Http;
using System.Web.Http;
using Monsterbutikken.UnitTests.Infrastructure;

namespace Monsterbutikken.UnitTests.Fixtures
{
    public class WebApiConfigFixture : IFixtureObject<RouteTester>
    {
        private Uri _url;

        private static HttpConfiguration _config = null;
        private static readonly Object Lock = new object();
        private HttpMethod _httpMethod;

        private static HttpConfiguration Config
        {
            get
            {
                lock (Lock)
                {
                    if (_config == null)
                    {
                        _config = CreateHttpConfiguration();
                    }
                }

                return _config;
            }
        }

        private static HttpConfiguration CreateHttpConfiguration()
        {
            var config = new HttpConfiguration()
            {
                IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always
            };

            WebApiConfig.Register(config);

            config.EnsureInitialized();

            return config;
        }

        public WebApiConfigFixture()
        {
            _httpMethod = HttpMethod.Get;
            _url = new Uri("http://localhost/api/url");
        }

        public WebApiConfigFixture WithUrl(Uri url)
        {
            _url = url;
            return this;
        }

        public WebApiConfigFixture Post()
        {
            _httpMethod = HttpMethod.Post;
            return this;
        }

        public RouteTester CreateSut()
        {
            var request = new HttpRequestMessage(_httpMethod, _url);

            return new RouteTester(Config, request);
        }
    }
}
