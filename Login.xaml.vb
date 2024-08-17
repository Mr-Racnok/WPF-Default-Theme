Imports System.Windows.Media.Animation
Imports System.Windows.Threading
Imports Template2.Template2
Imports Wpf.Ui.Controls

Class Login
    Dim PesanDialog As String
    Dim CanProceed As Boolean

    Private Sub OpenDialog_Click(sender As Object, e As RoutedEventArgs)
        Dim dialog As New DialogWindowExit()
        With dialog
            .DialogTittle.Text = "Warning"
            .DialogText.Text = "Seluruh proses yang belum disimpan akan hilang jika anda keluar."
            .DialogButtonYes.Visibility = Visibility.Collapsed
        End With
        dialog.ShowDialog()
    End Sub

    Private Sub Show_ToastNotification(sender As Object, e As RoutedEventArgs)
        ' Akses instance MainWindow yang sudah ada
        Dim mainWindow As MainWindow = Application.Current.MainWindow

        With mainWindow.ToastNotification
            .Title = "Info"
            .Message = "Fitur masih belum tersedia."
            .IsOpen = True
            .Severity = Wpf.Ui.Controls.InfoBarSeverity.Informational
        End With

        ' Timer untuk menutup InfoBar setelah 3 detik
        Dim timer As New DispatcherTimer()
        AddHandler timer.Tick, Sub(s, args)
                                   mainWindow.ToastNotification.IsOpen = False
                                   timer.Stop()
                               End Sub
        timer.Interval = TimeSpan.FromSeconds(3)
        timer.Start()
    End Sub

    Private Sub CheckEmptyFields()
        ' Dapatkan referensi ke Grid
        Dim grid As Grid = CType(Me.Content, Grid)
        Dim dialog As New DialogWindowExit()
        CanProceed = False

        ' Cari StackPanel di dalam Grid
        For Each element As UIElement In grid.Children
            If TypeOf element Is StackPanel Then
                Dim stackPanel As StackPanel = CType(element, StackPanel)
                ' Loop melalui semua elemen di dalam StackPanel
                For Each child As UIElement In stackPanel.Children
                    If TypeOf child Is Control AndAlso CType(child, Control).Tag IsNot Nothing AndAlso CType(child, Control).Tag.ToString().Contains("_rq_") Then
                        If TypeOf child Is Wpf.Ui.Controls.TextBox AndAlso String.IsNullOrWhiteSpace(CType(child, Wpf.Ui.Controls.TextBox).Text) Then
                            PesanDialog = $"( {CType(child, Wpf.Ui.Controls.TextBox).Name} ) tidak boleh kosong."
                            GoTo Akhiri
                        ElseIf TypeOf child Is Wpf.Ui.Controls.PasswordBox AndAlso String.IsNullOrWhiteSpace(CType(child, Wpf.Ui.Controls.PasswordBox).Password) Then
                            PesanDialog = $"( {CType(child, Wpf.Ui.Controls.PasswordBox).Name} ) tidak boleh kosong."
                            dialog.ShowDialog()
                            Exit Sub
                        End If
                    Else
                        CanProceed = True
                    End If
                Next
            End If
        Next

        If CanProceed = True Then
            MsgBox("Lanjut")
        End If
        Exit Sub
Akhiri:
        With dialog
            .DialogTittle.Text = "Caution"
            .DialogText.Text = PesanDialog
            .DialogButtonYes.Visibility = Visibility.Collapsed
            .DialogButtonNo.Content = "OK"
        End With
        dialog.ShowDialog()
    End Sub

End Class
