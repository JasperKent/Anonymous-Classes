using System.Linq;

namespace AnonymousClasses.DataAccess
{
    public static class Initializer
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books.Count() == 0)
            {
                Book b1 = new Book { Title = "Dr No", Author = "Ian Fleming", Blurb = "Bond tackles a giant squid.", Publisher = "Pan", PublisherAddress = "New York", ReviewCount = 253 };
                Book b2 = new Book { Title = "Goldfinger", Author = "Ian Fleming", Blurb = "Bond tackles a giant ego.", Publisher = "Pan", PublisherAddress = "New York", ReviewCount = 302 };
                Book b3 = new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Blurb = "The one without the zombies.", Publisher = "Wordsworth Classics", PublisherAddress = "London", ReviewCount = 123 };
                Book b4 = new Book { Title = "Mansfield Park", Author = "Jane Austen", Blurb = "Everyone is rightly upset by amateur theatre.", Publisher = "Wordsworth Classics", PublisherAddress = "London", ReviewCount = 231 };
                Book b5 = new Book { Title = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling", Blurb = "Harry unearths a secret at Hogwarts.", Publisher = "Bloomsbury", PublisherAddress = "Munich", ReviewCount = 1203 };
                Book b6 = new Book { Title = "Harry Potter and the Chamber of Secrets", Author = "J.K. Rowling", Blurb = "See 'Harry Potter and the Philosopher's Stone'.", Publisher = "Bloomsbury", PublisherAddress = "Munich", ReviewCount = 992 };

                context.Add(b1);
                context.Add(b2);
                context.Add(b3);
                context.Add(b4);
                context.Add(b5);
                context.Add(b6);

                context.SaveChanges();
            }
        }
    }
}
