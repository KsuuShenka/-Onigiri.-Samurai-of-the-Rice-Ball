using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartMotorDown : MonoBehaviour
{
    private Rigidbody2D platform;

    private void Start()
    {
        platform = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            platform.gravityScale = 1;
        }
    }
}
