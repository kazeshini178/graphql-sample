using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SampleQL.DataTypes
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GoodreadsResponse
    {
        public Request Request { get; set; }
        [XmlElement("author", IsNullable = true)]
        public Author Author { get; set; }
        [XmlElement("book", IsNullable = true)]
        public Book Book { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class Request
    {
        public bool Authentication { get; set; }
        public string Key { get; set; }
        public string Method { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class Author
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Link { get; set; }
        public GoodreadsResponseAttribute FansCount { get; set; }
        public GoodreadsResponse AuthorFollowersCount { get; set; }
        public string LargeImageUrl { get; set; }
        public string ImageUrl { get; set; }
        public string SmallImageUrl { get; set; }
        public string About { get; set; }
        public string Influences { get; set; }
        public byte WorksCount { get; set; }
        public string Gender { get; set; }
        public string Hometown { get; set; }
        public decimal AverageRating { get; set; }
        public long RatingsCount { get; set; }
        [XmlElement("born_at")]
        public DateTime Born { get; set; }
        [XmlElement("died_at")]
        public DateTime Died { get; set; }
        public bool? GoodreadsAuthor { get; set; }
        public GoodreadsResponseAuthorUser User { get; set; }
        [XmlArrayItem("book", IsNullable = false)]
        public List<Book> Books { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class GoodreadsResponseAttribute
    {
        [XmlAttribute()]
        public string Type { get; set; }
        [XmlText()]
        public long Value { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class GoodreadsResponseAuthorUser
    {
        public GoodreadsResponse Id { get; set; }//Possible Int
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class Work
    {
        public long Id { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class Book
    {
        public long Id { get; set; }
        public string Isbn { get; set; }
        public string Isbn13 { get; set; }
        public string Asin { get; set; }
        public string KindleAsin { get; set; }
        public string TextReviewsCount { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string TitleWithoutSeries { get; set; }
        public string ImageUrl { get; set; }
        public string SmallImageUrl { get; set; }
        public string LargeImageUrl { get; set; }
        public string Link { get; set; }
        public string NumPages { get; set; }
        public string Format { get; set; }
        public string EditionInformation { get; set; }
        public string Publisher { get; set; }
        public string PublicationDay { get; set; }
        public string PublicationYear { get; set; }
        public string PublicationMonth { get; set; }
        public decimal AverageRating { get; set; }
        public Work Work { get; set; }
        public long RatingsCount { get; set; }
        public string Description { get; set; }
        public List<Author> Authors { get; set; }
        public short Published { get; set; }
        public List<Book> SimilarBooks { get; set; }
    }
}
