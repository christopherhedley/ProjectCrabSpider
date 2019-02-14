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
    public float removingSpidersTimer = 2f;
    private int spidersAttached = 0;
    private bool removingSpiders = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            spidersAttached += 1;
            Debug.Log(other.name);
            other.gameObject.SetActive(false);
            UpdateSpiders();
        }

        if (other.tag == "Safe Zone")
        {
            inSafeZone = true;
            Debug.Log("inSafeZone = " + inSafeZone);
        }
        if (other.tag == "Objective")
        {
            other.gameObject.SetActive(false);
            g_manager.YouWin();
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            removingSpiders = true;
            Debug.Log("Holding E");
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            removingSpiders = false;
            removingSpidersTimer = 2f;
            Debug.Log("Released E");
        }

        if (removingSpiders && removingSpidersTimer > 0 && spidersAttached > 0)
        {
            removingSpidersTimer -= Time.deltaTime;
        }

        if (removingSpidersTimer <= 0)
        {
            spidersAttached -= 1;
            UpdateSpiders();
            removingSpidersTimer = 2f;
        }
    }

    private void UpdateSpiders()
    {
        spiderAttachedText.text = "Spiders Attached: " + spidersAttached;
        if (spidersAttached == 0)
        {
            screenBlock1.gameObject.SetActive(false);
            screenBlock2.gameObject.SetActive(false);
            screenBlock3.gameObject.SetActive(false);
        }

        if (spidersAttached == 1)
        {
            screenBlock1.gameObject.SetActive(true);
            screenBlock2.gameObject.SetActive(false);
            screenBlock3.gameObject.SetActive(false);
        }
        if (spidersAttached == 2)
        {
            screenBlock2.gameObject.SetActive(true);
            screenBlock3.gameObject.SetActive(false);
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
}
