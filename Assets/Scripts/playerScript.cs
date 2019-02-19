using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class playerScript : MonoBehaviour {

    public GameManager g_manager;
    public static bool inSafeZone;
    public Text spiderAttachedText;
    public Text pressEText;
    public Text pressFText;
    public Slider spiderSlider;
    public Image screenBlock1;
    public Image screenBlock2;
    public Image screenBlock3;
    public float removingSpidersTimer = 2f;
    private int spidersAttached = 0;
    private bool removingSpiders = false;
    public Animator anim;

    private void Start()
    {
        pressEText.gameObject.SetActive(false);
        pressFText.gameObject.SetActive(false);
        spiderSlider.gameObject.SetActive(false);
    }

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
            pressFText.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Safe Zone")
        {
            inSafeZone = false;
            Debug.Log("inSafeZone = " + inSafeZone);
        }

        if (other.tag == "Objective")
        {
            pressFText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Objective")
        {
            if (Input.GetButtonDown("Pull"))
            {
                pressFText.gameObject.SetActive(false);
                anim.SetBool("PlayerNear", true);
                StartCoroutine("leverDelay");
            }
        }
    }

    IEnumerator leverDelay()
    {
        yield return new WaitForSeconds(1.2f);
        pressEText.gameObject.SetActive(false);
        pressFText.gameObject.SetActive(false);
        spiderSlider.gameObject.SetActive(false);
        g_manager.YouWin();
        Debug.Log("YOU WIN!");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Shake"))
        {
            removingSpiders = true;
            Debug.Log("Holding E");
        }
        if (Input.GetButtonUp("Shake"))
        {
            removingSpiders = false;
            removingSpidersTimer = 2f;
            spiderSlider.gameObject.SetActive(false);
            Debug.Log("Released E");
        }

        if (removingSpiders && removingSpidersTimer > 0 && spidersAttached > 0 && Time.timeScale == 1)
        {
            removingSpidersTimer -= Time.deltaTime;
            spiderSlider.gameObject.SetActive(true);
            spiderSlider.value = removingSpidersTimer;
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
            spiderSlider.gameObject.SetActive(false);
            pressEText.gameObject.SetActive(false);
        }

        if (spidersAttached == 1)
        {
            screenBlock1.gameObject.SetActive(true);
            screenBlock2.gameObject.SetActive(false);
            screenBlock3.gameObject.SetActive(false);
            pressEText.gameObject.SetActive(true);
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
            pressEText.gameObject.SetActive(false);
            pressFText.gameObject.SetActive(false);
            spiderSlider.gameObject.SetActive(false);
            g_manager.GameOver();
            Debug.Log("GAME OVER");
        }
    }
}
