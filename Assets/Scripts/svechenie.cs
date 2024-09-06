using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class svechenie : MonoBehaviour
{
    public float fadeSpeed = 1f;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float alpha = Mathf.PingPong(Time.unscaledTime * fadeSpeed, 1.0f);
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
    }
}
