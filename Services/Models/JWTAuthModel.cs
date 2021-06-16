namespace Services.Models
{
    public class JWTAuthModel
    {
        public AccessToken jwt { get; set; }
        public Entities.User.User user { get; set; }
        public string ExtentionsNumber { get; set; }

    }
}
