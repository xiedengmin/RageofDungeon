//namespace GodotHFSM.MonsterAI;
namespace ET
{
    using Godot;
    using GodotHFSM;
    using HCoroutines;
    using System;
    using System.Collections;



    public partial class Goblin : Monster
    {
        //  [Export] public BulletSpawner bulletSpawn;
        private MonsterStatus status;

        private StateMachine<string, State, string> _fsm;

        /// <summary>
        /// Internal fields
        /// </summary>
        private int _patrolDirection = 1;
        private Node2D _player;
        private Vector2 _lastSeenPlayerPosition;
        private Vector2 _nextPosition;

        /// <summary>
        /// Parameters (can be changed in the inspector)
        /// </summary>
        // [Export] public Animator animator;
        [Export] public float AttackRange { get; set; } = 60;
        [Export] public float AttackSpeed { get; set; } = 150;
        [Export] public float ChaseSpeed { get; set; } = 200;
        [Export] public Vector2[] PatrolPoints { get; set; } = Array.Empty<Vector2>();
        [Export] public float PatrolSpeed { get; set; } = 150;
        [Export] public float SearchRange { get; set; } = 150;
        [Export] public float SearchSpotRange { get; set; } = 350;
        /// <summary>
        /// in seconds
        /// </summary>
        [Export] public float SearchTime { get; set; } = 20;
        [Export] public Label StateDisplayText { get; set; }

        /// <summary>
        /// Helper methods (depend on how your scene has been set up)
        /// </summary>
        private Vector2? PlayerPosition => _player?.Position;
        private float? DistanceToPlayer => PlayerPosition?.DistanceTo(Position);

        public enum State
        {
            Patrol = 0,
            Chase = 1,
            Fight = 2,
            Search = 3,
            Wait = 4,
            Telegraph = 5,
            Hit = 6
        }
        public enum FightState
        {
            Wait = 0,
            Telegraph = 1,
            Hit = 2
        }

        public override void _Ready()
        {
            base._Ready();
            _nextPosition = Position;

            // Root FSM
            _fsm = new();

            // Patrol
            _fsm.AddState(State.Patrol, new CoState<State>(Patrol, loop: false));

            _fsm.SetStartState(State.Patrol);

            // Chase
            _fsm.AddState(State.Chase,
              onLogic: (_, delta) =>
              {
                  if (PlayerPosition.HasValue)
                  {
                      MoveTowards(PlayerPosition.Value, ChaseSpeed, delta);
                  }
              }
            );

            _fsm.AddTriggerTransition("PlayerSpotted", State.Patrol, State.Chase);

            // Fight
            HybridStateMachine<State, FightState, string> fightFsm = new(
              beforeOnLogic: (_, delta) =>
              {
                  if (PlayerPosition.HasValue)
                  {
                      MoveTowards(PlayerPosition.Value, AttackSpeed, delta, 40);

                  }
              },
              needsExitTime: true
            );

            // Fight/Wait
            fightFsm.AddState(FightState.Wait /*, onEnter: state => animator.Play("GuardIdle")*/);

            // Because the exit transition should have the highest precedence,
            // it is added before the other transitions.
            fightFsm.AddExitTransition(FightState.Wait);

            // Fight/Telegraph
            fightFsm.AddState(FightState.Telegraph /*, onEnter: state => animator.Play("GuardTelegraph")*/);

            fightFsm.AddTransition(new TransitionAfter<FightState>(FightState.Wait, FightState.Telegraph, 0.5f));

            // Fight/Hit
            fightFsm.AddState(FightState.Hit,
              _ =>
              {
                  //animator.Play("GuardHit");
                  // TODO: Cause damage to player if in range.
                  var rockInstance = (paowu)GD.Load<PackedScene>("res://Prefabs/bullet/paowu/paowu.tscn").Instantiate();

                  // 设置石头的初始位置和方向
                  //  rockInstance.GlobalPosition = GlobalPosition;
                  //  var playerPosition = GlobalManager.Instance.main.player.GlobalPosition;
                  //  var dirbullet = new Vector2(playerPosition.X - rockInstance.GlobalPosition.X, playerPosition.Y - rockInstance.GlobalPosition.Y);
                  //  rockInstance.SetDirection(new Vector2(dirbullet.X > 0 ? 1 : -1, dirbullet.Y > 0 ? -0.5f : -0.5f));
                  AddChild(rockInstance);
              }
            );

            fightFsm.AddTransition(new TransitionAfter<FightState>(FightState.Telegraph, FightState.Hit, 0.42f));

            fightFsm.AddTransition(new TransitionAfter<FightState>(FightState.Hit, FightState.Wait, 0.5f));

            _fsm.AddState(State.Fight, fightFsm);

            _fsm.AddTwoWayTransition(State.Chase, State.Fight, condition: _ => DistanceToPlayer <= AttackRange);

            // Search
            _fsm.AddState(State.Search, new CoState<State>(Search, loop: false));

            _fsm.AddTransition(State.Chase, State.Search, condition: _ => DistanceToPlayer > SearchSpotRange,
                                                          onTransition: _ => _lastSeenPlayerPosition = PlayerPosition.Value);

            _fsm.AddTransition(State.Search, State.Chase, condition: _ => DistanceToPlayer <= SearchSpotRange);
            _fsm.AddTransition(new TransitionAfter<State>(State.Search, State.Patrol, SearchTime));

            _fsm.Init();
            //  StateDisplayText = GetNode<Label>("StateLabel");

            status = new MonsterStatus();
            status.ID = 1;
            status.InitData();
        }

        public override void _Process(double delta)
        {
            StateDisplayText.Text = _fsm.GetActiveHierarchyPath();
        }

        public override void _PhysicsProcess(double delta)
        {
            _fsm.OnLogic(delta);
            Position = _nextPosition;
        }

        /// <summary>
        /// Triggers the `PlayerSpotted` event.
        /// </summary>
        /// <param name="body"></param>
        private void OnDetectionAreaBodyEntered(Node2D body)
        {
            var baseTypeName = body.GetType().BaseType.Name;
            //  if (body.IsInGroup("Player"))
            if (baseTypeName == "Character")
            {
                _player = body;
                try
                {
                    _fsm.Trigger("PlayerSpotted");
                }
                catch (Exception e)
                {
                    //  GD.PrintErr(e); //第一次总是提示 协程已死
                    _fsm.Trigger("PlayerSpotted");
                }
            }
        }
        private void MoveTowards(Vector2 target, float speed, double delta, float minDistance = 0)
        {
            _nextPosition = Position.MoveToward(
            target,
            Mathf.Max(0, Mathf.Min(speed * (float)delta, Position.DistanceTo(target) - minDistance))
          );
        }

        private IEnumerator MoveToPosition(Vector2 target, float speed, double delta, float tolerance = 0.05f)
        {
            while (Position.DistanceTo(target) > tolerance)
            {
                MoveTowards(target, speed, delta);
                // Wait one frame.
                yield return null;
            }
        }

        private IEnumerator Patrol()
        {
            int currentPointIndex = FindClosestPatrolPoint();

            while (true)
            {
                yield return MoveToPosition(PatrolPoints[currentPointIndex], PatrolSpeed, Co.DeltaTime);

                // Wait at each patrol point.
                yield return Co.Wait(3);

                currentPointIndex += _patrolDirection;

                // Once the bot reaches the end or the beginning of the patrol path,
                // it reverses the direction.
                if (currentPointIndex >= PatrolPoints.Length || currentPointIndex < 0)
                {
                    currentPointIndex = Mathf.Clamp(currentPointIndex, 0, PatrolPoints.Length - 1);
                    _patrolDirection *= -1;
                }
            }
        }

        private int FindClosestPatrolPoint()
        {
            float minDistance = Position.DistanceTo(PatrolPoints[0]);
            int minIndex = 0;

            for (int i = 1; i < PatrolPoints.Length; i++)
            {
                float distance = Position.DistanceTo(PatrolPoints[i]);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minIndex = i;
                }
            }

            return minIndex;
        }

        private IEnumerator Search()
        {
            yield return MoveToPosition(_lastSeenPlayerPosition, ChaseSpeed, Co.DeltaTime);

            while (true)
            {
                yield return Co.Wait(2);

                yield return MoveToPosition(
                  Position + RandomInsideCircle(SearchRange),
                  PatrolSpeed,
                  Co.DeltaTime
                );
            }
        }

        private static Vector2 RandomInsideCircle(float radius)
        {
            double r = Mathf.Sqrt(Random.Shared.NextSingle()) * radius;
            double theta = Random.Shared.NextSingle() * 2 * Mathf.Pi;
            return new Vector2((float)(r * Mathf.Cos(theta)), (float)(r * Mathf.Sin(theta)));
        }


        // 受到伤害
        public override void OnHurtBoxAreaEntered(Area2D area)
        {
            base.OnHurtBoxAreaEntered(area);
            var attackData = (AttackData)area.Owner.Get("attackData");
            bool direction = GetDirection();
            int dir = direction ? 1 : -1;
            _knockback = Vector2.Right * attackData.XOffset * dir;

            status.HP -= attackData.Damage;
            if (status.HP < 0)
            {
                status.HP = 0;
                QueueFree();
            }
            GlobalManager.Instance.main.monsterHP.ShowHp(type, status);
        }

    }

}