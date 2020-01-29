using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 15.0f;
    public float rotationSpeed = 5;
    public float gravity = 700f;

    private Rigidbody rb;
    private Transform t;
    private float centerBody = 0;
    
    //public float mouseMovement = 100f; //Sensitivity of a Mouse
    //public Transform character; //Player Character


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //Forward and Backward movement
        if (Input.GetKey(KeyCode.W))
        {
            //rb.velocity += (this.transform.forward * speed * Time.deltaTime);
            rb.velocity += Time.deltaTime * speed * this.transform.forward;
        }else if (Input.GetKey(KeyCode.S))
        {
            //rb.velocity -= this.transform.forward * speed * Time.deltaTime;
            rb.velocity -= Time.deltaTime * speed * this.transform.forward;
        }
        
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(t.up * gravity);
        }

        //Mouse Movement for player rotation
        if (Input.GetAxis("Mouse X") < 0)
        {
            //t.Rotate((Vector3.up) * +rotationSpeed);
            t.rotation = Quaternion.Euler(0, rotationSpeed*Time.deltaTime, 0);
        }
        if (Input.GetAxis("Mouse Y") < 0)
        {
            //t.Rotate((Vector3.down) * -rotationSpeed);
            t.rotation = Quaternion.Euler(0, -rotationSpeed*Time.deltaTime, 0);
        }
        //float rotateX = Input.GetAxis("Mouse X") * mouseMovement * Time.deltaTime; //Mouse movement X-axis
        //float rotateY = Input.GetAxis("Mouse y") * mouseMovement * Time.deltaTime; //Mouse movement Y-axis

        //character.Rotate(Vector3.up * xmm);
    }
}
