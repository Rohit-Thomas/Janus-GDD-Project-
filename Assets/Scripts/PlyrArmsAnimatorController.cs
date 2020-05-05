using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyrArmsAnimatorController : MonoBehaviour
{
    Animator animator;
    private PlayerMovement p1;
    //bool hasBone;

    // Start is called before the first frame update
    void Start()
    {
        //hasBone = EquipmentManager.instance.handWithBone;
        animator = GetComponent<Animator>();
        p1 = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isMoving", p1.isMoving);
        //animator.SetBool("hasBone", hasBone);
    }

    public void RightClick()
    {
        animator.Play("Button");
    }

    void SwapDim()
    {
        StartCoroutine(p1.dimSwap());
    }
}
