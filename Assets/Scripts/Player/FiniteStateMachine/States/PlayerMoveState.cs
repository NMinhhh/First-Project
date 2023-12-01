using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    private float xInput;
    private bool jumpInput;
    private bool isGrounded;
    private bool attackInput;
    private bool dashInput;
    private bool heavyAttackInput;
    private bool waterBlastSkilllInput;
    private bool windSkillInput;
    public PlayerMoveState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        player.smokeAnim.SetBool("smoke", true);
    }

    public override void Exit()
    {
        base.Exit();
        player.smokeAnim.SetBool("smoke", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = InputManager.Instance.xInput;
        jumpInput = InputManager.Instance.jumpInput;
        attackInput= InputManager.Instance.attackInput;
        dashInput = InputManager.Instance.dashInput;
        heavyAttackInput = InputManager.Instance.heavyAttackInput;
        waterBlastSkilllInput = InputManager.Instance.waterBlastSkillInput;
        windSkillInput = InputManager.Instance.windSkillInput;

        player.CheckIfFlip(xInput);
        player.SetVelocityX(playerData.movementSpeed * xInput);

        if (isGrounded && xInput == 0)
        {
                stateMachine.ChangeState(player.IdleState);
        }
        else if (isGrounded && jumpInput)
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if(isGrounded && attackInput)
        {
            stateMachine.ChangeState(player.AttackState);
        }
        else if (!isGrounded && player.CurrentVelocity.y < 0.01)
        {
            stateMachine.ChangeState(player.InAirState);
        }
        else if (dashInput)
        {
            stateMachine.ChangeState(player.DashState);
        }
        else if (heavyAttackInput)
        {
            stateMachine.ChangeState(player.HeavyAttackState);
        }
        else if (waterBlastSkilllInput)
        {
            stateMachine.ChangeState(player.WaterBlastSkillState);
        }
        else if (windSkillInput)
        {
            stateMachine.ChangeState(player.WindSkillState);
        }

    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
