using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch_Bot_MoveState : MoveState
{
    private Punch_Bot punchBot;
    public Punch_Bot_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Punch_Bot punchBot) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.punchBot = punchBot;
    }

    public override void DoChecks()
    {
        base.DoChecks();
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
            stateMachine.ChangeState(punchBot.playerDetectedState);
        }
        else if (core.CollisionSenses.TouchWall || !core.CollisionSenses.Ledge)
        {
            punchBot.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(punchBot.idleState);
        }
    }
}
