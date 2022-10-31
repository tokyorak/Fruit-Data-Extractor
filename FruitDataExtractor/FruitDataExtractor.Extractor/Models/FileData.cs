namespace FruitDataExtractor.Extractor.Models;

public class FileData
{
    public string FolderPath { get; set; } = default!;
    public string FileName { get; set; } = default!;
    public string FilePath { get; set; } = default!;

    public FileData(string folderPath, string fileName)
    {
        FolderPath = folderPath;
        FileName = fileName;

        if (FolderPath is not null && FileName is not null)
        {
            FilePath = Path.Combine(FolderPath, FileName);
        }
    }
}