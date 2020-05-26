using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore; 
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.HostFiltering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PalTracker;

namespace PalTrackerTests
{
    public static class IntegrationTestServer
    {
        public static TestServer Start() =>
            new TestServer(Program.CreateHostBuilder(new string[] { }));
    }
}