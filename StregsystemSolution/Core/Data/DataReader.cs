using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace StregsystemSolution.Data
{
    public class DataReader : IDataReader
    {
        private void SetupReader(TextFieldParser parser, string delimiter)
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(delimiter);
            parser.ReadFields();
        }
        
        public List<User> GetUsers()
        {
            List<User> userList = new List<User>();

            using (TextFieldParser parser = new TextFieldParser("../../../../users.csv"))
            {
                SetupReader(parser, ",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (fields != null)
                    {
                        int userID = Convert.ToInt32(fields[0]);
                        string firstName = fields[1];
                        string lastName = fields[2];
                        string username = fields[3];
                        decimal balance = Convert.ToDecimal(fields[4]);
                        string email = fields[5];
                        
                        userList.Add(new User(userID, firstName, lastName, username, email, balance));
                    }
                    else
                    {
                        throw new Exception("Datafile fields is null");
                    }
                }
            }
            return userList;
        }

        public List<Product> GetProducts()
        {
            List<Product> productList = new List<Product>();
            using (TextFieldParser parser = new TextFieldParser("../../../../products.csv"))
            {
                SetupReader(parser, ";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (fields != null)
                    {
                        int productID = Convert.ToInt32(fields[0]);
                        string productName = Regex.Replace(fields[1], "<[^>]*>", String.Empty);
                        decimal price = Convert.ToDecimal(fields[2]);
                        bool active = Convert.ToBoolean(Convert.ToInt32(fields[3]));

                        if (fields[4] != "")
                        {
                            productList.Add(new ProductSeasonal(productID, productName, price, DateTime.Now < DateTime.Parse(fields[4]),
                                DateTime.Now, DateTime.Parse(fields[4])));
                        }
                        else
                        {
                            productList.Add(new Product(productID, productName, price, active));
                        }
                    }
                    else
                    {
                        throw new Exception("Datafile fields is null");
                    }
                }
            }

            return productList;
        }
    }
}