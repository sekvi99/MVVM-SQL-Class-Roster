using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dziennik_elektroniczny.DAL.Entity
{
    class Students
    {
        #region Properties
        //Student's id in database
        public sbyte? Student_id { get; set; }
        //Name
        public string Student_name { get; set; }
        //SecondName
        public string Student_secondName { get; set; }
        //sex
        public char Student_sex { get; set; }
        //birth_date
        public string Birth_date { get; set; }
        //residence
        public string Student_residence { get; set; }
        //phone number
        public string Phone_number { get; set; }
        #endregion

        #region Constructor
        //MySQL Constructor
        public Students(MySqlDataReader reader)
        {
            Student_id = sbyte.Parse(reader["student_id"].ToString());
            Student_name = reader["student_name"].ToString();
            Student_secondName = reader["student_secondName"].ToString();
            Student_sex = char.Parse(reader["student_sex"].ToString());
            Birth_date = reader["birth_date"].ToString();
            Student_residence = reader["student_residence"].ToString();
            Phone_number = reader["student_phone_number"].ToString();

        }

        //Creating Constructor, add record with empty ID
        public Students(string name, string secondName, char sex, string birth_date, string student_residence, string phone_number)
        {
            Student_name = name;
            Student_secondName = secondName;
            Student_sex = sex;
            Birth_date = birth_date;
            Student_residence = student_residence;
            Phone_number = phone_number;

        }

        public Students(Students s)
        {
            Student_name = s.Student_name;
            Student_secondName = s.Student_secondName;
            Student_sex = s.Student_sex;
            Birth_date = s.Birth_date;
            Student_residence = s.Student_residence;
            Phone_number = s.Phone_number;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Student_name}, {Student_secondName}, Sex:{Student_sex}, Birth Date:{Birth_date}, Residence:{Student_residence}, Phone:{Phone_number}";
        }

        public string toInsert()
        {
            return $"('{Student_name}', '{Student_secondName}', '{Student_sex}', '{Birth_date}', '{Student_residence}', '{Phone_number}')";
        }

        public override bool Equals(object obj)
        {
            var student = obj as Students;
            if (student is null) return false;
            if (Student_name.ToLower() != student.Student_name.ToLower()) return false;
            if (Student_secondName.ToLower() != student.Student_secondName.ToLower()) return false;
            if (Student_sex.ToString().ToLower() != student.Student_sex.ToString().ToLower()) return false;
            if (Birth_date != student.Birth_date) return false;
            if (Student_residence.ToLower() != student.Student_residence.ToLower()) return false;
            if (Phone_number.ToLower() != student.Phone_number.ToLower()) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
