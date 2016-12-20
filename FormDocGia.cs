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
    public partial class FormDocGia : DevExpress.XtraEditors.XtraForm
    {
        public FormDocGia()
        {
            InitializeComponent();
        }

        private void UpdateGridView()
        {
            using (var db = new ThuVien())
            {
                gridControl.DataSource = db.DocGia.ToList();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var db = new ThuVien())
            {
                db.DocGia.Add(new DocGia { madocgia = txtID.Text, hoten = txtName.Text, diachi = txtAddr.Text, sodienthoai = txtSDT.Text });
                db.SaveChanges();
            }
            UpdateGridView();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            GridView gridView = gridControl.MainView as GridView;
            if (gridView.GetFocusedRow() == null) return;
            string id = (gridView.GetFocusedRow() as DocGia).madocgia;
            using (var db = new ThuVien())
            {
                var dg = db.DocGia.First(x => x.madocgia == id);
                dg.hoten = txtName.Text;
                dg.sodienthoai = txtSDT.Text;
                dg.diachi = txtAddr.Text;
                db.SaveChanges();
            }
            UpdateGridView();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            GridView gridView = gridControl.MainView as GridView;
            if (gridView.GetFocusedRow() == null) return;
            string id = (gridView.GetFocusedRow() as DocGia).madocgia;
            using (var db = new ThuVien())
            {
                db.DocGia.Remove(db.DocGia.First(x => x.madocgia == id));
                db.SaveChanges();
            }
            UpdateGridView();
        }
    }
}