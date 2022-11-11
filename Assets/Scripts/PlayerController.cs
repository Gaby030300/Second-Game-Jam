using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    //private variables
    private float speed = 20.0f;
    private float speedRotation = 45.0f;
    private float jumpSpeed = 5.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rigidBody;
    private bool onGround = true;

    //Variables for double Jump
    private const int MAX_JUMP = 2;
    private int currentJump = 0;

    //Projectile
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float coolDown = 1;

    //Range player position
    public float xRange;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Keep the player in bounds.
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //This is where we get player horizontal input        
        horizontalInput = Input.GetAxis("Horizontal");
        // Move the vehicle forward on the horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * speedRotation * horizontalInput);

        //This is where we get player vertical input 
        verticalInput = Input.GetAxis("Vertical");
        // Move the vehicle forward on the vertical input
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        //This is where the player can jump
        if (Input.GetKeyDown(KeyCode.Space) && (onGround || MAX_JUMP > currentJump))
        {
            rigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            onGround = false;
            currentJump++;
        }

        //Launch projectiles
        if (Input.GetMouseButtonDown(0) && coolDown <= 0)
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);
            coolDown = 1;
        }
        if (coolDown >= 0)
        {
            coolDown -= Time.deltaTime;
        }
    }
    //Stop player jump
    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
        currentJump = 0;
    }
}