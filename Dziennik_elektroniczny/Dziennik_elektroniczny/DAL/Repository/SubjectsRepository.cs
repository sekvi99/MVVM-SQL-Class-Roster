using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Dziennik_elektroniczny.DAL.Repository
{
    using Entity;
    class SubjectsRepository
    {
        #region Queries
        private const string ALL_SUBJECTS = "Select * from subjects";
        #endregion

        #region CRUD Methods
        public static List<Subjects> GetAllSubjects()
        {
            List<Subjects> subjects = new List<Subjects>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_SUBJECTS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    subjects.Add(new Subjects(reader));
                connection.Close();
            }
            return subjects;
        }

        #endregion
    }
}
