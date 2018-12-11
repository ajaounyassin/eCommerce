﻿using Microsoft.EntityFrameworkCore;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ECommerceDbContext : DbContext
    {
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public ECommerceDbContext()
        {
        }

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext>options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port3306;database=eCommerceDb;uid=root;password=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>().HasOne(u => u.User).WithOne(a => a.Address);

            modelBuilder.Entity<Article>().HasOne(u => u.Vendor).WithMany(a => a.ArticleSale);
            modelBuilder.Entity<Article>().HasOne(t => t.Tax);

            modelBuilder.Entity<Basket>().HasOne(u => u.Buyer);
            modelBuilder.Entity<Basket>().HasMany(u => u.Articles);

            modelBuilder.Entity<Comment>().HasOne(a => a.Article);
            modelBuilder.Entity<Comment>().HasOne(u => u.User);

            modelBuilder.Entity<Order>().HasOne(b => b.Basket);
            modelBuilder.Entity<Order>().HasOne(u => u.Client);
            modelBuilder.Entity<Order>().HasOne(s => s.Status);

            modelBuilder.Entity<User>().HasOne(p => p.Profil);
            modelBuilder.Entity<User>().HasOne(s => s.Sexe);
           // modelBuilder.Entity<User>().HasOne(a => a.Address);



            //RELATION 1..O 1
            //modelBuilder.Entity<User>().HasOptional(s => s.Address).WithRequired(ad => ad.User);

            //modelBuilder.Entity<Article>().HasMany(u => u.ArticleSale).WithOne(ar => ar.Vendor);


            //modelBuilder.Entity<Person>()
            //    .HasMany(bc => bc.DirectedMovies)
            //    .WithOne(x => x.Director)
            //    ;

            //modelBuilder.Entity<Student>()
            //.HasOne<Grade>(s => s.Grade)
            //.WithMany(g => g.Students)
            //.HasForeignKey(s => s.CurrentGradeId);
        }
    }
}
