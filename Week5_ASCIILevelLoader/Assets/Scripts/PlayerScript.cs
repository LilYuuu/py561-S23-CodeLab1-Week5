using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;

    public float forceAmt = .0001f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // WASD control
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(forceAmt * new Vector3(0, 0, 1));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(forceAmt * Vector3.left);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(forceAmt * new Vector3(0, 0, -1));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(forceAmt * Vector3.right);
        }
        
        // Fall detection
        if (transform.position.y < -0.6)
        {
            Debug.Log("fell...");
            GameManager.instance.GetComponent<ASCIILevelLoaderScript>().ResetPlayer();
            
            // reset the velocity to provent it from falling
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
