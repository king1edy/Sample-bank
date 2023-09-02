using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBankApp.Domain;

namespace SampleBankApp.Core.Repository
{
    public interface IRepository<T> where T : class
    {
        public T GetById(Guid id);
        public List<T> GetAll();
        public T Save(T entity);
    }
}
