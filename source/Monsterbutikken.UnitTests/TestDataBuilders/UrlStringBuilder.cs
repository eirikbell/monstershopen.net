using System;

namespace Monsterbutikken.UnitTests.TestDataBuilders
{
    public class UrlStringBuilder : ITestDataBuilder<Uri>
    {
        private readonly string _host;
        private string _relativePath;

        public UrlStringBuilder()
        {
            _relativePath = string.Empty;
            _host = "http://localhost/";
        }

        public UrlStringBuilder WithRelativePath(string relativePath)
        {
            relativePath = relativePath.Replace("~", "");
            relativePath = relativePath.StartsWith("/") ? relativePath.Substring(1) : relativePath;
            relativePath = relativePath.StartsWith("\\") ? relativePath.Substring(1) : relativePath;
            _relativePath = relativePath;
            return this;
        }

        public Uri Build()
        {
            return new Uri(_host + _relativePath);
        }
    }
}
