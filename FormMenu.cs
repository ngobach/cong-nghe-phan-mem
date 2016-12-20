using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace CongNghePhanMem
{
    public partial class FormMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int userID;

        public FormMenu(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            using (var db = new ThuVien())
            {
                statusLabel.Caption = "Xin chào, " + db.User.First(u => u.id == userID).hoten;
            }
        }

        private void PopUp(Form f)
        {
            Hide();
            f.Show();
            f.FormClosed += (a, b) => Show();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopUp(new FormDoiMatKhau(userID));
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopUp(new FormTheLoai());
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopUp(new FormTacGia());
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopUp(new FormSach());
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopUp(new FormDocGia());
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopUp(new FormPhieuMuon());
        }
    }
}