using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] float jumpVelocity = 10.0f;
    [SerializeField] float shotVelocity = 10.0f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public int maxJumps = 1;
    int jumpCount = 0;

    public GameObject playerShotPrefab;
    public Transform playerShotSpawn;

    Rigidbody rb;

	// Use this for initialization
	void Awake () 
    {
        rb = GetComponent<Rigidbody>();
        jumpCount = maxJumps;
	}
	
	// Update is called once per frame
	void Update () 
    {
        HorizontalMovement();
        Jump();
        GravityThing();

        if(Input.GetKeyDown(KeyCode.E))
        {
            Fire();
        }
	}

    void GravityThing()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void HorizontalMovement()
    {
        if (Input.GetAxis("Horizontal") != Mathf.Abs(0.0f))
        {
            if (Input.GetAxis("Horizontal") > 0.0f)
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                //print("Go right");
            }

            else if (Input.GetAxis("Horizontal") < 0.0f)
            {
                transform.Translate(Vector3.left * -moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, -180, 0);
                //print("Go left");
            }
        }
    }

    void Jump()
    {
        //if (Input.GetButtonDown("Jump") && rb.velocity.y != Mathf.Abs(0.0f))
        if (jumpCount >= 1 && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector3.up * jumpVelocity;
            jumpCount--;
            print("Jump!");
        }
    }

    void Fire()
    {
        var playerShot = (GameObject)Instantiate(
            playerShotPrefab,
            playerShotSpawn.position,
            playerShotSpawn.rotation);

        playerShot.GetComponent<Rigidbody>().velocity = playerShot.transform.right * shotVelocity;

        Destroy(playerShot, 2.0f);
        //Add destroy on collision rules, as well
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jumpCount = maxJumps;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
            jumpCount--;
    }
}
