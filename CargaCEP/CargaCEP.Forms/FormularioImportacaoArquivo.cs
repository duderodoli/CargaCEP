using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargaCEP.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAbrirDialogoArquivo_Click(object sender, EventArgs e)
        {
            DialogResult resultado = ofdCaixaProcuraArquivo.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                txtNomeArquivo.Text = ofdCaixaProcuraArquivo.FileName;
            }
            else
            {

            }
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {

        }
    }
}
