using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider mouseSensitivitySlider;
    public Dropdown graphicsDropdown;
    public Toggle fullscreenToggle;
    public Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public Button applyButton;

    public Text mouseSensitivityText;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            resolutionOptions.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        fullscreenToggle.isOn = Screen.fullScreen;

        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicsQuality", 2));

        applyButton.interactable = false;
    }

    public void SetMouseSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity);
        PlayerPrefs.Save();
        applyButton.interactable = true;

        if (mouseSensitivityText != null)
        {
            mouseSensitivityText.text = sensitivity.ToString();
        }
    }

    public void SetGraphicsQuality(int qualityIndex)
    {
        PlayerPrefs.SetInt("GraphicsQuality", qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
        applyButton.interactable = true;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        applyButton.interactable = true;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        applyButton.interactable = true;
    }

    public void ApplySettings()
    {
        PlayerPrefs.Save();
        applyButton.interactable = false;
    }
}