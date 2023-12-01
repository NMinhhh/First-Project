using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    private bool isGrounded;
    public PlayerJumpState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = player.CheckGrounded();
    }

    public override void Enter()
    {
        base.Enter();
        SoundFXManager.Instance.CreateAudio(playerData.audioClips[1], player.transform, 1);
        player.DeCreaseAmountOfJump();
        player.SetVelocityY(playerData.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
        InputManager.Instance.UseJumpInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isGrounded)
        {
            stateMachine.ChangeState(player.InAirState);
        }
      
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
