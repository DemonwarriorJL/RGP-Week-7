using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce;
    private Vector2 mousePos;


    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 difference = mousePos - (Vector2)transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if(Input.GetMouseButtonDown(0))
        {
            var normVectorToMouse = difference.normalized;
            Rigidbody2D brb = Instantiate(bulletPrefab, transform.position, transform.rotation).GetComponent<Rigidbody2D>();
            brb.AddForce(normVectorToMouse * bulletForce);
        }
    }
}
