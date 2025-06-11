using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV2 : MonoBehaviour
{
    
    private Transform player; // Reference to the player's transform
    public float speed = 5f; // Speed of the enemy

    public float damage;

    public float hitWaitTime = 1f;
    private float hitCounter;
    
    
   void Start()
    {
        // Find the player GameObject by tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player with tag 'Player' not found in the scene.");
        }
    }
    
    void Update()
    {
        // Check if the player exists
        if (player != null)
        {
            // Move enemy towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            // Optional: rotate to face player
            if (direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 5f * Time.deltaTime);
            }
        } else if (player == null)
        {
            Debug.Log("Game Over");
        }

        if (hitCounter > 0f)
        {
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && hitCounter <= 0f)
        {
            PlayerHealthController.instance.TakeDamage(damage);

            hitCounter = hitWaitTime;
        }
        
    }
   



}
