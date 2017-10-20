using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ASF.Entities;


namespace ASF.Data
{
    public class ClientDAC : DataAccessComponent
    {
        public List<Client> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [Email], [CountryId], [AspNetUsers], [City], [SignupDate], [Rowid], [OrderCount], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Client ";

            var result = new List<Client>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var client = LoadClient(dr); // Mapper
                        result.Add(client);
                    }
                }
            }

            return result;
        }
        private static Client LoadClient(IDataReader dr)
        {
            var client = new Client
            {
                Id = GetDataValue<int>(dr, "Id"),
                FirstName = GetDataValue<string>(dr, "FirstName"),
                LastName = GetDataValue<string>(dr, "LastName"),
                Email = GetDataValue<string>(dr, "Email"),
                CountryId = GetDataValue<int>(dr, "CountryId"),
                AspNetUsers = GetDataValue<string>(dr, "AspNetUsers"),
                City = GetDataValue<string>(dr, "City"),
                SignupDate = GetDataValue<DateTime>(dr, "SignupDate"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                OrderCount = GetDataValue<int>(dr, "OrderCount"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return client;
        }
    }
}
