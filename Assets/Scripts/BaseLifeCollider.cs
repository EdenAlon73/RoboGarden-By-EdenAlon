using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLifeCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<BaseLives>().DecreaseLife();
            Destroy(other.gameObject);
        }
    }
}
