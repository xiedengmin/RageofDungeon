using CommandLine;

namespace ET.Server
{
    public class CreateRobotArgs
    {
        [Option("Num", Required = false, Default = 500)]
        public int Num { get; set; }
    }
}