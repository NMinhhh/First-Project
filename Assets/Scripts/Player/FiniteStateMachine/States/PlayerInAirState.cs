using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool isGrounded;
    private float xInput;
    private bool jumpInput;
    private bool canJump;
    private bool canCyoteJump;
    private bool attackInput;
    private bool dashInput;
    public PlayerInAirState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        canJump = false;
        isGrounded = player.CheckGrounded();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAnimation()
    {
        base.FinishAnimation();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = InputManager.Instance.xInput;
        jumpInput = InputManager.Instance.jumpInput;
        attackInput = InputManager.Instance.attackInput;
        dashInput = InputManager.Instance.dashInput;
        player.CheckIfFlip(xInput);
        player.SetVelocityX(playerData.movementSpeed * xInput);

        canCyoteJump = (Time.time <= startTime + playerData.coyoteJumpTime ? true : false);

        if (Time.time > startTime + playerData.jumpCooldown && jumpInput && player.LeftAmountOfJump > 0)
        {
            canJump = true;
        }

        if (isGrounded && player.CurrentVelocity.y < 0.1)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if (canJump)
        {
            InputManager.Instance.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }else if(canCyoteJump && player.LeftAmountOfJump == playerData.amountOfJump && jumpInput)
        {
            stateMachine.ChangeState(player.JumpState);
        }else if (attackInput && player.AmountOfJumpAttack < 3)
        {
            stateMachine.ChangeState(player.JumpAttackState);
        }else if (dashInput)
        {
            stateMachine.ChangeState(player.DashState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
    }
}
