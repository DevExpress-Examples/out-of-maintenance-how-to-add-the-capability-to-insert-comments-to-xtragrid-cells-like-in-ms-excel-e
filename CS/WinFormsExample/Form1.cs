using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;

namespace WinFormsExample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        Dictionary<CommentCoordinates, string> comments;
        private void Form1_Load(object sender, EventArgs e) {
            comments = new Dictionary<CommentCoordinates, string>();
            TestClass obj = new TestClass();
            obj.Property1 = "1";
            obj.Property2 = "1";
            obj.Property3 = "1";
            testClassBindingSource.Add(obj);
            obj = new TestClass();
            obj.Property1 = "2";
            obj.Property2 = "2";
            obj.Property3 = "2";
            testClassBindingSource.Add(obj);
            obj = new TestClass();
            obj.Property1 = "3";
            obj.Property2 = "3";
            obj.Property3 = "3";
            testClassBindingSource.Add(obj);
        }

        private void gridView1_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e) {
            if (!e.HitInfo.InRowCell) return;
            if (!ContainsComment(e.HitInfo.Column.Name, gridView1.GetDataSourceRowIndex(e.HitInfo.RowHandle))) {
                DXMenuItem insertItem = new DXMenuItem("Insert Comment");
                e.Menu.Items.Add(insertItem);
                insertItem.Tag = e.Point;
                insertItem.Click += new EventHandler(insertItem_Click);
            } else {
                DXMenuItem editItem = new DXMenuItem("Edit Comment");
                e.Menu.Items.Add(editItem);
                editItem.Tag = e.Point;
                editItem.Click += new EventHandler(editItem_Click);
            }
        }

        void editItem_Click(object sender, EventArgs e) {
            string comment = GetComment(gridView1.FocusedColumn.Name, gridView1.GetFocusedDataSourceRowIndex());
            ShowPopup((DXMenuItem)sender, comment);
        }

        void insertItem_Click(object sender, EventArgs e) {
            ShowPopup((DXMenuItem)sender);
        }
        private void ShowPopup(DXMenuItem item) {
            popupControlContainer1.ShowPopup(gridControl1.PointToScreen((Point)item.Tag));
            memoEdit1.Focus();
        }
        private void ShowPopup(DXMenuItem item, string text) {
            memoEdit1.Text = text;
            ShowPopup(item);
        }
        private void popupControlContainer1_CloseUp(object sender, EventArgs e) {
            CommentCoordinates coordinates = new CommentCoordinates(gridView1.GetFocusedDataSourceRowIndex(), gridView1.FocusedColumn.Name);
            if (String.IsNullOrEmpty(memoEdit1.Text)) {
                if (comments.ContainsKey(coordinates)) {
                    comments.Remove(coordinates);
                }
            } else {
                comments[coordinates] = memoEdit1.Text;
                memoEdit1.Text = String.Empty;
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {
            if (ContainsComment(e.Column.Name, gridView1.GetDataSourceRowIndex(e.RowHandle))) {
                Point[] triangle = new Point[]{
                    new Point(e.Bounds.Right, e.Bounds.Top),
                    new Point(e.Bounds.Right, e.Bounds.Top + 7),
                    new Point(e.Bounds.Right - 7, e.Bounds.Top),
                };
                e.Cache.DrawPolygon(triangle, Color.Green, 2);
                e.Cache.FillPolygon(triangle, Color.Green);
                //e.Graphics.DrawPolygon(new Pen(Color.Green), triangle);
               // e.Graphics.FillPolygon(new SolidBrush(Color.Green), triangle);
            }
        }
        private bool ContainsComment(string columnName, int rowIndex) {
            return comments.ContainsKey(new CommentCoordinates(rowIndex, columnName));
        }
        private string GetComment(string columnName, int rowIndex) {
            CommentCoordinates coordinates = new CommentCoordinates(rowIndex, columnName);
            if (comments.ContainsKey(coordinates)) {
                return comments[coordinates];
            } else {
                return String.Empty;
            }
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e) {
            if(e.Info != null) return;
            string columnName = String.Empty;
            int dataSourceRowIndex = -1, rowHandle = -1;
            if (e.SelectedControl == gridControl1) {
                GridHitInfo info = gridView1.CalcHitInfo(e.ControlMousePosition);
                if (info.InRowCell) {
                    columnName = info.Column.Name;
                    dataSourceRowIndex = gridView1.GetDataSourceRowIndex(info.RowHandle);
                    rowHandle = info.RowHandle;
                }
            } else if (e.SelectedControl is BaseEdit && gridView1.ActiveEditor.Equals(e.SelectedControl)){
                columnName = gridView1.FocusedColumn.Name;
                dataSourceRowIndex = gridView1.GetFocusedDataSourceRowIndex();
                rowHandle = gridView1.FocusedRowHandle;
            }
            if (columnName != String.Empty) {
                string text = GetComment(columnName, dataSourceRowIndex);
                string cellKey = String.Format("{0}-{1}", rowHandle, columnName);
                e.Info = new DevExpress.Utils.ToolTipControlInfo(cellKey, text);
            }
        }
    }
    public struct CommentCoordinates {
        public CommentCoordinates(int rowIndex, string columnName) {
            this.RowIndex = rowIndex;
            this.ColumnName = columnName;
        }
        public int RowIndex;
        public string ColumnName;
    }
}
