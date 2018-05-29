using System.Threading.Tasks;
using Octokit;
using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using System.Linq;

namespace bisquick
{
  public class GitHub
  {

    private GitHubClient github;

    public GitHub(string token)
    {
      this.github = new GitHubClient(new ProductHeaderValue("bisquick"));
      if (!string.IsNullOrEmpty(token))
      {
        this.github.Credentials = new Credentials(token);
      }
      else
      {
        Console.WriteLine("WARNING: No GitHub auth token is set. Please set the `GITHUB_TOKEN` environment variable to avoid rate limiting by the GitHub API.");
      }
    }

    public async Task<List<Issue>> GetIssues()
    {
      var repos = await this.GetRepos();
      var tasks = new List<Task<IReadOnlyList<Issue>>>();
      var opts = new ApiOptions();
      opts.PageSize = 100;
      foreach (var repo in repos.repos)
      {
        var parts = repo.repo.Split('/');
        var t = github.Issue.GetAllForRepository(parts[0], parts[1], opts);
        tasks.Add(t);
      }
      var results = await Task.WhenAll(tasks);
      var issues = results.SelectMany(x => x).ToList();
      return issues;
    }

    public async Task<Repos> GetRepos()
    {
      var uri = "https://raw.githubusercontent.com/JustinBeckwith/sloth/master/repos.json";
      var client = new HttpClient();
      var streamTask = client.GetStreamAsync(uri);
      var serializer = new DataContractJsonSerializer(typeof(Repos));
      var repos = serializer.ReadObject(await streamTask) as Repos;
      return repos;
    }
  }

  public class Repo
  {
    public string repo;
    public string language;
  }

  public class Repos
  {
    public List<Repo> repos;
  }
}