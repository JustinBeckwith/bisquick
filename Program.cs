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
      Console.WriteLine(user.Url);
    }
  }
}
