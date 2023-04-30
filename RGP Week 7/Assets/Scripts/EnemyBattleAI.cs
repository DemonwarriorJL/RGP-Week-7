using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBattleAI : MonoBehaviour
{
    [SerializeField] private float accelerationTime = 2f;
    [SerializeField] private float maxSpeed = 5f;

    [SerializeField] private float EnemyMaxHealth = 100.0f;
    [SerializeField] private float EnemyHealth;
    [SerializeField] private float EnemyMaxShield = 100.0f;
    [SerializeField] private float EnemyShield;
    [SerializeField] private float perpendicularDisplacment;
    [SerializeField] private float shieldPercentage = 35.0f;

    [SerializeField] private GameObject missle;

    [SerializeField] private Image healthEnemyIMG;
    [SerializeField] private Image shieldEnemyIMG;

    public static Vector3 misslePoint1;
    public static Vector3 misslePoint2;

    [SerializeField] private float missleTimerMax = 5f;

    private float missleTimer;
    private float healthValue;
    private float shieldValue;

    private Vector2 movement;
    private float timeLeft;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        EnemyHealth = EnemyMaxHealth;
        EnemyShield = EnemyMaxShield;
    }

    private void Update()
    {
        healthValue = EnemyHealth / EnemyMaxHealth;
        shieldValue = EnemyShield / EnemyMaxShield;

        healthEnemyIMG.fillAmount = healthValue;
        shieldEnemyIMG.fillAmount = shieldValue;

        missleTimer += Time.deltaTime;

        if(missleTimer >= missleTimerMax)
        {
            Instantiate(missle, transform.position, transform.rotation);
            missleTimer = 0;
        }

        Vector2 normalisedVector = transform.position - new Vector3(0, 0, 0);
        Vector3 perpendicularVector = new Vector3(-normalisedVector.y, normalisedVector.x, 0);
        perpendicularVector = perpendicularVector.normalized;

        misslePoint1 = transform.position + perpendicularVector * perpendicularDisplacment;
        misslePoint2 = transform.position + perpendicularVector * -1f * perpendicularDisplacment;

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += accelerationTime;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed * rb.mass);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("HIT");
        if (EnemyShield <= 0 && EnemyHealth > 0)
        {
            EnemyHealth -= damage;
        }
        else if (EnemyShield <= 0 && EnemyHealth <= 0)
        {
            Debug.Log("Ship Destroyed");
        }
        else if (EnemyShield > 0)
        {
            if(shieldPercentage < 20.0f)
            {
                EnemyShield -= (damage * 0.5f);
                if (EnemyShield < 0)
                {
                    EnemyHealth += (EnemyShield * 2.0f);
                }
            }
            else if(shieldPercentage > 40.0f)
            {
                EnemyShield -= (damage * 2.0f);
                if (EnemyShield < 0)
                {
                    EnemyHealth += (EnemyShield * 0.5f);
                }
            }
            else
            {
                EnemyShield -= (damage);
                if (EnemyShield < 0)
                {
                    EnemyHealth += EnemyShield;
                }
            }
        }
    }
}
