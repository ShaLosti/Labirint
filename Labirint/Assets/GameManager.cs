using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Settings currentSettings;


    public static int2 screenSettings;
    public static float musicVolum = 1f;
    private void Awake()
    {
        screenSettings.x = currentSettings.screenWidth;
        screenSettings.y = currentSettings.screenHeight;
        musicVolum = currentSettings.commonVolum;
        print(musicVolum);
        currentSettings.commonVolum = .5f;
    }

    public static void ChangeCommonVolumValue()
    {
        musicVolum = .5f;
    }
}
