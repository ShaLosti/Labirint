using System;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int2 screenSettings;
    public static float musicVolume = 1f;
    private void Awake()
    {
        Settings.LoadData();
        print($"Volume {Settings.commonVolume}");
        if(screenSettings.x != Settings.width || screenSettings.y != Settings.height)
        {
            screenSettings.x = Settings.width;
            screenSettings.y = Settings.height;
        }
        if(musicVolume != Settings.commonVolume)
            musicVolume = Settings.commonVolume;
    }

    private void OnDisable()
    {
        Settings.SaveData();
    }

    private void Start()
    {
        ChangeVolumeValue(musicVolume);
    }

    public static void ChangeVolumeValue(float volumeValue)
    {
        musicVolume = volumeValue;
        Settings.commonVolume = volumeValue;
        AudioListener.volume = musicVolume;
    }
}
