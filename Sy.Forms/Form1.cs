using Sy.Business.Repository;
using Sy.Core.ComplexTypes;
using Sy.Core.Entities;
using Sy.Forms.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sy.Forms
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            groupBox1.Visible = true;
            lblisim.Visible = false;

        }

        private void btngirisyap_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            frm.ShowDialog();
            if (StockSettings.UserInfo ==null)
            {
                groupBox1.Visible = true;
                lblisim.Visible = false;
            }
            else
            {
                groupBox1.Visible = false;
                lblisim.Visible = true;
                lblisim.Text = StockSettings.UserInfo.Display;
            }
        }

        private void btnkayıtol_Click(object sender, EventArgs e)
        {
            RegisterForm frm = new RegisterForm();
            frm.ShowDialog();
  
        }

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            frm.Show();
        }
    }
}
