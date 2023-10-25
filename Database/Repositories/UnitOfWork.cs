using Finance_manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access.Repositories
{
    public interface IUoW
    {
        Repository<Category> CategoryRepo { get; }
        Repository<User> UserRepo { get; }
        Repository<Transaction> TransactionRepo { get; }

        void Save();
    }

    public class UnitOfWork : IUoW, IDisposable
    {
        private static FinanceManagerDbContext context = new FinanceManagerDbContext();

        private Repository<User> userRepo;
        private Repository<Transaction> transactionRepo;
        private Repository<Category> categoryRepo;

        public Repository<User> UserRepo
        {
            get
            {
                if(this.userRepo == null)
                {
                    this.userRepo = new(context);
                }
                return userRepo;
            }
        }

        public Repository<Transaction> TransactionRepo
        {
            get
            {
                if(this.transactionRepo == null)
                {
                    this.transactionRepo = new(context);
                }
                return transactionRepo;
            }
        }

        public Repository<Category> CategoryRepo
        {
            get
            {
                if(this.categoryRepo == null)
                {
                    this.categoryRepo = new(context);
                }
                return categoryRepo;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}