using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] BulletPool bulletPool;
    [SerializeField] private Generator generator;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public BulletPool GetBulletPool()
    {
        return bulletPool;
    }

    public Generator GetGenerator()
    {
        return generator;
    }
}