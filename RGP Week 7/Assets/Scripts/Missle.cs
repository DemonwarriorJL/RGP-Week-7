using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float missleForce;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float damage;

    [SerializeField] private GameObject misslePoint;

    [SerializeField] private Vector3 misslePoint1Pos;
    [SerializeField] private Vector3 misslePoint2Pos;
    [SerializeField] private Vector3 toMissle;

    [SerializeField] private LayerMask missleLayer;

    private int choice;

    private bool visitedPoint = false;

    private Rigidbody2D rb;

    private void Start()
    {
        choice = Random.Range(0, 2);
        rb = GetComponent<Rigidbody2D>();

        Instantiate(misslePoint, EnemyBattleAI.misslePoint1, transform.rotation);
        Instantiate(misslePoint, EnemyBattleAI.misslePoint2, transform.rotation);

        if (choice == 0)
        {
            toMissle = EnemyBattleAI.misslePoint1 - transform.position;
        }
        else
        {
            toMissle = EnemyBattleAI.misslePoint2 - transform.position;
        }
        toMissle = toMissle.normalized;
    }

    private void Update()
    {
        if (!visitedPoint)
        {
            Debug.Log("To point");
            rb.AddForce(toMissle * missleForce);
            transform.rotation = Quaternion.FromToRotation(Vector3.up, toMissle);
        }
        else
        {
            Debug.Log("To player");
            Vector3 toPlayer = -transform.position;
            toPlayer = toPlayer.normalized;
            rb.AddForce(toPlayer * missleForce);
            transform.rotation = Quaternion.FromToRotation(Vector3.up, toPlayer);
        }

        
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("MisslePoint"))
        {
            visitedPoint = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Player"))
        {
            PlayerCounterMeasure pCM = col.collider.GetComponent<PlayerCounterMeasure>();
            pCM.PlayerTakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
