public class Cli{
    Stack<string> data;
    public Cli(string[] args){
        data = new Stack<string>(args.Reverse());
    }
    int Count {get {return data.Count;}}
    public string Next(){
        if(data.Count == 0) throw new Exception("Not enough arguments!");
        return data.Pop();
    }
    public string NextExtantFile(){
        var fname = Next();
        if(!File.Exists(fname)) throw new Exception($"File path '{fname}' does not exist!");
        return fname;
    }
    public Guid NextGuid(){
        var str = Next();
        var id = new Guid(str); // TODO: manually validate guid
        return id;
    }
    public bool Match(string str){
        var res = data.Peek() == str;
        if(res) data.Pop();
        return res;
    }
}