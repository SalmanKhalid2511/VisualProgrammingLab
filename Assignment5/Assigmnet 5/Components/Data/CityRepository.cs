namespace CityButtonApp.Data
{
    public static class CityRepository
    {
        public static List<string> GetCities()
        {
            return new List<string> { "New York", "London", "Tokyo", "Paris", "Sydney" };
        }
    }
}
