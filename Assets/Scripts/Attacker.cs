using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    
    private float currentSpeed = 0.5f;
    private GameObject currentTarget;
    public int attackerEnergyValue = 50;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }

    }

    private void Update()
    {
        transform.Translate(Vector2.left * (Time.deltaTime * currentSpeed));
        UpdateAnimationState();
    }

    public void SetMovementSpeed(float speed) //used in animation event
    {
        currentSpeed = speed;
    }

    public void EnemyAttack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage) //used in animation event
    {
        if (!currentTarget)
        {
            return;
        }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }

    public void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }
}
