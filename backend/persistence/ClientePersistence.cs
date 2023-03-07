using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using domain;

namespace persistence;

public class ClientePersistence : Repository<Cliente>, interfaces.IClientePersistence
{

    public ClientePersistence(AppDbContext context) : base(context)
    {
        
    }
    public IEnumerable<Cliente> ObterCliente(string nome)
    {
        return _context.Clientes.AsNoTracking().Where(c => EF.Functions.Like(c.Nome, $"%{nome}%")).ToList();
    }    
}