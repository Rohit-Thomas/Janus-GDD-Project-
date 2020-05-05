using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageAnimator : MonoBehaviour
{
    const float movementAnimationSmoothTime = .1f;
    public float cageNumber = 1;
    public GameObject openCage;
    public GameObject closedCage;
    Animator animator;
    CageButton CageButton;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        CageButton = GetComponentInChildren<CageButton>();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetBool("Closed", CageButton.isPushed);

        if (cageNumber == 1)
        {
            animator.SetBool("Closed", CageButton.isPushed);
        }
        else if (cageNumber == 2)
        {
            animator.SetBool("Closed", CageButton.isPushed1);
        }
        else if (cageNumber == 3)
        {
            animator.SetBool("Closed", CageButton.isPushed2);
        }
    }

    void SwapObject()
    {
        if (openCage.activeSelf == true)
        {
            closedCage.SetActive(true);
            //yield return new WaitUntil(() => pushedButton.activeSelf == true);
            openCage.SetActive(false);
        }
    }
}
