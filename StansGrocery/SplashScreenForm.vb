Public Class SplashScreenForm

    Private Sub SplashScreenForm_Click(sender As Object, e As EventArgs) Handles Me.Click
        Me.Hide()
        StansGroceryForm.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        StansGroceryForm.Show()
    End Sub

    Private Sub SplashScreenForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class