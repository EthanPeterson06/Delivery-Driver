using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasOrderColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 noOrderColor = new Color32 (1,1,1,1);

    [SerializeField] float destroyDelay = 0.3f;
    bool hasOrder;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Learn to drive");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Order" && !hasOrder)
        { 
            Debug.Log("Order received");
            hasOrder = true;
            spriteRenderer.color = hasOrderColor;
            Destroy(other.gameObject, destroyDelay);
        }
        if (other.tag == "Customer" && hasOrder)
        {
            Debug.Log("Pizza Delivered!");
            hasOrder = false;
            spriteRenderer.color = noOrderColor;
        }
    }
}
