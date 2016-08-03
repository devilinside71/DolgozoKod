
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call ZebraPrint.LoadPrinters()
        ComboBoxPrinter.Items.Clear()
        For Each pr In ZebraPrint.PrinterNames
            ComboBoxPrinter.Items.Add(pr)
        Next
        ComboBoxPrinter.SelectedIndex = 0
        Call ZebraPrint.LoadLabels()
    End Sub
    Sub ZPLPrint()
        Dim strPrinter As String
        Dim strPrintText As String
        Dim res As String

        Dim strVonalkod As String
        Dim strDolgozoNev As String


        strPrinter = ZebraPrint.PrinterWinNames(ComboBoxPrinter.SelectedIndex)
        strVonalkod = TextBoxKod.Text
        strDolgozoNev = TextBoxName.Text
        strPrintText = ZebraPrint.LabelCodes(0)
        strPrintText = strPrintText.Replace("VONALKOD", strVonalkod)
        strPrintText = strPrintText.Replace("DOLGOZONEV", strDolgozoNev)
        strPrintText = strPrintText.Replace("DOLGOZOUTF", ZebraPrint.GetZPLutf8Code(strDolgozoNev))

        res = ZebraPrint.SendStringToPrinter(strPrinter, strPrintText)

    End Sub

    Private Sub ButtonPrint_Click(sender As Object, e As EventArgs) Handles ButtonPrint.Click
        Call ZPLPrint()
    End Sub
End Class
