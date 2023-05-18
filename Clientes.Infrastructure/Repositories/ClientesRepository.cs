using Clientes.Infrastructure.Entities;

namespace Clientes.Infrastructure.Repositories
{
    public sealed class ClientesRepository
    {
        private readonly ClienteDbContext _context;

        private ClientesRepository(ClienteDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Cliente> GetClientes()
        {
            return _context.Clientes.ToList();
        }

        public Cliente FindById(int id)
        {
            return _context.Clientes.SingleOrDefault(x => x.Id == id);
        }

        public Cliente Add(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }

        public Cliente Update(Cliente cliente)
        {
            _context.Update(cliente);

            return cliente;
        }

        public Cliente Delete(Cliente cliente)
        {
            _context.Remove(cliente);

            return cliente;
        }
    }
}
