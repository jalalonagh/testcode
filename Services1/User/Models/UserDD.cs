using Services;

namespace ViewModels.User
{
    public class dto
    {
        public AccessTokenDto jwt { get; set; }
        public Entities.User.User user { get; set; }
        public string ExtentionsNumber { get; set; }
    }

}
