using System;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Settings.LoadData();
        ChangeVolumeValue(Settings.commonVolume);
        ChangeResolutionValue(Settings.width, Settings.height);
    }

    private void OnDisable()
    {
        Settings.SaveData();
    }

    public static void ChangeVolumeValue(float volumeValue)
    {
        Settings.commonVolume = volumeValue;
        AudioListener.volume = Settings.commonVolume;
    }
    public static void ChangeResolutionValue(int width, int height)
    {
        Settings.width = width;
        Settings.height = height;
        Screen.SetResolution(width, height, FullScreenMode.ExclusiveFullScreen);
    }
}
