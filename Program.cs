using System;
using System.Threading.Tasks;

namespace bisquick
{
  class Program
  {
    async static Task Main(string[] args)
    {
      if (args.Length == 0 || args[0] == "help" || args[0] == "--help") {
        showHelp();
      }

      var config = ConfigManager.LoadConfig();

      switch(args[0]) {
        case "init":
          var bq = new BigQuery(config.PROJECT_ID);
          bq.init();
          Console.WriteLine("Dataset and table created 🎉");
          break;
        case "sync":
          var gh = new GitHub(config.GITHUB_TOKEN);
          var issues = await gh.GetIssues();
          Console.WriteLine($"{issues.Count} Issues synchronized 🥞");
          break;
        default:
          showHelp();
          break;
      }
    }

    static void showHelp() {
      Console.WriteLine(@"bisquick - a tool for synchronizing GitHub issues with BigQuery
        USAGE:
          $ bisquick init - Set up the initial BigQuery dataset and table
          $ bisquick sync - Save all of the issues across repos to BigQuery

        To see this help page, run:
          $ bisquick --help
      ");
      Environment.Exit(0);
    }
  }
}
