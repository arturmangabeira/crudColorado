namespace webApp.Services.Interfaces;
using Models;

public interface IClienteService
{
    Task<IEnumerable<ClienteModel>> ObterTodos();

    Task<IEnumerable<ClienteModel>> ObterClientePorFiltro(string nome);

    Task<ClienteModel> ObterClientePorCodigoCliente(int nome);

    Task<string> InserirCliente(ClienteModel clienteModel);

    Task<string> AtualizarCliente(ClienteModel clienteModel);

    Task<string> ExcluirCliente(int codigoCliente);
}