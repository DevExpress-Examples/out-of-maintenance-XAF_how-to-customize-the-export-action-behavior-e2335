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
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Win
Imports System.Windows.Forms

Imports System.IO
Imports CustomizeExportAction.Module.Controllers

Namespace CustomizeExportAction.Module.Win.Controllers
   Partial Public Class CustomizeExportControllerWin
	   Inherits CustomizeExportController
	  Private winExportController As WinExportController
	  Protected Overrides Sub OnActivated()
		 MyBase.OnActivated()
		 winExportController = Frame.GetController(Of WinExportController)()
		 AddHandler winExportController.Exported, AddressOf winExportController_Exported
	  End Sub

	  Private Sub winExportController_Exported(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.SystemModule.CustomExportEventArgs)
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
	  Protected Overrides Sub CustomExport(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.SystemModule.CustomExportEventArgs)
		 MyBase.CustomExport(sender, e)
		 'Show a message before exporting a Grid List Editor
		 Dim gridListEditor As GridListEditor = TryCast((CType(View, DevExpress.ExpressApp.ListView)).Editor, GridListEditor)
		 If gridListEditor IsNot Nothing Then
			Dim gridView As XafGridView = gridListEditor.GridView
			If HasCollapsedGroups(gridView) Then
			   Dim message As String = "There are collapsed groups in the grid. Expand all groups in the exported file?"
			   gridView.OptionsPrint.ExpandAllGroups = WinApplication.Messaging.GetUserChoice(message, GetMessageBoxCaption(), MessageBoxButtons.YesNo) = DialogResult.Yes
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
	  Private Function GetMessageBoxCaption() As String
		 Return String.Format("{0} {1}", winExportController.ExportAction.Caption, winExportController.ExportAction.SelectedItem)
	  End Function
	  Protected Overrides Sub OnDeactivated()
		 RemoveHandler winExportController.Exported, AddressOf winExportController_Exported
		 MyBase.OnDeactivated()
	  End Sub
   End Class
End Namespace
