using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchingWallState : PlayerState
{
    protected bool isGrounded = true;
    protected bool isTouchingWall;
    protected int xInput;
    public PlayerTouchingWallState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckIfGrounded();
        isTouchingWall = player.CheckIfTouchingWall();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetIsDashing(false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        if (isGrounded)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if (player.InputHandler.JumpInput)
        {
            stateMachine.ChangeState(player.WallJumpState);
        }
        else if (!isTouchingWall || xInput != player.FacingDirection)
        {
            stateMachine.ChangeState(player.InAirState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}
