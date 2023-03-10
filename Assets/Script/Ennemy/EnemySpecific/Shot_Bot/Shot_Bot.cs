using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Bot : Entity
{
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_PlayerDetectedState playerDetectedStateData;
    public Shot_Bot_MoveState moveState { get; private set; }
    public Shot_Bot_IdleState idleState { get; private set; }
    public Shot_Bot_PlayerDetectedState playerDetectedState { get; private set; }


    public override void Start()
    {
        base.Start();
        moveState = new Shot_Bot_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Shot_Bot_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new Shot_Bot_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        stateMachine.Initialize(moveState);
    }
}
