using Godot;

namespace ET
{
    public class HPChange1 : AEvent<EventType.HPChange>
    {
        protected override async void Run(EventType.HPChange args)
        {
            await ETTask.CompletedTask;
        }
    }
}
