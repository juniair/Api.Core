using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RestApi.Core.Extensions.Entity
{
    public static class EntityExtension
    {
        public static ModelBuilder PropertyConverter<TEntity, TValue>(this ModelBuilder modelBuilder, Expression<Func<TEntity, TValue>> expression, ValueConverter converter) where TEntity : class
        {
            modelBuilder.Entity<TEntity>()
                .Property(expression)
                .HasConversion(converter);

            return modelBuilder;
        }
    }
}
