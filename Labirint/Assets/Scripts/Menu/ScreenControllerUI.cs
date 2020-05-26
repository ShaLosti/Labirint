using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenControllerUI : MonoBehaviour
{
    public void ScreenOff()
    {
        gameObject.SetActive(false);
    }

    public void ScreenOn()
    {
        gameObject.SetActive(true);
    }
}
