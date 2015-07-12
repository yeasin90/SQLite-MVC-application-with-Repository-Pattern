using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using CriminalSearch.Repository.Entity;
using CriminalSearch.Repository.CustomException;
using CriminalSearch.Utility;


namespace CriminalSearch.Repository.Repository
{
    public class CriminalRepository : ICriminalRepository
    {
        private readonly SqLiteHelper _sqliteHelper;
        private readonly InputValidator _inputValidtor;

        public CriminalRepository(InputValidator inputValidtor, SqLiteHelper sqliteHelper)
        {
            _sqliteHelper = sqliteHelper;
            _inputValidtor = inputValidtor;
        }

        public void Insert(Criminal entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Criminal entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Criminal entity)
        {
            throw new NotImplementedException();
        }

        public IList<Criminal> GetAll()
        {
            List<Criminal> result = new List<Criminal>();
            SQLiteConnection con;
            SQLiteDataReader reader = _sqliteHelper.ExecuteCommand("Select * FROM Criminal", out con);

            while (reader.Read())
            {
                result.Add(new Criminal
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Age = Convert.ToInt32(reader["Age"]),
                    Sex = (Gender)Convert.ToInt32(reader["Sex"]),
                    Height = Convert.ToDouble(reader["Height"]),
                    Nationality = reader["Nationality"].ToString()
                });
            }

            con.Close();
            return result;
        }

        public IList<Criminal> GetCriminalsByType(SearchType type, CriminalSearchItem searchItem)
        {
            List<Criminal> records = GetAll().ToList();
            List<Criminal> results;

            switch (type)
            {
                case SearchType.Age:
                    {
                        if (!_inputValidtor.IsValidRange(searchItem.From, searchItem.To))
                            throw new CriminalSearchException("Invalid age range");

                        results = records.Where(x => x.Age >= searchItem.From && x.Age <= searchItem.To).ToList();
                        break;
                    }
                case SearchType.Height:
                    {
                        if (!_inputValidtor.IsValidRange(searchItem.From, searchItem.To))
                            throw new CriminalSearchException("Invalid height range");

                        results = records.Where(x => x.Height >= searchItem.From && x.Height <= searchItem.To).ToList();
                        break;
                    }
                case SearchType.Name:
                    {
                        if (string.IsNullOrWhiteSpace(searchItem.SingleInput) || !_inputValidtor.IsAlphaNumeric(searchItem.SingleInput))
                            throw new CriminalSearchException("Invalid Name");

                        results = records.Where(x => x.Name.ToLower().Contains(searchItem.SingleInput.ToLower())).ToList();
                        break;
                    }
                case SearchType.Nationality:
                    {
                        if (string.IsNullOrWhiteSpace(searchItem.SingleInput) || !_inputValidtor.IsAlphaNumeric(searchItem.SingleInput))
                            throw new CriminalSearchException("Invalid Nationality");

                        results = records.Where(x => x.Nationality.ToLower().Contains(searchItem.SingleInput.ToLower())).ToList();
                        break;
                    }
                case SearchType.Sex:
                    {
                        results = records.Where(x => x.Sex == searchItem.Sex).ToList();
                        break;
                    }
                default:
                    {
                        results = new List<Criminal>();
                        break;
                    }
            }

            return results;
        }


        public Criminal Get(int id)
        {
            Criminal result = null;
            SQLiteConnection con;
            SQLiteDataReader reader = _sqliteHelper.ExecuteCommand("Select * FROM Criminal where ID='" + id + "'", out con);
            while (reader.Read())
            {
                result = new Criminal
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Age = Convert.ToInt32(reader["Age"]),
                    Sex = (Gender)Convert.ToInt32(reader["Sex"]),
                    Height = Convert.ToDouble(reader["Height"]),
                    Nationality = reader["Nationality"].ToString()
                };
            }
            con.Close();
            return result;
        }
    }
}
