Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<DefaultClassOptions()> _
 Public Class Contact
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
        ' This constructor is used when an object is loaded from a persistent storage.
        ' Do not place any code here or place it only when the IsLoading property is false:
        ' if (!IsLoading){
        '   It is now OK to place your initialization code here.
        ' }
        ' or as an alternative, move your initialization code into the AfterConstruction method.
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place here your initialization code.
    End Sub
    Private fLastName As String
    Public Property LastName() As String
        Get
            Return fLastName
        End Get
        Set(ByVal value As String)
            SetPropertyValue("LastName", fLastName, value)
        End Set
    End Property
    Private fFirstName As String
    Public Property FirstName() As String
        Get
            Return fFirstName
        End Get
        Set(ByVal value As String)
            SetPropertyValue("FirstName", fFirstName, value)
        End Set
    End Property
    Private fDepartment As String
    Public Property Department() As String
        Get
            Return fDepartment
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Department", fDepartment, value)
        End Set
    End Property
End Class
