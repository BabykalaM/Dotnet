using BooksManagement.Data_Access;
using BooksManagement.Entities;
using System.Data.SqlClient;

namespace BooksManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            //save();
            getbooks();

        }

        private static void getbooks()
        {
            IBookRepository repo = new BookRepository();
            List<Book> Books = repo.GetBooks();
            foreach (var b in Books)
            {
                Console.WriteLine($"Book ID:{b.BookID}\nBook Name:{b.Name} \n Book Author:{b.Author}");
            }
        }

        private static void update()
        {
            Book b = new Book();
            Console.WriteLine("Enter the Book Id to update:");
            b.BookID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new Book Name:");
            b.Name = Console.ReadLine();
            Console.WriteLine("Enter the new book author name:");
            b.Author = Console.ReadLine();

            IBookRepository repo = new BookRepository();
            repo.Update(b);
            Console.WriteLine("Contact updated....");
        }

        private static void delete()
        {
            Book b = new Book();
            Console.WriteLine("Enter the Book Id to delete:");
            b.BookID = int.Parse(Console.ReadLine());

            IBookRepository repo = new BookRepository();
            repo.Delete(b.BookID);
            Console.WriteLine("Contact deleted....");
        }

        private static void getbyid()
        {
            Console.WriteLine("Enter the book id to search:");
            int bookId = int.Parse(Console.ReadLine());

            IBookRepository repo = new BookRepository();
            Book b = repo.GetBook(bookId);
            Console.WriteLine($"Book Name:{b.Name} \n Book Author:{b.Author}");
        }

        private static void save()
        {
            Book b = new Book();
            Console.WriteLine("Enter the Book Id:");
            b.BookID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Book Name:");
            b.Name = Console.ReadLine();
            Console.WriteLine("Enter the book author name:");
            b.Author = Console.ReadLine();

            IBookRepository repo = new BookRepository();
            repo.Save(b);
            Console.WriteLine("Contact saved....");
        }
    }
}