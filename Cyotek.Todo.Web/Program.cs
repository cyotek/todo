using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Cyotek.Todo
{
  public class Program
  {
    #region Static Methods

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

    public static void Main(string[] args)
    {
      CreateWebHostBuilder(args).Build().Run();
    }

    #endregion
  }
}
