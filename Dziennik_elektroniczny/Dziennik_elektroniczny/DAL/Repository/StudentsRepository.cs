using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Dziennik_elektroniczny.DAL.Repository
{
    using Entity;
    class StudentsRepository
    {
        #region Queries
        private const string ALL_STUDENTS = "Select * from students";
        private const string ADD_STUDENTS = "Insert into `students`(`student_name`, `student_secondName`, `student_sex`, `birth_date`, `student_residence`, `student_phone_number`) VALUES ";
        private const string DELETE_STUDENTS = "Delete from `students` where student_id= ";
        #endregion

        #region CRUD Methods
        public static List<Students> GetAllStudents()
        {
            List<Students> students = new List<Students>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_STUDENTS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    students.Add(new Students(reader));
                connection.Close();
            }
            return students;
        }

        public static bool AddStudentToDataBase(Students student)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_STUDENTS} {student.toInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                student.Student_id = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        public static bool DeleteStudentFromDataBase(Students student)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DELETE_STUDENTS} {student.Student_id}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                connection.Close();
            }
            return state;
        }

        public static bool EditStudentInDatabase(Students student, sbyte studentID)
        {
            bool state = false;
            using(var connection = DBConnection.Instance.Connection)
            {
                string EDIT_STUDENT = $"UPDATE students SET student_name='{student.Student_name}', student_secondName='{student.Student_secondName}', student_sex='{student.Student_sex}', birth_date='{student.Birth_date}', student_residence='{student.Student_residence}', student_phone_number={student.Phone_number} where student_id={studentID}";
                MySqlCommand command = new MySqlCommand(EDIT_STUDENT, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;

                connection.Close();

            }

            return state;
        }
        #endregion 
    }
}
