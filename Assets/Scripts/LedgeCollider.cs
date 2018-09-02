using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            //transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.rotation *= Quaternion.Euler(0, 180, 0);
            print("Ledge hit!");
        }
    }
}