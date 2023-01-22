using System.Text.Json;
using System.Reflection;

public class SimData{
    public Dictionary<Guid,Location> locations;
    public Guid? rootId = null;
    public SimData(){
        locations = new Dictionary<Guid, Location>();
    }
}
public class Sim{
    private static SimData? data = null;
    private static JsonSerializerOptions jsonOptions = new JsonSerializerOptions {WriteIndented = true, IncludeFields = true};
    public static SimData Data{get{
        if(data == null) throw new Exception("Sim was not initialized!");
        return data;
    }}
    public static void Init(){
        data = new SimData();
        var galaxy = Galaxy.New("Galaxy");
        data.rootId = galaxy.data.id;
        AddLocation(galaxy);
        galaxy.Init();
    }
    public static void Load(string sourceFile){
        if(!File.Exists(sourceFile)) throw new Exception($"Source path {sourceFile} does not exist!");
        var text = File.ReadAllText(sourceFile);
        // This should probably be wrapped in a try/catch block
        data = JsonSerializer.Deserialize<SimData>(text, jsonOptions);
        if(data == null) throw new Exception("dunno");
        // Convert the locations into their true types
        foreach (var (id, location) in data.locations.AsEnumerable())
        {
            switch (location.data.type)
            {
                case "Galaxy":
                data.locations[id] = new Galaxy(location.data);
                break;
                case "Cluster":
                data.locations[id] = new Cluster(location.data);
                break;
                case "StarSystem":
                data.locations[id] = new StarSystem(location.data);
                break;
                default:
                break;
            }
        }
    }
    public static void Save(string destFile, SimData? simData = null){
        if(simData == null) simData = Data;
        var text = JsonSerializer.Serialize(simData, jsonOptions);
        File.WriteAllText(destFile, text);
    }
    public static void AddLocation(Location location){
        Data.locations.Add(location.data.id, location);
    }
    public static Location InitLocation(Guid id){
        var location = Data.locations[id];
        if(!location.data.initialized){
            location.Init();
        }
        return location;
    }
    public static void InitLocationTree(Guid rootId){
        var location = InitLocation(rootId);
        foreach (var childId in location.data.childIds)
        {
            InitLocationTree(childId);
        }
    }
    public static SimData GetLocation(Guid id, bool deep){
        if(!Data.locations.ContainsKey(id)) throw new Exception($"Id {id} does not exist!");
        var openIds = new Queue<Guid>();
        openIds.Enqueue(id);
        if(deep) InitLocationTree(id);
        else InitLocation(id);
        // var root = Data.locations[id];
        // Console.WriteLine(root.GetType().Name);
        // root.Init();
        var simData = new SimData();
        simData.rootId = id;
        while(openIds.Count() > 0){
            var location = Data.locations[openIds.Dequeue()];
            simData.locations.Add(location.data.id, location);
            foreach (var _id in location.data.childIds)
            {
                openIds.Enqueue(_id);
            }
        }
        return simData;
    }
}