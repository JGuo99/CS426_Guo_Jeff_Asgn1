using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    public float speed = 8.0f;
    public float rotationSpeed = 90;
    public float force = 1.5f;
    public float gravity = 200.0f;
    public GameObject cannon;
    public GameObject bullet;

    private Rigidbody rb;
    private Transform t;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Forward/Backward
        if (Input.GetKey(KeyCode.W))
            rb.velocity += Time.deltaTime * speed * this.transform.forward;
        else if (Input.GetKey(KeyCode.S))
            rb.velocity -= Time.deltaTime * speed * this.transform.forward;
        
        //Left/Right
        float direction = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * force;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * force;
        }
        
        //Rotation
        if (Input.GetKey(KeyCode.E))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.Q))
            t.rotation *= Quaternion.Euler(0, - rotationSpeed * Time.deltaTime, 0);
        
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(t.up * gravity);
        
        //Firing
        if (Input.GetMouseButtonDown(0)){

            GameObject newBullet = GameObject.Instantiate(bullet, cannon.transform.position, cannon.transform.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 5;
            newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 500);
            Destroy(newBullet, 5f);
        }
    }
}