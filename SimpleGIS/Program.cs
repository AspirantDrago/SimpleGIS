using System.Xml.Serialization;
using SimpleGIS;
using SimpleGIS.obj;

internal class Program
{
    private static Dictionary<short, Region> data = new Dictionary<short, Region>();
    private static XmlSerializer xmlSerializer = new (typeof(
        List<Region>
    ));
    
    private static void Generate()
    {
        Region.Create(ref data, 02, "Башкортостан");
        Region.Create(ref data, 96, "Чечня");
        Region.Create(ref data, 48, "Москва");
        
        data[02].Cities.Add(new City("Стерлитамак", 1.0, 1.0));
        data[02].Cities.Add(new City("Уфа", 2.0, 1.0));
        data[96].Cities.Add(new City("Грозный", 10.0, 30.0));
    }

    private static void SaveToXML(string FileName)
    {
        try
        {
            using (var fs  = new FileStream(FileName, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, data.Values.ToList());
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);
        }
    }

    private static void LoadFromXML(string FileName)
    {
        try
        {
            using (var fs = new FileStream(FileName, FileMode.Open))
            {
                var lst = (List<Region>)xmlSerializer.Deserialize(fs);
                if (lst != null)
                {
                    data.Clear();
                    foreach (var item in lst)
                    {
                        data[item.Code] = item;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);
        }
    }

    private static void Show()
    {
        foreach (var region in data.Values)
        {
            Console.WriteLine(region);
        }
    }

    public static void Main(string[] args)
    {
        // Generate();
        // SaveToXML("Russia.xml");
        LoadFromXML("Russia.xml");
        Show();
    }
}