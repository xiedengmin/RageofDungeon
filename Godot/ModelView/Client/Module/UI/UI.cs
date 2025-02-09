using System.Collections.Generic;
using Godot;

namespace ET.Client
{
    [FriendOf(typeof(UI))]
    public static class UISystem
    {
        [ObjectSystem]
        public class UIAwakeSystem : AwakeSystem<UI, string, Node>
        {
            protected override void Awake(UI self, string name, Node NodeObject)
            {
                self.nameChildren.Clear();
                // NodeObject.layer = LayerMask.NameToLayer(LayerNames.UI);
                self.Name = name;
                self.NodeObject = NodeObject;
            }
        }

        [ObjectSystem]
        public class UIDestroySystem : DestroySystem<UI>
        {
            protected override void Destroy(UI self)
            {
                foreach (UI ui in self.nameChildren.Values)
                {
                    ui.Dispose();
                }
                //self.NodeObject.Dispose();
                self.NodeObject.Free();
                self.NodeObject.Dispose();
                //ResourceLoader.
                //Object.Destroy(self.NodeObject);
                self.nameChildren.Clear();
            }
        }

        //  public static void SetAsFirstSibling(this UI self)
        //  {
        //      self.NodeObject.transform.SetAsFirstSibling();
        //  }

        public static void Add(this UI self, UI ui)
        {
            self.nameChildren.Add(ui.Name, ui);
        }

        public static void Remove(this UI self, string name)
        {
            UI ui;
            if (!self.nameChildren.TryGetValue(name, out ui))
            {
                return;
            }
            self.nameChildren.Remove(name);
            ui.Dispose();
        }

        public static UI Get(this UI self, string name)
        {
            UI child;
            if (self.nameChildren.TryGetValue(name, out child))
            {
                return child;
            }
            Node childNodeObject = self.NodeObject.GetNode(name);
            if (childNodeObject == null)
            {
                return null;
            }
            child = self.AddChild<UI, string, Node>(name, childNodeObject);
            self.Add(child);
            return child;
        }
    }

    [ChildOf()]
    public sealed class UI : Entity, IAwake<string, Node>, IDestroy
    {
        public Node NodeObject { get; set; }

        public string Name { get; set; }

        public Dictionary<string, UI> nameChildren = new Dictionary<string, UI>();
    }
}