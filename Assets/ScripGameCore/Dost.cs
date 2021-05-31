using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dost : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public int wasTouch ;
    public int number;

    private void OnTriggerEnter2D(Collider2D collision)
    { 
       
            spriteRenderer.color = Color.red;
            wasTouch = 1;
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
        wasTouch = 0;
    }
}
