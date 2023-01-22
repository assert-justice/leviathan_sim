public class StarSystem : Location{
    new public static Location New(string name){
        var data = new LocationData(name, "StarSystem");
        return new StarSystem(data);
    }
    public StarSystem(LocationData data): base(data){
        this.data = data;
    }
}