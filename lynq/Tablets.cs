namespace lynq
{
    public class Tablets
    {
        public string Model { get; set; }
        public string Brand { get; set; }

        public Tablets(string model, string brand)
        {
            Model = model;
            Brand = brand;
        }
    }
}