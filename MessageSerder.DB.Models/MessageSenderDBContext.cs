using MessageSerder.DB.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MessageSerder.DB.Models
{
    public class MessageSenderDBContext : DbContext
    {
        public DbSet<Message> Blogs { get; set; }
        public DbSet<SentMessage> Posts { get; set; }

        public string DbPath { get; }

        public MessageSenderDBContext(DbContextOptions<MessageSenderDBContext> options) : base(options)
        {
        }
        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=PERSONAL\\SQLSERVER;Initial Catalog=MessageSender;Integrated Security=True;Encrypt=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<SentMessage>().ToTable("SentMessage");
        }
    }
}
