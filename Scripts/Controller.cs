using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Controller : MonoBehaviour
{
    private Rigidbody rb;

    public bool isOnGRound;
    public bool isinAir;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
 
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        
#if UNITY_EDITOR 
         AWSDController();

#else
        AccelerationController();
#endif
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.collider.tag == "Ground")
        {
            isOnGRound = true;
            isinAir = false;

        }
    }

    
    private void OnCollisionExit(Collision other)
    {
        if (other.collider.tag == "Ground")
        {
            isOnGRound = false;
            isinAir = true;
        }
    }

    private void AWSDController()
    {
        if (isOnGRound)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Vector3 movingpos =  new Vector3(h, 0, v);
            movingpos = movingpos.normalized * speed * Time.deltaTime;
            rb.MovePosition((transform.position + movingpos));
          
             
            //jump
            if (Input.GetKeyDown(KeyCode.K))
            {
                Jump();
            }
        }

        
        
         
    }

    public void Jump()
    {
        if (!isinAir)
        {
            rb.AddForce(new Vector3(0,10*80,0));
        }
       
    }

    private void AccelerationController()
    {
        //  Vector3 movingpos =  new Vector3(Input.acceleration.x, 0,-Input.acceleration.z);
        // movingpos = movingpos.normalized * speed * Time.deltaTime;
        // rb.MovePosition((transform.position + movingpos));
  
     
        if (isOnGRound)
        { 
            Vector3 dir = new Vector3(Input.acceleration.x,0,Input.acceleration.y);
            rb.MovePosition((transform.position + dir *Time.deltaTime  *speed));
            
        }

    }
}