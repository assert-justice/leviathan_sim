public class Cluster : Location{
    new public static Location New(string name){
        var data = new LocationData(name, "Cluster");
        return new Cluster(data);
    }
    public Cluster(LocationData data): base(data){
        this.data = data;
    }
    public override void Init()
    {
        base.Init();
        
        // create uninitialized star systems
        AddChild(StarSystem.New(Exquisite.StarSystemName()));
    }
}