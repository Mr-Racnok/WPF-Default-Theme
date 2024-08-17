Imports System.Media
Imports Template2.Template2
Imports Wpf.Ui.Controls

Class MainWindow

    Public Sub New()
        InitializeComponent()
        With SideNavigation
            .IsPaneOpen = False
            .Visibility = Visibility.Collapsed
        End With
        goto_Login()
    End Sub

    Private Sub Border_MouseDown(sender As Object, e As MouseButtonEventArgs)
        If e.LeftButton = MouseButtonState.Pressed Then
            Me.DragMove()
        End If
    End Sub

    Private Sub Border_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
        If e.ClickCount = 2 Then
            If Me.WindowState = WindowState.Maximized Then
                Me.WindowState = WindowState.Normal
            Else
                Me.WindowState = WindowState.Maximized
            End If
        End If
    End Sub

    Sub goto_Login()
        Content.Navigate(New Uri("Login.xaml", UriKind.Relative))
    End Sub

    Private Sub OpenDialog_Click(sender As Object, e As RoutedEventArgs)
        Dim dialog As New DialogWindowExit()
        With dialog
            .DialogTittle.Text = "Warning"
            .DialogText.Text = "Seluruh proses yang belum disimpan akan hilang jika anda keluar."
            .DialogButtonYes.Appearance = ControlAppearance.Danger
            .DialogButtonYes.Foreground = New BrushConverter().ConvertFromString("#ffffff")
        End With
        dialog.ShowDialog()
    End Sub

End Class
