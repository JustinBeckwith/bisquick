using Microsoft.Extensions.Configuration;

namespace bisquick
{
  public class ConfigManager
  {
    public static Config LoadConfig()
    {
      var config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables()
              .Build();
      return config as Config;
    }
  }

  public class Config
  {
    public string GITHUB_TOKEN;
    public string PROJECT_ID;
  }
}
