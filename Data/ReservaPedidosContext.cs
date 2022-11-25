using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservaPedidos.ClientAPI;

namespace ReservaPedidos.Data
{
    public class ReservaPedidosContext : DbContext
    {
        public ReservaPedidosContext (DbContextOptions<ReservaPedidosContext> options)
            : base(options)
        {
        }

        public DbSet<ReservaPedidos.ClientAPI.Client> Client { get; set; } = default!;
    }
}
