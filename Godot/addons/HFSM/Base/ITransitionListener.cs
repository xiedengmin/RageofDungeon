namespace GodotHFSM;

public interface ITransitionListener {
    void BeforeTransition();
    void AfterTransition();
}
