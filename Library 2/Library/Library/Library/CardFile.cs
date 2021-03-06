using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class CardFile
    {
        int x;
        Dictionary<char, SortedList<Author, List<Book>>> _storage;
        //SortedList<Author, List<Book>> test1;
        //Dictionary<Dictionary<char, SortedList<Author, List<Book>>>, Dictionary<char, SortedList<Author, List<Book>>>> test2;

       
        public CardFile()
        {
            _storage = new Dictionary<char, SortedList<Author, List<Book>>>();

            //SortedList<Author, List<Book>> test2 = _storage['k'];
            //Author author1  =  new Author("Александр", "Пушкин", "Сергеевич", new DateTime(1799, 6, 26));
            //List<Book> books = test2[author1];
            //Book book1 = books[0];
            //Book book2 = _storage['k'][author1][0];

            //1040-1071
            for (int i = 1040; i < 1072; i++)
            {
                _storage.Add((char)i, new SortedList<Author, List<Book>>());
            }
        }



        public List<Book> getBooks(string name, string surname)
        {
            char Letter = surname.ToUpper()[0]; //первая буква фамилии автора
            if (_storage.ContainsKey(Letter))
            {
                foreach (Author oneAuthor in _storage[Letter].Keys)
                {
                    if (oneAuthor.Name.Equals(name) && oneAuthor.Surname.Equals(surname))
                    {
                        return _storage[Letter][oneAuthor];
                    }
                }
            }
            return null;
        }

        public List<Book> getBooks(string title)
        {
            List<Book> result = new List<Book>();

            foreach (var item in _storage.Values) //строки нашего словаря
            {
                foreach (List<Book> books in item.Values)
                {
                    foreach (Book oneBook in books)
                    {
                        if (oneBook.Title.Equals(title))
                        {
                            result.Add(oneBook);
                        }
                    }
                }
            }
            return result;
        }

        public bool AddAuthor(Author author)
        {
            char Letter = author.Surname.ToUpper()[0]; //первая буква фамилии автора
            if (_storage.ContainsKey(Letter))
            {
                //_storage[Letter] - доступ к значениям нужной строки (SortedList)
                //_storage[Letter].Keys - доступ ко всем авторам SortedLista
                foreach (Author item in _storage[Letter].Keys)
                {
                    if (item.Equals(author))
                    {
                        return false;
                    }
                }
                _storage[Letter].Add(author, new List<Book>());
               // _storage[Letter][author] = new List<Book>();
                return true;
            }
            return false;
        }
        public void AddBook(Book book)
        {

            foreach (Author oneA in book.Authors)
            {
                AddAuthor(oneA);
                if (getBook(oneA, book.Title) == null)
                {
                    //add book
                    _storage[oneA.Surname.ToUpper()[0]][oneA].Add(book);
                }
            }
        }
        public Book getBook(Author author, string title)
        {
            if (_storage.ContainsKey(author.Surname.ToUpper()[0]))
            {
                foreach (Author auth in _storage[author.Surname.ToUpper()[0]].Keys)
                {
                    if (author.Equals(auth))
                    {
                        foreach (Book book in _storage[author.Surname.ToUpper()[0]][author])
                        {
                            if (book.Title.Equals(title))
                            {
                                return book;
                            }
                        }
                    }
                }
            }
            return null;
        }

        public List<Book> getBooks(Author author)
        {
            if (_storage.ContainsKey(author.Surname.ToUpper()[0]))
            {
                foreach (Author auth in _storage[author.Surname.ToUpper()[0]].Keys)
                {
                    if (author.Equals(auth))
                    {
                        return _storage[author.Surname.ToUpper()[0]][author];
                    }
                }
            }
            return null;
        }
        public KeyValuePair<Author, List<Book>>?  getAuthorData(string name, string surname, string patronimic, DateTime birthDate)
        {
            if (_storage.ContainsKey(surname.ToUpper()[0]))
            {
                foreach (Author auth in _storage[surname.ToUpper()[0]].Keys)
                {
                    if (
                        auth.Name.Equals(name) && 
                        auth.Surname.Equals(surname) &&
                        auth.Partonimic.Equals(patronimic) &&
                        auth.BirthDate == birthDate
                    )
                    {
                        return new KeyValuePair<Author, List<Book>>(auth, _storage[surname.ToUpper()[0]][auth]);
                    }
                }
            }
            return null;
        }
    }
}


