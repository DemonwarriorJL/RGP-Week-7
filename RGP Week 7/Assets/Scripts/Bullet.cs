using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 40;

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);

        if (col.collider.CompareTag("Enemy"))
        {
            EnemyBattleAI eBA = col.collider.GetComponent<EnemyBattleAI>();
            eBA.TakeDamage(damage);
        }
    }
}
