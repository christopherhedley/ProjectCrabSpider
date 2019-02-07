using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class playerScript : MonoBehaviour {

    public GameManager g_manager;
    public static bool inSafeZone;
    public Text spiderAttachedText;
    public Image screenBlock1;
    public Image screenBlock2;
    public Image screenBlock3;
    private int spidersAttached = 0;
	
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
                g_manager.GameOver();
                Debug.Log("GAME OVER");
            }
        }

        if (other.tag == "Safe Zone")
        {
            inSafeZone = true;
            Debug.Log("inSafeZone = " + inSafeZone);
        }
        if (other.tag == "Objective")
        {
            other.gameObject.SetActive(false);
            Debug.Log("YOU WIN!");
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
