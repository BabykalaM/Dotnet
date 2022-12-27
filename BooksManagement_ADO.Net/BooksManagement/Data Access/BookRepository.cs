using BooksManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagement.Data_Access
{
    public class BookRepository : IBookRepository
    {
        public void Delete(int BookID)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=CoolBooksDB;Integrated Security=True;Pooling=False";
            conn.Open();

            //Step 2:prepare SQL insert command
            string delete = $"delete Books where BookId={BookID}";
            //Step 3: execute SQL cmd
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = delete;
            cmd.Connection = conn;
            try
            {
                int count=cmd.ExecuteNonQuery();
                if (count == 0)
                {
                    throw new BookNotFoundException("Book Id is not found");
                }
            }

            //Step 4:close connection
            finally
            {

                conn.Close();
            }

        }

        public Book GetBook(int BookID)
        {
            //Step 1:connect to DB
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=CoolBooksDB;Integrated Security=True;Pooling=False";
            conn.Open();

            //Step 2:prepare SQL insert command
            string select = $"select * from Books where BookID={BookID}";
            //Step 3: execute SQL cmd
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = select;
            cmd.Connection = conn;

            Book b = new Book();
            try
            {
                //cmd.ExecuteNonQuery(); //used only for insert,update and delete
                SqlDataReader reader=cmd.ExecuteReader(); //select
                
                reader.Read();
                b.BookID = (int)(reader[1]);
                b.Name = reader[2].ToString();
                b.Author = reader[3].ToString();

            }

            //Step 4:close connection
            finally
            {

                conn.Close();
            }
            return b;
        }

        public List<Book> GetBooks()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=CoolBooksDB;Integrated Security=True;Pooling=False";
            conn.Open();

            //Step 2:prepare SQL insert command
            string select = $"select * from Books";
            //Step 3: execute SQL cmd
            SqlCommand cmd = new SqlCommand(select,conn);
            //cmd.CommandText = select;
            //cmd.Connection = conn;

            List<Book> Books = new List<Book>();
            try
            {
                //cmd.ExecuteNonQuery(); //used only for insert,update and delete
                SqlDataReader reader = cmd.ExecuteReader(); //select

                while (reader.Read())
                {
                    Book b = new Book();
                    b.BookID = (int)(reader[1]);
                    b.Name = reader[2].ToString();
                    b.Author = reader[3].ToString();
                    Books.Add(b);
                }
            }

            //Step 4:close connection
            finally
            {

                conn.Close();
            }
            return Books;
        }

        public void Save(Book bookToSave)
        {
            //Step 1:connect to DB
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=CoolBooksDB;Integrated Security=True;Pooling=False";
            conn.Open();
            
            //Step 2:prepare SQL insert command
            string sqlInsert = $"insert into Books values ({bookToSave.BookID},'{bookToSave.Name}','{bookToSave.Author}')";
            //Step 3: execute SQL cmd
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlInsert;
            cmd.Connection = conn;
            try
            {
                cmd.ExecuteNonQuery();
            }

            //Step 4:close connection
            finally
            {

                conn.Close();
            }
            
        }

        public void Update(Book bookToUpdate)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=CoolBooksDB;Integrated Security=True;Pooling=False";
            conn.Open();

            //Step 2:prepare SQL insert command
            string update = $"update Books set name='{bookToUpdate.Name}',author='{bookToUpdate.Author}' where BookId={bookToUpdate.BookID}";
            //Step 3: execute SQL cmd
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = update;
            cmd.Connection = conn;
            try
            {
                cmd.ExecuteNonQuery();
            }

            finally
            {

                conn.Close();
            }

        }
    }
}
