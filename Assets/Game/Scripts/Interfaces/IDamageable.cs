using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    
    void ApplyDamage(int value);
    bool IsDead();
    Transform GetTransform();
}
