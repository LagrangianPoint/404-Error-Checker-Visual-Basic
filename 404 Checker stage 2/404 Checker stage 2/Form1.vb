Imports System.Threading

Public Class Form1

    Public listUrls As List(Of String)
    Public listFetchedUrls As List(Of UrlFetcher)
    Public strOriginalText As String
    Public bFirstTime As Boolean = True

    Private objTextUrlsLock As New Object

    ' Starts the checking of the Urls
    Private Sub btnCheckUrls_Click(sender As Object, e As EventArgs) Handles btnCheckUrls.Click
        If bFirstTime = True Then
            strOriginalText = txtUrlList.Text
            bFirstTime = False
        End If

        Dim arrTmp() As String

        listUrls.Clear()

        arrTmp = txtUrlList.Text.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        For Each strUrl As String In arrTmp
            listUrls.Add(strUrl)
        Next

        ProcessUrls()

    End Sub

    ' Process the URLs in the TextBox .
    Public Sub ProcessUrls()
        'ThreadPool.SetMaxThreads(8, 16)
        ThreadPool.SetMaxThreads(nudThreads.Value, nudThreads.Value)

        listFetchedUrls.Clear()

        Dim objUrlFetcher As UrlFetcher

        For Each strUrl As String In listUrls
            objUrlFetcher = New UrlFetcher(strUrl)
            listFetchedUrls.Add(objUrlFetcher)
            ThreadPool.QueueUserWorkItem(AddressOf CheckUrl, objUrlFetcher)
        Next

    End Sub

    ' Checks a single UrlFetcher object
    Public Sub CheckUrl(ByVal objUrlFetcher As UrlFetcher)
        objUrlFetcher.Check()
        Dim strNewUrlText = objUrlFetcher.Url & " [" & objUrlFetcher.Status() & "] " & Environment.NewLine
        SyncLock objTextUrlsLock
            txtUrlList.Invoke(Sub()
                                  txtUrlList.Text = txtUrlList.Text.Replace(objUrlFetcher.Url & Environment.NewLine, strNewUrlText)
                              End Sub)
        End SyncLock

    End Sub

    ' Initializes important variables
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        listUrls = New List(Of String)
        listFetchedUrls = New List(Of UrlFetcher)
    End Sub

    ' Clears the contents of the TextBox
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtUrlList.Text = ""
        bFirstTime = True
    End Sub

    ' Restores the initial URL list
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtUrlList.Text = strOriginalText
    End Sub

    ' Changes the maximum number of thread number.
    Private Sub nudThreads_ValueChanged(sender As Object, e As EventArgs) Handles nudThreads.ValueChanged
        ThreadPool.SetMaxThreads(nudThreads.Value, nudThreads.Value)
    End Sub
End Class
