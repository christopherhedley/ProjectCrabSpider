using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class playerScript : MonoBehaviour {

    public static bool inSafeZone;
    public static bool paused;
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
        if (Input.GetKeyUp(KeyCode.Escape) && !paused)
        {
            Time.timeScale = 0;
            paused = true;
            Debug.Log("paused");
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && paused)
        {
            Time.timeScale = 1;
            paused = false;
            Debug.Log("unpaused");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            spidersAttached += 1;
            spiderAttachedText.text = "Spiders Attached: " + spidersAttached;
            Debug.Log(other.name);
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
            if (spidersAttached == 4)
            {
                // Trigger GAME OVER screen
                Debug.Log("GAME OVER");
            }
        }

        if (other.tag == "Safe Zone")
        {
            inSafeZone = true;
            Debug.Log("inSafeZone = " + inSafeZone);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Safe Zone")
        {
            inSafeZone = false;
            Debug.Log("inSafeZone = " + inSafeZone);
        }
    }

    private void DetachSpider()
    {
        //if (spidersAttached == 1);
    }

}
