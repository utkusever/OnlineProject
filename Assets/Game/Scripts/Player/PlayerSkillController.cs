using System.Collections;
using System.Collections.Generic;
using _Game.Scripts.Enums;
using _Game.Scripts.UserInterface;
using _Game.Scripts.UserInterface.Canvases;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{
    [SerializeField] PlayerInventory playerInventory;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float attackCooldown;
    [SerializeField] PlayerEffects playerEffects;
    private InGameUI inGameUI;
    private BulletPool bulletPool;
    private Coroutine coroutine;
    private WaitForSeconds waitForSeconds;
    private bool canAttack;

    void Start()
    {
        bulletPool = GameManager.Instance.GetBulletPool();
        waitForSeconds = new WaitForSeconds(attackCooldown);
        coroutine = StartCoroutine(AttackCooldown());
        inGameUI = UIManager.Instance.GetCanvas(CanvasTypes.InGame) as InGameUI;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // DmgBooster
        {
            if (playerInventory.HasItem(ItemType.DamageBooster))
            {
                playerInventory.UseItem(ItemType.DamageBooster);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q)) //Health
        {
            if (playerInventory.HasItem(ItemType.HealthPotion))
            {

                playerInventory.UseItem(ItemType.HealthPotion);
            }
        }
        if (Input.GetKeyDown(KeyCode.E)) //Homing 
        {
            if (playerInventory.HasItem(ItemType.HomingRocket))
            {
                playerInventory.UseItem(ItemType.HomingRocket);
            }
        }
        if (Input.GetKeyDown(KeyCode.V)) //Kamikaze 
        {
            if (playerInventory.HasItem(ItemType.Kamikaze))
            {
                playerInventory.UseItem(ItemType.Kamikaze);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) //Normal Shot
        {
            if (!canAttack) return;
            FireBullet();
        }
    }
    
    private void FireBullet()
    {
        playerEffects.Effect.Play();
        canAttack = false;
        ResetBulletOverlay();
        var bullet = bulletPool.GetFromPool();
        bullet.transform.rotation = spawnPoint.rotation;
        bullet.transform.position = spawnPoint.position;
        bullet.Init();
        coroutine = StartCoroutine(AttackCooldown());
    }

    private void ResetBulletOverlay()
    {
        inGameUI.BulletOverlayFill(attackCooldown);
    }

    private IEnumerator AttackCooldown()
    {
        yield return waitForSeconds;
        canAttack = true;
    }

}
