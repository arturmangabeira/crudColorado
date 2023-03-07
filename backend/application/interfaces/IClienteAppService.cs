using System.Collections.Generic;
using application.models;
using domain;

namespace application.interfaces;

public interface IClienteAppService
{
    IEnumerable<ClienteModel> ObterClientePorFiltro(string nome);

    IEnumerable<ClienteModel> ObterTodosCliente(); 

    ClienteModel ObterClientePorCodigoCliente(int CodigoCliente);

    bool InserirCliente(ClienteModel cliente);

    bool AtualizarCliente(ClienteModel cliente);

    bool ExcluirCliente(int CodCliente);
}
