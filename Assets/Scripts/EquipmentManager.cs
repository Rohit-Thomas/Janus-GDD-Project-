using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    Equipment[] currentEquipment;
    public Equipment bone;
    public GameObject handWithBone;
    public GameObject normalHand;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    public bool hasBone;

    private void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        currentEquipment[slotIndex] = newItem;

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, null);
        }
    }

    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            //inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            //drop the item
        }
        if(currentEquipment[0]== bone)
        {
            //Debug.Log(" bone in inventory");
            StartCoroutine(SwapToBone());
            hasBone = true;
        }
        else
        {
            StartCoroutine(SwapToHand());
            hasBone = false;
        }
    }

    private IEnumerator SwapToBone()
    {
        if (handWithBone.activeSelf == false)
        {
            handWithBone.SetActive(true);
            normalHand.SetActive(false);

        }
        yield return null;
    }

    private IEnumerator SwapToHand()
    {
        if (handWithBone.activeSelf == true)
        {
            handWithBone.SetActive(false);
            normalHand.SetActive(true);
        }
        yield return null;
    }

}
