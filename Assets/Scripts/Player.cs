using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 100f;
    private Rigidbody rigidBody;
    private Transform myTransform;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        myTransform = transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
               if (Input.GetKey (KeyCode.W))
                { // Идем вверх
                    rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
                    myTransform.rotation = Quaternion.Euler (0, 0, 0);
                   //animator.SetBool ("Walking", true);
                }
        
                if (Input.GetKey (KeyCode.A))
                { // Идем влево
                    rigidBody.velocity = new Vector3 (-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
                    myTransform.rotation = Quaternion.Euler (0, 270, 0);
                   // animator.SetBool ("Walking", true);
                }
        
                if (Input.GetKey (KeyCode.S))
                { // Идем вниз
                    rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
                    myTransform.rotation = Quaternion.Euler (0, 180, 0);
                  //  animator.SetBool ("Walking", true);
                }
        
                if (Input.GetKey (KeyCode.D))
                { // Идем вправо
                    rigidBody.velocity = new Vector3 (moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
                    myTransform.rotation = Quaternion.Euler (0, 90, 0);
                  //  animator.SetBool ("Walking", true);
                }


       

    }
}
