public class Program{
    public static void Main(string[] args){
        var cli = new Cli(args);
        if(cli.Match("init")){
            //
            var destFilename = cli.Next();
            Sim.Init();
            Sim.Save(destFilename);
        }
        else if(cli.Match("get")){
            //
            var sourceFilename = cli.NextExtantFile();
            if (cli.Match("location")){
                //
                var rootId = cli.NextGuid();
                var destFilename = cli.Next();
                Sim.Load(sourceFilename);
                var data = Sim.GetLocation(rootId);
                Sim.Save(destFilename, data);
                // Because locations are created lazily as requested the data can be changed.
                // Therefore we need to save the structure back to source.
                Sim.Save(sourceFilename);
            }
            else {
                //
                throw new Exception("Invalid command.");
            }
        }
        else {
            throw new Exception("Invalid command.");
        }
    }
}