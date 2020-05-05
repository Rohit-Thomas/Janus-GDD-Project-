using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitStand : Interactable
{
    public Equipment bone;
    public GameObject bonePlaced;
    public GameObject boneOnHand;

    public override void Interact(Transform playerTransform)
    {
        base.Interact(playerTransform);

        Place();
    }

    void Place()
    {
        Debug.Log("Placing Bait " );
        if (Inventory.instance.items[0] == bone) 
        {
            if (bonePlaced.activeSelf == false)
            {
                bonePlaced.SetActive(true);
                Inventory.instance.Remove(bone);
                EquipmentManager.instance.Unequip(0);
            }
        }
    }

}
