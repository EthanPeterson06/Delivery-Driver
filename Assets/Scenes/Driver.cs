using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 20f;

    [SerializeField] float steerSpeed = 190f;
    [SerializeField] float moveSpeed = 15f;


    void Update()
    {
        float speedAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount); 
        transform.Translate(0, speedAmount, 0);
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boost")
        {
             moveSpeed = boostSpeed;
        }
    }
}
