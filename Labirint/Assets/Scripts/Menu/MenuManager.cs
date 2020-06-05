using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private ScreenControllerUI hideAllScreen;
    [SerializeField] private AudioSource myFx;
    [SerializeField] private AudioClip hoverFx;
    [SerializeField] private AudioClip clickFx;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private GameObject startMenuPanel;
    [SerializeField] private TMP_Dropdown resolutionDropDown;
    [SerializeField] private Toggle fullScreenToggle;

    private GameObject settingsMenuPanel;
    private Resolution[] resolutions;

    private void Start()
    {
        if(resolutionDropDown != null)
            SetStartResolution();

        volumeSlider.value = Settings.commonVolume;
        Screen.fullScreen = Settings.isFullScreenState != 0;
        settingsMenuPanel = volumeSlider.gameObject.transform.parent.gameObject;
        if (myFx == null)
            TryGetComponent<AudioSource>(out myFx);

        fullScreenToggle.isOn = Settings.isFullScreenState != 0;
    }

    private void SetStartResolution()
    {
        int currentResolutionIndex = 0;
        resolutionDropDown.options.Clear();
        resolutions = Screen.resolutions;
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = resolutions[i].width + " x " + resolutions[i].height;
            resolutionDropDown.options.Add(option);

            if (resolutions[i].width == Settings.width
                && resolutions[i].height == Settings.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void ShowPauseMenu(bool state)
    {
        if(state == true)
        {
            Time.timeScale = 0;
            hideAllScreen.ScreenOn();
            gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            hideAllScreen.ScreenOff();
            gameObject.SetActive(false);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ChangePanels()
    {
        startMenuPanel.SetActive(!startMenuPanel.activeSelf);
        settingsMenuPanel.SetActive(!volumeSlider.IsActive());
    }
    public void ChangeCommonSoundValue()
    {
        GameManager.ChangeVolumeValue(volumeSlider.value);
    }
    public void ChangeCommonResolutionValue(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        GameManager.ChangeResolutionValue(resolution.width, resolution.height);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void FullScreenChanger(bool state)
    {
        Settings.isFullScreenState = state ? 1 : 0;
        Screen.fullScreen = state;
    }

    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);
    }

    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }

}
