Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl

Namespace CustomizeExportAction.Module
    Public Class Updater
        Inherits ModuleUpdater
        Public Sub New(ByVal session As Session, ByVal currentDBVersion As Version)
            MyBase.New(session, currentDBVersion)
        End Sub
        Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
            MyBase.UpdateDatabaseAfterUpdateSchema()
            If Session.FindObject(Of Contact)(CriteriaOperator.Parse("FirstName == 'Mary' && LastName == 'Tellitson'")) Is Nothing Then
                Dim contact1 As New Contact(Session)
                contact1.FirstName = "Mary"
                contact1.LastName = "Tellitson"
                contact1.Department = "Sales Department"
                contact1.Save()
            End If
            If Session.FindObject(Of Contact)(CriteriaOperator.Parse("FirstName == 'John' && LastName == 'Nielsen'")) Is Nothing Then
                Dim contact2 As New Contact(Session)
                contact2.FirstName = "John"
                contact2.LastName = "Nielsen"
                contact2.Department = "Development Department"
                contact2.Save()
            End If
            If Session.FindObject(Of Contact)(CriteriaOperator.Parse("FirstName == 'Robert' && LastName == 'King'")) Is Nothing Then
                Dim contact3 As New Contact(Session)
                contact3.FirstName = "Robert"
                contact3.LastName = "King"
                contact3.Department = "Development Department"
                contact3.Save()
            End If
        End Sub
    End Class
End Namespace

