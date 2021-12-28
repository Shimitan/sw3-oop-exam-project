using System.Collections.Generic;

namespace StregsystemSolution.Data
{
    public interface IDataReader
    {
        public List<User> GetUsers();
        public List<Product> GetProducts();
    }
}