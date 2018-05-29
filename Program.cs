using System;
using System.Threading.Tasks;

namespace bisquick
{
  class Program
  {
    public async static Task Main(string[] args)
    {
      var config = ConfigManager.LoadConfig();
      var gh = new GitHub(config.GITHUB_TOKEN);
      var issues = await gh.GetIssues();
      var bq = new BigQuery(config.PROJECT_ID);
    }
  }
}
