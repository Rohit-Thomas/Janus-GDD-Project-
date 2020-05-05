using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region singelton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    public GameObject baitStand;
    public GameObject chickenOnStand;
    public GameObject baitStand2;
    public GameObject chickenOnStand2;
    public GameObject baitStand3;
    public GameObject chickenOnStand3;

}
