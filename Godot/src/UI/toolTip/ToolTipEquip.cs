using Godot;
using System;

public partial class ToolTipEquip : Control
{
    public string origin = "";
    public string slot = "";
    public int slotIndex = 0;
    public Vector2 offsetPos = Vector2.Zero;

    public void InitData()
    {
        Vector2 mousePos = GetGlobalMousePosition();
        Vector2 pos = new Vector2(Utils.LessCheck(mousePos.X - Size.X - offsetPos.X, 0),
                                  Utils.LessCheck(mousePos.Y - Size.Y - offsetPos.Y, 0));
        Position = pos;
    }

   // int itemId;
  // if (origin == "Inventory")
   //  {
    //     if (DataManager.InvData.Data[GlobalManager.Main.Bag.selectIndex][slotIndex] != null)
    //     {
    //         itemId = (int)DataManager.InvData.Data[GlobalManager.Main.Bag.selectIndex][slotIndex]["id"];
    //     }
    // }
    // else if (origin == "CharacterSheet")
    // {
    //     if (DataManager.EquipData.EquipmentData[slot] != null)
    //     {
    //         itemId = (int)DataManager.EquipData.EquipmentData[slot]["id"];
    //     }
    // }
    // else if (origin == "Storate")
    // {
    //     if (DataManager.StorateData.Data[slotIndex] != null)
    //     {
    //         itemId = (int)DataManager.StorateData.Data[slotIndex]["id"];
    //     }
    // }
    // else if (origin == "InvShortcut")
    // {
    //     if (DataManager.InvShortcutData.Data[slotIndex] != null)
    //     {
    //         itemId = (int)DataManager.InvShortcutData.Data[slotIndex]["id"];
    //     }
     //}
}