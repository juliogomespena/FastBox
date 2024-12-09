using FastBox.BLL.Services.Interfaces;
using FastBox.UI.Forms;
using FastBox.UI.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace FastBox.UI
{
    public partial class FormDashboard : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public FormDashboard(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            if (!Session.ActiveSession())
            {
                MessageBox.Show("Sessão expirada. Por favor, faça login novamente.", "Sessão Expirada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            else
                this.Show();

            var frmSummary = _serviceProvider.GetRequiredService<FormSummary>();
            LoadFormInContainer(frmSummary);
        }

        private void FormDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Session.ActiveSession())
                Application.Exit();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            LblBemVindo.Text = $"Seja bem vindo {Session.Username}!";
            DataHora.Start();
        }

        private void DataHora_Tick(object sender, EventArgs e)
        {
            LblDataHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Session.Terminate();
            var frmLogin = _serviceProvider.GetRequiredService<FormLogin>();
            frmLogin.Show();
            this.Close();
        }

        private void LoadFormInContainer(Form form)
        {
            PanelMain.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            PanelMain.Controls.Add(form);
            PanelMain.Tag = form;
            form.Show();
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            var frmClientes = _serviceProvider.GetRequiredService<FormClientes>();
            LoadFormInContainer(frmClientes);
        }

        private void PicBoxLogo_Click(object sender, EventArgs e)
        {
            var frmSummary = _serviceProvider.GetRequiredService<FormSummary>();
            LoadFormInContainer(frmSummary);
        }
    }
}
