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
    public partial class FormMenuOld : Form
    {
        public FormMenuOld()
        {
            InitializeComponent();
        }

        private void btnQLSach_Click(object sender, EventArgs e)
        {
            Hide();
            (new FormSach()).ShowDialog();
            Show();
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }

}