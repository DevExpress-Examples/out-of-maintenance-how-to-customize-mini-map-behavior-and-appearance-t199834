Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls

Namespace MiniMapProperties

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub ValidationError(ByVal sender As Object, ByVal e As ValidationErrorEventArgs)
            If e.Action = ValidationErrorEventAction.Added Then Call MessageBox.Show(e.Error.ErrorContent.ToString())
        End Sub
    End Class

    Public Class PositiveDoubleValidationRule
        Inherits ValidationRule

        Public Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As CultureInfo) As ValidationResult
            Dim val As Double
            If Double.TryParse(TryCast(value, String), NumberStyles.Number, cultureInfo, val) Then
                If val <= 0 Then Return New ValidationResult(False, "Input value should be larger than 0.")
                Return New ValidationResult(True, Nothing)
            End If

            Return New ValidationResult(False, "Input value should be floating point number.")
        End Function
    End Class
End Namespace
