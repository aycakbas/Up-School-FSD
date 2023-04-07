namespace Domain.Entities
{
    public class NoteCategory
    {
        // NoteCategory 

        public Guid NoteId { get; set; }
        public Note Note { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
