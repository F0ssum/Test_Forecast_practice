using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forecast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Установка размера формы в соответствии с размером TabControl
            this.Size = new System.Drawing.Size(tabControl1.Width, tabControl1.Height);
        }
    }
}
