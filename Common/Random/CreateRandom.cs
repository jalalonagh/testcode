namespace Common.Random
{
    public class CreateRandom
    {
        private readonly System.Random _random = new System.Random();

        public int RandomNumber()
        {
            return _random.Next(1000000, 9999999);
        }

        public int RandomNumber4()
        {

            return _random.Next(1000, 9999);
        }
    }
}