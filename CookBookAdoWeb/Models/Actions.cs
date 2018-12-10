using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CookBookAdoWeb.Models
{
    public class Actions
    {
        private readonly string strConnect;

        public Actions()
        {
            strConnect = ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString;
        }

        #region Unit
        //список всех единиц измерения
        public List<Unit> getAllUnit()
        {
            string sqlExpr = "SELECT * FROM Unit ORDER BY Name_Unit";

            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExpr, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                List<Unit> allUnit = (from r in ds.Tables[0].AsEnumerable()
                                             select new Unit()
                                             {
                                                 IdUnit = r.Field<int>("ID_Unit"),
                                                 NameUnit = r.Field<string>("Name_Unit")
                                             })
                                          .ToList();
                return allUnit;
            }
        }

        public int addUnit(string nameUnit)
        {
            try
            {
                string sqlExpr = String.Format("INSERT INTO Unit (Name_Unit) VALUES ('{0}')", nameUnit);
                SqlConnection connection = new SqlConnection(strConnect);
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpr, connection);
                int number = command.ExecuteNonQuery();

                return number;
            }
            catch (Exception ex) { }

            return -1;
        }

        public void deleteUnit(int id)
        {
            string sqlExpr = String.Format("DELETE FROM Unit WHERE ID_Unit = {0}", id);

            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpr, connection);
                int number = command.ExecuteNonQuery();
            }
        }

        public Unit getUnit(int id)
        {
            string sqlExpr = String.Format("SELECT * FROM Unit WHERE ID_Unit = {0}", id);
            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExpr, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                Unit allTypes = (from r in ds.Tables[0].AsEnumerable()
                                             select new Unit()
                                             {
                                                 IdUnit = r.Field<int>("ID_Unit"),
                                                 NameUnit = r.Field<string>("Name_Unit")
                                             })
                                             .ToList().FirstOrDefault();
                return allTypes;
            }
        }

        public void updateUnit(int idUnit, string nameUnit)
        {
            string sqlExp = String.Format("UPDATE Unit SET Name_Unit = '{0}' WHERE ID_Unit = {1}", nameUnit, idUnit);

            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExp, connection);
                int number = command.ExecuteNonQuery();
            }
        }

        #endregion


        
        //список всех блюд
        public List<Dish> getAllDishes()
        {
            string sqlExpression = "SELECT ID_Dish, Name_Dish, Price_Dish, TypeOfDish.Name_Type as t FROM Dish INNER JOIN TypeOfDish on TypeOfDish.ID_Type = Dish.ID_TypeDish ORDER BY Name_Dish ";
            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                List<Dish> allDishes = (from r in ds.Tables[0].AsEnumerable()
                                          select new Dish() {
                                              Id = r.Field<int>("ID_Dish"),
                                              Name = r.Field<string>("Name_Dish"),
                                              Price = r.Field<Decimal>("Price_Dish"),
                                              TypeOfDish = r.Field<string>("t"),

                                          }).ToList();
                return allDishes;
            }
        }

        public void addDish(string name, Decimal price, string typeOfDish)
        {
            string sqlExpression = "sp_GetDish";

            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // параметр для ввода имени
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name
                };
                // добавляем параметр
                command.Parameters.Add(nameParam);
                // параметр для ввода возраста
                SqlParameter priceParam = new SqlParameter
                {
                    ParameterName = "@price",
                    Value = price
                };
                command.Parameters.Add(priceParam);

                SqlParameter typeOfDishParam = new SqlParameter
                {
                    ParameterName = "@typeOfDish",
                    Value = typeOfDish
                };
                command.Parameters.Add(typeOfDishParam);

                var result = command.ExecuteScalar();
                // если нам не надо возвращать id
                //try
                //{
                //    var result = command.ExecuteNonQuery();
                //}
                //catch (Exception ex) { }
            }
        }

        public void deleteDish(int id)
        {
            string sqlExpr = String.Format("DELETE FROM Dish WHERE ID_Dish = {0}", id);

            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpr, connection);
                int number = command.ExecuteNonQuery();
            }
        }

        public Dish getDish(int id)
        {
            string sqlExpr = String.Format("SELECT ID_Dish as id_d, Name_Dish as n, Price_Dish, TypeOfDish.Name_Type as t FROM Dish INNER JOIN TypeOfDish on TypeOfDish.ID_Type=Dish.ID_TypeDish  WHERE ID_Dish = {0}", id);
            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExpr, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                Dish ingr = (from r in ds.Tables[0].AsEnumerable()
                                   select new Dish()
                                   {
                                       Id = r.Field<int>("id_d"),
                                       Name = r.Field<string>("n"),
                                       Price = r.Field<Decimal>("Price_Dish"),
                                       TypeOfDish = r.Field<string>("t")
                                   })
                                 .ToList().FirstOrDefault();
                return ingr;
            }
        }










        #region TypeOfDish
        public List<TypeOfDish> getAllType()
        {
            string sqlExpr = "SELECT * FROM TypeOfDish ORDER BY Name_Type";
            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExpr, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                List<TypeOfDish> allTypes = (from r in ds.Tables[0].AsEnumerable()
                                             select new TypeOfDish()
                                             {
                                                 IdType = r.Field<int>("ID_Type"),
                                                 NameType = r.Field<string>("Name_Type")
                                             })
                                          .ToList();
                return allTypes;
            }
        }

        public void deleteType(int id)
        {
            string sqlExpr = String.Format("DELETE FROM TypeOfDish WHERE ID_Type = {0}", id);

            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpr, connection);
                int number = command.ExecuteNonQuery();
            }
        }
        
        public int addType(string sqlExpr)
        {
            try
            {
                SqlConnection connection = new SqlConnection(strConnect);
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpr, connection);
                int number = command.ExecuteNonQuery();
                
                return number;
            }
            catch (Exception ex) {}

            return -1;
        }

        public TypeOfDish getTypeOfDish(int id)
        {
            string sqlExpr = String.Format("SELECT * FROM TypeOfDish WHERE ID_Type = {0}",id);
            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExpr, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                TypeOfDish allTypes = (from r in ds.Tables[0].AsEnumerable()
                                             select new TypeOfDish()
                                             {
                                                 IdType = r.Field<int>("ID_Type"),
                                                 NameType = r.Field<string>("Name_Type")
                                             })
                                             .ToList().FirstOrDefault();
                return allTypes;
            }
        }

        public void updateType(int idType, string nameType)
        {
            string sqlExp= String.Format("UPDATE TypeOfDish SET Name_Type = '{0}' WHERE ID_Type = {1}", nameType, idType);

            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExp, connection);
                int number = command.ExecuteNonQuery();
            }
        }
        #endregion



        #region Ingredient
        public List<Ingredient> getAllIngr()
        {
            string sqlExpr = "SELECT ID_Ingredient as Id, Name_Ingredient as NameIngr, Price_Dish as Price, Unit.Name_Unit as Unit FROM Ingredients INNER JOIN Unit on Unit.ID_Unit = Ingredients.ID_Unit ORDER BY Name_Ingredient";
            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExpr, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                List<Ingredient> allIngr = (from r in ds.Tables[0].AsEnumerable()
                                             select new Ingredient()
                                             {
                                                 Id = r.Field<int>("Id"),
                                                 Name = r.Field<string>("NameIngr"),
                                                 Price = r.Field<Decimal>("Price"),
                                                 Unit = r.Field<string>("Unit")
                                             })
                                          .ToList();
                return allIngr;
            }
        }

        public void addIngredient(string name, Decimal price, string unit)
        {
            string sqlExpression = "sp_GetIngredient";

            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // параметр для ввода имени
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name
                };
                // добавляем параметр
                command.Parameters.Add(nameParam);
                // параметр для ввода возраста
                SqlParameter priceParam = new SqlParameter
                {
                    ParameterName = "@price",
                    Value = price
                };
                command.Parameters.Add(priceParam);

                SqlParameter unitParam = new SqlParameter
                {
                    ParameterName = "@unit",
                    Value = unit
                };
                command.Parameters.Add(unitParam);

                //var result = command.ExecuteScalar();
                // если нам не надо возвращать id
                try
                {
                    var result = command.ExecuteNonQuery();
                }
                catch (Exception ex) { }
            }
        }

        public Ingredient getIngredient(int id)
        {
            string sqlExpr = String.Format("SELECT ID_Ingredient as id_i, Name_Ingredient as n, Price_Dish, Unit.Name_Unit as u FROM Ingredients INNER JOIN Unit on Unit.ID_Unit=Ingredients.ID_Unit  WHERE ID_Ingredient = {0}", id);
            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExpr, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                Ingredient ingr = (from r in ds.Tables[0].AsEnumerable()
                                 select new Ingredient()
                                 {
                                     Id = r.Field<int>("id_i"),
                                     Name = r.Field<string>("n"),
                                     Price = r.Field<Decimal>("Price_Dish"),
                                     Unit = r.Field<string>("u")
                                 })
                                 .ToList().FirstOrDefault();
                return ingr;
            }
        }

        public void deleteIngredient(int id)
        {
            string sqlExpr = String.Format("DELETE FROM Ingredients WHERE ID_Ingredient = {0}", id);

            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpr, connection);
                int number = command.ExecuteNonQuery();
            }
        }

        public void updateIngredient(int id, string name, Decimal price, string unit)
        {
            string sqlExpression = "sp_UpdateIngredient";

            using (SqlConnection connection = new SqlConnection(strConnect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name
                };
                command.Parameters.Add(nameParam);

                SqlParameter priceParam = new SqlParameter
                {
                    ParameterName = "@price",
                    Value = price
                };
                command.Parameters.Add(priceParam);

                SqlParameter unitParam = new SqlParameter
                {
                    ParameterName = "@unit",
                    Value = unit
                };
                command.Parameters.Add(unitParam);

                //var result = command.ExecuteScalar();
                // если нам не надо возвращать id

                try
                {
                    var result = command.ExecuteNonQuery();
                }
                catch (Exception ex) { }
            }
        }
        #endregion








    }
}