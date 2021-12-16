﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(t => t.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(t => t.LastName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(t => t.DateOfBirth)
                .IsRequired();
        }
    }
}