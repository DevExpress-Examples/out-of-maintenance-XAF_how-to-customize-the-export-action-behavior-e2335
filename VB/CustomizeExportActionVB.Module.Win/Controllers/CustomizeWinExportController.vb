Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Win.SystemModule
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Win
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
Imports System.IO

Partial Public Class CustomizeWinExportController
    Inherits ViewController
    Public Sub New()
        InitializeComponent()
        RegisterActions(components)
        Me.TargetViewType = ViewType.ListView
    End Sub
    Private exportController As WinExportController
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        exportController = Frame.GetController(Of WinExportController)()
        AddHandler exportController.CustomExport, AddressOf exportController_CustomExport
        AddHandler exportController.Exported, AddressOf exportController_Exported
    End Sub

    Private Sub exportController_CustomExport(ByVal sender As Object, ByVal e As CustomExportEventArgs)


        'Show message before exporting
        Dim gridListEditor As GridListEditor = TryCast((CType(View, DevExpress.ExpressApp.ListView)).Editor, GridListEditor)
        If gridListEditor IsNot Nothing Then
            Dim gridView As XafGridView = gridListEditor.GridView
            If HasCollapsedGroups(gridView) Then
                Dim message As String = "There are collapsed groups in the grid. Do you need to expand all groups in the exported file?"
                gridView.OptionsPrint.ExpandAllGroups = WinApplication.Messaging.GetUserChoice(message, GetMessageBoxCaption(), MessageBoxButtons.YesNo) = DialogResult.Yes
            End If
        End If
        'Customize Export Options
        If e.ExportTarget = ExportTarget.Xls Then
            Dim printable As IPrintable = exportController.Exportable.Printable
            Dim options As XlsExportOptions = CType(e.ExportOptions, XlsExportOptions)
            If options Is Nothing Then
                options = New XlsExportOptions()
            End If
            options.SheetName = View.Caption
            options.ShowGridLines = True
            e.ExportOptions = options
        End If
    End Sub
    Private Function HasCollapsedGroups(ByVal gridView As XafGridView) As Boolean
        If gridView.GroupCount > 0 Then
            Dim rowHandle As Integer = -1
            Do While gridView.IsValidRowHandle(rowHandle)
                If (Not gridView.GetRowExpanded(rowHandle)) Then
                    Return True
                End If
                rowHandle -= 1
            Loop
        End If
        Return False
    End Function
    Private Function GetMessageBoxCaption() As String
        Return String.Format("{0} {1}", exportController.ExportAction.Caption, exportController.ExportAction.SelectedItem)
    End Function
    Private Sub exportController_Exported(ByVal sender As Object, ByVal e As CustomExportEventArgs)
        If TypeOf e.Stream Is FileStream Then
            Dim fileName As String = (CType(e.Stream, FileStream)).Name
            If File.Exists(fileName) Then
                e.Stream.Close()
                If WinApplication.Messaging.GetUserChoice("Open the exported file?", GetMessageBoxCaption(), MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    Process.Start(fileName)
                End If
            End If
        End If
    End Sub
    Protected Overrides Sub OnDeactivated()
        RemoveHandler exportController.CustomExport, AddressOf exportController_CustomExport
        RemoveHandler exportController.Exported, AddressOf exportController_Exported
        MyBase.OnDeactivated()
    End Sub
End Class

