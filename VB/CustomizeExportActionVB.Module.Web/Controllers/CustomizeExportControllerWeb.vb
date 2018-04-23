Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base


Imports DevExpress.ExpressApp.Web.SystemModule
'add a reference to the DevExpress.Web.ASPxGridView.Export assembly
Imports DevExpress.Web.ASPxGridView.Export

Public Class CustomizeExportControllerWeb
    Inherits CustomizeExportController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 

    End Sub
    Protected Overrides Sub CustomExport(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.SystemModule.CustomExportEventArgs)
        MyBase.CustomExport(sender, e)
        'Export only selected rows
        Dim exporter As ASPxGridViewExporter = TryCast(e.Printable, ASPxGridViewExporter)
        If exporter IsNot Nothing Then
            exporter.ExportedRowType = GridViewExportedRowType.Selected
        End If
    End Sub
End Class
