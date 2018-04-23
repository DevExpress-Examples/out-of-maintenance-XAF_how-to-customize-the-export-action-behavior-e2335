Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Imports DevExpress.ExpressApp.Web.SystemModule
'add a reference to the DevExpress.Web.Export assembly
Imports DevExpress.Web
Imports CustomizeExportAction.Module.Controllers

Namespace CustomizeExportAction.Module.Web.Controllers
   Partial Public Class CustomizeExportControllerWeb
       Inherits CustomizeExportController

      Protected Overrides Sub CustomExport(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.SystemModule.CustomExportEventArgs)
         MyBase.CustomExport(sender, e)
         'Export only selected rows
         Dim exporter As ASPxGridViewExporter = TryCast(e.Printable, ASPxGridViewExporter)
         If exporter IsNot Nothing Then
            exporter.ExportSelectedRowsOnly = True
         End If
      End Sub
   End Class
End Namespace
