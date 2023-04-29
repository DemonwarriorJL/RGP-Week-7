using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarPing : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float disappearTimer = 0f;
    [SerializeField] private float disappearTimerMax = 1f;
    private Color colour;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colour = new Color(1f, 1f, 1f, 1f);
    }

    private void Update()
    {
        disappearTimer += Time.deltaTime;

        colour.a = Mathf.Lerp(disappearTimerMax, 0f, disappearTimer / disappearTimerMax);
        spriteRenderer.color = colour;

        if (disappearTimer >= disappearTimerMax)
        {
            Destroy(gameObject);
        }
    }

    public void SetColour(Color color)
    {
        this.colour = color;
    }

    public void SetDisappearTimer()
    {
        this.disappearTimerMax = disappearTimerMax;
        disappearTimer = 0f;
    }
}
