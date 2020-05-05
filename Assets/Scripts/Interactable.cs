using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3f;

    bool isFocus = false;
    Transform player;

    public virtual void Interact(Transform playerTransform)
    {

        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (!(distance <= radius))
        {

            Debug.Log("Not Close enough to " + transform.name + distance);
            return;
        }
        //the interaction function
        Debug.Log("interacting with " + transform.name);
    }

    //private void Update()
    //{
    //    if (isFocus)
    //    {
    //        float distance = Vector3.Distance(player.position, transform.position);
    //        if (distance <= radius)
    //        {
    //            Interact();
    //        }
    //    }
    //}
    
    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
