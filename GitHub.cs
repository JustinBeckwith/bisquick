using System.Threading.Tasks;
using Octokit;
using System;

namespace bisquick {
  public class GitHub {
    public async Task<User> GetUser() {
      var github = new GitHubClient(new ProductHeaderValue("MyAmazingApp"));
      var user = await github.User.Get("half-ogre");
      Console.WriteLine(user.Followers + " folks love the half ogre!");
      return user;
    }
  }
}