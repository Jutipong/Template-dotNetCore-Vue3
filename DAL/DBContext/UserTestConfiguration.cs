﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using DAL.Entity;

namespace DAL.DBContext
{
    public class UserTestConfiguration : IEntityTypeConfiguration<UserTest>
    {
        public void Configure(EntityTypeBuilder<UserTest> entity)
        {
            entity.Property(e => e.ID).HasDefaultValueSql("(newsequentialid())");

            entity.Property(e => e.IsActive)
                .IsUnicode(false)
                .IsFixedLength();
        }
    }
}
