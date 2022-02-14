using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Dziennik_elektroniczny.DAL.Repository
{
    using Entity;
    class GradesRepository
    {
        #region Queries
        private const string ALL_GRADES = "Select * from grades";
        private const string ADD_GRADE = "Insert into `grades`(`student_id`, `subject_id`, `grade_value`) VALUES ";
        private const string DELETE_GRADE = "Delete from `grades` where grade_id = ";
        #endregion

        #region CRUD Methods
        public static List<Grades> GetAllGrades()
        {
            List<Grades> grades_list = new List<Grades>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_GRADES, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    grades_list.Add(new Grades(reader));
                connection.Close();
            }
            return grades_list;
        }

        public static bool AddGradeToBase(Grades grade)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_GRADE} {grade.toInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                grade.Grade_ID = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        public static bool DeleteStudentFromDataBase(Grades grade)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DELETE_GRADE} {grade.Grade_ID}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                connection.Close();
            }
            return state;
        }

        #endregion
    }
}
