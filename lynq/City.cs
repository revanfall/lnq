namespace lynq
{
    public class City
    {
        public string Name { get; set; }
        public string Monuments { get; set; }

        public City(string name, string monuments)
        {
            Name = name;
            Monuments = monuments;
        }
    }
}