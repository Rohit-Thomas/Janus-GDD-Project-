using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : Interactable
{
    public GameObject exitPosition;
    public GameObject player;
    public float x, y, z;

    public override void Interact(Transform playerTransform)
    {
        base.Interact(playerTransform);
        //Function here
        moveUp();
    }

    void moveUp()
    {
        Debug.Log("Moving up the ladder");
        player.transform.SetPositionAndRotation(exitPosition.transform.position, exitPosition.transform.rotation);
    }
}
