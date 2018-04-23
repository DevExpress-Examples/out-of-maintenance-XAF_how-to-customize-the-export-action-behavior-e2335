Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Windows.Forms

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Imports CustomizeExportAction.Module
Imports DevExpress.ExpressApp.Xpo


Namespace CustomizeExportAction.Win
   Friend NotInheritable Class Program
	  ''' <summary>
	  ''' The main entry point for the application.
	  ''' </summary>
	  Private Sub New()
	  End Sub
	  <STAThread> _
	  Shared Sub Main()
#If EASYTEST Then
			DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register()
#End If

		 Application.EnableVisualStyles()
		 Application.SetCompatibleTextRenderingDefault(False)
		 EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
		 Dim winApplication As New CustomizeExportActionWindowsFormsApplication()
		 InMemoryDataStoreProvider.Register()
		 winApplication.ConnectionString = InMemoryDataStoreProvider.ConnectionString

		 Try
			' Uncomment this line when using the Middle Tier application server:
			' new DevExpress.ExpressApp.MiddleTier.MiddleTierClientApplicationConfigurator(winApplication);
			winApplication.Setup()
			winApplication.Start()
		 Catch e As Exception
			winApplication.HandleException(e)
		 End Try
	  End Sub
   End Class
End Namespace
