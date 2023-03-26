namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    public class Tests
    {
        private UniversityLibrary library;
        private TextBook book;

        [SetUp]
        public void Setup()
        {
            library = new UniversityLibrary();
            book = new TextBook("title", "author", "category");
        }

        [Test]
        public void Constructor()
        {
            library = new UniversityLibrary();
        }
        [Test]
        public void AddMethod()
        {
           library.AddTextBookToLibrary(book);
            Assert.That(library.Catalogue.Count, Is.EqualTo(1));
           
        }
        [Test]
        public void AddMethodMessage()
        {
            string message = library.AddTextBookToLibrary(book);           
            Assert.That(book.ToString(), Is.EqualTo(message));
        }
        [Test]
        public void LoanMethodFirstIf()
        {
                      
            book.Holder = "Alex Eubank";
            library.AddTextBookToLibrary(book);
            string message = library.LoanTextBook(1, "Alex Eubank");
            string expectedMessage = "Alex Eubank still hasn't returned title!";
            Assert.That(expectedMessage, Is.EqualTo(message));
        }
        [Test]
        public void LoanMethodSecondIf()
        {

            book.Holder = "Alex Eubank";
            library.AddTextBookToLibrary(book);
            string message = library.LoanTextBook(1, "Little Lex");
            string expectedMessage = "title loaned to Little Lex.";
            Assert.That(expectedMessage, Is.EqualTo(message));
            Assert.That(book.Holder, Is.EqualTo("Little Lex"));
        }
        [Test]
        public void ReturnTextBookMethod()
        {
            book.Holder = "Alex Eubank";
            library.AddTextBookToLibrary(book);
            string message = library.ReturnTextBook(1);
            string expectedMessage = "title is returned to the library.";
            Assert.That(expectedMessage, Is.EqualTo(message));
            Assert.That(book.Holder, Is.EqualTo(string.Empty));
        }
    }
}