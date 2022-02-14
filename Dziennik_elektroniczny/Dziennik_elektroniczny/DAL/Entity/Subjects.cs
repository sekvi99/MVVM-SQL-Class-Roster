using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dziennik_elektroniczny.DAL.Entity
{
    class Subjects
    {
        #region Properties
        //Subject id
        public sbyte? Subject_id { get; set; }
        //Subject Name
        public string Subjects_name { get; set; }
        //Subject Teacher Name
        public string Subject_teacher_name { get; set; }
        //Subject Teacjer SecondName
        public string Subject_teacher_secondName { get; set; }

        #endregion

        #region Constructor
        public Subjects(MySqlDataReader reader)
        {
            Subject_id = sbyte.Parse(reader["subject_id"].ToString());
            Subjects_name = reader["subject_name"].ToString();
            Subject_teacher_name = reader["subject_teacher_name"].ToString();
            Subject_teacher_secondName = reader["subject_teacher_secondName"].ToString();
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Subject:{Subjects_name}, Teacher:{Subject_teacher_name} {Subject_teacher_secondName}";
        }
        #endregion
    }
}
