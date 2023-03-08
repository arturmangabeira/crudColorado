namespace webApp.Services.Interfaces;
using Models;

public interface IClienteService
{
    Task<IEnumerable<ClienteModel>> ObterTodos();

    Task<IEnumerable<ClienteModel>> ObterClientePorFiltro(string nome);
}