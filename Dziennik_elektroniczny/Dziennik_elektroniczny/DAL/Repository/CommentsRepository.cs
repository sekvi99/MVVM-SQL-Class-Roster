using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Dziennik_elektroniczny.DAL.Repository
{
    using Entity;
    class CommentsRepository
    {
        #region Queries
        private const string ALL_COMMENTS = "Select * from comments";
        private const string ADD_COMMENT = "Insert into `comments`(`student_id`, `comment_content`, `comment_date`) values ";
        #endregion

        #region CRUD Methods
        public static List<Comments> GetAllComments()
        {
            List<Comments> comment_List = new List<Comments>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_COMMENTS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    comment_List.Add(new Comments(reader));
                connection.Close();
            }
            return comment_List;
        }

        public static bool AddCommentToDataBase(Comments comment)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_COMMENT} {comment.toInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                comment.Comment_ID = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        #endregion
    }
}
