using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    public SpriteRenderer sr;
    public static int counter = 0;


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sr.color = Color.green;
            counter++;
        }
        if (other.CompareTag("Enemy"))
        {
            sr.color = Color.blue;
            counter--;
        }
    }

}
