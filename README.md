<body>
<h1 align="center">FastBox - Sistema de Gestão Automotiva</h1>

<p align="center">
<img src="https://github.com/user-attachments/assets/4e03ab5c-3cdc-4476-8e3f-522f92498c55"/>
</p>

<h3>FastBox é um projeto que foi desenhado para tornar a administração de clientes, veículos, serviços e orçamentos mais eficiente e prática.</h3>

<hr>

<h4>Estrutura do Projeto FastBox</h4>
<h5>
<ul>
    <li>1. FastBox.UI (Camada de Apresentação)</li>
    <br>
    <ul>
        <p>A UI (User Interface) é a camada responsável pela interação com o usuário. Ela utiliza Windows Forms para fornecer uma interface gráfica funcional e amigável.</p>
<p>Funcionalidades Implementadas:</p>

<li>Gerenciamento de Clientes (CRUD):</li>
<ul>
<li>Cadastro, edição, exclusão e listagem paginada de clientes.</li>
<li>Filtragem por nome, NIF (CPF/CNPJ), telefone, e-mail, data de cadastro e outros parâmetros.</li>
</ul>
<br>
<li>Gerenciamento de Veículos:</li>
<ul>
<li>Cadastro, edição, exclusão e listagem paginada de veículos associados a clientes.</li>
<li>Filtragem por marca, modelo, ano, cliente, matrícula e observações.</li>
<br>
</ul>
<li>Gerenciamento de Fornecedores:</li>
<ul>
<li>Cadastro, edição, exclusão e listagem paginada de fornecedores.</li>
<li>Filtragem por nome, email, telemóvel, peças e endereço.</li>
<li>Peças de um orçamento são associadas a um fornecedor.</li>
<br>
</ul>
<li>Gerenciamento de Ordens de Serviço (OS):</li>
<ul>
    <li>Criação, atualização e finalização de ordens de serviço.</li>
    <li>Associar orçamentos com status dinâmico: pendente, aprovado, reprovado.</li>
    <li>Cálculo automático do Valor Total da OS com base em orçamentos aprovados.</li>
    <li>Cálculo automático do IVA da OS com base no valor total.</li>
    <li>Filtros e paginação em todas as listagens para melhor performance.</li>
    <li>Exportação de orçamentos em PDF para envio a clientes.</li>
    <li>Geração de relatório customizados. (a ser implementado)</li>
    <li>Validação de entrada lógica implementada nos formulários.</li>
    <li>Feedbacks de operações ao usuário com MessageBox.</li>
    <li>Pagamentos para ordens de serviço, conclusão apenas após pagamento total do valor devido.</li>
</ul>
<br>
Principais Telas:
<ul>
<li>FormClientes: Gerenciamento de clientes.</li>
<li>FormVeiculos: Gerenciamento de veículos.</li>
<li>FormOrdensDeServico: Gerenciamento das ordens de serviço.</li>
<li>FormFornecedores: Gerenciamento de fornecedores.</li>
<li>FormCadastrarOrdem e FormAtualizarOrdem: Cadastro e edição de ordens.</li>
</ul>
</ul>
<table>
    <tr>
        <td>
        <img src="https://github.com/user-attachments/assets/a91236f1-67a6-4241-8b1c-4120b2a8870b"/>
        </td>
        <td>
        <img src="https://github.com/user-attachments/assets/1e6b4040-ccd8-40d3-9182-2fa51bbf8870"/>       
        </td>
        <td>
        <img src="https://github.com/user-attachments/assets/6cc8b919-eb93-4f4b-869b-adcf9df72185"/>            
        </td>
    </tr>
    <tr>
        <td>
        <img src="https://github.com/user-attachments/assets/d481d863-6f0a-49ed-8078-7c2cfc861d3c"/>
        </td>
        <td>
        <img src="https://github.com/user-attachments/assets/8d5a07e0-8c01-424d-9c94-13b42fb8edd6"/>
        </td>
    </tr>
</table>
<br><br>

<li>2. FastBox.BLL (Camada de Lógica de Negócios)</li>
<ul>
    <br><br>
A BLL (Business Logic Layer) contém a lógica de negócio e validação de dados do sistema. Essa camada manipula os DTOs (Data Transfer Objects) e os serviços que conectam a UI com a camada de dados (DAL).
<br><br>
Componentes Principais:<br><br>

<li>DTOs (ViewModels):</li>
<ul>
<li>Representações simplificadas dos dados que a UI consome e envia.</li>
Exemplos:
<ul>
<li>ClienteViewModel</li>
<li>VeiculoViewModel</li>
<li>OrdemDeServicoViewModel</li>
<li>FornecedorViewModel</li>
<li>OrcamentoViewModel</li>
<li>ItemOrcamentoViewModel</li>
</ul>
</ul><br>
<li>Serviços:</li>
<ul>
<li>Interface e implementação para manipulação dos dados.</li>
Exemplo de serviços:
<ul>
<li>IClienteService e ClienteService
<li>IVeiculoService e VeiculoService
<li>IOrdemDeServicoService e OrdemDeServicoService
</ul>
</ul><br>
<li>Regras de Negócio:</li>
<ul>
<li>Validação dos dados antes de enviá-los para a camada DAL.</li>
<li>Cálculo do valor total da ordem de serviço.</li>
<li>Atualização dinâmica do status de ordens e orçamentos.</li>
</ul>
</ul>
<br><br>
<li>3. FastBox.DAL (Camada de Acesso a Dados)</li><br><br>
A DAL (Data Access Layer) contém o modelo de dados e a lógica de persistência utilizando o Entity Framework Core 9.
<br><br>
Componentes Principais:<br><br>
<ul>
<li>Modelos de Dados:</li>
<ul>
<li>Representações das tabelas no banco de dados.</li>
Exemplos:
<ul>
<li>Cliente</li>
<li>Veiculo</li>
<li>OrdemDeServico</li>
<li>Fornecedor</li>
<li>Orcamento</li>
<li>ItemOrcamento</li>
<li>MetodoPagamento</li>
</ul>
</ul>
<br>
<li>DbContext:</li>
<ul>
<li>FastBoxDbContext gerencia o acesso ao banco de dados e inclui os DbSet<T> correspondentes.</li>
Repositórios:
<ul>
<li>Implementação genérica para acesso e manipulação de dados.</li>
<li>Exemplo: IRepository e Repository.</li>
</ul>
</ul>
<li>Migrações:</li>
<ul>
<li>Gerenciamento de mudanças no banco de dados.</li>
<li>Migrations aplicadas através do EF Core CLI.</li>
</ul>
</ul>
</ul>
</h5>
</body>