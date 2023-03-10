using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Components
    public Core core { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public D_Entity entityData;
    public GameObject aliveGO { get; private set; }
    public FiniteStateMachine stateMachine { get; private set; }
    #endregion


    #region Unity Callback Functions

    private Vector2 velocityWorkspace;

    public virtual void Start()
    {
        aliveGO = transform.Find("Alive").gameObject;
        core = aliveGO.GetComponentInChildren<Core>();
        rb = aliveGO.GetComponent<Rigidbody2D>();
        anim = aliveGO.GetComponent<Animator>();
        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        core.LogicUpdate();
        stateMachine.currentState.LogicUpdate();
    }


    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
    #endregion


    

}
