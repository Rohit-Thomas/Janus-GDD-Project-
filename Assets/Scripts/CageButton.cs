using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageButton : Interactable
{

    public GameObject normalButton;
    public GameObject pushedButton;
    public static bool isPushed;
    public static bool isPushed1;
    public static bool isPushed2;
    Animator animator;
    public float buttonNumber = 1;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isPushed = false;
        isPushed1 = false;
        isPushed2 = false;
}

    private void Update()
    {
        //animator.SetBool("isPushed", isPushed);
        if (buttonNumber == 1)
        {
            animator.SetBool("isPushed", isPushed);
        }
        else if (buttonNumber == 2)
        {
            animator.SetBool("isPushed", isPushed1);
        }
        else if (buttonNumber == 3)
        {
            animator.SetBool("isPushed", isPushed2);
        }
    }
    public override void Interact(Transform playerTransform)
    {
        base.Interact(playerTransform);
        PushButton();
    }

    void PushButton()
    {
        Debug.Log("Pushing Cage Button ");
        
        if (buttonNumber == 1)
        {
            if (isPushed == false)
            {
                isPushed = true;
                //transform.Translate(0, -0.5f, 0f);
            }
        }
        else if (buttonNumber == 2)
        {
            if (isPushed1 == false)
            {
                isPushed1 = true;
                //transform.Translate(0, -0.5f, 0f);
            }
        }
        else if (buttonNumber == 3)
        {
            if (isPushed2 == false)
            {
                isPushed2 = true;
                //transform.Translate(0, -0.5f, 0f);
            }
        }
    }

    void SwapObject()
    {
        if (normalButton.activeSelf == true)
        {
            pushedButton.SetActive(true);
            //yield return new WaitUntil(() => pushedButton.activeSelf == true);
            normalButton.SetActive(false);
        }        
    }

}