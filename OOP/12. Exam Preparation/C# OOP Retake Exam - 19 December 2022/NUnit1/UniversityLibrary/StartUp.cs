namespace UniversityLibrary
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            TextBook book = new("title", "author", "cat");
            book.InventoryNumber = 10;
            book.Holder = "Alex Eubank";
            UniversityLibrary library = library = new UniversityLibrary();
            library.AddTextBookToLibrary(book);
            string message = library.LoanTextBook(10, "Alex Eubank");
            string expectedMessage = "Alex Eubank still hasn't returned title!";
            
        }
    }
}
