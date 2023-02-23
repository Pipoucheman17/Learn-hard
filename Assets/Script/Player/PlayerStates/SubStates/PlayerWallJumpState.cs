using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerAbilityState
{

    private bool isTouchingWall;
    private bool isGrounded;

    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isTouchingWall = core.CollisionSenses.TouchWall;
        isGrounded = core.CollisionSenses.Ground;
    }
    public override void Enter()
    {
        base.Enter();

        player.JumpState.ResetAmountOfJumpsLeft();
        core.Movement.SetVelocityY(0f);
        player.RB.AddForce(new Vector2(playerData.wallJumpStrength.x * -core.Movement.FacingDirection, playerData.wallJumpStrength.y), ForceMode2D.Impulse);
        player.JumpState.DecreaseAmountOfJumpsLeft();

    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + playerData.wallJumpTime)
        {
            isAbilityDone = true;
        }

    }


}
