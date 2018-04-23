Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace WinFormsExample
	Public Class TestClass
		Private _Property1 As String
		Public Property Property1() As String
			Get
				Return _Property1
			End Get
			Set(ByVal value As String)
				_Property1 = value
			End Set
		End Property
		Private _Property2 As String
		Public Property Property2() As String
			Get
				Return _Property2
			End Get
			Set(ByVal value As String)
				_Property2 = value
			End Set
		End Property
		Private _Property3 As String
		Public Property Property3() As String
			Get
				Return _Property3
			End Get
			Set(ByVal value As String)
				_Property3 = value
			End Set
		End Property
	End Class
End Namespace
