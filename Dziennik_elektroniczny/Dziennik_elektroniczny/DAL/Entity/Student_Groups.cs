using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dziennik_elektroniczny.DAL.Entity
{
    class Student_Groups
    {
        #region Properties
        //Record ID in database
        public sbyte? Added_record { get; set; }
        //Student Id
        public sbyte Student_id { get; set; }
        //Class ID
        public sbyte Class_id { get; set; }

        #endregion

        #region Constructor
        public Student_Groups(MySqlDataReader reader)
        {
            Added_record = sbyte.Parse(reader["added_record"].ToString());
            Student_id = sbyte.Parse(reader["student_id"].ToString());
            Class_id = sbyte.Parse(reader["class_id"].ToString());
        }

        public Student_Groups(double student_id, double class_id)
        {
            Student_id = (sbyte)student_id;
            Class_id = (sbyte)class_id;
        }

        #endregion

        #region Methods

        public string toInsert()
        {
            return $"({Student_id}, {Class_id})";
        }

        #endregion
    }
}
