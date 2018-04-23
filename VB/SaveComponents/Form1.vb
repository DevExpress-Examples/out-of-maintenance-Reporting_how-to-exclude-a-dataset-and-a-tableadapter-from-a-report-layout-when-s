Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Windows.Forms
Imports System.Collections
Imports DevExpress.XtraReports.UI
' ...

Namespace SaveComponents
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Load
            Dim report As New XtraReport1()
            AddHandler report.SaveComponents, AddressOf report_SaveComponents
            report.ShowDesignerDialog()
        End Sub

        Private Sub report_SaveComponents(ByVal sender As Object, _
        ByVal e As SaveComponentsEventArgs)

            Dim tableAdapterIdx As Integer = GetItemIndex(e.Components, _
            GetType(Component))
            If tableAdapterIdx >= 0 Then
                e.Components.RemoveAt(tableAdapterIdx)
            End If
            Dim dsIdx As Integer = GetItemIndex(e.Components, GetType(DataSet))
            If dsIdx >= 0 Then
                e.Components.RemoveAt(dsIdx)
            End If

        End Sub

        Private Shared Function GetItemIndex(ByVal components As IList, _
        ByVal targetType As Type) As Integer

            Dim idx As Integer = -1
            For i As Integer = 0 To components.Count - 1
                If components(i).GetType().BaseType Is targetType Then
                    idx = i
                    Exit For
                End If
            Next i

            Return idx
        End Function
    End Class

End Namespace