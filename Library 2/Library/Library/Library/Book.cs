using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Book
    {
        //private string _title;
        //private string _content;
        public Genre genre;
        //private DateTime _dateOfPublished;
        List<Author> _authors;
        public Publisher publisher;
        public string Title
        {
            get; set;
        }
        public string Content
        {
            get; set;
        }
        public DateTime DatePublished
        {
            get;
        }
        public List<Author> Authors
        {
            get
            {
                return _authors;
            }
        }
        public Book()
        {
            _authors = new List<Author>();   
        }
        public Book(string title, string content, Genre genre, DateTime datePublished, Publisher publisher)
        {
            _authors = new List<Author>();
            Title = title;
            Content = content;
            this.genre = genre;
            DatePublished = datePublished;
            this.publisher = publisher;
        }
        public override string ToString()
        {
            return $"Title: {Title}; Genre: {this.genre}; Publisher: {this.publisher}; Date Published: {DatePublished.ToString("MM/dd/yyyy")}";
        }

    }
}
