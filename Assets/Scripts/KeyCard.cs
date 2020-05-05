using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : Interactable
{
    public float keyNumber = 1;
    public static bool key1, key2, key3;
    public override void Interact(Transform playerTransform)
    {
        base.Interact(playerTransform);

        PickUp();
    }
    private void Start()
    {
        key1 = false;
        key2 = false;
        key3 = false;
    }

    void PickUp()
    {
        Debug.Log("Picking up keycard");
        if(keyNumber == 1)
        {
            key1 = true;
        }
        else if(keyNumber == 2)
        {
            key2 = true;
        }
        else if(keyNumber ==3)
        {
            key3 = true;
        }
        Destroy(gameObject);
    }
}
