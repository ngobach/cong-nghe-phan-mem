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
        }

        private void LoadGridView()
        {
            using (var db = new ThuVien())
            {
                gridControl.DataSource = db.PhieuMuon.Select(x => new { maphieumuon = x.maphieumuon, nguoimuon = x.DocGia.hoten, ngaymuon = x.ngaymuon }).ToList();
            }
        }
    }
}