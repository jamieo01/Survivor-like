using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbility : MonoBehaviour
{

    protected float _cooldown;

    
   
    protected abstract void Activate();
}
