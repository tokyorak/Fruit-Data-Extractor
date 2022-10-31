namespace FruitDataExtractor.Extractor.Models;

public class ExtractorParams
{
    public string QueryGroupName { get; set; } = default!;
    public FileData OutputData { get; set; } = default!;
    public List<Query> Queries { get; set; } = default!;

    // List of values from which the queries should be filtered on
    public List<string> QueryFilteringValues { get; set; } = default!;
}

public class Query
{
    public string CsvOutputName { get; set; } = default!;
    public string SqlQuery { get; set; } = default!;
}
