namespace webApp.Services;
using Models;
using Services.Interfaces;
using webApp.Helpers;
using Newtonsoft.Json;
using System.Text;

public class ClienteService : IClienteService
{

    private readonly HttpClient _client;
    public ClienteService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<ClienteModel>> ObterTodos()
    {
        var response = await _client.GetAsync("/Cliente/obter-todos-cliente");

        return await response.ReadContentAsync<List<ClienteModel>>();
    }

    public async Task<IEnumerable<ClienteModel>> ObterClientePorFiltro(string nome)
    {
        var response = await _client.GetAsync("/Cliente/obter-cliente-por-filtro?nome=" + nome);

        return await response.ReadContentAsync<List<ClienteModel>>();
    }

    public async Task<ClienteModel> ObterClientePorCodigoCliente(int codigoCliente)
    {
        var response = await _client.GetAsync("/Cliente/obter-cliente-por-codigo-cliente?codigoCliente=" + codigoCliente);

        return await response.ReadContentAsync<ClienteModel>();
    }

    public async Task<string> InserirCliente(ClienteModel clienteModel)
    {
        var response = await _client.SendAsync(
            new HttpRequestMessage(HttpMethod.Post,
                                   "/Cliente/inserir-cliente") 
                                   { Content = new StringContent(JsonConvert.SerializeObject(clienteModel), Encoding.UTF8, "application/json") }
        );

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> AtualizarCliente(ClienteModel clienteModel)
    {
        var response = await _client.SendAsync(
            new HttpRequestMessage(HttpMethod.Put,
                                   "/Cliente/atualizar-cliente") { Content = new StringContent(JsonConvert.SerializeObject(clienteModel), Encoding.UTF8, "application/json") }
        );

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> ExcluirCliente(int codigoCliente)
    {
        var response = await _client.SendAsync(
            new HttpRequestMessage(HttpMethod.Delete,
                                   "/Cliente/excluir-cliente?codigoCliente=" + codigoCliente)
        );

        return await response.Content.ReadAsStringAsync();
    }
}