using UnityEngine;

public class Stick : Interactable
{

    public Equipment item;

    public override void Interact(Transform playerTransform)
    {
        base.Interact(playerTransform);

        PickUp();
        item.Use();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool pickedUp = Inventory.instance.Add(item);
        if(pickedUp)
            Destroy(gameObject);
    }

}
