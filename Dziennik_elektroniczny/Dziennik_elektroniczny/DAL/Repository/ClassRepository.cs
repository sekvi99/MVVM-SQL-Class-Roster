using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Dziennik_elektroniczny.DAL.Repository
{
    using Entity;
    class ClassRepository
    {
        #region Queries
        private const string ALL_CLASSES = "Select * from class";
        #endregion

        #region CRUD Methods
        public static List<Class> GetAllClasses()
        {
            List<Class> class_list = new List<Class>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_CLASSES, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    class_list.Add(new Class(reader));
                connection.Close();
            }

            

            return class_list;
        }
        #endregion
    }
}
