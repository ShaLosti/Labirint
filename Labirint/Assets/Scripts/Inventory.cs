using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Inventory : MonoBehaviour
{
    private List<string> objects = new List<string>();

    [SerializeField] private GameObject flashLight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<ITakeble>(out ITakeble takeble);
        if (takeble != null)
            takeble.OnTake(this);
    }

    public void TakeObjectToInvertory(GameObject obj)
    {
        objects.Add(obj.tag);
        UpdatePlrComponents();
    }

    private void UpdatePlrComponents()
    {
        if (objects.Contains("FlashLight"))
        {
            flashLight.GetComponent<Light2D>().intensity = 1;
        }
        if (objects.Contains("Key"))
        {
            GameManager.canOpenTheDoor = true;
        }
        if (objects.Contains("Notebook"))
        {
            flashLight.GetComponent<Light2D>().intensity = 1;
        }
    }
}
