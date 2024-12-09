using Godot;
using Godot.Collections;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

public partial class JobUpConfig : BaseConfig
{
    public JobUpConfig()
    {
        LoadJson("res://assets/configs/JobUp.json");
    }

    public  Godot.Collections.Dictionary<string, Variant> GetJobData(string job)
    {
         Godot.Collections.Dictionary<string, Variant> jobData = new ();
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i]["job"].ToString() == job)
            {
                jobData = data[i];
                break;
            }
        }

        return jobData;
    }
}