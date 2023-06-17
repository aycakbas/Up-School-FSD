namespace ChatApplicationApi.Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
    }
}
