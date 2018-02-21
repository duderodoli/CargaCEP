using CargaCEP.Dominio.Processo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace CargaCEP.Forms
{
    public partial class FormularioImportacaoArquivo : Form
    {

        private readonly ICargaCepProcesso _cargaCepProcesso;
        private List<String> mensagem = new List<String>();
        private String arquivo = "";        

        public FormularioImportacaoArquivo()
        {
            InitializeComponent();
            _cargaCepProcesso = IoC.IoCIniciar.ObterInstancia<ICargaCepProcesso>();
            backgroundWorker1.WorkerReportsProgress = true;            
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;

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
                arquivo = txtNomeArquivo.Text;
            }
            else
            {

            }
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {            

            if (backgroundWorker1.IsBusy != true)
            {
                listBoxErros.Items.Clear();
                listBoxErros.Show();
                btnProcessar.Enabled = false;
                backgroundWorker1.RunWorkerAsync();               
            }
            
        }
       
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;            
            atualizarListBox();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //exibe a menssagem de sucesso, ou qualquer outra coisa que queira fazer.            
            btnProcessar.Enabled = true;
        }

        private void txtNomeArquivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void atualizarListBox()
        {
            listBoxErros.Items.Clear();
            foreach(String erro in mensagem)
            {
                listBoxErros.Items.Add(erro);
            }
                       
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _cargaCepProcesso.ExecutarSincronizacaoCep(arquivo, mensagem, backgroundWorker1);
        }
        
    }
}
