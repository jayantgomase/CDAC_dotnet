﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookMVC.Models;

public partial class BookMvcContext : DbContext
{
    public BookMvcContext()
    {
    }

    public BookMvcContext(DbContextOptions<BookMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookMVC;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__3DE0C2072421F110");

            entity.Property(e => e.BookId).ValueGeneratedNever();
            entity.Property(e => e.BookAuthor)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.BookName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.BookPrice).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
