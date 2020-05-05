using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardUI : MonoBehaviour
{

    public GameObject blueKeycard;
    public GameObject redKeycard;
    public GameObject greenKeycard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (DeathScreen.isDead == true)
            Destroy(gameObject);

        if(KeyCard.key1 == true)
        {
            if(blueKeycard.activeSelf == false)
            {
                blueKeycard.SetActive(true);
            }
        }
        else
        {
            if (blueKeycard.activeSelf == true)
            {
                blueKeycard.SetActive(false);
            }
        }

        if (KeyCard.key2 == true)
        {
            if (redKeycard.activeSelf == false)
            {
                redKeycard.SetActive(true);
            }
        }
        else
        {
            if (redKeycard.activeSelf == true)
            {
                redKeycard.SetActive(false);
            }
        }

        if (KeyCard.key3 == true)
        {
            if (greenKeycard.activeSelf == false)
            {
                greenKeycard.SetActive(true);
            }
        }
        else
        {
            if (greenKeycard.activeSelf == true)
            {
                greenKeycard.SetActive(false);
            }
        }
    }
}
