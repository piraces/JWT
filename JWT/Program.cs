using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace JWT
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Temp fix for linker: https://github.com/mono/linker/issues/870
            _ = new JwtHeader();
            _ = new JwtPayload();

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();

            await builder.Build().RunAsync();
        }
    }
}
