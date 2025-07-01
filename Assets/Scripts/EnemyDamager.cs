using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    
    public float damageAmount;
    
    public float lifeTime, growSpeed = 5f;

    private Vector3 targetSize;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        
        targetSize = transform.localScale;
        transform.localScale = Vector3.zero;
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, growSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyV2>().TakeDamage(damageAmount);   
        }
    }
}
