using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private SO_WeaponData weaponData;

    private Animator baseAnimator;
    private Animator weaponAnimator;
    protected PlayerMoveState moveState;
    protected PlayerAttackState state;
    protected int attackType;
    protected int attackCounter;
    protected float moveFrame;

    protected virtual void Start()
    {
        baseAnimator = transform.Find("Base").GetComponent<Animator>();
        weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);
        if (attackType == 0)
        {
            if (attackCounter >= 3)
            {
                attackCounter = 0;
            }
        }
        else if (attackType == 1)
        {
            moveFrame = state.GetMoveFrame();
            baseAnimator.SetFloat("frameNum", moveFrame);
            weaponAnimator.SetBool("attack", true);
            attackCounter = 5;
            state.SetVelocity(4f);
        }

        baseAnimator.SetBool("attack", true);
        baseAnimator.SetInteger("attackCounter", attackCounter);
    }


    public virtual void ExitWeapon()
    {
        baseAnimator.SetBool("attack", false);
        weaponAnimator.SetBool("attack", false);

        attackCounter++;
        gameObject.SetActive(false);

    }

    public float FrameCalculator(float frame)
    {
        float result;
        if (frame == 0.1f)
        {
            result = 0.8f;
        }
        else if (frame == 0.2f)
        {
            result = 0.1f;
        }
        else if (frame == 0.3f)
        {
            result = 0.2f;
        }
        else if (frame == 0.4f)
        {
            result = 0.3f;
        }
        else if (frame == 0.5f)
        {
            result = 0.4f;
        }
        else if (frame == 0.6f)
        {
            result = 0.5f;
        }
        else
        {
            result = 0.8f;
        }

        return result;
    }

    #region Animation Trigger

    public virtual void AnimationComboTrigger()
    {
        state.AnimationComboTrigger();
    }

    public virtual void AnimationFinishTrigger()
    {
        state.AnimationFinishTrigger();
    }
    public virtual void AnimationStartMovementTrigger()
    {
        state.SetVelocity(weaponData.movementSpeed[attackCounter]);
    }

    public virtual void AnimationStopMovementTrigger()
    {
        state.SetVelocity(0f);
    }

    public virtual void AnimationTurnOffFlipTrigger()
    {
        state.SetFlipCheck(false);
    }

    public virtual void AnimationTurnOnFlipTrigger()
    {
        state.SetFlipCheck(true);
    }

    #endregion

    public void InitializeWeapon(PlayerAttackState state)
    {
        this.state = state;
    }

    public void SetAttackType(int type)
    {
        attackType = type;
    }
    public int GetAttackType()
    {
        return attackType;
    }

    public float GetFrameOut()
    {
        return FrameCalculator(moveFrame);
    }
}


