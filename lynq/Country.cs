namespace lynq
{
    public class Country
    {
        public string CountryName { get; set; }
        public string City { get; set; }

        public Country(string countryName, string city)
        {
            CountryName = countryName;
            City = city;
        }
    }
}