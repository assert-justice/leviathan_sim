public class Sim{
    public Dictionary<Guid,Location> locations;
    public Sim(){
        locations = new Dictionary<Guid, Location>();
    }
    public void AddLocation(Location location){
        locations.Add(location.id, location);
    }
}