using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Bot_PlayerDetectedState : PlayerDetectedState
{
    private Shot_Bot shotBot;
    public Shot_Bot_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedState stateData, Shot_Bot shotBot) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.shotBot = shotBot;
    }

    public override void Enter()
    {
        base.Enter();
        core.Movement.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!core.CollisionSenses.TargetInMaxAgroRange)
        {
            shotBot.idleState.SetFlipAfterIdle(false);
            stateMachine.ChangeState(shotBot.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
