using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Dziennik_elektroniczny.DAL.Entity
{
    class Comments
    {
        #region Properties
        //Comment ID
        public sbyte? Comment_ID { get; set; }
        //Student ID
        public sbyte Student_ID { get; set; }
        //Comment Content
        public string Comment_Content { get; set; }
        //Comment Date
        public string Comment_Date { get; set; }

        #endregion

        #region Constructor
        public Comments(MySqlDataReader reader)
        {
            Comment_ID = sbyte.Parse(reader["comment_id"].ToString());
            Student_ID = sbyte.Parse(reader["student_id"].ToString());
            Comment_Content = reader["comment_content"].ToString();
            Comment_Date = reader["comment_date"].ToString();
        }

        public Comments(double s_id, string comment_content, string comment_date)
        {
            Student_ID = (sbyte)s_id;
            Comment_Content = comment_content;
            Comment_Date = comment_date;
        }

        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Uwaga: {Comment_Content} dodano:{Comment_Date}";
        }

        public string toInsert()
        {
            return $"({Student_ID}, '{Comment_Content}','{Comment_Date}')";
        }
        #endregion

    }
}
