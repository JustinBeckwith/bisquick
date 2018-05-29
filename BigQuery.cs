using System;
using Octokit;
using System.Collections.Generic;
using Google.Cloud.BigQuery.V2;
using Google.Apis.Bigquery.v2.Data;
using Newtonsoft.Json;
using System.IO;

namespace bisquick
{
  public class BigQuery
  {
    protected BigQueryClient client;

    public BigQuery(string projectId) {
      this.client = BigQueryClient.Create(projectId);
    }

    public void init() {
      var dataset = this.client.GetOrCreateDataset("bisquick");
      var file = File.OpenText("tableSchema.json");
      var serializer = new JsonSerializer();
      var schema = (TableSchema)serializer.Deserialize(file, typeof(TableSchema));
      var options = new CreateTableOptions {
        TimePartitioning = TimePartition.CreateDailyPartitioning(expiration: null)
      };
      var table = dataset.GetOrCreateTable("issues", schema, null, options);
    }

    public void insertIssues(List<Issue> issues)
    {
      return;
    }
  }
}