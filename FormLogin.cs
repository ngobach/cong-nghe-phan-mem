using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace CongNghePhanMem
{
    public partial class FormLogin : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void HandleFormDrag(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); 
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var db = new ThuVien())
            {
                if (!db.User.Any(u => u.username == txtUsername.Text && u.password == txtPassword.Text))
                {
                    MessageBox.Show("Đăng nhập không thành công !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    var user = db.User.First(u => u.username == txtUsername.Text && u.password == txtPassword.Text);
                    Hide();
                    MessageBox.Show(String.Format("Đăng nhập thành công!\nXin chào {0}", user.hoten), "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    (new FormMenu(user.id)).Show();
                }
            }
        }


    }
}
