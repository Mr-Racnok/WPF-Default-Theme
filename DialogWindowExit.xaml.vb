Namespace Template2
    Public Class DialogWindowExit
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Click_Exit()
            Me.Close()
            Application.Current.Shutdown()
        End Sub

        Private Sub Click_Cancel()
            Me.Close()
        End Sub
    End Class
End Namespace
