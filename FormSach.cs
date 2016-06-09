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
    public partial class FormSach : Form
    {
        public FormSach()
        {
            InitializeComponent();
        }

        private void Init()
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            gridView.AutoGenerateColumns = false;
            gridView.DataSource = DB.QueryTable("SELECT Sach.masach, Sach.tensach, Sach.gioithieu, TheLoai.tentheloai AS theloai,TacGia.tentacgia AS tacgia, TacGia.gioithieu as tg_gioithieu, NhaXB.tennhaxb as nhaxb FROM Sach JOIN NhaXB ON Sach.nhaxb = NhaXB.manhaxb JOIN TheLoai ON Sach.theloai = TheLoai.matheloai JOIN TacGia ON Sach.tacgia = TacGia.matacgia");
        }
        private void FormSach_Load(object sender, EventArgs e)
        {
            Init();
        }
    }
}
