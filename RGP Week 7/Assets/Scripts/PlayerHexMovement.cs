using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayerHexMovement : MonoBehaviour
{
    private Vector2 velocity;
    private Vector3 direction;
    private bool hasMoved;

    public Tilemap fogTileMap;

    [SerializeField] private int visionRange = 3;

    private void Update()
    {
        if(velocity.y == 0)
        {
            hasMoved = false;
        }
        else if(velocity.y != 0 && !hasMoved)
        {
            hasMoved = true;
            MoveByDirection();
        }

        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void MoveByDirection()
    {
        if (velocity.y < 0)
        {
            if (velocity.x > 0)
            {
                direction = new Vector3(0.76f, -0.43f);
            }
            else if (velocity.x < 0)
            {
                direction = new Vector3(-0.76f, -0.43f);
            }
            else
            {
                direction = new Vector3(0, -0.86f);
            }
        }
        else if (velocity.y > 0)
        {
            if (velocity.x > 0)
            {
                direction = new Vector3(0.76f, 0.43f);
            }
            else if (velocity.x < 0)
            {
                direction = new Vector3(-0.76f, 0.43f);
            }
            else
            {
                direction = new Vector3(0, 0.86f);
            }
        }
        transform.position += direction;
        UpdateFog();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            transform.position -= direction;
        }
    }

    private void UpdateFog()
    {
        Vector3Int currentPlayerPos = fogTileMap.WorldToCell(transform.position); //world position converts to cell position

        for (int i = -visionRange; i <= visionRange; i++)
        {
            for (int j = -visionRange; j <= visionRange; j++)
            {
                fogTileMap.SetTile(currentPlayerPos + new Vector3Int(i, j, 0), null);
            }
        }
    }
}
