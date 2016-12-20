using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CongNghePhanMem
{
    public partial class FormSach : DevExpress.XtraEditors.XtraForm
    {
        public FormSach()
        {
            InitializeComponent();
        }
        private void ApplyComboBox(ComboBox cb, object list, string display, string value)
        {
            cb.DataSource = list;
            cb.DisplayMember = display;
            cb.ValueMember = value;
        }

        private void Init()
        {
            gridView.AutoGenerateColumns = false;
            LoadGrid();

            // Load combo boxes
            using (var db = new ThuVien())
            {
                ApplyComboBox(cbTacGia, db.TacGia.ToList(), "tentacgia", "matacgia");
                ApplyComboBox(cbTheLoai, db.TheLoai.ToList(), "tentheloai", "matheloai");
            }
        }
        private void LoadGrid()
        {
            using (var db = new ThuVien())
            {
                gridView.DataSource = db.Sach.Select(s => new { masach = s.masach, tensach = s.tensach, gioithieu = s.gioithieu, theloai = s.TheLoai.tentheloai, tacgia = s.TacGia.tentacgia }).ToList();
            }
        }
        private void FormSach_Load(object sender, EventArgs e)
        {
            Init();
        }

        private Sach Current
        {
            get
            {
                return new Sach
                {
                    theloai = cbTheLoai.SelectedValue.ToString(),
                    tacgia = cbTacGia.SelectedValue.ToString(),
                    tensach = txtName.Text,
                    gioithieu = txtCaption.Text,
                    sotrang = Convert.ToInt32(txtTrang.Text),
                    giatien = Convert.ToInt64(txtGia.Text)

                };
            }
            set
            {
                cbTheLoai.SelectedValue = value.theloai;
                cbTacGia.SelectedValue = value.tacgia;
                txtName.Text = value.tensach;
                txtCaption.Text = value.gioithieu;
                txtTrang.Text = value.sotrang.ToString();
                txtGia.Text = value.giatien.ToString();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            using (var db = new ThuVien())
            {
                db.Sach.Add(Current);
                db.SaveChanges();
            }
            LoadGrid();
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridView.SelectedRows.Count > 0)
            {
                using (var db = new ThuVien())
                {
                    var id = (int)gridView.SelectedRows[0].Cells[0].Value;
                    db.Sach.Remove(db.Sach.First(s => s.masach == id));
                    db.SaveChanges();
                }
                LoadGrid();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (gridView.SelectedRows.Count > 0)
            {
                using (var db = new ThuVien())
                {
                    var id = (int)gridView.SelectedRows[0].Cells[0].Value;
                    var s = Current;
                    s.masach = id;
                    db.Sach.Attach(s);
                    db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                LoadGrid();
            }
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            if (gridView.SelectedRows.Count > 0)
            {
                using (var db = new ThuVien())
                {
                    var id = (int)gridView.SelectedRows[0].Cells[0].Value;
                    Current = db.Sach.First(s => s.masach == id);
                }
            }
        }
    }
}
