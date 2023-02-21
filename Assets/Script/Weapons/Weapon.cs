using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private SO_WeaponData weaponData;

    private Animator baseAnimator;
    private Animator weaponAnimator;

    protected PlayerAttackState state;

    protected int attackCounter;

    protected virtual void Start()
    {
        baseAnimator = transform.Find("Base").GetComponent<Animator>();
        //weaponAnimator = transform.Find("Weapon").GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        if (attackCounter >= 3)
        {
            attackCounter = 0;
        }
        baseAnimator.SetBool("attack", true);
        // weaponAnimator.SetBool("attack", true);


        baseAnimator.SetInteger("attackCounter", attackCounter);
    }


    public virtual void ExitWeapon()
    {
        baseAnimator.SetBool("attack", false);
        //  weaponAnimator.SetBool("attack", false);

        attackCounter++;
        gameObject.SetActive(false);

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
}


