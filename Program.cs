using System;
using System.Threading.Tasks;

namespace bisquick
{
  class Program
  {
    public async static Task Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      //var bq = BigQueryClient.Create("yoshi-team");
      var gh = new GitHub();
      var user = await gh.GetUser();
      var repos = await gh.GetRepos();
      Console.WriteLine(user.Url);
      repos.repos.ForEach(i => Console.WriteLine(i.repo));
    }
  }
}
