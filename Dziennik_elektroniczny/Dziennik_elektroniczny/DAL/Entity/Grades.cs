using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dziennik_elektroniczny.DAL.Entity
{
    class Grades
    {
        #region Properties
        //Id of record in database
        public int? Grade_ID { get; set; }
        //Student ID default from 1 to 80
        public sbyte Student_ID { get; set; }
        //Subject ID from 1 to 10
        public sbyte Subject_ID { get; set; }
        //Grade value from 1 to 6
        public sbyte Grade_Value { get; set; }

        #endregion

        #region Constructor
        public Grades(MySqlDataReader reader)
        {
            Grade_ID = int.Parse(reader["grade_id"].ToString());
            Student_ID = sbyte.Parse(reader["student_id"].ToString());
            Subject_ID = sbyte.Parse(reader["subject_id"].ToString());
            Grade_Value = sbyte.Parse(reader["grade_value"].ToString());
        }

        public Grades(double student_id, double subject_id, double grade)
        {
            Student_ID = (sbyte)student_id;
            Subject_ID = (sbyte)subject_id;
            Grade_Value = (sbyte)grade;
        }

        #endregion

        #region Methods
        public string toInsert()
        {
            return $"({Student_ID}, {Subject_ID}, {Grade_Value})";
        }
        #endregion

    }
}