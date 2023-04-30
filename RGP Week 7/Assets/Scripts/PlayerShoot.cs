using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletForce;
    [SerializeField] private float timerMax;

    private float timer;
    public float timerValue;

    private int counter = 3;

    private Vector2 mousePos;

    [SerializeField] private Image shellIMG1;
    [SerializeField] private Image shellIMG2;
    [SerializeField] private Image shellIMG3;

    [SerializeField] private Image shellReloadIMG;


    private List<Image> shellsList = new List<Image>();

    private void Start()
    {
        shellsList.Add(shellIMG1);
        shellsList.Add(shellIMG2);
        shellsList.Add(shellIMG3);
    }

    private void Update()
    {
        timerValue = timer/timerMax;

        shellReloadIMG.fillAmount = timerValue;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 difference = mousePos - (Vector2)transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && counter != 0)
        {
            bool hasChanged = false;

            for (int i = 0; i < shellsList.Count; i++)
            {
                if (shellsList[i].enabled == true && !hasChanged)
                {
                    hasChanged = true;
                    shellsList[i].enabled = false;
                    counter--;
                     
                    if(timer > timerMax)
                    {
                        timer = 0;
                    }
                }
            }

            var normVectorToMouse = difference.normalized;
            Rigidbody2D brb = Instantiate(bulletPrefab, transform.position, transform.rotation).GetComponent<Rigidbody2D>();
            brb.AddForce(normVectorToMouse * bulletForce);
        }

        if (timer >= timerMax && counter < 3)
        {
            bool hasChanged = false;
            for (int i = shellsList.Count - 1; i >= 0; i--)
            {
                if (shellsList[i].enabled == false && hasChanged == false)
                {
                    counter++;
                    shellsList[i].enabled = true;
                    hasChanged = true;
                }
                if (shellsList[i].enabled == false && hasChanged == true)
                {
                    timer = 0;
                }
            }
        }
    }
}
