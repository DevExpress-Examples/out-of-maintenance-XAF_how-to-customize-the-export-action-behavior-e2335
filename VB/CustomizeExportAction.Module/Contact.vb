Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace CustomizeExportAction.Module
    <DefaultClassOptions> _
    Public Class Contact
        Inherits BaseObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private lastName_Renamed As String
        Public Property LastName() As String
            Get
                Return lastName_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("LastName", lastName_Renamed, value)
            End Set
        End Property
        Private firstName_Renamed As String
        Public Property FirstName() As String
            Get
                Return firstName_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("FirstName", firstName_Renamed, value)
            End Set
        End Property
        Private department_Renamed As String
        Public Property Department() As String
            Get
                Return department_Renamed
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Department", department_Renamed, value)
            End Set
        End Property
    End Class

End Namespace
