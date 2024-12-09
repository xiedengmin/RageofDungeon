using Godot;
using Godot.Collections;
using System;

public partial class SkillSlot : TextureRect
{
    private TextureRect icon;
    private TextureRect select;
    private Label lv;
    private TextureRect static_lv;

    public override void _Ready()
    {
        icon = GetNode<TextureRect>("Icon");
        select = GetNode<TextureRect>("select");
        lv = GetNode<Label>("lv");
        static_lv = GetNode<TextureRect>("static_lv");
    }

    public override Variant _GetDragData(Vector2 pos)
    {
       if (DataManager.Instance.skillData.data[((dynamic)GetParent().GetParent()).selectIndex][GetIndex()] != null)
        {
            var data = new Dictionary();
            data["origin_node"] = icon;
            data["origin_panel"] = "SkillInventory";
          var skl = DataManager.Instance.skillData.data[GetParent().GetParent<SkillInventory>().selectIndex][GetIndex()];
            data["origin_item_id"] = skl;
           data["origin_skill_class"] = ConfigManager.Instance.skillConfigProxy.GetClassByID(DataManager.Instance.roleData.job,(int) skl["id"]);
            data["origin_texture"] = icon.Texture;

            var drag_texture = new TextureRect();
          //err  drag_texture.Expand = true;
            drag_texture.Texture = icon.Texture;
            drag_texture.Size = new Vector2(28, 28);

            var control = new Control();
            control.AddChild(drag_texture);
            drag_texture.Position = -0.5f * drag_texture.Size;
            SetDragPreview(control);

            return data;
        }
        return 0;
    }

    public override bool _CanDropData(Vector2 pos, Variant dataObj)
    {
        var data = (Godot.Collections.Dictionary<string, Variant>)dataObj;
        if (!(data["origin_panel"].ToString() == "SkillInventory") && !(data["origin_panel"].ToString() == "SkillShortcut"))
        {
            return false;
        }

        var target_inv_index = GetIndex();
        if (DataManager.Instance.skillData.data[GetParent().GetParent<SkillInventory>().selectIndex][target_inv_index] == null)
        {
            data["target_item_id"] = 0;
            data["target_texture"] = 0;
            return true;
        }
        else
        {
            var skl = DataManager.Instance.skillData.data[GetParent().GetParent<SkillInventory>().selectIndex][target_inv_index];
           data["target_item_id"] = skl;
            data["target_texture"] = icon.Texture;
            if (data["origin_panel"].ToString() == "SkillInventory")
            {
                var target_skill_class = ConfigManager.Instance.skillConfigProxy.GetClassByID(DataManager.Instance.roleData.job,(int) skl["id"]);
                if (target_skill_class ==(int) data["origin_skill_class"])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }

    public override void _DropData(Vector2 _pos, Variant dataObj)
    {
        var data = (Dictionary<string, Variant>)dataObj;
        var target_inv_index = GetIndex();
        var origin_index = ((dynamic)data["origin_node"] ).GetParent().GetIndex();

        if (data["origin_panel"].ToString() == "SkillInventory")
        {
          DataManager.Instance.skillData.data[GetParent().GetParent<SkillInventory>().selectIndex][origin_index] = data["target_item_id"];
        }
        else
        {
           DataManager.Instance.skillShortcutData.data[origin_index] = data["target_item_id"];
        }

        if ((int)data["target_item_id"] == 0)
        {
           ((TextureRect)data["origin_node"]).Texture = null;
        }
        else
        {
           ((TextureRect)data["origin_node"] ).Texture =(Texture2D)data["target_texture"] ;
        }

      if (DataManager.Instance.skillData.data[GetParent().GetParent<SkillInventory>().selectIndex][target_inv_index] == null)
        {
            DataManager.Instance.skillData.data[GetParent().GetParent<SkillInventory>().selectIndex][target_inv_index] = new();
        }
        DataManager.Instance.skillData.data[GetParent().GetParent<SkillInventory>().selectIndex][target_inv_index] =  (Dictionary<string, Variant>)data["origin_item_id"];

        icon.Texture = (Texture2D)data["origin_texture"] ;
        lv.Text = ((Dictionary<string, Variant>)data["origin_item_id"])["show_lv"].ToString();
        lv.Visible = true;
        static_lv.Visible = true;

        var origin_visible = (Dictionary<string, Variant>) data["target_item_id"] != null;

       // var slot = (Control)(data["origin_node"] as Node).GetParent().GetParent().GetChild(origin_index);
      //  if (origin_visible)
        {
       //     slot.GetNode<Label>("lv").Text = data["target_item_id"]["show_lv"].ToString();
        }
      //  slot.GetNode<Label>("lv").Visible = origin_visible;
     //  slot.GetNode<TextureRect>("static_lv").Visible = origin_visible; 
    }

    private void _OnSkillSlotMouseEntered()
    {
        select.Visible = true;
       var skl = DataManager.Instance.skillData.data[GetParent().GetParent<SkillInventory>().selectIndex][GetIndex()];
        if (skl.Count>0)
        {
         GlobalManager.Instance.main.OnShowToolTipSkill((int)skl["id"], (int)skl["show_lv"], GetLocalMousePosition());
        }
    }

    private void _OnSkillSlotMouseExited()
    {
        select.Visible = false;
        GlobalManager.Instance.main.OnHideToolTipSkill();
    }
}