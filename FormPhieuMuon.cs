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
    public partial class FormPhieuMuon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormPhieuMuon()
        {
            InitializeComponent();
        }

        private void FormPhieuMuon_Load(object sender, EventArgs e)
        {
            LoadGridView();
            using (var db = new ThuVien())
            {
                luDocGia.Properties.DataSource = db.DocGia.Select(dg => new { ID = dg.madocgia, Name = dg.hoten }).ToList();
            }
        }

        private void LoadGridView()
        {
            using (var db = new ThuVien())
            {
                gridControl.DataSource = db.PhieuMuon.Select(x => new { maphieumuon = x.maphieumuon, nguoimuon = x.DocGia.hoten, ngaymuon = x.ngaymuon, soluong = x.Sach.Count }).ToList();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Them
            using (var db = new ThuVien()) {
                db.PhieuMuon.Add(new PhieuMuon { maphieumuon = txtMaPhieu.Text, nguoimuon = luDocGia.EditValue as string, ngaymuon = (DateTime) calendar.EditValue });
                db.SaveChanges();
            }
            LoadGridView();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Cap nhat
            var gridview = (GridView)gridControl.MainView;
            var id = gridview.GetFocusedRowCellValue("maphieumuon") as string;
            if (id == null) return;

            using (var db = new ThuVien())
            {
                var phieumuon = db.PhieuMuon.First(pm => pm.maphieumuon == id);
                phieumuon.ngaymuon = (DateTime)calendar.EditValue;
                phieumuon.nguoimuon = (string)luDocGia.EditValue;
                db.SaveChanges();
            }
            LoadGridView();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Xoa
            var gridview = (GridView)gridControl.MainView;
            var id = gridview.GetFocusedRowCellValue("maphieumuon") as string;
            if (id == null) return;
            using (var db = new ThuVien())
            {
                var phieumuon = db.PhieuMuon.First(pm => pm.maphieumuon == id);
                db.PhieuMuon.Remove(phieumuon);
                db.SaveChanges();
            }
            LoadGridView();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Chi tiet phieu muon
            var gridview = (GridView)gridControl.MainView;
            var id = gridview.GetFocusedRowCellValue("maphieumuon") as string;
            if (id == null) return;
            (new FormCTPM(id)).ShowDialog();
            LoadGridView();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.ShowRibbonPrintPreview();
        }
    }
}