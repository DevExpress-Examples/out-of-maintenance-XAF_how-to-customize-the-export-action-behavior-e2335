Imports System
Imports System.Security.Principal

Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Base.Security
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Public Class Updater
    Inherits DevExpress.ExpressApp.Updating.ModuleUpdater
    Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
        MyBase.New(objectSpace, currentDBVersion)
    End Sub

    Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
        MyBase.UpdateDatabaseAfterUpdateSchema()
        If ObjectSpace.FindObject(Of Contact)(CriteriaOperator.Parse("FirstName == 'Mary' && LastName == 'Tellitson'")) Is Nothing Then
            Dim contact1 As Contact = ObjectSpace.CreateObject(Of Contact)()
            contact1.FirstName = "Mary"
            contact1.LastName = "Tellitson"
            contact1.Department = "Sales Department"
            contact1.Save()
        End If
        If ObjectSpace.FindObject(Of Contact)(CriteriaOperator.Parse("FirstName == 'John' && LastName == 'Nielsen'")) Is Nothing Then
            Dim contact2 As Contact = ObjectSpace.CreateObject(Of Contact)()
            contact2.FirstName = "John"
            contact2.LastName = "Nielsen"
            contact2.Department = "Development Department"
            contact2.Save()
        End If
        If ObjectSpace.FindObject(Of Contact)(CriteriaOperator.Parse("FirstName == 'Robert' && LastName == 'King'")) Is Nothing Then
            Dim contact3 As Contact = ObjectSpace.CreateObject(Of Contact)()
            contact3.FirstName = "Robert"
            contact3.LastName = "King"
            contact3.Department = "Development Department"
            contact3.Save()
        End If
    End Sub
End Class

