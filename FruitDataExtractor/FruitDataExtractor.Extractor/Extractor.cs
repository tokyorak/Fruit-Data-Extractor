using System.Text;
using System.Data;
using FruitDataExtractor.Extractor.Models;
using MySql.Data.MySqlClient;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace FruitDataExtractor.Extractor;
public class Extractor
{
    private readonly ExtractorParams _extractorParams;
    private readonly MySqlConnection _mysqlConnection;

    public Extractor(ExtractorParams extractorParams, MySqlConnection mysqlConnection)
    {
        _extractorParams = extractorParams;
        _mysqlConnection = mysqlConnection;
    }

    public void Run()
    {
        string outFileDirectory = Path.Combine(_extractorParams.OutputData.FilePath, _extractorParams.QueryGroupName);

        // Create the main directory
        // Delete the directory if it already exists
        if(File.Exists(outFileDirectory))
        {
            File.Delete(outFileDirectory);
        }
        else
        {
            File.Create(outFileDirectory);
        }

        // Launch extraction
        ExtractMySqlToCSV(outFileDirectory);
    }

    private void ExtractMySqlToCSV(string outFileDirectory)
    {
        try
        {
            // Loop for each QueryParams and execute all required queries
            foreach(var queryparam in _extractorParams.QueryFilteringValues)
            {
                var excelFile = string.Format("{0}-{1}", queryparam, _extractorParams.OutputData.FileName);
                using var fs = new FileStream(excelFile, FileMode.Create, FileAccess.Write);
                // Excel file prep
                IWorkbook workbook = new XSSFWorkbook();

                foreach(var query in _extractorParams.Queries)
                {
                    // Set the request
                    var script = string.Format(query.SqlQuery, queryparam);
                    var request = new MySqlCommand(script, _mysqlConnection);
                    var dataAdapter = new MySqlDataAdapter(request);
                    var dataSet = new DataSet();

                    // Record the result
                    dataAdapter.Fill(dataSet, query.CsvOutputName);

                    // Prepare .csv path
                    var outFileName = Path.Combine(outFileDirectory, string.Format("{0}.csv", query.CsvOutputName));

                    // Write to .csv file
                    StreamWriter writer = WriteToCsv(query, dataSet, outFileName);

                    // Compile to xlsx
                    WriteToXlsx(workbook, query, outFileName);
                }
                workbook.Write(fs);
            }
            System.Console.WriteLine("Extraction OK");
        }
        catch(Exception ex)
        {
            System.Console.WriteLine("Extraction KO");
            System.Console.WriteLine(ex.Message);
        }
    }

    private static int WriteToXlsx(IWorkbook workbook, Query query, string outFileName)
    {
        ISheet sheet = workbook.CreateSheet(query.CsvOutputName);
        // Open each .csv file and add them to the xlsx
        var fileRows = File.ReadAllLines(outFileName);
        return AddContentToRow(sheet, fileRows);
    }

    private static int AddContentToRow(ISheet sheet, string[] contentRow)
    {
        int rowIndex = 0;
        IRow row = sheet.CreateRow(rowIndex);
        foreach(var content in contentRow)
        {
            row.CreateCell(0).SetCellValue(content);
            rowIndex++;
        }
        return rowIndex;
    }

    private static StreamWriter WriteToCsv(Query query, DataSet? dataSet, string outFileName)
    {
        StreamWriter writer = new(outFileName, false, Encoding.UTF8);
        for (int i = 0; i < dataSet?.Tables[query.CsvOutputName]?.Rows.Count; ++i)
        {
            StringBuilder sb = new();
            DataRow? row = dataSet?.Tables[query.CsvOutputName]?.Rows[i];

            if (row is not null)
            {
                foreach (DataColumn item in row.Table.Columns)
                {
                    sb.AppendFormat("\"{0}\"", row[item]);
                    sb.Append(';');
                }
                sb.Remove(sb.Length - 1, 1);
                sb.AppendLine("");
                writer.Write(sb.ToString());
            }
        }

        return writer;
    }
}
