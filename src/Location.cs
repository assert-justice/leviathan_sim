
public class Location{
    public Guid id;
    public string name;
    public Guid? parentId;
    public List<Guid> children;
    public Vector3 localPosition;
    public bool initialized;
    public Location(Guid? parentId = null, string name = "[No Name Provided]", Vector3? localPosition = null){
        this.id = System.Guid.NewGuid();
        this.localPosition = localPosition == null ? new Vector3() : localPosition;
        this.initialized = false;
        this.parentId = parentId;
        this.name = name;
        children = new List<Guid>();
        Sim.AddLocation(this);
    }
    public void AddChild(Location child){
        children.Add(child.id);
        child.parentId = id;
    }
    virtual public void Init(){
        // Does nothing, designed to be overridden.
        initialized = true;
    }
}