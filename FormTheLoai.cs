using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace CongNghePhanMem
{
    public partial class FormTheLoai : DevExpress.XtraEditors.XtraForm
    {
        public FormTheLoai()
        {
            InitializeComponent();
        }

        private void UpdateGridView()
        {
            using (var db = new ThuVien())
            {
                gridControl.DataSource = db.TheLoai.ToList();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var db = new ThuVien())
            {
                db.TheLoai.Add(new TheLoai { matheloai = txtID.Text, tentheloai = txtName.Text });
                db.SaveChanges();
            }
            UpdateGridView();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            GridView gridView = gridControl.MainView as GridView;
            if (gridView.GetFocusedRow() == null) return;
            string id = (gridView.GetFocusedRow() as TheLoai).matheloai;
            using (var db = new ThuVien())
            {
                var tl = db.TheLoai.First(x => x.matheloai == id);
                tl.tentheloai = txtName.Text;
                db.SaveChanges();
            }
            UpdateGridView();
        }

        private void FormTheLoai_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            GridView gridView = gridControl.MainView as GridView;
            if (gridView.GetFocusedRow() == null) return;
            string id = (gridView.GetFocusedRow() as TheLoai).matheloai;
            using (var db = new ThuVien())
            {
                db.TheLoai.Remove(db.TheLoai.First(x => x.matheloai == id));
                db.SaveChanges();
            }
            UpdateGridView();
        }
    }
}