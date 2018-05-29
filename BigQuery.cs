using Octokit;
using System.Collections.Generic;
using Google.Cloud.BigQuery.V2;

namespace bisquick
{
  public class BigQuery
  {
    protected BigQueryClient client;

    public BigQuery(string projectId) {
      this.client = BigQueryClient.Create(projectId);
    }

    public void init() {
      return;
    }

    public void insertIssues(List<Issue> issues)
    {
      return;
    }
  }
}