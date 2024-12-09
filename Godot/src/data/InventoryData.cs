using Godot;

public partial class InventoryData 
{
    public  Godot.Collections.Array<Godot.Collections.Array< Godot.Collections.Dictionary<string, Variant> >> data = new ();

    public InventoryData()
    {
        // 构造函数
    }

    public void InitData()
    {

        data[0][0].Add("id", 10007);
        data[0][0].Add("amount", 1);


        data[0][1].Add("id", 10001);
        data[0][1].Add("amount", 1);

        // 以下为注释部分
        // data[0].Add(new Dictionary<string, int> { {"id", 10004}, {"amount", 1} });
        // data[0].Add(new Dictionary<string, int> { {"id", 10001}, {"amount", 1} });
        // data[0].Add(new Dictionary<string, int> { {"id", 10007}, {"amount", 1} });
        // data[0].Add(new Dictionary<string, int> { {"id", 10010}, {"amount", 1} });
    }
}
