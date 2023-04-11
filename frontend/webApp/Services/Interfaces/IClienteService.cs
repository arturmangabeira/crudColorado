namespace webApp.Services.Interfaces;
using Models;

public interface IClienteService
{
    Task<IEnumerable<ClienteModel>> ObterTodos();

    Task<IEnumerable<ClienteModel>> ObterClientePorFiltro(string nome);

    Task<ClienteModel> ObterClientePorCodigoCliente(int nome);

    Task<ClienteModel> InserirCliente(ClienteModel clienteModel);

    Task<ClienteModel> AtualizarCliente(ClienteModel clienteModel);

    Task<ClienteModel> ExcluirCliente(int codigoCliente);
}