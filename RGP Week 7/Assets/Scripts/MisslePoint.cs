using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisslePoint : MonoBehaviour
{
    [SerializeField] private float timerMax;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > timerMax)
        {
            Destroy(gameObject);
        }
    }
}
