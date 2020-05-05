using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit2Door : MonoBehaviour
{
    public GameObject Door;
    private Vector3 openPosition;
    private Vector3 closePosition;
    public float moveSpeed = 2.5f;
    bool isOpen;
    public bool key1, key2, key3;

    // Start is called before the first frame update
    void Start()
    {
        closePosition = Door.transform.position;
        openPosition = new Vector3(Door.transform.position.x, Door.transform.position.y + 8f, Door.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        key1 = KeyCard.key1;
        key2 = KeyCard.key2;
        key3 = KeyCard.key3;
        //Door.transform.position = Vector3.Lerp(openPosition, closePosition, moveSpeed * Time.deltaTime);
        if (isOpen)
        {
            Door.transform.position = Vector3.Lerp(Door.transform.position, openPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            Door.transform.position = Vector3.Lerp(Door.transform.position, closePosition, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && KeyCheck())
        {
            isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isOpen = false;
        }
    }

    bool KeyCheck()
    {
        if (key1 && key2 && key3)
            return true;
        else
            return false;
    }
}
