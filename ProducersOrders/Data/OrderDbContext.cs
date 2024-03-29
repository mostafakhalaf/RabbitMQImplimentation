﻿using Microsoft.EntityFrameworkCore;

namespace ProducersOrders.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }

       
    }
}
