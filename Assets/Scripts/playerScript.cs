using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour {

    public Text spiderAttachedText;
    public Image screenBlock1;
    public Image screenBlock2;
    public Image screenBlock3;
    private int spidersAttached = 0;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spiderAttachedText.text = "Spiders Attached: " + spidersAttached;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            spidersAttached += 1;
            other.gameObject.SetActive(false);

            if (spidersAttached == 1)
            {
                screenBlock1.gameObject.SetActive(true);
            }
            if (spidersAttached == 2)
            {
                screenBlock2.gameObject.SetActive(true);
            }
            if (spidersAttached == 3)
            {
                screenBlock3.gameObject.SetActive(true);
            }

            Debug.Log(other.name);
        }
    }
}
