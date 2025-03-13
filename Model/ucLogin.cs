using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System.Model
{
    public partial class ucLogin : UserControl
    {
        public ucLogin()
        {
            InitializeComponent();
        }
        public event Action OnSwitchToRegister;

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnSwitchToRegister_Click(object sender, EventArgs e)
        {
            OnSwitchToRegister?.Invoke();
        }
    }
}
