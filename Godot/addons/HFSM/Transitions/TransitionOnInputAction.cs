namespace GodotHFSM;

using Godot;

public static class TransitionOnInputAction {
    public class Down<TStateId> : TransitionBase<TStateId> {
        private readonly string _action;
        private readonly bool _exactMatch;

        /// <summary>
        /// Initializes a new transition that triggers, while an action is down.
        /// It behaves like Input.IsActionPressed(...).
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="action"></param>
        /// <param name="exactMatch"></param>
        /// <param name="forceInstantly"></param>
        public Down(
                TStateId from,
                TStateId to,
                string action,
                bool exactMatch = false,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _action = action;
            _exactMatch = exactMatch;
        }

        public override bool ShouldTransition() {
            return Input.IsActionPressed(_action, _exactMatch);
        }
    }

    public class Release<TStateId> : TransitionBase<TStateId> {
        private readonly string _action;
        private readonly bool _exactMatch;

        /// <summary>
        /// Initializes a new transition that triggers, when an action was just down and is up now.
        /// It behaves like Input.IsActionJustReleased(...).
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="action"></param>
        /// <param name="exactMatch"></param>
        /// <param name="forceInstantly"></param>
        public Release(
                TStateId from,
                TStateId to,
                string action,
                bool exactMatch = false,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _action = action;
            _exactMatch = exactMatch;
        }

        public override bool ShouldTransition() {
            return Input.IsActionJustReleased(_action, _exactMatch);
        }
    }

    public class Press<TStateId> : TransitionBase<TStateId> {
        private readonly string _action;
        private readonly bool _exactMatch;

        /// <summary>
        /// Initializes a new transition that triggers, when an action was just up and is down now.
        /// It behaves like Input.IsActionJustPressed(...).
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="action"></param>
        /// <param name="exactMatch"></param>
        /// <param name="forceInstantly"></param>
        public Press(
                TStateId from,
                TStateId to,
                string action,
                bool exactMatch = false,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _action = action;
            _exactMatch = exactMatch;
        }

        public override bool ShouldTransition() {
            return Input.IsActionJustPressed(_action, _exactMatch);
        }
    }

    public class Up<TStateId> : TransitionBase<TStateId> {
        private readonly string _action;
        private readonly bool _exactMatch;

        /// <summary>
        /// Initializes a new transition that triggers, while an action is up.
        /// It behaves like ! Input.IsActionPressed(...).
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="action"></param>
        /// <param name="exactMatch"></param>
        /// <param name="forceInstantly"></param>
        public Up(
                TStateId from,
                TStateId to,
                string action,
                bool exactMatch = false,
                bool forceInstantly = false) : base(from, to, forceInstantly) {
            _action = action;
            _exactMatch = exactMatch;
        }

        public override bool ShouldTransition() {
            return !Input.IsActionPressed(_action, _exactMatch);
        }
    }

    public class Down : Down<string> {
        public Down(
            string @from,
            string to,
            string action,
            bool exactMatch = false,
            bool forceInstantly = false) : base(@from, to, action, exactMatch, forceInstantly) {
        }
    }

    public class Release : Release<string> {
        public Release(
            string @from,
            string to,
            string action,
            bool exactMatch = false,
            bool forceInstantly = false) : base(@from, to, action, exactMatch, forceInstantly) {
        }
    }

    public class Press : Press<string> {
        public Press(
            string @from,
            string to,
            string action,
            bool exactMatch = false,
            bool forceInstantly = false) : base(@from, to, action, exactMatch, forceInstantly) {
        }
    }

    public class Up : Up<string> {
        public Up(
            string @from,
            string to,
            string action,
            bool exactMatch = false,
            bool forceInstantly = false) : base(@from, to, action, exactMatch, forceInstantly) {
        }
    }
}
