using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public ItemType itemType;
    public float value;
    public virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }
    protected abstract void UseItem();
    public virtual void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerInventory>().AddItem(itemType);
    }
}
