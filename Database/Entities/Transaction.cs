using Data_access.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_manager
{
    public class Transaction : IEntity
    {
        public int Id { get; set; }
        public int Sum { get; set; }
        public bool IsCrediting { get; set; }
        public DateTime DateTime { get; set; } 
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

}