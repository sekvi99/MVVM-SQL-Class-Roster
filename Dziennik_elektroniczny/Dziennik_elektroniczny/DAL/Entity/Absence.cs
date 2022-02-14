using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dziennik_elektroniczny.DAL.Entity
{
    class Absence
    {
        #region Properties
        //Absence ID in database
        public sbyte? Absence_ID { get; set; }
        //Student ID in database
        public sbyte Student_ID { get; set; }
        //Subject ID in database
        public sbyte Subject_ID { get; set; }
        //Absence Date
        public string Absence_Date { get; set; }

        #endregion

        #region Constructor
        public Absence(MySqlDataReader reader)
        {
            Absence_ID = sbyte.Parse(reader["absence_id"].ToString());
            Student_ID = sbyte.Parse(reader["student_id"].ToString());
            Subject_ID = sbyte.Parse(reader["subject_id"].ToString());
            Absence_Date = reader["absence_date"].ToString();
        }

        #endregion
    }
}