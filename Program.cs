using System;
namespace BookAuthorManagement
{
    #region AuthorClass
    public class Author
    {
        private string _Author;
        private string _AuthorEmail;
        private char _Gender;

        public string author
        {
            get { return this._Author; }
            set { this._Author = value; }
        }
        public string authorEmail
        {
            get { return this._AuthorEmail; }
            set { this._AuthorEmail = value; }
        }
        public char gender
        {
            get { return this._Gender; }
            set { this._Gender = value; }
        }
        public Author(string author,string authoremail,char gender)
        {
            this._Author = author;
            this._AuthorEmail = authoremail;    
            this._Gender = gender;
        }
        public void DisplayAuthorDetails()
        {
            Console.WriteLine();
            Console.WriteLine("Author Details....");
            Console.WriteLine();
            Console.WriteLine("Name : {0}",this._Author);
            Console.WriteLine("Email : {0}", this._AuthorEmail);
            Console.WriteLine("Gender : {0}", this._Gender);
        }
    }
    #endregion

    #region BookClass
    public class Book
    {
        private string _ISBN;
        private string _BookName;
        private int _YearPublished;
        private decimal _Price;
        private Author _AuthorDetails;
        
        public string ISBN
        {
            get { return this._ISBN; }
            set { this._ISBN = value; }
        }
        public int YearPublished
        {
            get { return this._YearPublished; }
            set { this._YearPublished = value; }
        }
        public decimal Price
        {
            get { return this._Price; }
            set { this._Price = value; }
        }
        public string BookName
        {
            get { return this._BookName; }
            set { this._BookName = value; }
        }

        public Author AuthorDetails
        {
            get { return this._AuthorDetails; }
            set { this._AuthorDetails = value; }
        }
        public Book(string isbn, string bookname, int yearpublished,decimal price,Author authordetails)
        {
            this._ISBN = isbn;
            this._BookName = bookname;
            this._YearPublished = yearpublished;
            this._Price = price;
            this._AuthorDetails = authordetails;
        }
        public void DisplayBookDetails()
        {
            Console.WriteLine();
            Console.WriteLine("Book Details....");
            Console.WriteLine();
            Console.WriteLine("Name : {0}", this._BookName);
            Console.WriteLine("Published Year : {0}", this._YearPublished);
            Console.WriteLine("Price : {0}", this._Price);
            Console.WriteLine("ISBN : {0}", this._ISBN);
            this._AuthorDetails.DisplayAuthorDetails();
        }
    }
    #endregion

    #region BookManagementClass
    public class BookManagement
    {
        private Book[] Rack=new Book[10];
        private int i = 0;
        public void AddBook()
        {
            if(this.i<10)
            {
                Console.Write("Enter Book Name : ");
                string name=Console.ReadLine();
                Console.Write("Enter ISBN : ");
                string isbn=Console.ReadLine();
                Console.Write("Enter Price : ");
                decimal price=Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter Published Year : ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Author Name : ");
                string authorname = Console.ReadLine();
                Console.Write("Enter Author Email : ");
                string authoremail = Console.ReadLine();
                Console.Write("Enter Author Gender (m/f) : ");
                char authorgender = Convert.ToChar(Console.ReadLine());
                Author a = new Author(authorname,authoremail,authorgender);
                Book b=new Book(isbn,name,year,price,a);
                this.Rack[i++] = b;
            }
            else
            {
                Console.WriteLine("Rack is filled.Can't add more books");
            }
        }
        public bool SearchBook(string isbn)
        {
            if(this.i==0)
            {
                Console.WriteLine("No books in the Rack");
                return false;
            }
            foreach(Book b in this.Rack)
            {
                if(b!=null && b.ISBN == isbn)
                {
                    return true;
                }
            }
            return false;
        }
        public void ViewBooks()
        {
            if (this.i == 0)
            {
                Console.WriteLine("No books in the Rack");
            }
            else
            {
                foreach (Book b in this.Rack)
                {
                    if(b!=null)
                    {
                        Console.WriteLine();
                        b.DisplayBookDetails();
                        Console.WriteLine();
                    }
                }
            }
        }
        public void ViewAuthors()
        {
            if (this.i == 0)
            {
                Console.WriteLine("No books in the Rack");
            }
            else
            {
                foreach (Book b in this.Rack)
                {
                    if (b != null)
                    {
                        Console.WriteLine();
                        b.AuthorDetails.DisplayAuthorDetails();
                        Console.WriteLine();
                    }
                }
            }
        }
        public void UpdateBookDetails(string isbn)
        {
            if (this.i == 0)
            {
                Console.WriteLine("No books in the Rack");
            }
            else
            {
                for (int j = 0; j < 10; j++)
                {
                    if (this.Rack[j]!=null && this.Rack[j].ISBN == isbn)
                    {
                        Console.Write("Enter Book Name : ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Price : ");
                        decimal price = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter Published Year : ");
                        int year = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Author Name : ");
                        string authorname = Console.ReadLine();
                        Console.Write("Enter Author Email : ");
                        string authoremail = Console.ReadLine();
                        Console.Write("Enter Author Gender (m/f) : ");
                        char authorgender = Convert.ToChar(Console.ReadLine());
                        Author a = new Author(authorname, authoremail, authorgender);
                        Book c = new Book(isbn, name, year, price, a);
                        this.Rack[j] = c;
                        Console.WriteLine();
                        Console.WriteLine("Book Details Updated...");
                        break;
                    }
                }
            }
        }
    }
    #endregion

    #region ProgramClass
    public class Program
    {
        static void Main(string[] args)
        {
            BookManagement bm=new BookManagement();
            int a=0;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Add Book.");
                Console.WriteLine("2. Search Book.");
                Console.WriteLine("3. Update Book.");
                Console.WriteLine("4. View All Books.");
                Console.WriteLine("5. View All Authors.");
                Console.WriteLine("6. Exit.");
                Console.WriteLine();
                Console.Write("Pleace Enter Your Choice :: ");
                a = Convert.ToInt32(Console.ReadLine());

                switch(a)
                {
                    case 1:
                        bm.AddBook();
                        break;
                    case 2:
                        Console.Write("Enter ISBN of book : ");
                        string isbn = Console.ReadLine();
                        Console.WriteLine(bm.SearchBook(isbn));
                        break;
                    case 3:
                        Console.Write("Enter ISBN of book : ");
                        string ib = Console.ReadLine();
                        bm.UpdateBookDetails(ib);
                        break;
                    case 4:
                        bm.ViewBooks();
                        break;
                    case 5:
                        bm.ViewAuthors();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Enter option from 1 to 6");
                        break;
                }
            } while(a!=6);
        }
    }
    #endregion
}
