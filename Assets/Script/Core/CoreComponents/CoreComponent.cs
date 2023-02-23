using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MonoBehaviour
{
    protected Core core;

    protected virtual void Awake()
    {
        core = transform.parent.GetComponentInParent<Core>();

        if (core == null)
        {
            Debug.LogError("Core Component is missing Core");
        }
    }

    
}
