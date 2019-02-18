using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Anim : MonoBehaviour {

    public Animator anim;
    public SphereCollider sctouch;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        sctouch = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("PlayerNear", true);
    }
}
