﻿using System;
using System.Globalization;

namespace ConsoleApplication1
{
        /// <summary>
        /// Book class
        /// </summary>
        public class Book : IEquatable<Book>, IComparable<Book>, IComparable, IFormattable
        {
            #region properties

            /// <summary>
            /// Book properties title, author name, genre(fantstic,detective and etc.), published year and number of edition
            /// </summary>
            public string Title { get; }
            public string Author { get; }
            public string Genre { get; }
            public int Year { get; }
            public int Edition { get; }

            #endregion

            #region constructors

            public Book(string title, string author, string genre, int year, int edition)
            {
                ConstructorValidator(title, author, genre, year, edition);
                Title = title;
                Author = author;
                Genre = genre;
                Year = year;
                Edition = edition;
            }

            #endregion

            #region validator

            private void ConstructorValidator(string title, string author, string genre, int year, int edition)
            {
                if (string.IsNullOrEmpty(title)) throw new ArgumentException("cant be null or empty param name: ", nameof(title));
                if (string.IsNullOrEmpty(author)) throw new ArgumentException("cant be null or empty param name: ", nameof(author));
                if (string.IsNullOrEmpty(genre)) throw new ArgumentException("cant be null or empty param name: ", nameof(genre));
                if (year <= 0) throw new ArgumentOutOfRangeException(nameof(year), "year must be more than zero");
                if (edition <= 0) throw new ArgumentOutOfRangeException(nameof(edition), "edition must be more than zero");
            }

            #endregion

            #region Equals methods

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Book)obj);
            }

            /// <summary>
            /// Equals method 
            /// </summary>
            /// <param name="other"> another book </param>
            /// <returns>true(when all fields are the same), and false in other case</returns>
            public bool Equals(Book other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                if (Title == other.Title &&
                    Author == other.Author &&
                    Genre == other.Genre &&
                    Year == other.Year &&
                    Edition == other.Edition)
                    return true;
                return false;
            }

            #endregion

            #region GetHashCode

            /// <summary>
            /// gethashcode method? base on immutable fields of book
            /// </summary>
            /// <returns>hashcode</returns>
            public override int GetHashCode()
            {
                int hashcode = Title.GetHashCode();
                hashcode = 31 * hashcode + Author.GetHashCode();
                hashcode = 31 * hashcode + Genre.GetHashCode();
                hashcode = 31 * hashcode + Year.GetHashCode();
                hashcode = 31 * hashcode + Edition.GetHashCode();
                return hashcode;
            }

            #endregion

            #region CompareTo

            public int CompareTo(object obj)
            {
                if (obj.GetType() != GetType()) throw new ArgumentException("obj type is not book", nameof(obj));
                return CompareTo((Book)obj);
            }

            /// <summary>
            /// default compare of two books based on title
            /// </summary>
            /// <param name="other">other book</param>
            /// <returns>+1 or -1 or 0</returns>
            public int CompareTo(Book other)
            {
                if (ReferenceEquals(null, other)) return 1;
                if (ReferenceEquals(this, other)) return 0;
                return string.Compare(Title, other.Title, StringComparison.Ordinal);
            }

            #endregion

            #region ToString

            public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

            public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

            public string ToString(string format, IFormatProvider formatProvider)
            {
                if (string.IsNullOrEmpty(format))
                {
                    format = "G";
                }

                if (formatProvider == null)
                {
                    formatProvider = CultureInfo.CurrentCulture;
                }

                switch (format.ToUpperInvariant())
                {
                    case "G":
                    case "TAGYE":
                        return $"Title: {Title}\nAuthor: {Author}\nGenre: {Genre}\nYear: {Year}\nEdition: {Edition}";
                    case "TAE":
                        return $"Title: {Title}\nAuthor: {Author}\nEdition: {Edition}";
                    case "TAG":
                        return $"Title: {Title}\nAuthor: {Author}\nGenre: {Genre}";
                    case "TY":
                        return $"Title: {Title}\nYear: {Year}";
                    case "TA":
                        return $"Title: {Title}\nAuthor: {Author}";
                    case "T":
                        return $"Title: {Title}";
                    default:
                        throw new FormatException("such format string not supported");
                }
            }

            #endregion
        }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
