using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    public SpriteRenderer sr;
    public static int counter = 0;
    private bool playerOwned = false;
    private bool enemyOwned = false;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !playerOwned)
        {
            playerOwned = true;
            enemyOwned = false;
            sr.color = Color.green;
            counter++;
        }
        if (other.CompareTag("Enemy") && !enemyOwned)
        {
            playerOwned = false;
            enemyOwned = true;
            sr.color = Color.blue;
            counter--;
        }
    }

}
