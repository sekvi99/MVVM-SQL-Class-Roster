using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Dziennik_elektroniczny.DAL.Repository
{
    using Entity;
    class GradesWithSubjectsRepository
    {
        #region Queries
        private const string ALL_GRADE_WTIH_SUBJECT_NAMES = "select grades.grade_id, grades.student_id, grades.grade_value, subjects.subject_name from grades inner join subjects on grades.subject_id = subjects.subject_id";

        #endregion

        #region CRUD Methods
        public static List<GradesWithSubjects> GetAllGradesWithSubjectNames()
        {
            List<GradesWithSubjects> grades_list = new List<GradesWithSubjects>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_GRADE_WTIH_SUBJECT_NAMES, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    grades_list.Add(new GradesWithSubjects(reader));
                connection.Close();
            }
            return grades_list;
        }
        #endregion
    }
}
