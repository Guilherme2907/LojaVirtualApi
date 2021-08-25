using Guilherme.LojaVirtualApi.Models.Entities;
using Guilherme.LojaVirtualApi.Models.Entities.Enums;
using Guilherme.LojaVirtualApi.Models.Enums;
using Guilherme.LojaVirtualApi.Repository.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Guilherme.LojaVirtualApi.Repository
{
    public sealed class EFContext : DbContext
    {
        public EFContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderProducts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentWithBillet> PaymentsWithBillet { get; set; }
        public DbSet<PaymentWithCard> PaymentsWithCard { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<User> Users { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureCategory();
            modelBuilder.ConfigureProduct();
            modelBuilder.ConfigureAddress();
            modelBuilder.ConfigureCustomer();
            modelBuilder.ConfigureOrder();
            modelBuilder.ConfigureOrderItem();
            modelBuilder.ConfigureState();
            modelBuilder.ConfigureTelephone();
            modelBuilder.ConfigurePayment();
            modelBuilder.ConfigureCity();
            modelBuilder.ConfigureUser();

            var products = new[]
            {
                 new Product{Id=1, Name="Computador",Price = 2000.00,CreatedDate = DateTime.Now},
                 new Product{Id=2, Name="Impressora",Price = 800.00,CreatedDate = DateTime.Now},
                 new Product{Id=3, Name="Mouse",Price = 80.00,CreatedDate = DateTime.Now}
            };

            var categories = new[]
            {
                 new Category{Id=1, Name= "Informatica",CreatedDate = DateTime.Now},
                 new Category{Id=2, Name= "Escritorio",CreatedDate = DateTime.Now}
            };


            var users = new[]
            {
                 new User{Id=1, Username= "gui123",Password="1234",CreatedDate = DateTime.Now}
            };

            var customers = new[]
            {
                 new Customer{Id = 1,Name = "Maria Silva" , Email = "maria@gmail.com",Cpf = "36378912377",UserId = 1,CustomerType = CustomerType.PHYSICAL_PERSON,CreatedDate = DateTime.Now}
            };

            var orders = new[]
            {
                 new Order{Id=1, Date= new DateTime(2021,7,30),CustomerId = 1,DeliveryAddressId = 1,CreatedDate = DateTime.Now},
                 new Order{Id=2, Date= new DateTime(2021,6,10),CustomerId = 1,DeliveryAddressId = 2,CreatedDate = DateTime.Now}
            };

            var payments = new List<Payment>()
            {
                 new PaymentWithCard{Id = 1,PaymentStatus = PaymentStatus.PAID,Installments = 6,OrderId =1 ,CreatedDate = DateTime.Now},
                 new PaymentWithBillet{Id =2,PaymentStatus = PaymentStatus.PENDING,DueDate = new DateTime(2021,10,20),PayDate = null,OrderId = 2  ,CreatedDate = DateTime.Now},
            };

            var telephones = new[]
            {
                 new Telephone{Id=1,Number= "27363323",CustomerId = 1,CreatedDate = DateTime.Now},
                 new Telephone{Id=2,Number= "27363323",CustomerId = 1,CreatedDate = DateTime.Now}
            };

            var states = new[]
            {
                 new State{Id=1,Name="Minas Gerais",CreatedDate = DateTime.Now},
                 new State{Id=2,Name="São Paulo",CreatedDate = DateTime.Now}
            };

            var cities = new[]
            {
                 new City{Id=1,Name="Uberlândia",StateId = 1,CreatedDate = DateTime.Now},
                 new City{Id=2,Name="São Paulo",StateId = 2,CreatedDate = DateTime.Now},
                 new City{Id=3,Name="Campinas",StateId = 2,CreatedDate = DateTime.Now}
            };

            var addresses = new[]
            {
                 new Address{Id=1,Street = "Rua das Flores",Number = "300",Complement = "Apto 203",Block = "Jardim",ZipCode = "382220834",CustomerId = 1,CityId = 1,CreatedDate = DateTime.Now},
                 new Address{Id=2,Street = "Avenida Matos",Number = "105",Complement = "Sala 800",Block = "Centro",ZipCode = "38777012",CustomerId = 1,CityId = 2,CreatedDate = DateTime.Now}
            };


            var orderProducts = new[]
            {
                 new OrderItem{OrderId = 1 , ProductId = 1,Discount = 0,Quantity=1,Price = 2000.00},
                 new OrderItem{OrderId = 1 , ProductId = 3,Discount = 0,Quantity=2,Price = 80.00 },
                 new OrderItem{OrderId = 2 , ProductId = 2,Discount = 0,Quantity=1,Price = 800.00 }
            };



            modelBuilder.Entity<Product>().HasData(products[0], products[1], products[2]);
            modelBuilder.Entity<Category>().HasData(categories[0], categories[1]);
            modelBuilder.Entity<User>().HasData(users[0]);
            modelBuilder.Entity<Customer>().HasData(customers[0]);
            modelBuilder.Entity<Order>().HasData(orders[0], orders[1]);
            modelBuilder.Entity<OrderItem>().HasData(orderProducts[0], orderProducts[1], orderProducts[2]);
            modelBuilder.Entity<PaymentWithCard>().HasData(payments[0]);
            modelBuilder.Entity<PaymentWithBillet>().HasData(payments[1]);
            modelBuilder.Entity<State>().HasData(states[0], states[1]);
            modelBuilder.Entity<City>().HasData(cities[0], cities[1], cities[2]);
            modelBuilder.Entity<Address>().HasData(addresses[0], addresses[1]);
            modelBuilder.Entity<Telephone>().HasData(telephones[0], telephones[1]);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
