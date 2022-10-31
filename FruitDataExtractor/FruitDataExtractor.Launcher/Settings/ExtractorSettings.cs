namespace FruitDataExtractor.Launcher;

public class ExtractorSettings
{
    public List<QueryGroup> QueryGroupList { get; set;} = default!;
    public ConnectionParams ConnectionString { get; set; } = default!;
}

public class FileDataParam
{
    public string FolderPath { get; set; } = default!;
    public string XlsxFileName { get; set; } = default!;
}

public class QueryGroup
{
    public string QueryGroupName { get; set; } = default!;
    public FileDataParam FileData { get; set; } = default!;
    public List<string> QueryParams { get; set; } = default!;
    public List<SqlQuery> Queries { get; set;} = default!;
}

public class SqlQuery
{
    public string CsvFileName { get; set; } = default!;
    public List<string> Query { get; set; } = default!;
}

public class ConnectionParams
{
    public string Database { get; set; } = default!;
    public string User { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Host { get; set; } = default!;
    public int Port { get; set; }
}