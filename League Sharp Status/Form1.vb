Public Class Form1
    Dim source As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser2.Navigate("https://www.joduska.me")


        'Dim sourceString As String = New System.Net.WebClient().DownloadString("https://www.joduska.me")
        ' MsgBox(sourceString)
        ' WebBrowser1.DocumentText = sourceString

        '   WebBrowser1.DocumentText = "<strong class='bbc'>LeagueSharp status: <span style='color: #FF0000'>Outdated for 5.6</span></strong> | <strong class='bbc'>Information about the auth system: </strong><a "
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub

    Private Sub WebBrowser2_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser2.DocumentCompleted
        Dim htmlSourceCode As String = WebBrowser2.DocumentText.ToString()

        Dim bodyContent As String = WebBrowser2.Document.Body.InnerText
        If bodyContent.Contains("checking") Then
            Timer1.Start()
            Label1.Text = ("joduska is validating your ip address")

        Else
            Label1.Text = ("Extracting Data")
            Timer2.Start()
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Form1_Load(Nothing, Nothing)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            WebBrowser2.Document.GetElementById("ips_username").SetAttribute("value", "username")
            WebBrowser2.Document.GetElementById("ips_password").SetAttribute("value", "password")
            WebBrowser2.Document.GetElementById("lbtn").InvokeMember("click")
        Catch

        End Try
        Dim htmlSourceCode As String = WebBrowser2.DocumentText.ToString()
        If htmlSourceCode = "" Then

        Else
            source = htmlSourceCode
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MsgBox(source)
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Try
            If source = "" Then

            Else
                Dim index As Integer = source.IndexOf("<strong class")
                Dim st As String = source.Substring(index, 200)
                Dim subt = st.Split("|")
                Dim status As String = subt(0)
                ' MsgBox(status)
                WebBrowser1.DocumentText = status
                Timer3.Stop()
                Timer1.Stop()
                Timer2.Stop()
                timer4.start()
                Label1.Text = ("Data Extracted ^")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Dim count As Integer
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        count += 1
        If count = 10 Then
            Process.Start(Application.StartupPath & "\" & Application.ProductName & ".exe")
            Me.Close()
        Else

        End If

        Label1.Text = "Data Extracted ^" & vbNewLine & "Updating Info In " & 10 - count
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("Coded & Designed By Saeed Suleiman , Idea By Wiciaki")
    End Sub
End Class
