using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float chaseSpeed = 5f;  // Speed at which the enemy chases the player
    private Transform playerTransform;
    private bool isChasing = false;
    // Ensure the enemy has a collider set as trigger for chase detection
    private void Reset()
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }
    
    
    
    
    private void Update()
    {
        if (isChasing && playerTransform != null)
        {
            // Move enemy towards player position
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * chaseSpeed * Time.deltaTime;
            // Optional: Face the player
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            }
        }
        
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
            isChasing = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = false;
            playerTransform = null;
        }
    }
    

    
    
}
