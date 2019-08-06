using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCPA_DB
{
    public partial class Popup : Form
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="parent">parent form</param>
        public Popup(PCPA_DB parent)
        {
            InitializeComponent();
            
            pathBox.Text = parent.DBpath;
        }

        private void CloseBttn_Click(object sender, EventArgs e)
        {
            if (!File.Exists(pathBox.Text))
            {
                Blink(pathBox);
            }
        }

        private async void Blink(TextBox tb)
        {
            for (int i = 0; i < 6; i++)
            {
                await Task.Delay(80);
                tb.BackColor = tb.BackColor == SystemColors.Window ? Color.HotPink : SystemColors.Window;
            }
        }
    }
}
