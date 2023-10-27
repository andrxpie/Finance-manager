using Data_access.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_manager
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}