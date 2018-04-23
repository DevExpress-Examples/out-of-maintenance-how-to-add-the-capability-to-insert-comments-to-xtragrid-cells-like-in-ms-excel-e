Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors

Namespace WinFormsExample
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub
		Private comments As Dictionary(Of CommentCoordinates, String)
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			comments = New Dictionary(Of CommentCoordinates, String)()
			Dim obj As New TestClass()
			obj.Property1 = "1"
			obj.Property2 = "1"
			obj.Property3 = "1"
			testClassBindingSource.Add(obj)
			obj = New TestClass()
			obj.Property1 = "2"
			obj.Property2 = "2"
			obj.Property3 = "2"
			testClassBindingSource.Add(obj)
			obj = New TestClass()
			obj.Property1 = "3"
			obj.Property2 = "3"
			obj.Property3 = "3"
			testClassBindingSource.Add(obj)
		End Sub

		Private Sub gridView1_ShowGridMenu(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs) Handles gridView1.ShowGridMenu
			If Not e.HitInfo.InRowCell Then
				Return
			End If
			If Not ContainsComment(e.HitInfo.Column.Name, gridView1.GetDataSourceRowIndex(e.HitInfo.RowHandle)) Then
				Dim insertItem As New DXMenuItem("Insert Comment")
				e.Menu.Items.Add(insertItem)
				insertItem.Tag = e.Point
				AddHandler insertItem.Click, AddressOf insertItem_Click
			Else
				Dim editItem As New DXMenuItem("Edit Comment")
				e.Menu.Items.Add(editItem)
				editItem.Tag = e.Point
				AddHandler editItem.Click, AddressOf editItem_Click
			End If
		End Sub

		Private Sub editItem_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim comment As String = GetComment(gridView1.FocusedColumn.Name, gridView1.GetFocusedDataSourceRowIndex())
			ShowPopup(CType(sender, DXMenuItem), comment)
		End Sub

		Private Sub insertItem_Click(ByVal sender As Object, ByVal e As EventArgs)
			ShowPopup(CType(sender, DXMenuItem))
		End Sub
		Private Sub ShowPopup(ByVal item As DXMenuItem)
			popupControlContainer1.ShowPopup(gridControl1.PointToScreen(CType(item.Tag, Point)))
			memoEdit1.Focus()
		End Sub
		Private Sub ShowPopup(ByVal item As DXMenuItem, ByVal text As String)
			memoEdit1.Text = text
			ShowPopup(item)
		End Sub
		Private Sub popupControlContainer1_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles popupControlContainer1.CloseUp
			Dim coordinates As New CommentCoordinates(gridView1.GetFocusedDataSourceRowIndex(), gridView1.FocusedColumn.Name)
			If String.IsNullOrEmpty(memoEdit1.Text) Then
				If comments.ContainsKey(coordinates) Then
					comments.Remove(coordinates)
				End If
			Else
				comments(coordinates) = memoEdit1.Text
				memoEdit1.Text = String.Empty
			End If
		End Sub

		Private Sub gridView1_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles gridView1.CustomDrawCell
			If ContainsComment(e.Column.Name, gridView1.GetDataSourceRowIndex(e.RowHandle)) Then
				Dim triangle() As Point = { _
					New Point(e.Bounds.Right, e.Bounds.Top), _
					New Point(e.Bounds.Right, e.Bounds.Top + 7), _
					New Point(e.Bounds.Right - 7, e.Bounds.Top) _
				}
				e.Cache.DrawPolygon(triangle, Color.Green, 2)
				e.Cache.FillPolygon(triangle, Color.Green)
				'e.Graphics.DrawPolygon(new Pen(Color.Green), triangle);
			   ' e.Graphics.FillPolygon(new SolidBrush(Color.Green), triangle);
			End If
		End Sub
		Private Function ContainsComment(ByVal columnName As String, ByVal rowIndex As Integer) As Boolean
			Return comments.ContainsKey(New CommentCoordinates(rowIndex, columnName))
		End Function
		Private Function GetComment(ByVal columnName As String, ByVal rowIndex As Integer) As String
			Dim coordinates As New CommentCoordinates(rowIndex, columnName)
			If comments.ContainsKey(coordinates) Then
				Return comments(coordinates)
			Else
				Return String.Empty
			End If
		End Function

		Private Sub toolTipController1_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles toolTipController1.GetActiveObjectInfo
			If e.Info IsNot Nothing Then
				Return
			End If
			Dim columnName As String = String.Empty
			Dim dataSourceRowIndex As Integer = -1, rowHandle As Integer = -1
			If e.SelectedControl Is gridControl1 Then
				Dim info As GridHitInfo = gridView1.CalcHitInfo(e.ControlMousePosition)
				If info.InRowCell Then
					columnName = info.Column.Name
					dataSourceRowIndex = gridView1.GetDataSourceRowIndex(info.RowHandle)
					rowHandle = info.RowHandle
				End If
			ElseIf TypeOf e.SelectedControl Is BaseEdit AndAlso gridView1.ActiveEditor.Equals(e.SelectedControl) Then
				columnName = gridView1.FocusedColumn.Name
				dataSourceRowIndex = gridView1.GetFocusedDataSourceRowIndex()
				rowHandle = gridView1.FocusedRowHandle
			End If
			If columnName <> String.Empty Then
'INSTANT VB NOTE: The variable text was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim text_Renamed As String = GetComment(columnName, dataSourceRowIndex)
				Dim cellKey As String = String.Format("{0}-{1}", rowHandle, columnName)
				e.Info = New DevExpress.Utils.ToolTipControlInfo(cellKey, text_Renamed)
			End If
		End Sub
	End Class
	Public Structure CommentCoordinates
		Public Sub New(ByVal rowIndex As Integer, ByVal columnName As String)
			Me.RowIndex = rowIndex
			Me.ColumnName = columnName
		End Sub
		Public RowIndex As Integer
		Public ColumnName As String
	End Structure
End Namespace
