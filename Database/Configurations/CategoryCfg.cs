using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_manager
{
    public class CategoryCfg : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();

            builder.HasData(new Category[]
            {
                new Category { Id = 1, Name = "Food" },
                new Category { Id = 2, Name = "Hygiene" },
                new Category { Id = 3, Name = "Home" },
                new Category { Id = 4, Name = "Communication" },
                new Category { Id = 5, Name = "Health" },
                new Category { Id = 6, Name = "Cafe" },
                new Category { Id = 7, Name = "Car" },
                new Category { Id = 8, Name = "Cloth" },
                new Category { Id = 9, Name = "Surprises" },
                new Category { Id = 10, Name = "Accounts" },
                new Category { Id = 11, Name = "Entertainment" },
                new Category { Id = 12, Name = "Sport" },
                new Category { Id = 13, Name = "Taxi" },
                new Category { Id = 14, Name = "Transport" },
                new Category { Id = 15, Name = "Pets" }
            });
        }
    }
}