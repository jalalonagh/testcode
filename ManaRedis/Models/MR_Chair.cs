namespace ManaRedis.Models
{
    public class MR_Chair
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object? Roles { get; set; }
        public object? ChairToUsers { get; set; }
    }
}
