﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Inventory : MonoBehaviour
{
    public List<string> objects;

    [SerializeField] private GameObject flashLight;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ITakeble>() != null)
            TakeObjectToInvertory(collision.gameObject);
    }

    private void TakeObjectToInvertory(GameObject obj)
    {
        objects.Add(obj.tag);
        UpdatePlrComponents();
    }

    private void UpdatePlrComponents()
    {
        if (objects.Contains("FlashLight"))
        {
            Instantiate(flashLight, gameObject.transform);
        }
    }
}
