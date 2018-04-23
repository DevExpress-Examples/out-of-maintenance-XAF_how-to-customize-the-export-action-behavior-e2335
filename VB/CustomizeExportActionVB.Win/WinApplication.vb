Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Win

Partial Public Class CustomizeExportActionVBWindowsFormsApplication
	Inherits WinApplication
	Public Sub New()
		InitializeComponent()
        DelayedViewItemsInitialization = True
	End Sub

	Private Sub CustomizeExportActionVBWindowsFormsApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch

        e.Updater.Update()
        e.Handled = True

    End Sub
End Class
