using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dziennik_elektroniczny.DAL.Entity
{
    class GradesWithSubjects
    {
        #region Properties
        public int? Grade_ID { get; set; }
        public sbyte Student_ID { get; set; }
        public sbyte Grade_Value { get; set; }
        public string Subject_Name { get; set; }

        #endregion

        #region Constructor
        public GradesWithSubjects(MySqlDataReader reader)
        {
            Grade_ID = int.Parse(reader["grade_id"].ToString());
            Student_ID = sbyte.Parse(reader["student_id"].ToString());
            Grade_Value = sbyte.Parse(reader["grade_value"].ToString());
            Subject_Name = reader["subject_name"].ToString();
        }
        #endregion
    }
}
