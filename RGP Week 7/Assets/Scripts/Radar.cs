using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Radar : MonoBehaviour
{
    private Transform sweepTransform;

    [SerializeField] private float rotationSpeed = 180;
    [SerializeField] private float radarRange = 30.95f;

    [SerializeField] private Transform pfRadarPing;

    [SerializeField] private LayerMask whatToHit;

    private List<Collider2D> collidersList;

    private void Awake()
    {
        sweepTransform = transform.Find("Sweep");
        collidersList = new List<Collider2D>();
    }

    private void Update()
    {
        float previousRotation = (sweepTransform.eulerAngles.z % 360) - 180;
        sweepTransform.eulerAngles -= new Vector3(0, 0, rotationSpeed * Time.deltaTime);
        float currentRotation = (sweepTransform.eulerAngles.z % 360) - 180;

        if (previousRotation < 0 && currentRotation >= 0)
        {
            collidersList.Clear();
        }

        RaycastHit2D[] raycastHit2DArray = Physics2D.RaycastAll(transform.position, UtilsClass.GetVectorFromAngle(sweepTransform.eulerAngles.z), radarRange, whatToHit);
        foreach (RaycastHit2D raycastHit2D in raycastHit2DArray)
        {
            if (raycastHit2D.collider != null)
            {
                if (!collidersList.Contains(raycastHit2D.collider))
                {
                    collidersList.Add(raycastHit2D.collider);
                    RadarPing radarping = Instantiate(pfRadarPing, raycastHit2D.point, Quaternion.identity).GetComponent<RadarPing>();
                    radarping.SetColour(Color.red);
                }
            }
        }
    }
}
