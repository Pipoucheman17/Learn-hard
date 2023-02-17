using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallGrabState : PlayerTouchingWallState
{
    public PlayerWallGrabState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isExitingState)
        {
            if (isAnimationFinished)
            {
                if(player.InputHandler.JumpInput)
                {
                    stateMachine.ChangeState(player.WallJumpState);
                }
                stateMachine.ChangeState(player.WallSlideState);
            }
            
        }
    }


}
