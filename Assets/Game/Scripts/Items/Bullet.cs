using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
    [SerializeField] private Rigidbody myRb;

    [SerializeField] float damage;
    [SerializeField] float time;
    [SerializeField] int speed;
    [SerializeField] int range;
    Coroutine coroutine;

    public void Init()
    {
        FireBullet();
    }

    private void FireBullet()
    {
        // coroutine = StartCoroutine(MoveProjectile(time, speed));
        StartCoroutine(DeactiveProjectile());
    }

    private IEnumerator DeactiveProjectile()
    {
        yield return new WaitForSeconds(4f);
        GameManager.Instance.GetBulletPool().ReturnToPool(this);
    }

    private void Update()
    {
        myRb.velocity = myRb.transform.forward * 10;
    }

    // private IEnumerator MoveProjectile(float time, int speed)
    // {
    //     Vector3 startingPos = transform.position;
    //     Vector3 finalPos = this.transform.position + (this.transform.forward.normalized * range);
    //     float elapsedTime = 0;
    //     StartCoroutine(DeactiveProjectile());
    //     while (elapsedTime < time)
    //     {
    //         transform.position = Vector3.MoveTowards(startingPos, finalPos, (elapsedTime / time) * speed);
    //         elapsedTime += Time.deltaTime;
    //         yield return null;
    //     }
    // }
    private void OnTriggerEnter(Collider other)
    {
        if (!IsOwner)
        {
            return;
        }

        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.ApplyDamage(damage);
            StopAllCoroutines();
            GameManager.Instance.GetBulletPool().ReturnToPool(this);
        }
    }
}