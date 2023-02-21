using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapon weapon;
    private int xInput;
    private float velocityToSet;
    private bool setVelocity;
    private bool shouldCheckFlip;
    private int CurrentAttackInput;
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        setVelocity = false;
        weapon.EnterWeapon();
    }

    public override void Exit()
    {
        base.Exit();
        weapon.ExitWeapon();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.InputHandler.NormInputX;
        if (shouldCheckFlip)
        {
            player.CheckIfShouldFlip(xInput);
        }
        if (setVelocity)
        {
            player.SetVelocityX(velocityToSet * player.FacingDirection);
        }
    }

    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        weapon.InitializeWeapon(this);
    }

    public void SetVelocity(float velocity)
    {
        player.SetVelocityX(velocity * player.FacingDirection);
        velocityToSet = velocity;
        setVelocity = true;
    }


    public void GetCurrentInput()
    {
        if (this == player.PrimaryAttackState)
        {
            CurrentAttackInput = 0;
        }
        else if (this == player.SecondaryAttackState)
        {
            CurrentAttackInput = 1;
        }
    }


    public void SetFlipCheck(bool value)
    {
        shouldCheckFlip = value;
    }
    #region Animation Trigger

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }

    public void AnimationComboTrigger()
    {
        if (player.InputHandler.AttackInputs[(int)CombatInputs.primary] && CurrentAttackInput == 0)
        {
            AnimationFinishTrigger();
        }
        else if (player.InputHandler.AttackInputs[(int)CombatInputs.secondary] && CurrentAttackInput == 1)
        {
            AnimationFinishTrigger();
        }
        else if(player.InputHandler.NormInputX != 0)
        {
            AnimationFinishTrigger();
        }

    }

    #endregion
}
