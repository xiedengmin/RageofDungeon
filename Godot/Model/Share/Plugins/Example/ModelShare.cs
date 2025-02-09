using Godot;
public class ModelShare
{
    #if GODOT
    public static void PrintNodePaths(Node node)
    {
        GD.Print(node.GetPath());
        foreach (Node child in node.GetChildren())
        {
            PrintNodePaths(child);
        }
    }
#endif
}
