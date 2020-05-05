using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueAnimator : MonoBehaviour
{
    const float movementAnimationSmoothTime = .1f;
    Animator animator;
    Statue Statue;
    
    bool isClose;

    // Start is called before the first frame update
    void Start()
    {
        Statue = GetComponent<Statue>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        animator.SetBool("isClose", Statue.isClose);
    }
}
