using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderScript : MonoBehaviour {

    void OnTriggerStay(Collider other)  
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.AddForce(Vector3.up * 10);
            Debug.Log("boom?");
        }
    }
}
