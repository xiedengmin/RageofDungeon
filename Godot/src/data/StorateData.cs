using Godot;
using System;
using System.Collections.Generic;

namespace ET {
public partial class StorateData : Node
{
    // Define a list to hold data
    public Godot.Collections.Array<Variant> data { get; set; } = new ();

    // Constructor
    public StorateData()
    {
        // Initialize data if necessary
        // Data.Resize(10); // Uncomment this line if you need to resize the list to a specific size
    }
}

}