using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private ScreenControllerUI hideAllScreen;
    [SerializeField] private AudioSource myFx;
    [SerializeField] private AudioClip hoverFx;
    [SerializeField] private AudioClip clickFx;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private GameObject startMenuPanel;
    [SerializeField] private Dropdown resolutionDropDown;

    private GameObject settingsMenuPanel;

    private void Start()
    {
        volumeSlider.value = Settings.commonVolume;
        settingsMenuPanel = volumeSlider.gameObject.transform.parent.gameObject;
        if (myFx == null)
            TryGetComponent<AudioSource>(out myFx);
    }

    public void ShowPauseMenu(bool state)
    {
        if(state == true)
        {
            Time.timeScale = 0;
            hideAllScreen.ScreenOn();
            gameObject.SetActive(true);
            print("Time scale 0");
        }
        else
        {
            Time.timeScale = 1;
            hideAllScreen.ScreenOff();
            gameObject.SetActive(false);
            print("Time scale 1");
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
    public void ChangeCommonResolutionValue()
    {

        print("Resolution func");
    }

    public void ExitGame()
    {
        Application.Quit();
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
