namespace GodotHFSM;

using Godot;

public static class TransitionOnKey {
    public class Down<TStateId> : TransitionBase<TStateId> {
        private readonly Key _keyCode;

        /// <summary>
        /// Initializes a new transition that triggers, while a key is down.
        /// It behaves like Input.IsKeyPressed(...).
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="key">The KeyCode of the key to watch.</param>
        /// <param name="forceInstantly"></param>
        public Down(
                TStateId from,
                TStateId to,
                Key key,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _keyCode = key;
        }

        public override bool ShouldTransition() {
            return Input.IsKeyPressed(_keyCode);
        }
    }

    public class Release<TStateId> : TransitionBase<TStateId> {
        private readonly Key _keyCode;
        private bool _wasPressed;

        /// <summary>
        /// Initializes a new transition that triggers, when a key was just down and is up now.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="key">The KeyCode of the key to watch.</param>
        /// <param name="forceInstantly"></param>
        public Release(
                TStateId from,
                TStateId to,
                Key key,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _keyCode = key;
        }

        public override bool ShouldTransition() {
            bool isPressed = Input.IsKeyPressed(_keyCode);
            bool shouldTransition = _wasPressed && !isPressed;
            _wasPressed = isPressed;
            return shouldTransition;
        }
    }

    public class Press<TStateId> : TransitionBase<TStateId> {
        private readonly Key _keyCode;
        private bool _wasPressed;

        /// <summary>
        /// Initializes a new transition that triggers, when a key was just up and is down now.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="key">The KeyCode of the key to watch.</param>
        /// <param name="forceInstantly"></param>
        public Press(
                TStateId from,
                TStateId to,
                Key key,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _keyCode = key;
        }

        public override bool ShouldTransition() {
            bool isPressed = Input.IsKeyPressed(_keyCode);
            bool shouldTransition = !_wasPressed && isPressed;
            _wasPressed = isPressed;
            return shouldTransition;
        }
    }

    public class Up<TStateId> : TransitionBase<TStateId> {
        private readonly Key _keyCode;

        /// <summary>
        /// Initializes a new transition that triggers, while a key is up.
        /// It behaves like ! Input.IsKeyPressed(...).
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="key">The KeyCode of the key to watch.</param>
        /// <param name="forceInstantly"></param>
        public Up(
                TStateId from,
                TStateId to,
                Key key,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _keyCode = key;
        }

        public override bool ShouldTransition() {
            return !Input.IsKeyPressed(_keyCode);
        }
    }

    public class Down : Down<string> {
        public Down(
            string @from,
            string to,
            Key key,
            bool forceInstantly = false) : base(@from, to, key, forceInstantly) {
        }
    }

    public class Release : Release<string> {
        public Release(
            string @from,
            string to,
            Key key,
            bool forceInstantly = false) : base(@from, to, key, forceInstantly) {
        }
    }

    public class Press : Press<string> {
        public Press(
            string @from,
            string to,
            Key key,
            bool forceInstantly = false) : base(@from, to, key, forceInstantly) {
        }
    }

    public class Up : Up<string> {
        public Up(
            string @from,
            string to,
            Key key,
            bool forceInstantly = false) : base(@from, to, key, forceInstantly) {
        }
    }
}
