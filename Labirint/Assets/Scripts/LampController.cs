using System;
using System.Collections;
using UnityEngine;

public class LampController : MonoBehaviour, ITakeble
{
    public void OnTake(Inventory inventory)
    {
        inventory.TakeObjectToInvertory(gameObject);
        Destroy(gameObject);
    }
}
