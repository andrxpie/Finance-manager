using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_manager
{
    public class UserCfg : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Login).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Balance).IsRequired();
            builder.Property(x => x.Email).IsRequired();
    
            builder.HasMany(x => x.Categories).WithMany(x => x.Users);

            builder.HasData(new User[]
            {
                new User() { Id = 1, Login = "amdin", Password = "$2a$11$SE5dN37YdLiwcmWIgRwfpOxuvhMjD8xlBW08z9J58WaaLFzFgb6yW", Balance = 15000, Email = "admin@finance.manager" },
                new User() { Id = 2, Login = "123", Password = "$2a$11$xaLu5fQiWJ3feYZ40ndy3O1YI9pnG5G6g8lgxfvL8iFmF27hVlIyy", Balance = 15000, Email = "admin@finance.manager" }
            });
        }
    }
}