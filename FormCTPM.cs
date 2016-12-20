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
    public partial class FormCTPM : DevExpress.XtraEditors.XtraForm
    {
        private string id;

        public FormCTPM()
        {
            InitializeComponent();
        }

        public FormCTPM(string id)
        {
            this.id = id;
            InitializeComponent();
        }

        public void LoadData()
        {
            using (var db = new ThuVien())
            {
                var phieu = db.PhieuMuon.First(pm => pm.maphieumuon == id);
                var list = phieu.Sach.ToList();
                var hashs = new HashSet<int>(list.Select(x => x.masach).ToList());
                listMuon.DataSource = list.Select(s => new { ID = s.masach, Name = s.tensach }).ToList();
                listKho.DataSource = db.Sach.Where(s => !hashs.Contains(s.masach)).Select(s => new { ID = s.masach, Name = s.tensach }).ToList();
            }
        }
        private void FormCTPhieuMuon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (listKho.SelectedValue == null) return;
            var selected = (int)listKho.SelectedValue;
            using (var db = new ThuVien())
            {
                var phieu = db.PhieuMuon.First(pm => pm.maphieumuon == id);
                phieu.Sach.Add(db.Sach.First(s => s.masach == selected));
                db.SaveChanges();
            }
            LoadData();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (listMuon.SelectedValue == null) return;
            var selected = (int)listMuon.SelectedValue;
            using (var db = new ThuVien())
            {
                var phieu = db.PhieuMuon.First(pm => pm.maphieumuon == id);
                phieu.Sach.Remove(db.Sach.First(s => s.masach == selected));
                db.SaveChanges();
            }
            LoadData();
        }
    }
}