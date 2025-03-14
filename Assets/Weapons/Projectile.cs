﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public static GameObject projectileParent;


    public float lifespan;
    public float damage;
    public GameObject explosionEffect;

    public AudioClip fireSound;
    public AudioClip hitSound;

    Component projectileType;

    public void Awake()
    {
        if(projectileParent == null)
        {
            projectileParent = FindObjectOfType<ProjectileParent>().gameObject;
        }
        transform.parent = projectileParent.transform;
    }


	IEnumerator Start () {
        float startTime = GameTime.time;
        while(true)
        {
            if (lifespan < (GameTime.time - startTime)) Destroy(gameObject);
            yield return null;
        }
	}
	public void OnCollisionEnter(Collision col)
    {
        Debug.Log("collided with " + col.gameObject.name);
        var explode = Instantiate(explosionEffect) as GameObject;
        explode.transform.position = transform.position;
        explode.audio.PlayOneShot(hitSound, 0.1f);
        col.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
