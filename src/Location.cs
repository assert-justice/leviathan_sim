
public class Location{
    public Guid id;
    public string name;
    public Guid? parentId;
    public List<Guid> children;
    public Vector3 localPosition;
    public Location(Guid? parentId = null, string name = "[No Name Provided]", Vector3? localPosition = null){
        this.id = System.Guid.NewGuid();
        this.localPosition = localPosition == null ? new Vector3() : localPosition;
        this.parentId = parentId;
        this.name = name;
        children = new List<Guid>();
    }
    public void AddChild(Location child){
        children.Add(child.id);
        child.parentId = id;
    }
}