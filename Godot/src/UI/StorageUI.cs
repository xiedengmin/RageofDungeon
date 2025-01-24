using Godot;

namespace ET {
public partial class StorageUI : Control
{
    // 预加载资源
    PackedScene slotResource = (PackedScene)GD.Load("res://scenes/UI/slot/StorateSlot.tscn");

    // 定义OnReady属性
    private GridContainer gridContainer;

    public override void _Ready()
    {
        gridContainer = GetNode<GridContainer>("GridContainer");

        // 获取存储数据
        Godot.Collections.Array<Variant> data = DataManager.Instance.storateData.data;
        foreach (var item in data)
        {
            // 实例化Slot
            var item1 = (Godot.Collections.Dictionary<string, Variant>)item;
            Control slot = (Control)slotResource.Instantiate();

            // 如果item不为空
            if (item1.Count > 0)
            {
                // 获取图标路径并加载纹理
                string iconPath = GLOBALS_TYPE.ICON_PATH + ConfigManager.Instance.equipConfigProxy.GetItemIcon((int)item1["id"]);
                Texture2D iconTexture = (Texture2D)GD.Load<Texture2D>(iconPath);

                // 设置Slot节点中的纹理
                slot.GetNode<TextureRect>("Icon").Texture = iconTexture;
            }

            // 将Slot添加到GridContainer中
            gridContainer.AddChild(slot, true);
        }
    }

    // 按钮点击信号函数
    private void _on_closeBtn_pressed()
    {
        GlobalManager.Instance.main.OnOpenStorate();
    }
}


}