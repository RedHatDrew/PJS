using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Grounder : MonoBehaviour {


    [SerializeField] float moveSpeed = 2.0f;
    //[SerializeField] float shotVelocity = 5.0f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;


    Rigidbody rb;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //jumpCount = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        GravityThing();
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
        transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }


    /*private void OnTriggerEnter(Collision collision)
    {

        if (collision.gameObject.tag == "enemy")
        {
            //transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.rotation *= Quaternion.Euler(0, 180, 0);
            print("Ledge hit!");
        }
    }*/

}
