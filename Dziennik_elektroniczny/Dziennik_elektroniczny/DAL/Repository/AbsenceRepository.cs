using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Dziennik_elektroniczny.DAL.Repository
{
    using Entity;
    class AbsenceRepository
    {
        #region Queries
        private const string ALL_ABSENCE = "Select * from absence";
        #endregion

        #region CRUD Methods
        public static List<Absence> GetAllAbsences()
        {
            List<Absence> absence_List = new List<Absence>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_ABSENCE, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    absence_List.Add(new Absence(reader));
                connection.Close();
            }
            return absence_List;
        }
        #endregion
    }
}
