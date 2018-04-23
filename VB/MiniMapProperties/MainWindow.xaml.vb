Imports System
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls

Namespace MiniMapProperties
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub ValidationError(ByVal sender As Object, ByVal e As ValidationErrorEventArgs)
            If e.Action = ValidationErrorEventAction.Added Then
                MessageBox.Show(e.Error.ErrorContent.ToString())
            End If
        End Sub
    End Class

    Public Class PositiveDoubleValidationRule
        Inherits ValidationRule

        Public Overrides Function Validate(ByVal value As Object, ByVal cultureInfo As CultureInfo) As ValidationResult
            Dim val As Double = Nothing
            If Double.TryParse(TryCast(value, String), NumberStyles.Number, cultureInfo, val) Then
                If val <= 0 Then
                    Return New ValidationResult(False, "Input value should be larger than 0.")
                End If
                Return New ValidationResult(True, Nothing)
            End If
            Return New ValidationResult(False, "Input value should be floating point number.")
        End Function
    End Class
End Namespace
