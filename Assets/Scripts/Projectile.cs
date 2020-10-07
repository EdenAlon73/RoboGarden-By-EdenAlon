using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 1f;
    [SerializeField] private float damage = 20f;
    [SerializeField] private GameObject hitVFX;
    
    private void Update()
    {
        transform.Translate(Vector2.right * (Time.deltaTime * projectileSpeed));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // reduce health
        var health = other.GetComponent<Health>();
        var attacker = other.GetComponent<Attacker>();
        if (attacker && health)
        {
            health.DealDamage(damage);
            GameObject hitVfxoGameObject = Instantiate(hitVFX, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(hitVfxoGameObject, 1f);
        }
        
        
    }
}
