Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web

Partial Public Class CustomizeExportActionVBAspNetApplication
	Inherits WebApplication
	Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
    Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
	Private module3 As CustomizeExportActionVB.Module.CustomizeExportActionVBModule
	Private module4 As CustomizeExportActionVB.Module.Web.CustomizeExportActionVBAspNetModule
	Private module5 As DevExpress.ExpressApp.Validation.ValidationModule
    Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
	Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule

    Private securitySimple As DevExpress.ExpressApp.Security.SecurityStrategySimple
	Private authenticationActiveDirectory1 As DevExpress.ExpressApp.Security.AuthenticationActiveDirectory
	Private sqlConnection1 As System.Data.SqlClient.SqlConnection

	Public Sub New()
		InitializeComponent()
	End Sub

	Private Sub CustomizeExportActionVBAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch

        e.Updater.Update()
        e.Handled = True

    End Sub

	Private Sub InitializeComponent()
		Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
        Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
		Me.module3 = New CustomizeExportActionVB.Module.CustomizeExportActionVBModule()
		Me.module4 = New CustomizeExportActionVB.Module.Web.CustomizeExportActionVBAspNetModule()
		Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule()
        Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
		Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
        Me.securitySimple = New DevExpress.ExpressApp.Security.SecurityStrategySimple()
		Me.authenticationActiveDirectory1 = New DevExpress.ExpressApp.Security.AuthenticationActiveDirectory()
		Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
		CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
		' 
		' securitySimple1
		' 
        Me.securitySimple.Authentication = Me.authenticationActiveDirectory1
        Me.securitySimple.UserType = GetType(DevExpress.ExpressApp.Security.SecuritySimpleUser)
        ' 
		' authenticationActiveDirectory1
		' 
		Me.authenticationActiveDirectory1.CreateUserAutomatically = True
        Me.authenticationActiveDirectory1.UserType = GetType(DevExpress.ExpressApp.Security.SecuritySimpleUser)
		' 
		' sqlConnection1
		' 
		Me.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=CustomizeExportActionVB;Integrated Security=SSPI;Pooling=false"
		Me.sqlConnection1.FireInfoMessageEventOnUserErrors = False
		' 
		' CustomizeExportActionVBAspNetApplication
		' 
		Me.ApplicationName = "CustomizeExportActionVB"
		Me.Connection = Me.sqlConnection1
		Me.Modules.Add(Me.module1)
		Me.Modules.Add(Me.module2)
		Me.Modules.Add(Me.module3)
		Me.Modules.Add(Me.module4)
		Me.Modules.Add(Me.module5)
        Me.Modules.Add(Me.module6)
		Me.Modules.Add(Me.securityModule1)

        Me.Security = Me.securitySimple
		AddHandler Me.DatabaseVersionMismatch, AddressOf CustomizeExportActionVBAspNetApplication_DatabaseVersionMismatch
		CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
	End Sub
End Class

