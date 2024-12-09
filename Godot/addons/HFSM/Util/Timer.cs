namespace GodotHFSM;

using Godot;

/// <summary>
/// Default timer that calculates the elapsed time based on Time.GetTicksMsec().
/// </summary>
public class Timer : ITimer {
    private static float GodotTimeAsSeconds => Time.GetTicksMsec() / 1000f;

    public float Elapsed => GodotTimeAsSeconds - StartTime;

    public float StartTime { get; private set; }

    public Timer() {
        StartTime = GodotTimeAsSeconds;
    }

    public void Reset() {
        StartTime = GodotTimeAsSeconds;
    }

    public static bool operator >(Timer timer, float duration)
        => timer.Elapsed > duration;

    public static bool operator <(Timer timer, float duration)
        => timer.Elapsed < duration;

    public static bool operator >=(Timer timer, float duration)
        => timer.Elapsed >= duration;

    public static bool operator <=(Timer timer, float duration)
        => timer.Elapsed <= duration;
}
