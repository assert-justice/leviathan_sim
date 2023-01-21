
// For our sins, the Sim class is a singleton.
// It is initialized once in Program.cs
public class Sim{
    private static Sim? instance = null;
    public Dictionary<Guid,Location> locations;
    public static Sim Get(){
        if(instance == null) throw new Exception("Sim was not initialized!");
        return instance;
    }
    public static void Init(){
        if(instance != null) throw new Exception("Attempted to initialize Sim multiple times!");
        instance = new Sim();
    }
    private Sim(){
        locations = new Dictionary<Guid, Location>();
    }
    public static void AddLocation(Location location){
        Get().locations.Add(location.id, location);
    }
}