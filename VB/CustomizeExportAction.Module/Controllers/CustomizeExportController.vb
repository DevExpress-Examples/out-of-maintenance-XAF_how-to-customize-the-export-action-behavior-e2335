Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Imports DevExpress.ExpressApp.SystemModule

Imports DevExpress.XtraPrinting

Namespace CustomizeExportAction.Module.Controllers
   Partial Public Class CustomizeExportController
       Inherits ViewController

      Public Sub New()
         InitializeComponent()
         RegisterActions(components)
         TargetViewType = ViewType.ListView
      End Sub
      Private exportController As ExportController
      Protected Overrides Sub OnActivated()
         MyBase.OnActivated()
         exportController = Frame.GetController(Of ExportController)()
         AddHandler exportController.CustomGetDefaultFileName, AddressOf exportController_CustomGetDefaultFileName
         AddHandler exportController.CustomExport, AddressOf CustomExport
      End Sub

      Protected Overridable Sub CustomExport(ByVal sender As Object, ByVal e As CustomExportEventArgs)
         'Customize Export Options
         If e.ExportTarget = ExportTarget.Xls Then
            Dim options As XlsExportOptions = CType(e.ExportOptions, XlsExportOptions)
            If options Is Nothing Then
               options = New XlsExportOptions()
            End If
            options.SheetName = View.Caption
            options.ShowGridLines = True
            e.ExportOptions = options
         End If
      End Sub
      Private Sub exportController_CustomGetDefaultFileName(ByVal sender As Object, ByVal e As CustomGetDefaultFileNameEventArgs)
#If EASYTEST Then
             'Provide a custom file name
         e.FileName = e.FileName & "_06.25.12"
#Else
          'Provide a custom file name
         e.FileName = e.FileName & "_" & Date.Now.ToString("MM.dd.yy")
#End If
      End Sub
      Protected Overrides Sub OnDeactivated()
         RemoveHandler exportController.CustomGetDefaultFileName, AddressOf exportController_CustomGetDefaultFileName
         RemoveHandler exportController.CustomExport, AddressOf CustomExport
         MyBase.OnDeactivated()
      End Sub
   End Class
End Namespace
