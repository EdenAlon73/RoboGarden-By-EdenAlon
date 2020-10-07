using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private GameObject deathVFX;

    public void DealDamage(float damage)
    {
        var energyDisplay = FindObjectOfType<EnergyDisplay>();
        var attackerScript = FindObjectOfType<Attacker>();
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
            energyDisplay.AddEnergy(attackerScript.attackerEnergyValue);
        }
    }

    public void TriggerDeathVFX()
    {
        if (!deathVFX)
        {
            return;
        }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBase"))
        {
            TriggerDeathVFX();
            Destroy(this.gameObject);
        }
    }
}
