Sub Format_Extraction_habituelle()
'
' Format_Extraction_habituelle Macro
'
' Touche de raccourci du clavier: Ctrl+m
'
    Range(Selection, ActiveCell.SpecialCells(xlLastCell)).Select
    Selection.TextToColumns Destination:=Range("A1"), DataType:=xlDelimited, _
        TextQualifier:=xlDoubleQuote, ConsecutiveDelimiter:=False, Tab:=True, _
        Semicolon:=False, Comma:=True, Space:=False, Other:=False, FieldInfo _
        :=Array(Array(1, 1), Array(2, 1), Array(3, 1), Array(4, 2), Array(5, 4), Array(6, 1), _
        Array(7, 4), Array(8, 1), Array(9, 4), Array(10, 1), Array(11, 1), Array(12, 4), Array(13, 4 _
        ), Array(14, 1), Array(15, 1), Array(16, 1), Array(17, 1), Array(18, 4), Array(19, 4), Array _
        (20, 1), Array(21, 1), Array(22, 1), Array(23, 1), Array(24, 2), Array(25, 4), Array(26, 4), _
        Array(27, 4)), TrailingMinusNumbers:=True
    Sheets("Statut-Cb").Select
    Range(Selection, ActiveCell.SpecialCells(xlLastCell)).Select
    Sheets("Statut-Ct").Select
    Range(Selection, ActiveCell.SpecialCells(xlLastCell)).Select
    Selection.Columns.AutoFit
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Sheets("Statut-Cb").Select
    Range("A1").Select
    Range(Selection, ActiveCell.SpecialCells(xlLastCell)).Select
    Selection.TextToColumns Destination:=Range("A1"), DataType:=xlDelimited, _
        TextQualifier:=xlDoubleQuote, ConsecutiveDelimiter:=False, Tab:=True, _
        Semicolon:=False, Comma:=True, Space:=False, Other:=False, FieldInfo _
        :=Array(Array(1, 1), Array(2, 1), Array(3, 1), Array(4, 4), Array(5, 1), Array(6, 4), _
        Array(7, 4), Array(8, 1), Array(9, 1), Array(10, 2), Array(11, 4), Array(12, 4), Array(13, 4 _
        )), TrailingMinusNumbers:=True
    Range(Selection, ActiveCell.SpecialCells(xlLastCell)).Select
    Selection.Columns.AutoFit
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Range("E11").Select
    Sheets("Taux").Select
    Range(Selection, ActiveCell.SpecialCells(xlLastCell)).Select
    Selection.TextToColumns Destination:=Range("A1"), DataType:=xlDelimited, _
        TextQualifier:=xlDoubleQuote, ConsecutiveDelimiter:=False, Tab:=True, _
        Semicolon:=False, Comma:=True, Space:=False, Other:=False, FieldInfo _
        :=Array(Array(1, 1), Array(2, 1), Array(3, 1), Array(4, 1), Array(5, 1), Array(6, 1), _
        Array(7, 1), Array(8, 4), Array(9, 1), Array(10, 1), Array(11, 1), Array(12, 1), Array(13, 1 _
        ), Array(14, 1), Array(15, 1), Array(16, 1), Array(17, 1), Array(18, 1), Array(19, 1), Array _
        (20, 4), Array(21, 4), Array(22, 1), Array(23, 4), Array(24, 1)), TrailingMinusNumbers:=True
    Range(Selection, ActiveCell.SpecialCells(xlLastCell)).Select
    Selection.Columns.AutoFit
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    Range("A1").Select
    Dim Table3 As ListObject
    Set Table3 = ActiveSheet.ListObjects.Add(xlSrcRange, Range("A1", ActiveCell.SpecialCells(xlLastCell)), , xlYes)
    Sheets("Statut-Cb").Select
    Range("A1").Select
    Dim Table2 As ListObject
    Set Table2 = ActiveSheet.ListObjects.Add(xlSrcRange, Range("A1", ActiveCell.SpecialCells(xlLastCell)), , xlYes)
    Sheets("Statut-Ct").Select
    Range("A1").Select
    Dim Table1 As ListObject
    Set Table1 = ActiveSheet.ListObjects.Add(xlSrcRange, Range("A1", ActiveCell.SpecialCells(xlLastCell)), , xlYes)
End Sub
