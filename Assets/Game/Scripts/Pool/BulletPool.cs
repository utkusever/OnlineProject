using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Pool;
using Unity.Netcode;
using UnityEngine;

public class BulletPool : GenericObjectPool<Bullet>
{
    
    public override void ReturnToPool(Bullet item)
    {
        item.GetComponent<NetworkObject>().Despawn(false);
        base.ReturnToPool(item);
    }

    public override Bullet GetFromPool()
    {
        
        var bullet = base.GetFromPool();
        // bullet.GetComponent<NetworkObject>().Spawn(true);
        return bullet;
    }
}