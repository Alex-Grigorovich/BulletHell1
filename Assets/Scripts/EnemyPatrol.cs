using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float patrolDistance = 3f;  // Distance on each side of the player for patrolling
    public float speed = 2f;  // Patrol speed
    private Vector3 leftPoint;
    private Vector3 rightPoint;
    private Vector3 targetPoint;
    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player Transform not assigned in EnemyPatrolNearPlayer script.");
            enabled = false;
            return;
        }
        CalculatePatrolPoints();
        targetPoint = rightPoint;
    }
    
    void Update()
    {
        // Continuously update patrol points as player moves
        CalculatePatrolPoints();
        // Move enemy towards target point
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
        // Check if enemy reached the target point and switch target
        if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
        {
            if (targetPoint == rightPoint)
                targetPoint = leftPoint;
            else
                targetPoint = rightPoint;
        }
        // Optional: Flip enemy sprite to face direction moving
        FlipEnemy();
    }
    
    void CalculatePatrolPoints()
    {
        // Calculate points on the x-axis offset from player
        Vector3 playerPos = player.position;
        leftPoint = new Vector3(playerPos.x - patrolDistance, transform.position.y, transform.position.z);
        rightPoint = new Vector3(playerPos.x + patrolDistance, transform.position.y, transform.position.z);
    }
    void FlipEnemy()
    {
        Vector3 scale = transform.localScale;
        if (targetPoint.x > transform.position.x)
            scale.x = Mathf.Abs(scale.x);  // Face right
        else
            scale.x = -Mathf.Abs(scale.x);  // Face left
        transform.localScale = scale;
    }
}
