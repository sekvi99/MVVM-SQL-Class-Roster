using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Dziennik_elektroniczny.DAL.Entity
{
    class Class
    {
        #region Properties
        //Class ID
        public sbyte? Class_ID { get; set; }
        //Class Name - "Pierwsza", "Druga", ...
        public string Class_Name { get; set; }
        //Start Class Date
        public string Class_begin_date { get; set; }
        //Class Graduate Date
        public string Class_graduate_date { get; set; }
        //Class Semester - "letni", "zimowy"
        public string Class_Semester { get; set; }
        #endregion

        #region Constructor
        public Class(MySqlDataReader reader)
        {
            Class_ID = sbyte.Parse(reader["class_id"].ToString());
            Class_Name = reader["class_name"].ToString();
            Class_begin_date = reader["class_begin_date"].ToString();
            Class_graduate_date = reader["class_graduate_date"].ToString();
            Class_Semester = reader["class_semester"].ToString();
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Class_Name} - Zaczęła:{Class_begin_date}, Zakończyła:{Class_graduate_date} - Semestr:{Class_Semester}";
        }

        #endregion
    }
}