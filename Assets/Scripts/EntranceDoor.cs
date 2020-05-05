using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoor : MonoBehaviour
{

    public GameObject Door;
    private Vector3 openPosition;
    private Vector3 closePosition;
    public float moveSpeed = 2.5f;
    bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        closePosition = Door.transform.position;
        openPosition = new Vector3(Door.transform.position.x, Door.transform.position.y + 8f, Door.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
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
        if(other.tag == "Player")
        {
            isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isOpen = false;
        }
    }
}
