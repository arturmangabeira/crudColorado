namespace webApp.Services;
using Models;
using Services.Interfaces;
using webApp.Helpers;
using webApp.Configurations;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Options;

public class ClienteService : BaseHttpClientService<ClienteModel>, IClienteService
{
    private readonly HttpClient _client;        
    public ClienteService(HttpClient client, IConfiguration configuration): base(client, configuration)
    {
        _client = client;
    }

    public async Task<IEnumerable<ClienteModel>> ObterTodos()
    {
        return await SendGetAll<ClienteModel>("/Cliente/obter-todos-cliente");
    }

    public async Task<IEnumerable<ClienteModel>> ObterClientePorFiltro(string nome)
    {       
        return await SendGetAll<ClienteModel>("/Cliente/obter-cliente-por-filtro?nome=" + nome);
    }

    public async Task<ClienteModel> ObterClientePorCodigoCliente(int codigoCliente)
    {
        return await SendGet<ClienteModel>("/Cliente/obter-cliente-por-codigo-cliente?codigoCliente=" + codigoCliente);     
    }

    public async Task<ClienteModel> InserirCliente(ClienteModel clienteModel)
    {        
       return await SendPost<ClienteModel>("/Cliente/inserir-cliente", clienteModel);     
    }

    public async Task<ClienteModel> AtualizarCliente(ClienteModel clienteModel)
    {        
       return await SendPut<ClienteModel>("/Cliente/atualizar-cliente", clienteModel);
    }

    public async Task<ClienteModel> ExcluirCliente(int codigoCliente)
    {
       return await SendDelete<ClienteModel>("/Cliente/excluir-cliente?codigoCliente=" + codigoCliente);
    }
}