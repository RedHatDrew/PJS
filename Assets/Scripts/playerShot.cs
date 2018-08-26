using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShot : MonoBehaviour {

    private void OnCollisionEnter()
    {
        Destroy(gameObject);
    }

}