using CargaCEP.Dominio.Processo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CargaCEP.Forms
{
    public partial class FormularioImportacaoArquivo : Form
    {

        private readonly ICargaCepProcesso _cargaCepProcesso;

        public FormularioImportacaoArquivo()
        {
            InitializeComponent();
            _cargaCepProcesso = IoC.IoCIniciar.ObterInstancia<ICargaCepProcesso>();
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
            listBoxErros.Items.Clear();
            if (string.IsNullOrWhiteSpace(txtNomeArquivo.Text))
            {
                MessageBox.Show("Preencha o caminho do arquivo.");
            }
            else
            {
                String mensagemErro = _cargaCepProcesso.ExecutarSincronizacaoCep(txtNomeArquivo.Text);
                if (!string.IsNullOrWhiteSpace(mensagemErro))
                {
                    var erros = mensagemErro.Split(new[] { '\r', '\n' });
                    foreach (String erro in erros)
                    {
                        listBoxErros.Items.Add(erro);
                    }
                    listBoxErros.Show();
                }
                else
                {
                    MessageBox.Show("A OPERAÇÃO FOI UM SUCESSO!");
                }
                
                
            }
        }

        private void txtNomeArquivo_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
