using System;

namespace Persist.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins

        // Relation avec d'autres entités si nécessaire
        // public int AuthorId { get; set; }
        // public Author Author { get; set; }
    }
}
