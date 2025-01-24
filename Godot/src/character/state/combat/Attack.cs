using Godot;
using System.Collections.Generic;
using System;

namespace ET {
public partial class Attack : IState
{
    // [Signal]
    //  public delegate void FinishedEventHandler(string nextStateName);
    private AudioStream attack1Sound = (AudioStream)GD.Load("res://assets/sounds/swordman/sm_atk_01.ogg");
    private AudioStream attack2Sound = (AudioStream)GD.Load("res://assets/sounds/swordman/sm_atk_02.ogg");
    private AudioStream attack3Sound = (AudioStream)GD.Load("res://assets/sounds/swordman/sm_atk_03.ogg");

    [Export]
    public int MAX_COMBO_COUNT = 3; // 普攻最大连击数

    private int comboCount = 0; // 当前连击数
    public List<string> combo = new List<string> { "attack1", "attack2", "attack3" };
    public bool isCombo = true; // 是否继续攻击
    public bool canCombo = true; // 是否可以combo



    public override void Enter()
    {
        comboCount = 0;
        Owner.GetNode<AnimationPlayer>("AnimationPlayer").Play("attack1");
        comboCount = 1;
    }


    public override void HandleInput(InputEvent @event)
    {
        if (@event.IsActionPressed("attack"))
        {
            //  if (Input.IsActionPressed("attack"))
            //  {
            isCombo = true;
            //  }
        }
        else if (@event.IsActionReleased("attack"))
        {
            isCombo = false;
        }

        if (canCombo && isCombo)
        {
            PlayCombo();
            canCombo = false;
        }
        base.HandleInput(@event);
    }

    public override void OnAnimationFinished(string animName)
    {
        if (isCombo)
        {
            PlayCombo();
        }
        else
        {
            isCombo = true;
            EmitSignal(SignalName.Finished, "idle");
        }
    }

    public void PlayCombo()
    {
        Owner.GetNode<AnimationPlayer>("AnimationPlayer").Play(combo[comboCount]);
        comboCount += 1;
        if (comboCount > MAX_COMBO_COUNT - 1)
        {
            comboCount = 0;
        }
    }

    public void AttackSound()
    {
        var soundPlayer = Owner.GetNode<AudioStreamPlayer>("AudioStreamPlayer");
        if (soundPlayer.Playing)
        {
            soundPlayer.Stop();
        }

        int random = (int)Math.Ceiling((float)GD.RandRange(0, 3));
        switch (random)
        {
            case 1:
                soundPlayer.Stream = attack1Sound;
                break;
            case 2:
                soundPlayer.Stream = attack2Sound;
                break;
            case 3:
                soundPlayer.Stream = attack3Sound;
                break;
        }

        soundPlayer.Play();
    }
}


}