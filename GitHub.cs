using System.Threading.Tasks;
using Octokit;
using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;

namespace bisquick {
  public class GitHub {
    public async Task<User> GetUser() {
      var github = new GitHubClient(new ProductHeaderValue("MyAmazingApp"));
      var user = await github.User.Get("half-ogre");
      Console.WriteLine(user.Followers + " folks love the half ogre!");
      return user;
    }

    public async Task<Repos> GetRepos() {
      var uri = "https://raw.githubusercontent.com/JustinBeckwith/sloth/master/repos.json";
      var client = new HttpClient();
      var streamTask = client.GetStreamAsync(uri);
      var serializer = new DataContractJsonSerializer(typeof(Repos));
      var repos = serializer.ReadObject(await streamTask) as Repos;
      return repos;
    }
  }

  public class Repo {
    public string repo;
    public string language;
  }

  public class Repos {
    public List<Repo> repos;
  }
}