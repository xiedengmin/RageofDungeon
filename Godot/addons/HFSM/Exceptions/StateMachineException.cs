namespace GodotHFSM.Exceptions;

using System;

[Serializable]
public class StateMachineException : Exception {
    public StateMachineException(string message) : base(message) { }

    public StateMachineException() {
    }

    public StateMachineException(string message, Exception innerException) : base(message, innerException) {
    }
}
