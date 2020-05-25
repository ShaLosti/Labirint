using System;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Settings settings;

    public static int2 screenSettings;
    public static float musicVolume = 1f;
    private void Awake()
    {
        screenSettings.x = settings.screenWidth;
        screenSettings.y = settings.screenHeight;
        musicVolume = settings.commonVolume;
    }

    private void Start()
    {
        ChangeVolumeValue(musicVolume);
    }

    public static void ChangeVolumeValue(float volumeValue)
    {
        musicVolume = volumeValue;
        AudioListener.volume = musicVolume;
    }
}
