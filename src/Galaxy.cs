public class Galaxy : Location{
    new public static Location New(string name){
        var data = new LocationData(name, "Galaxy");
        return new Galaxy(data);
    }
    public Galaxy(LocationData data): base(data){
        this.data = data;
    }
    public override void Init()
    {
        base.Init();
        // create uninitialized clusters
        AddChild(Cluster.New(Exquisite.ClusterName()));
    }
}