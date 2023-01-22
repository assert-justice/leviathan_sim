
public class LocationData{
    public Guid id;
    public string name;
    public Guid? parentId;
    public List<Guid> childIds;
    public Vector3 localPosition;
    public bool initialized;
    public string type;
    public Dictionary<string, string> properties;
    
    public LocationData(string name, string type){
        this.name = name;
        this.type = type;
        id = System.Guid.NewGuid();
        parentId = new Guid();
        childIds = new List<Guid>();
        localPosition = new Vector3();
        initialized = false;
        properties = new Dictionary<string, string>();
    }
}
public class Location{
    public LocationData data;
    public static Location New(string name){
        var data = new LocationData(name, "Location");
        return new Location(data);
    }
    public Location(LocationData data){
        this.data = data;
    }
    public void AddChild(Location child){
        data.childIds.Add(child.data.id);
        child.data.parentId = data.id;
        Sim.AddLocation(child);
    }
    virtual public void Init(){
        data.initialized = true;
    }
}