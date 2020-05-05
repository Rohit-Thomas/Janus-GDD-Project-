using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : Interactable
{
    Transform target;
    public GameObject floor1;
    public GameObject floor2;
    public AudioSource AudioSource;
    public AudioSource AudioSource1;
    public bool isClose;
    string statueSound;
    string dimCound;

    private void Start()
    {
        target = PlayerManager.instance.player.transform;
        statueSound = "Statue";
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= radius)
            isClose = true;
        else
            isClose = false;
    }

    public void PlaySound()
    {
        AudioSource.Play();
    }

    public override void Interact(Transform playerTransform)
    {
        base.Interact(playerTransform);

        StartCoroutine(dimSwap());
    }

    private IEnumerator dimSwap()
    {
        if (floor1.activeSelf == true)
        {
            AudioSource1.Play();
            floor2.SetActive(true);
            yield return new WaitUntil(() => floor2.activeSelf == true);
            floor1.SetActive(false);
        }
        else
        {
            AudioSource1.Play();
            floor1.SetActive(true);
            yield return new WaitUntil(() => floor2.activeSelf == true);
            floor2.SetActive(false);
        }
        yield return null;
    }

    
}
