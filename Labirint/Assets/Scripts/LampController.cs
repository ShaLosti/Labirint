using System;
using System.Collections;
using UnityEngine;

public class LampController : MonoBehaviour, ITakeble
{
    public void OnTake()
    {
        Destroy(gameObject);
    }
}
