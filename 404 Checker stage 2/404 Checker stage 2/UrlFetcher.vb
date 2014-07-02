Imports System.Net

' DOCUMENTATION
' http://msdn.microsoft.com/en-us/library/system.net.httpstatuscode%28v=vs.110%29.aspx?cs-save-lang=1&cs-lang=vb#code-snippet-2
' http://msdn.microsoft.com/en-us/library/system.net.httpwebresponse.statuscode%28v=vs.110%29.aspx
' https://support.microsoft.com/kb/315577
' http://abi.exdream.com/post/2009/04/07/HttpWebRequest-is-very-slow-and-taking-forever-on-Windows-7.aspx
' http://stackoverflow.com/questions/2519655/httpwebrequest-is-extremely-slow
' http://msdn.microsoft.com/en-us/library/ms173179.aspx
' http://www.dotnetperls.com/threadpool-vbnet
' http://stackoverflow.com/questions/14795943/how-to-split-new-line-in-string-in-vb-net
' http://msdn.microsoft.com/en-us/library/h4732ks0.aspx

Public Class UrlFetcher
    Private strUrl As String
    Private intStatus As Integer = 0
    Private bIsChecked As Boolean = False

    ' Initializing UrlFetcher
    Public Sub New(strUrl As String)
        Url = strUrl
    End Sub

    ' This is for accessing the strUrl property
    Public Property Url As String
        Get
            Return strUrl
        End Get
        Set(value As String)
            strUrl = value
        End Set
    End Property

    ' This is for checking if a URL has already been checked
    Public ReadOnly Property IsChecked() As Boolean
        Get
            Return bIsChecked
        End Get
    End Property

    ' Returns the status of the URL
    Public ReadOnly Property Status() As Integer
        Get
            Return intStatus
        End Get
    End Property


    ' Checks the status of a given URL
    Public Sub Check()
        Try
            ' Creating the Request
            Dim objRequest As HttpWebRequest = CType(WebRequest.Create(Url), HttpWebRequest)
            objRequest.Proxy = Nothing
            ' Sending request and wait for answer
            Dim objResponse As HttpWebResponse = CType(objRequest.GetResponse(), HttpWebResponse)
            objResponse.Close()
            intStatus = objResponse.StatusCode

        Catch ex As WebException
            If ex.Status = 7 Then
                intStatus = 404
            End If
        Catch ex As Exception
            intStatus = -1
        End Try
        bIsChecked = True
    End Sub

End Class
