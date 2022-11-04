using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Expcollctible : MonoBehaviour
{
    public float value;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().AddExp(value);
            Destroy(gameObject);
        }
    }
}
