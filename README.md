# 🥞 bisquick
> A fancy little utility for synchronizing GitHub issues with BigQuery.

![bisquick](https://i.imgur.com/uS1kH7i.gif?noredirect)

## Usage

First, you need to set up your environment.  Bisquick expects the `BISQUICK_PROJECT_ID` and `BISQUICK_GITHUB_TOKEN` environment settings to be set. You're probably also going to want to `gcloud config set project $PROJECT_ID`.

To setup your project, the `init` command will create a dataset, and a table with the correct schema.

```sh
$ dotnet run init
```

After that, you can run the `sync` command to read all the GitHub issues, and save them to a partitioned BigQuery table:

```sh
$ dotnet run sync
```

## License
[Apache 2.0](LICENSE.md)

