Imports System.Threading

Public Class Form1

    ' Sub for testing UrlFetcher
    Public Sub TestUrlFetcher()
        'Dim strSample = "http://www.huffingtonpost.com/"
        Dim strSample = "http://www.huffingtonpost.com/asda23"
        Dim objUrlFetcher As UrlFetcher = New UrlFetcher(strSample)
        'Dim intStatus As Integer

        lblStatus.Text = "Checking..."
        objUrlFetcher.Check()
        lblStatus.Text = CStr(objUrlFetcher.Status)

    End Sub


    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim objUrlFetcher As UrlFetcher = New UrlFetcher(txtUrl.Text)
        Dim trd As Thread

        lblStatus.Text = "Checking..."


        'objUrlFetcher.Check()

        trd = New Thread(AddressOf objUrlFetcher.Check)
        trd.IsBackground = True
        trd.Start()
        trd.Join()

        lblStatus.Text = CStr(objUrlFetcher.Status)

    End Sub
End Class
