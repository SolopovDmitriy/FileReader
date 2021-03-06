using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        static void TestDateTime()
        {
            DateTime date1 = new DateTime(1999, 11, 22);                 
            Console.WriteLine(date1.ToString("MM/dd/yyyy"));
        }

        static void TestDictionary5()
        {
            Dictionary<string, int> dictionary1 = new Dictionary<string, int>();
            dictionary1["Nick"] = 25;
            dictionary1["Alex"] = 215;
            dictionary1["Anna"] = 245;
            dictionary1.Add("John",432);


            var names = dictionary1.Keys;
            foreach (string item in names)
            {
                Console.WriteLine(item);
            }

        }

        static int? GetNumber()
        {
            // if not found return null
            return null;
        }

        static Author GetAuthor()
        {           
            return null;
        }

        static void TestQuestionSymbol()
        {
            int? x = null;
          
            Author author1 = new Author("Александр", "Пушкин", "Сергеевич", new DateTime(1799, 6, 26));
            Author author2 = GetAuthor();
            Author author3 = null;

            //string name;
            //if (author3 != null)
            //{
            //    name = author2.Name;
            //}
            //else
            //{
            //    name = null;
            //}
            string name = author3?.Name;
            Console.WriteLine(name);
           

        }


        static void Main(string[] args)
        {
            try
            {
                CardFile cardFile = new CardFile();
                cardFile.AddAuthor(new Author("Александр", "Пушкин", "Сергеевич", new DateTime(1799, 6, 26)));
                cardFile.AddAuthor(new Author("Николя", "Гоголь", "Васильевич", new DateTime(1809, 4, 1)));
                cardFile.AddAuthor(new Author("Иван", "Тургенев", "Сергеевич", new DateTime(1883, 9, 3)));

                Book oneginBook = new Book("Евгений Онегин", "", Genre.Drama, DateTime.Now, Publisher.Piter);
                oneginBook.Authors.Add(new Author("Александр", "Пушкин", "Сергеевич", new DateTime(1799, 6, 26)));

                Book vijBook = new Book("Вий", "", Genre.Drama, DateTime.Now, Publisher.Labirint);
                vijBook.Authors.Add(new Author("Николя", "Гоголь", "Васильевич", new DateTime(1809, 4, 1)));

                Book godunovBook = new Book("Борис Годунов", "", Genre.Triller, DateTime.Now, Publisher.Piter);
                godunovBook.Authors.Add(new Author("Александр", "Пушкин", "Сергеевич", new DateTime(1799, 6, 26)));

                cardFile.AddBook(oneginBook);
                cardFile.AddBook(vijBook);
                cardFile.AddBook(godunovBook);

                Console.WriteLine(cardFile);

                Book book = cardFile.getBook(new Author("Николя", "Гоголь", "Васильевич", new DateTime(1809, 4, 1)), "Вий");
                Console.WriteLine(book);


                foreach (Book oneBook in cardFile.getBooks("Евгений Онегин"))
                {
                    Console.WriteLine(oneBook);
                }

                Console.WriteLine("Книги Пушкина");
                foreach (Book item in cardFile.getBooks(new Author("Александр", "Пушкин", "Сергеевич", new DateTime(1799, 6, 26))))
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Вернул пару");
                KeyValuePair<Author, List<Book>> ? data = cardFile.getAuthorData("Александр", "Пушкин", "Сергеевич", new DateTime(1799, 6, 26));
                Console.WriteLine(data.Value.Key);
                Console.WriteLine(data.Value.Value.Count);


                // TestDateTime();
                // TestQuestionSymbol();
                // TestDictionary5();
                Console.WriteLine();
            
                string path = @"d:\c#\lesson9\1.txt";
                string path2 = "d:\\c#\\lesson9\\1.txt";
                Console.WriteLine(path);
                Console.WriteLine(path2);
                string result = FileReader.ReadTxtFile(path);
                Console.WriteLine(result);

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ResetColor();
            }
            Console.ReadKey();
        }
    }
}
