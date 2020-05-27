using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    public static float commonVolume;
    public static int width;
    public static int height;

    public static void LoadData()
    {
        commonVolume = PlayerPrefs.GetFloat("GlobalVolume");
        width = PlayerPrefs.GetInt("ScreenWidth");
        height = PlayerPrefs.GetInt("ScreenHeight");
    }

    public static void SaveData()
    {
        PlayerPrefs.SetFloat("GlobalVolume", commonVolume);
        PlayerPrefs.SetInt("ScreenWidth", width);
        PlayerPrefs.SetInt("ScreenHeight", height);
    }
}
