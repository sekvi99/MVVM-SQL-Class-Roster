using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Dziennik_elektroniczny.DAL.Repository
{
    using Entity;
    class StudentGroupsRepository
    {
        #region Queries
        private const string ALL_STUDENT_GROUPS = "Select * from student_groups";
        private const string ADD_STUDENT_TO_GROUP = "Insert into `student_groups`(`student_id`, `class_id`) Values";
        private const string DELETE_STUDENT_FROM_GROUP = "Delete from `student_groups` where student_id = ";
        #endregion

        #region CRUD Methods
        public static List<Student_Groups> GetAllStudentInGroups()
        {
            List<Student_Groups> student_groups = new List<Student_Groups>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_STUDENT_GROUPS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    student_groups.Add(new Student_Groups(reader));
                connection.Close();
            }
            return student_groups;
        }

        public static bool AddStudentToGroup(Student_Groups current_student)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_STUDENT_TO_GROUP} {current_student.toInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                current_student.Student_id = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        // ??? - nie wiem czy to tak
        public static bool DeleteStudentFromDataBase(Student_Groups current_student)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DELETE_STUDENT_FROM_GROUP} {current_student.Student_id}", connection);
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
