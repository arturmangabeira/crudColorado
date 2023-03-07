using application.interfaces;
using persistence.interfaces;

using domain;
using application.models;

using AutoMapper;
using System.Collections.Generic;

namespace application;

public class ClienteAppService : IClienteAppService
{

    private readonly IClientePersistence _clientePersistence;
    private readonly IMapper _mapper;
    public ClienteAppService(IClientePersistence clientePersistence, 
                             IMapper mapper)
    {
        _clientePersistence = clientePersistence;
        _mapper = mapper;
    }

    public IEnumerable<ClienteModel> ObterClientePorFiltro(string nome)
    {
        return _mapper.Map<IEnumerable<ClienteModel>>(_clientePersistence.ObterCliente(nome));
    }

    public IEnumerable<ClienteModel> ObterTodosCliente()
    {
        return _mapper.Map<IEnumerable<ClienteModel>>(_clientePersistence.GetAll());
    }

    public ClienteModel ObterClientePorCodigoCliente(int CodigoCliente)
    {
        return _mapper.Map<ClienteModel>(_clientePersistence.GetById(CodigoCliente));
    } 

    public bool InserirCliente(ClienteModel clienteModel)
    {
        var cliente = _mapper.Map<Cliente>(clienteModel);

        cliente.DataInsercao = DateTime.Now;

        var retorno = _clientePersistence.Find(x => x.Nome.Contains(cliente.Nome)).FirstOrDefault();

        if(retorno != null)
            throw new Exception("O cliente existe na base de dados!");            
        
        _clientePersistence.Add(cliente);

        _clientePersistence.SaveChanges();

        return true;
    }

    public bool AtualizarCliente(ClienteModel clienteModel)
    {
        var cliente = _mapper.Map<Cliente>(clienteModel);

        cliente.DataInsercao = DateTime.Now;

        var clienteUpdate = _clientePersistence.Find(c => c.CodigoCliente == cliente.CodigoCliente);

        if(clienteUpdate == null)
            throw new Exception("O cliente não existe na base para atualizar!");

        _clientePersistence.Update(cliente);

        _clientePersistence.SaveChanges();

        return true;
    }

    public bool ExcluirCliente(int CodCliente)
    {
        var cliente = _clientePersistence.GetById(CodCliente);

        if(cliente == null)
            throw new Exception("O cliente não existe na base para excluir!");

        _clientePersistence.Remove(cliente);

        _clientePersistence.SaveChanges();

        return true;
    }
}

