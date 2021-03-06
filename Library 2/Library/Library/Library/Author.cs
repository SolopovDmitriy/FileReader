using System;

namespace Library
{
    internal class Author : IComparable
    {
        private string _name;
        private string _surname;
        private string _patronimic;
        private DateTime _birthDate;

        public string Name
        {
            get; set;
        }
        public string Surname
        {
            get; set;
        }
        public string Partonimic
        {
            get; set;
        }
        public DateTime BirthDate
        {
            get;
            set;
        }
        public Author(string name, string surname, string patronimic, DateTime birtnDate)
        {
            Name = name;
            Surname = surname;
            Partonimic = patronimic;
            BirthDate = birtnDate;
        }

        public override string ToString()
        {
            return $"Name: {Name}; Surname: {Surname}; Patronimic: {Partonimic}; Birth Date: {BirthDate}";
        }
        public override bool Equals(object obj)
        {
            Author author = obj as Author;
            if (author != null)
            {
                return this.ToString().Equals(author.ToString());
            }
            else
            {
                throw new ArgumentException("Не могу сравнить два обьекта");
            }
        }
        public int CompareTo(object obj)
        {
            Author author = obj as Author;
            if (author != null)
            {
                return author.ToString().CompareTo(this.ToString());
            }
            else
            {
                throw new ArgumentException("Не могу сравнить два обьекта");
            }
        }
    }
}