using System.Collections.Generic;

namespace Core.Data
{
    public interface IDataReader
    {
        public List<User> GetUsers();
        public List<Product> GetProducts();
    }
}