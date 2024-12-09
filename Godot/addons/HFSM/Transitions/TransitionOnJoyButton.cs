namespace GodotHFSM;

using Godot;

public static class TransitionOnJoyButton {
    public class Down<TStateId> : TransitionBase<TStateId> {
        private readonly int _device;
        private readonly JoyButton _joyButton;

        /// <summary>
        /// Initializes a new transition that triggers, while a joy button is down.
        /// It behaves like Input.IsJoyButtonPressed(...).
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="device"></param>
        /// <param name="joyButton">The JoyButton of the button to watch.</param>
        /// <param name="forceInstantly"></param>
        public Down(
                TStateId from,
                TStateId to,
                int device,
                JoyButton joyButton,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _device = device;
            _joyButton = joyButton;
        }

        public override bool ShouldTransition() {
            return Input.IsJoyButtonPressed(_device, _joyButton);
        }
    }

    public class Release<TStateId> : TransitionBase<TStateId> {
        private readonly int _device;
        private readonly JoyButton _joyButton;
        private bool _wasPressed;

        /// <summary>
        /// Initializes a new transition that triggers, when a joy button was just down and is up now.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="device"></param>
        /// <param name="joyButton">The JoyButton of the button to watch.</param>
        /// <param name="forceInstantly"></param>
        public Release(
                TStateId from,
                TStateId to,
                int device,
                JoyButton joyButton,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _device = device;
            _joyButton = joyButton;
        }

        public override bool ShouldTransition() {
            bool isPressed = Input.IsJoyButtonPressed(_device, _joyButton);
            bool shouldTransition = _wasPressed && !isPressed;
            _wasPressed = isPressed;
            return shouldTransition;
        }
    }

    public class Press<TStateId> : TransitionBase<TStateId> {
        private readonly int _device;
        private readonly JoyButton _joyButton;
        private bool _wasPressed;

        /// <summary>
        /// Initializes a new transition that triggers, when a joy button was just up and is down now.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="device"></param>
        /// <param name="joyButton">The JoyButton of the button to watch.</param>
        /// <param name="forceInstantly"></param>
        public Press(
                TStateId from,
                TStateId to,
                int device,
                JoyButton joyButton,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _device = device;
            _joyButton = joyButton;
        }

        public override bool ShouldTransition() {
            bool isPressed = Input.IsJoyButtonPressed(_device, _joyButton);
            bool shouldTransition = !_wasPressed && isPressed;
            _wasPressed = isPressed;
            return shouldTransition;
        }
    }

    public class Up<TStateId> : TransitionBase<TStateId> {
        private readonly int _device;
        private readonly JoyButton _joyButton;

        /// <summary>
        /// Initializes a new transition that triggers, while a joy button is up.
        /// It behaves like ! Input.IsJoyButtonPressed(...).
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="device"></param>
        /// <param name="joyButton">The JoyButton of the button to watch.</param>
        /// <param name="forceInstantly"></param>
        public Up(
                TStateId from,
                TStateId to,
                int device,
                JoyButton joyButton,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _device = device;
            _joyButton = joyButton;
        }

        public override bool ShouldTransition() {
            return !Input.IsJoyButtonPressed(_device, _joyButton);
        }
    }

    public class Down : Down<string> {
        public Down(
            string @from,
            string to,
            int device,
            JoyButton joyButton,
            bool forceInstantly = false) : base(@from, to, device, joyButton, forceInstantly) {
        }
    }

    public class Release : Release<string> {
        public Release(
            string @from,
            string to,
            int device,
            JoyButton joyButton,
            bool forceInstantly = false) : base(@from, to, device, joyButton, forceInstantly) {
        }
    }

    public class Press : Press<string> {
        public Press(
            string @from,
            string to,
            int device,
            JoyButton joyButton,
            bool forceInstantly = false) : base(@from, to, device, joyButton, forceInstantly) {
        }
    }

    public class Up : Up<string> {
        public Up(
            string @from,
            string to,
            int device,
            JoyButton joyButton,
            bool forceInstantly = false) : base(@from, to, device, joyButton, forceInstantly) {
        }
    }
}
