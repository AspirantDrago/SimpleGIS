using SimpleGIS.obj;

namespace SimpleGIS;

[Serializable]
public class Region
{
    public short Code { get; set; } = -1;
    public string Name { get; set; } = "<unknown>";
    public List<City> Cities { get; set; } = new List<City>();
    
    public Region() {}
    public Region(short code, string name) 
    {
        Code = code;
        Name = name;
    }

    public override string ToString()
    {
        string result = $"({Code}) {Name}";
        foreach (var city in Cities)
        {
            result += $"\n\t- {city}";
        }
        return result;
    }

    public static void Create(ref Dictionary<short, Region> dc, short code, string name)
    {
        dc[code] = new Region(code, name);
    }
}