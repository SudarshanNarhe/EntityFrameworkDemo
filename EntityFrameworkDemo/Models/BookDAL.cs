using EntityFrameworkDemo.Data;

namespace EntityFrameworkDemo.Models
{
    public class BookDAL
    {
        private ApplicationDbContext db;

        public BookDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Book> GetBooks()
        {
            return db.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            var book = db.Books.FirstOrDefault(x => x.Id == id);
            return book;
        }

        public int AddBook(Book book)
        {
            int result = 0;
            db.Books.Add(book);
            result = db.SaveChanges();
            return result;
        }

        public int UpdateBook(Book book)
        {
            int result = 0;
            var model = db.Books.FirstOrDefault(x => x.Id == book.Id);
            if (model != null)
            {
                model.BookName = book.BookName;
                model.Author = book.Author;
                model.Price = book.Price;
                result = db.SaveChanges();
            }
            return result;
        }

        public int DeleteBook(int id)
        {
            int result = 0;
            var model = db.Books.FirstOrDefault(x => x.Id ==id);
            if (model != null)
            {
                db.Books.Remove(model);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
