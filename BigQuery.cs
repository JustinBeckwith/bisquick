using System;
using Octokit;
using System.Collections.Generic;
using Google.Cloud.BigQuery.V2;
using Google.Apis.Bigquery.v2.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Linq;

namespace bisquick
{
  public class BigQuery
  {
    protected BigQueryClient client;
    protected static string datasetName = "bisquick";
    protected static string tableName = "issues";

    public BigQuery(string projectId)
    {
      this.client = BigQueryClient.Create(projectId);
    }

    public void init()
    {
      var dataset = this.client.GetOrCreateDataset(datasetName);
      var file = File.OpenText("tableSchema.json");
      var serializer = new JsonSerializer();
      var schema = (TableSchema)serializer.Deserialize(file, typeof(TableSchema));
      var options = new CreateTableOptions
      {
        TimePartitioning = TimePartition.CreateDailyPartitioning(expiration: null)
      };
      var table = dataset.GetOrCreateTable(tableName, schema, null, options);
    }

    public void insertIssues(List<Issue> issues)
    {
      var table = client.GetTable(datasetName, tableName);
      foreach (var issue in issues)
      {
        var json = JsonConvert.SerializeObject(issue, new ItemStateConverter(typeof(StringEnum<ItemState>)));
        Console.WriteLine(json);
      }
    }
  }

  public class ItemStateConverter : JsonConverter
  {
    private readonly Type[] _types;

    public ItemStateConverter(params Type[] types)
    {
      _types = types;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      //throw new NotImplementedException("Not done yet!");
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
    }

    public override bool CanRead
    {
      get { return false; }
    }

    public override bool CanConvert(Type objectType)
    {
      return _types.Any(t => t == objectType);
    }
  }

}