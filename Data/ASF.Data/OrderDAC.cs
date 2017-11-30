using ASF.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Data
{
    public class OrderDAC : DataAccessComponent
    {
        public List<Order> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [ClientId], [OrderDate], [TotalPrice], [State], [OrderNumber], [ItemCount], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM [Order] ";

            var result = new List<Order>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
         
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var order = LoadOrder(dr); // Mapper
                        result.Add(order);
                    }
                }
            }

            return result;
        }

        public Order Create(Order Order)
        {
            const string sqlStatement = "INSERT INTO [Order] ([ClientId], [OrderDate], [TotalPrice], [State], [OrderNumber], [ItemCount], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@ClientId, @OrderDate, @TotalPrice, @State, @OrderNumber, @ItemCount, @Rowid, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@ClientId", DbType.Int32, Order.ClientId);
                db.AddInParameter(cmd, "@OrderDate", DbType.DateTime2, Order.OrderDate);
                db.AddInParameter(cmd, "@TotalPrice", DbType.Double, Order.TotalPrice);
                db.AddInParameter(cmd, "@State", DbType.Int32, Order.State);
                db.AddInParameter(cmd, "@OrderNumber", DbType.Int32, Order.OrderNumber);
                db.AddInParameter(cmd, "@ItemCount", DbType.Int32, Order.ItemCount);
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, Order.Rowid);
                //db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, Order.CreatedOn);
                //db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, Order.CreatedBy);
                //db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, Order.ChangedOn);
                //db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, Order.ChangedBy);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, DateTime.Now);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, 1);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, DateTime.Now);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, 1);


                // Obtener el valor de la primary key.
                Order.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return Order;
        }

        private static Order LoadOrder(IDataReader dr)
        {
            var order = new Order
            {
                Id = GetDataValue<int>(dr, "Id"),
                ClientId = GetDataValue<int>(dr, "ClientId"),
                OrderDate = GetDataValue<DateTime>(dr, "OrderDate"),
                TotalPrice = GetDataValue<double>(dr, "TotalPrice"),
                State = GetDataValue<int>(dr, "State"),
                OrderNumber = GetDataValue<int>(dr, "OrderNumber"),
                ItemCount = GetDataValue<int>(dr, "ItemCount"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return order;
        }
    }
}