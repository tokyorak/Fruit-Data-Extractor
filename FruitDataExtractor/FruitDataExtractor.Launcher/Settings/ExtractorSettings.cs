namespace FruitDataExtractor.Launcher;

public class ExtractorSettings
{
    public FileDataParam FileData { get; set; } = default!;
    public List<QueriesParam> Queries { get; set;} = default!;
}

public class FileDataParam
{
    public string FolderPath { get; set; } = default!;
    public string XlsxFileName { get; set; } = default!;
}

public class QueriesParam
{
    public string CsvFileName { get; set; } = default!;
    public List<string> Query { get; set; } = default!;
}