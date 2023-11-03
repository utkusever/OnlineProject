using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] float speed;
    [SerializeField] ParticleSystem particleSystem;
    private PlayerController playerController;
    private Transform target;
    private IDamageable damageableTarget;
    private float value;
    private bool isFinished;

    public void Init(PlayerController playerController, float value)
    {
        this.playerController = playerController;
        this.value = value;
        StartCoroutine(GetTarget());
    }

    private IEnumerator GetTarget()
    {
        isFinished = false;
        while (!isFinished)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(playerController.GetMouseRay(), out raycastHit, 1000, layerMask))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    // Absorb the whole mouse click
                    yield return new WaitWhile(() => Input.GetMouseButton(0));
                    if (raycastHit.collider.TryGetComponent<IDamageable>(out IDamageable damageable))
                    {
                        target = damageable.GetTransform();
                        damageableTarget = damageable;
                        isFinished = true;
                    }
                    break;
                }
            }

            yield return null;
        }
        StartCoroutine(LaunchMissile());

    }



    private IEnumerator LaunchMissile()
    {
        print("launched");
        particleSystem.Play();
        while (Vector3.Distance(target.transform.position, this.transform.position) > 0.2f)
        {
            this.transform.position += (target.transform.position - this.transform.position).normalized * speed * Time.deltaTime;
            this.transform.LookAt(target.transform);
            yield return null;
        }
        damageableTarget.ApplyDamage(value);
        Destroy(this.gameObject);
    }
}
