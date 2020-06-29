using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RootNamespace.Menu
{

    public static class Settings
    {
        public static float commonVolume;
        public static int width;
        public static int height;
        public static int isFullScreenState;

        public static void LoadData()
        {
            commonVolume = PlayerPrefs.GetFloat("GlobalVolume");
            width = PlayerPrefs.GetInt("ScreenWidth");
            height = PlayerPrefs.GetInt("ScreenHeight");
            isFullScreenState = PlayerPrefs.GetInt("FullScreenState");
        }

        public static void SaveData()
        {
            PlayerPrefs.SetFloat("GlobalVolume", commonVolume);
            PlayerPrefs.SetInt("ScreenWidth", width);
            PlayerPrefs.SetInt("ScreenHeight", height);
            PlayerPrefs.SetInt("FullScreenState", isFullScreenState);
        }

        public static void printValues()
        {
            Debug.Log(width);
            Debug.Log(height);
            Debug.Log(commonVolume);
            Debug.Log(isFullScreenState);
        }
    }
}