using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public float xInput { get; private set; }
    public bool jumpInput { get; private set; }
    public bool attackInput { get; private set; }

    public bool heavyAttackInput { get; private set; }
    public bool dashInput { get; private set; }
    public bool waterBlastSkillInput { get; private set; }
    public bool windSkillInput { get; private set; }
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
        xInput = 0;
    }

    public void MoveLeftDownInput() => xInput = -1;

    public void MoveRightDownInput() => xInput = 1;

    public void MoveUpInput() => xInput = 0;

    public void JumpDownInput() => jumpInput = true;

    public void JumpUpInput() => jumpInput = false;

    public void UseJumpInput() => jumpInput = false;

    public void AttackDownInput() => attackInput = true;

    public void AttackUpInput() => attackInput = false;

    public void UseAttackInput() => attackInput = false;

    public void DashDownInput()
    {
        dashInput = true;
    }
    
    public void DashUpInput() => dashInput = false;
    
    public void UseDashInput() => dashInput = false;
    public void HeavyAttackDownInput() => heavyAttackInput = true;
    
    public void HeavyAttackUpInput() => heavyAttackInput = false;
    
    public void UseHeavyAttackInput() => heavyAttackInput = false;

    public void WaterBlastDownInput() => waterBlastSkillInput = true;

    public void WaterBlastUpInput() => waterBlastSkillInput = false; 
    public void WindSkillDownInput() => windSkillInput = true;

    public void WindSkillUpInput() => windSkillInput = false;
}
