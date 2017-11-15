using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 50f;
    private EnemyPatrol patrol;

    private void Awake()
    {
        patrol = GetComponent<EnemyPatrol>();
    }

    public void TakeDamage(float amount)
    {
        //health -= amount;
        //if (health <= 0f)
        //{
        //    Die();
        //}
        patrol.enabled = false;
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
