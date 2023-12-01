using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private Transform attackPoint;
    public PlayerAttackState(Player player, StateMachine stateMachine, PlayerData playerData, string animBoolName, Transform attackPoint) : base(player, stateMachine, playerData, animBoolName)
    {
        this.attackPoint = attackPoint;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        player.Anim.SetInteger("attackCounter", player.AmountOfAttack);
        player.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
        player.ComboAttack();
        if (player.AmountOfAttack >= 3)
            player.SetAmountOfAttack();
        InputManager.Instance.UseAttackInput();
    }

    public override void FinishAnimation()
    {
        base.FinishAnimation();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isFinishAnimation)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void TriggerAnimation()
    {
        base.TriggerAnimation();
        player.attackDetails.attackDamage = player.AmountDamage();
        player.attackDetails.attackPos = player.transform;
        int amountSound = 1;
        if (player.AmountOfAttack < 2)
        {
            RaycastHit2D[] hit = Physics2D.BoxCastAll(attackPoint.position, playerData.attackSize, 0, Vector2.right, 0, playerData.whatIsEnemy);
            foreach (RaycastHit2D col in hit)
            {
                if (col)
                {
                    if(amountSound == 1)
                    {
                        SoundFXManager.Instance.CreateAudio(playerData.audioClips[0], player.transform, 1);
                        amountSound++;
                    }
                    col.transform.SendMessage("Damage", player.attackDetails);
                }
            }
        }
        else
        {
            Collider2D[] hit2 = Physics2D.OverlapCircleAll(attackPoint.position, playerData.attackRadius, playerData.whatIsEnemy);
            foreach (Collider2D col in hit2)
            {
                if (col)
                {
                    if (amountSound == 1)
                    {
                        SoundFXManager.Instance.CreateAudio(playerData.audioClips[0], player.transform, 1);
                        amountSound++;
                    }
                    col.transform.SendMessage("Damage", player.attackDetails);
                }
            }
        }
       

    }
}
