using System;

namespace bisquick
{
  public class ConfigManager
  {
    public static Config LoadConfig()
    {
      var config = new Config();
      config.GITHUB_TOKEN = Environment.GetEnvironmentVariable("BISQUICK_GITHUB_TOKEN");
      config.PROJECT_ID = Environment.GetEnvironmentVariable("BISQUICK_PROJECT_ID");
      return config;
    }
  }

  public class Config
  {
    public string GITHUB_TOKEN;
    public string PROJECT_ID;
  }
}
