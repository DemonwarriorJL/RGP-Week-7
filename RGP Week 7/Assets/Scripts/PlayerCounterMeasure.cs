using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCounterMeasure : MonoBehaviour
{
    [SerializeField] ParticleSystem flareParticles;

    [SerializeField] private float playerHealth;
    [SerializeField] private float timerMax;

    [SerializeField] private Image healthIMG;


    private float timer;

    public float healthValue;

    [SerializeField] bool invincible = false;

    private void Awake()
    {
        playerHealth = PlayerInfo.playerMaxHealth;
    }

    private void Update()
    {
        healthValue = playerHealth/PlayerInfo.playerMaxHealth;
        healthIMG.fillAmount = healthValue;

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(flareParticles);
            invincible = true;
        }

        if(invincible)
        {
            timer += Time.deltaTime;
            if(timer > timerMax)
            {
                invincible = false;
                timer = 0;
            }
        }

        if(playerHealth <= 0)
        {
            Debug.Log("Player Dead");
        }
    }

    public void PlayerTakeDamage(float damage)
    {
        if(!invincible)
        {
            playerHealth -= damage;
        }
    }
}
