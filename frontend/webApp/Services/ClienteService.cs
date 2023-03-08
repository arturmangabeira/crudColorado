namespace webApp.Services;
using Models;
using Services.Interfaces;
using webApp.Helpers;

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
}