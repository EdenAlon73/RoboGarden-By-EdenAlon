using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject cannon;
    private Animator animator;
    private AttackerSpawner myLaneSpawner;
    private GameObject projectileParent;
    private const string PROJECTILE_PARENT = "Projectile Parent";
    

    private void Start()
    {
        CreateProjectileParent();
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsOnSameYValue = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsOnSameYValue)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0 && myLaneSpawner != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT);
        }
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, cannon.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
    
}
