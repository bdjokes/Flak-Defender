﻿using UnityEngine;
using System.Collections;

public class ExplosionCleanup : MonoBehaviour {
    public float timer = 3;
        
    void Awake()
    {
        transform.parent = Projectile.projectileParent.transform;
    }
    IEnumerator Start()
    {
        var startT = GameTime.time;
        while(true)
        {
            if (GameTime.time - startT > timer) break;
            yield return null;
        }
        Destroy(gameObject);
    }
}
