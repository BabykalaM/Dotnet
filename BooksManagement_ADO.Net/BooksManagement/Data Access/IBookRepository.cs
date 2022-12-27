using BooksManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManagement.Data_Access
{
    public interface IBookRepository
    {
        void Save(Book bookToSave);
        void Update(Book bookToUpdate);
        void Delete(int BookID);
        List<Book> GetBooks();
        Book GetBook(int BookID);
    }
}
