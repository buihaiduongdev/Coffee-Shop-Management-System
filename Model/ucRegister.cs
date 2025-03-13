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
    public partial class ucRegister : UserControl
    {
        public ucRegister()
        {
            InitializeComponent();
        }
        public event Action OnSwitchToLogin;
        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        private void btnSwitchToLogin2_Click(object sender, EventArgs e)
        {
            OnSwitchToLogin?.Invoke();
        }
    }
}
