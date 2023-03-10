using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Bot_MoveState : MoveState
{
    private Shot_Bot shotBot;
    public Shot_Bot_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Shot_Bot shotBot) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.shotBot = shotBot;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (core.CollisionSenses.TargetInMinAgroRange)
        {
            stateMachine.ChangeState(shotBot.playerDetectedState);
        }
        else if (!core.CollisionSenses.Ledge || core.CollisionSenses.TouchWall)
        {
            shotBot.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(shotBot.idleState);

        }
    }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}
