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
    public partial class FormDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        private int userID;
        public FormDoiMatKhau(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            txt1.EditValue = "";
            txt2.EditValue = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string s1 = txt1.EditValue as string;
            string s2 = txt1.EditValue as string;
            if (!s1.Equals(s2))
            {
                XtraMessageBox.Show(this, "Mật khẩu nhập lại không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (s1.Length < 6)
            {
                XtraMessageBox.Show(this, "Mật khẩu tối thiểu 6 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (var db = new ThuVien())
            {
                db.User.First(u => u.id == userID).password = s1;
                db.SaveChanges();
                XtraMessageBox.Show(this, "Đổi mật khẩu thành công", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}