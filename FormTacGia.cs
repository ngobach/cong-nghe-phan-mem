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
    public partial class FormTacGia : DevExpress.XtraEditors.XtraForm
    {
        public FormTacGia()
        {
            InitializeComponent();
        }

        private void UpdateGridView()
        {
            using (var db = new ThuVien())
            {
                gridControl.DataSource = db.TacGia.ToList();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var db = new ThuVien())
            {
                db.TacGia.Add(new TacGia { matacgia = txtID.Text, tentacgia = txtName.Text, gioithieu = txtGioiThieu.Text });
                db.SaveChanges();
            }
            UpdateGridView();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            GridView gridView = gridControl.MainView as GridView;
            if (gridView.GetFocusedRow() == null) return;
            string id = (gridView.GetFocusedRow() as TacGia).matacgia;
            using (var db = new ThuVien())
            {
                var tg = db.TacGia.First(x => x.matacgia == id);
                tg.tentacgia = txtName.Text;
                tg.gioithieu = txtGioiThieu.Text;
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
            string id = (gridView.GetFocusedRow() as TacGia).matacgia;
            using (var db = new ThuVien())
            {
                db.TacGia.Remove(db.TacGia.First(x => x.matacgia == id));
                db.SaveChanges();
            }
            UpdateGridView();
        }
    }
}