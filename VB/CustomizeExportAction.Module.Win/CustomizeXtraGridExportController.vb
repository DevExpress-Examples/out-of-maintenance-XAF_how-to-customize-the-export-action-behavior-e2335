Imports Microsoft.VisualBasic
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
Imports System.IO
Imports DevExpress.ExpressApp.Win
Imports System.Windows.Forms

Namespace CustomizeExportAction.Module.Win
    Partial Public Class CustomizeXtraGridExportController
        Inherits ViewController
        Public Sub New()
            InitializeComponent()
            RegisterActions(components)
        End Sub
        Private exportController As XtraGridExportController
        Protected Overrides Overloads Sub OnActivated()
            MyBase.OnActivated()
            exportController = Frame.GetController(Of XtraGridExportController)()
            AddHandler exportController.CustomExport, AddressOf exportController_CustomExport
            AddHandler exportController.Exported, AddressOf exportController_Exported
        End Sub
        Private Sub exportController_Exported(ByVal sender As Object, ByVal e As CustomExportEventArgs)
            If File.Exists(e.FileName) Then
                e.Stream.Close()
                If WinApplication.Messaging.GetUserChoice("Open the exported file?", "Export", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    Process.Start(e.FileName)
                End If
            End If
        End Sub
        Private Sub exportController_CustomExport(ByVal sender As Object, ByVal e As CustomExportEventArgs)
            Dim gridListEditor As GridListEditor = TryCast((CType(View, DevExpress.ExpressApp.ListView)).Editor, GridListEditor)
            Dim gridView As XafGridView = gridListEditor.GridView
            If HasCollapsedGroups(gridView) Then
                If WinApplication.Messaging.GetUserChoice("There are collapsed groups in the grid. Expand all groups in the exported file?", "Export", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    gridView.OptionsPrint.ExpandAllGroups = True
                Else
                    gridView.OptionsPrint.ExpandAllGroups = False
                End If
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
        Protected Overrides Overloads Sub OnDeactivating()
            MyBase.OnDeactivating()
            RemoveHandler exportController.CustomExport, AddressOf exportController_CustomExport
            RemoveHandler exportController.Exported, AddressOf exportController_Exported
        End Sub
    End Class
End Namespace
