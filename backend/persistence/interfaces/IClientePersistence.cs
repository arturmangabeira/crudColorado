using domain;

namespace persistence.interfaces
{
    public interface IClientePersistence : IRepository<Cliente>
    {
        IEnumerable<Cliente> ObterCliente(string nome);        
    }
}