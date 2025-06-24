namespace SimpleGIS.obj;

[Serializable]
public class City
{
    public string Name { get; set; } = "<unknown>";
    public double Latitude { get; set; } = 0;   // Широта
    public double Longitude { get; set; } = 0;  // Долгота
    
    public City() {}

    public City(string name, double latitude, double longitude)
    {
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
    }

    public override string ToString()
    {
        return $"{Name} ({Latitude},{Longitude})";
    }
}