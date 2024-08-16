Class MainWindow
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

End Class
