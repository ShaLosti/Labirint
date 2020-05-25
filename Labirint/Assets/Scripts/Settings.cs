using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New settings", menuName = "Settings")]
public class Settings : ScriptableObject
{
    public float commonVolume = 1f;
    public int screenWidth = 1920;
    public int screenHeight = 1080;
}
