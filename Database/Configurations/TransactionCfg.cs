using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_manager
{
    public class TransactionCfg : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Sum).IsRequired();
            builder.Property(x => x.IsCrediting).IsRequired();
            builder.Property(x => x.DateTime).IsRequired();
            
            builder.HasOne(x => x.Category)
                    .WithMany(x => x.Transactions)
                    .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.User)
                    .WithMany(x => x.Transactions)
                    .HasForeignKey(x => x.UserId);

            builder.HasData(new Transaction[]
            {
                new Transaction() { Id = 1, IsCrediting = true, CategoryId = 1, DateTime = DateTime.Now, Sum = 5000, UserId = 1 },
                new Transaction() { Id = 2, IsCrediting = false, CategoryId = 5, DateTime = DateTime.Now, Sum = 15000, UserId = 2 },
            });
        }
    }
}