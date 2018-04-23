Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Namespace CustomizeExportAction.Module.Win
    Partial Public Class ViewController1
        Inherits ViewController
        Public Sub New()
            InitializeComponent()
            RegisterActions(components)
        End Sub
    End Class
End Namespace
