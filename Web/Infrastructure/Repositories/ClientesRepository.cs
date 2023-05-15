using Web.Infrastructure;
using Web.Models;

namespace Web.Infrastructure.Repositories
{
    public sealed class ClientesRepository
    {
        private readonly CursoMicroContext _context;

        private ClientesRepository(CursoMicroContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Cliente> GetClientes()
        {
            return _context.Clientes.ToList();
        }
    }
}
