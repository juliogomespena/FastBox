using FastBox.BLL.Services.Interfaces;

namespace FastBox.UI.Forms;

public partial class FormClientes : Form
{
    private readonly IClienteService _clienteService;
    private int currentPage = 1;
    private int pageSize = 10;
    public FormClientes(IClienteService clienteService)
    {
        InitializeComponent();
        _clienteService = clienteService;
    }

    private async void FormClientes_Load(object sender, EventArgs e)
    {
        await LoadClientsIntoDgvAsync(1, pageSize);
    }

    private async Task LoadClientsIntoDgvAsync(int page, int size)
    {
        var clientes = await _clienteService.GetClientsInPagesAsync(page, size);
        DgvClientes.DataSource = clientes;
        DgvClientes.Columns.Remove("EnderecoId");
        DgvClientes.Columns.Remove("Endereco");
        DgvClientes.Columns.Remove("OrdemDeServicos");
        DgvClientes.Columns.Remove("Usuarios");
        DgvClientes.Columns.Remove("Veiculos");
        DgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        DgvClientes.Columns["DataCadastro"].HeaderText = "Data de cadastro";
    }

    private async void BtnNextPage_Click(object sender, EventArgs e)
    {
        currentPage++;
        await LoadClientsIntoDgvAsync(currentPage, pageSize);
    }

    private async void BtnPreviousPage_Click(object sender, EventArgs e)
    {
        if (currentPage > 1)
        {
            currentPage--;
            await LoadClientsIntoDgvAsync(currentPage, pageSize);
        }
    }
}
