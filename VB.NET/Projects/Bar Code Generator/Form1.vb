Imports DevExpress.XtraPrinting.BarCode
Imports DevExpress.XtraReports.UI
Imports System.IO
Imports DevExpress.XtraPrinting

Public Class Form1

    Dim barCode As New XRBarCode

    Public Function CreateQRCodeBarCode(ByVal BarCodeText As String) As XRBarCode

        ' Create a bar code control.
        Dim barCode As New XRBarCode()

        ' Set the bar code's type to QRCode.
        barCode.Symbology = New QRCodeGenerator()

        ' Adjust the bar code's main properties.
        barCode.Text = BarCodeText
        barCode.Width = 400
        barCode.Height = 150

        ' If the AutoModule property is set to false, uncomment the next line.
        barCode.AutoModule = True
        ' barcode.Module = 3;

        ' Adjust the properties specific to the bar code type.
        CType(barCode.Symbology, QRCodeGenerator).CompactionMode = QRCodeCompactionMode.AlphaNumeric
        CType(barCode.Symbology, QRCodeGenerator).ErrorCorrectionLevel = QRCodeErrorCorrectionLevel.H
        CType(barCode.Symbology, QRCodeGenerator).Version = QRCodeVersion.AutoVersion

        Return barCode

    End Function

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'PictureBox1.Image = DirectCast(CreateQRCodeBarCode("012345678").ToImage(), Bitmap)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim report As New XtraReport()
        report.Bands.Add(New DetailBand())

        Dim qrCodeGenerator1 As New DevExpress.XtraPrinting.BarCode.QRCodeGenerator()
        Dim code As New XRBarCode()
        report.Bands(0).Controls.Add(code)
        code.Size = New System.Drawing.Size(100, 100)
        code.Symbology = qrCodeGenerator1
        code.Text = "12334"
        code.ShowText = False
        Dim im As System.Drawing.Image = code.ToImage()

        PictureBox1.Image = im

        'Using ms = New MemoryStream()
        '    report.ExportToImage(ms, New ImageExportOptions(System.Drawing.Imaging.ImageFormat.Jpeg))
        '    ms.Seek(0, SeekOrigin.Begin)
        '    Dim bytes As Byte() = ms.ToArray()
        '    Page.Response.ContentType = "image/jpg"
        '    Page.Response.Clear()
        '    Page.Response.OutputStream.Write(bytes, 0, bytes.Length)
        '    Page.Response.[End]()
        'End Using

    End Sub

End Class