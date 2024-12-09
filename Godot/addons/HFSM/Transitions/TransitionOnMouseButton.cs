namespace GodotHFSM;

using Godot;

public static class TransitionOnMouseButton {
    public class Down<TStateId> : TransitionBase<TStateId> {
        private readonly MouseButton _button;

        /// <summary>
        /// Initializes a new transition that triggers, while a mouse button is down.
        /// It behaves like Input.IsMouseButtonPressed(...).
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="button">The mouse button to watch.</param>
        /// <param name="forceInstantly"></param>
        public Down(
                TStateId from,
                TStateId to,
                MouseButton button,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _button = button;
        }

        public override bool ShouldTransition() {
            return Input.IsMouseButtonPressed(_button);
        }
    }

    public class Release<TStateId> : TransitionBase<TStateId> {
        private readonly MouseButton _button;
        private bool? _wasPressed;

        /// <summary>
        /// Initializes a new transition that triggers, when a mouse button was just down and is up now.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="button">The mouse button to watch.</param>
        /// <param name="forceInstantly"></param>
        public Release(
                TStateId from,
                TStateId to,
                MouseButton button,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _button = button;
        }

        public override bool ShouldTransition() {
            bool isPressed = Input.IsMouseButtonPressed(_button);
            bool shouldTransition = _wasPressed == true && !isPressed;
            _wasPressed = isPressed;
            return shouldTransition;
        }
    }

    public class Press<TStateId> : TransitionBase<TStateId> {
        private readonly MouseButton _button;
        private bool? _wasPressed;

        /// <summary>
        /// Initializes a new transition that triggers, when a mouse button was just up and is down now.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="button">The mouse button to watch.</param>
        /// <param name="forceInstantly"></param>
        public Press(
                TStateId from,
                TStateId to,
                MouseButton button,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _button = button;
        }

        public override bool ShouldTransition() {
            bool isPressed = Input.IsMouseButtonPressed(_button);
            bool shouldTransition = _wasPressed == false && isPressed;
            _wasPressed = isPressed;
            return shouldTransition;
        }
    }

    public class Up<TStateId> : TransitionBase<TStateId> {
        private readonly MouseButton _button;

        /// <summary>
        /// Initializes a new transition that triggers, while a mouse button is up.
        /// It behaves like ! Input.IsMouseButtonPressed(...).
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="button">The mouse button to watch.</param>
        /// <param name="forceInstantly"></param>
        public Up(
                TStateId from,
                TStateId to,
                MouseButton button,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _button = button;
        }

        public override bool ShouldTransition() {
            return !Input.IsMouseButtonPressed(_button);
        }
    }

    public class Down : Down<string> {
        public Down(
            string @from,
            string to,
            MouseButton button,
            bool forceInstantly = false) : base(@from, to, button, forceInstantly) {
        }
    }

    public class Release : Release<string> {
        public Release(
            string @from,
            string to,
            MouseButton button,
            bool forceInstantly = false) : base(@from, to, button, forceInstantly) {
        }
    }

    public class Press : Press<string> {
        public Press(
            string @from,
            string to,
            MouseButton button,
            bool forceInstantly = false) : base(@from, to, button, forceInstantly) {
        }
    }

    public class Up : Up<string> {
        public Up(
            string @from,
            string to,
            MouseButton button,
            bool forceInstantly = false) : base(@from, to, button, forceInstantly) {
        }
    }
}
