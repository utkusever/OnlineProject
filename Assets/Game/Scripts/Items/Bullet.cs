using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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
        coroutine = StartCoroutine(MoveProjectile(time, speed));
    }
    private IEnumerator DeactiveProjectile()
    {
        yield return new WaitForSeconds(3f);
        GameManager.Instance.GetBulletPool().ReturnToPool(this);

    }

    private IEnumerator MoveProjectile(float time, int speed)
    {
        Vector3 startingPos = transform.position;
        Vector3 finalPos = this.transform.position + (this.transform.forward.normalized * range);
        float elapsedTime = 0;
       // StartCoroutine(DeactiveProjectile());
        while (elapsedTime < time)
        {
            transform.position = Vector3.MoveTowards(startingPos, finalPos, (elapsedTime / time) * speed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.ApplyDamage(damage);
            StopAllCoroutines();
            GameManager.Instance.GetBulletPool().ReturnToPool(this);
        }
    }


}
