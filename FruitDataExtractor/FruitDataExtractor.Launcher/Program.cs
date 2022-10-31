using System.Text.Json;
using FruitDataExtractor.Launcher;
using FruitDataExtractor.Extractor.Models;
using FruitDataExtractor.Extractor;
using MySql.Data.MySqlClient;

// Get data from setting.json file
string jsonFile = File.ReadAllText("../Settings.json");
ExtractorSettings settings = JsonSerializer.Deserialize<ExtractorSettings>(jsonFile)!;

// Set the connection string
string connectionString = string.Format(
    "server={0}; port={1}; uid={2}; pwd={3}; database={4};",
    settings.ConnectionString.Host,
    settings.ConnectionString.Port,
    settings.ConnectionString.User,
    settings.ConnectionString.Password,
    settings.ConnectionString.Database);

var mysqlConnection = new MySqlConnection(connectionString);

try
{
    System.Console.WriteLine(
        "Connecting to [{0}]{1} with user: {2}",
        settings.ConnectionString.Host,
        settings.ConnectionString.Database,
        settings.ConnectionString.User);

    mysqlConnection.Open();

    // Set then execute an extraction for each Query Group
    foreach(var queryGroup in settings.QueryGroupList)
    {
        // Prepare file location data
        var output = new FileData(queryGroup.FileData.FolderPath, queryGroup.FileData.XlsxFileName);

        ExtractorParams extractorParams = new()
        {
            QueryGroupName = queryGroup.QueryGroupName,
            OutputData = output,
            QueryFilteringValues = queryGroup.QueryParams,
            Queries = queryGroup.Queries.ConvertAll(x => new Query()
            {
                CsvOutputName = x.CsvFileName,
                SqlQuery = string.Join(" ", x.Query)
                // SqlQuery = x.Query.Aggregate((x, y) => x + " " + y)
            })
        };

        Extractor extractor = new(extractorParams, mysqlConnection);
        extractor.Run();
    }
}
catch(Exception ex)
{
    System.Console.WriteLine(ex.Message);
}
finally
{
    System.Console.WriteLine("Closing database connection...");
    mysqlConnection.Close();
}