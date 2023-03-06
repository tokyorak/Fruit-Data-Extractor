# TODO add format to table

[Link to Stack](https://stackoverflow.com/questions/65178752/format-a-excel-cell-range-as-a-table-using-npoi=)

Add style to table

```cs
// NPOI dependencies
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;


IWorkbook workbook = new XSSFWorkbook();
XSSFSheet worksheet = workbook.CreateSheet("Grades") as XSSFSheet;

InsertTestData(worksheet);

// Format Cell Range As Table
XSSFTable xssfTable = worksheet.CreateTable();
CT_Table ctTable = xssfTable.GetCTTable();
AreaReference myDataRange = new AreaReference(new CellReference(0, 0), new CellReference(3, 2));
ctTable.@ref = myDataRange.FormatAsString();
ctTable.id = 1;
ctTable.name = "Table1";
ctTable.displayName = "Table1";
ctTable.tableStyleInfo = new CT_TableStyleInfo();
ctTable.tableStyleInfo.name = "TableStyleMedium2"; // TableStyleMedium2 is one of XSSFBuiltinTableStyle
ctTable.tableStyleInfo.showRowStripes = true;
ctTable.tableColumns = new CT_TableColumns();
ctTable.tableColumns.tableColumn = new List<CT_TableColumn>();
ctTable.tableColumns.tableColumn.Add(new CT_TableColumn() { id = 1, name = "ID" });
ctTable.tableColumns.tableColumn.Add(new CT_TableColumn() { id = 2, name = "Name" });
ctTable.tableColumns.tableColumn.Add(new CT_TableColumn() { id = 3, name = "Score" });

using (FileStream file = new FileStream(@"test.xlsx", FileMode.Create))
{
    workbook.Write(file);
}
```

Insertion into cells

```cs
// Function to Populate Test Data
private void InsertTestData(XSSFSheet worksheet)
{
    worksheet.CreateRow(0);
    worksheet.GetRow(0).CreateCell(0).SetCellValue("ID");
    worksheet.GetRow(0).CreateCell(1).SetCellValue("Name");
    worksheet.GetRow(0).CreateCell(2).SetCellValue("Score");
    worksheet.CreateRow(1);
    worksheet.GetRow(1).CreateCell(0).SetCellValue(1);
    worksheet.GetRow(1).CreateCell(1).SetCellValue("John");
    worksheet.GetRow(1).CreateCell(2).SetCellValue(82);
    worksheet.CreateRow(2);
    worksheet.GetRow(2).CreateCell(0).SetCellValue(2);
    worksheet.GetRow(2).CreateCell(1).SetCellValue("Sam");
    worksheet.GetRow(2).CreateCell(2).SetCellValue(90);
    worksheet.CreateRow(3);
    worksheet.GetRow(3).CreateCell(0).SetCellValue(3);
    worksheet.GetRow(3).CreateCell(1).SetCellValue("Amy");
    worksheet.GetRow(3).CreateCell(2).SetCellValue(88);
}
```

Probable fix if header issues

```cs
var headerNames = _headers.Select(x => x.Name).ToArray();
for (uint i = 0; i < headerNames.Count; i++)
{
    ctTable.tableColumns.tableColumn.Add(new CT_TableColumn() { id = i + 1, name = headerNames[i] });
}
```
