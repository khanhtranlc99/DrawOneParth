using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dost : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public int wasTouch =0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = Color.red;
        wasTouch = 1; 
    }
}
