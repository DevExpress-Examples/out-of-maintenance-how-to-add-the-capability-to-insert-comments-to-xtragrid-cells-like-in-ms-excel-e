Imports Microsoft.VisualBasic
Imports System
Namespace WinFormsExample
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.testClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colProperty1 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colProperty2 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colProperty3 = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.toolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
			Me.popupControlContainer1 = New DevExpress.XtraBars.PopupControlContainer(Me.components)
			Me.memoEdit1 = New DevExpress.XtraEditors.MemoEdit()
			Me.barManager1 = New DevExpress.XtraBars.BarManager(Me.components)
			Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
			Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
			Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
			Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.testClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.popupControlContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.popupControlContainer1.SuspendLayout()
			CType(Me.memoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.barManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl1
			' 
			Me.gridControl1.DataSource = Me.testClassBindingSource
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(469, 262)
			Me.gridControl1.TabIndex = 2
			Me.gridControl1.ToolTipController = Me.toolTipController1
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' testClassBindingSource
			' 
			Me.testClassBindingSource.DataSource = GetType(WinFormsExample.TestClass)
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colProperty1, Me.colProperty2, Me.colProperty3})
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			Me.gridView1.OptionsHint.ShowColumnHeaderHints = False
			Me.gridView1.OptionsHint.ShowFooterHints = False
'			Me.gridView1.CustomDrawCell += New DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(Me.gridView1_CustomDrawCell);
'			Me.gridView1.ShowGridMenu += New DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(Me.gridView1_ShowGridMenu);
			' 
			' colProperty1
			' 
			Me.colProperty1.FieldName = "Property1"
			Me.colProperty1.Name = "colProperty1"
			Me.colProperty1.Visible = True
			Me.colProperty1.VisibleIndex = 0
			' 
			' colProperty2
			' 
			Me.colProperty2.FieldName = "Property2"
			Me.colProperty2.Name = "colProperty2"
			Me.colProperty2.Visible = True
			Me.colProperty2.VisibleIndex = 1
			' 
			' colProperty3
			' 
			Me.colProperty3.FieldName = "Property3"
			Me.colProperty3.Name = "colProperty3"
			Me.colProperty3.Visible = True
			Me.colProperty3.VisibleIndex = 2
			' 
			' toolTipController1
			' 
'			Me.toolTipController1.GetActiveObjectInfo += New DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(Me.toolTipController1_GetActiveObjectInfo);
			' 
			' popupControlContainer1
			' 
			Me.popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
			Me.popupControlContainer1.Controls.Add(Me.memoEdit1)
			Me.popupControlContainer1.Location = New System.Drawing.Point(12, 140)
			Me.popupControlContainer1.Manager = Me.barManager1
			Me.popupControlContainer1.Name = "popupControlContainer1"
			Me.popupControlContainer1.Size = New System.Drawing.Size(148, 100)
			Me.popupControlContainer1.TabIndex = 3
			Me.popupControlContainer1.Visible = False
'			Me.popupControlContainer1.CloseUp += New System.EventHandler(Me.popupControlContainer1_CloseUp);
			' 
			' memoEdit1
			' 
			Me.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.memoEdit1.Location = New System.Drawing.Point(0, 0)
			Me.memoEdit1.Name = "memoEdit1"
			Me.memoEdit1.Size = New System.Drawing.Size(148, 100)
			Me.memoEdit1.TabIndex = 0
			' 
			' barManager1
			' 
			Me.barManager1.DockControls.Add(Me.barDockControlTop)
			Me.barManager1.DockControls.Add(Me.barDockControlBottom)
			Me.barManager1.DockControls.Add(Me.barDockControlLeft)
			Me.barManager1.DockControls.Add(Me.barDockControlRight)
			Me.barManager1.Form = Me
			Me.barManager1.MaxItemId = 0
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(469, 262)
			Me.Controls.Add(Me.popupControlContainer1)
			Me.Controls.Add(Me.gridControl1)
			Me.Controls.Add(Me.barDockControlLeft)
			Me.Controls.Add(Me.barDockControlRight)
			Me.Controls.Add(Me.barDockControlBottom)
			Me.Controls.Add(Me.barDockControlTop)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.testClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.popupControlContainer1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.popupControlContainer1.ResumeLayout(False)
			CType(Me.memoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.barManager1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private testClassBindingSource As System.Windows.Forms.BindingSource
		Private colProperty1 As DevExpress.XtraGrid.Columns.GridColumn
		Private colProperty2 As DevExpress.XtraGrid.Columns.GridColumn
		Private colProperty3 As DevExpress.XtraGrid.Columns.GridColumn
		Private WithEvents popupControlContainer1 As DevExpress.XtraBars.PopupControlContainer
		Private memoEdit1 As DevExpress.XtraEditors.MemoEdit
		Private barManager1 As DevExpress.XtraBars.BarManager
		Private barDockControlTop As DevExpress.XtraBars.BarDockControl
		Private barDockControlBottom As DevExpress.XtraBars.BarDockControl
		Private barDockControlLeft As DevExpress.XtraBars.BarDockControl
		Private barDockControlRight As DevExpress.XtraBars.BarDockControl
		Private WithEvents toolTipController1 As DevExpress.Utils.ToolTipController
	End Class
End Namespace

