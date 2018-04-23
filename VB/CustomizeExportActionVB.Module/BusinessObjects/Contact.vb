Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<DefaultClassOptions(), ImageName("BO_Contact")> _
Public Class Contact
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Private _lastName As String
    Public Property LastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            SetPropertyValue("LastName", _lastName, value)
        End Set
    End Property
    Private _firstName As String
    Public Property FirstName() As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            SetPropertyValue("FirstName", _firstName, value)
        End Set
    End Property
    Private _department As String
    Public Property Department() As String
        Get
            Return _department
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Department", _department, value)
        End Set
    End Property
End Class

