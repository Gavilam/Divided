using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TittleMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [Header("Settings elements")]
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    string settingsSaveFilePath;
    SettingsData settingsData;

    private void Awake()
    {
        settingsData = new SettingsData();
        settingsSaveFilePath = Application.persistentDataPath + "/SettingsData.json";
    }

    private void Start()
    {
        LoadSettings();
    }

    public void LoadScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Juego cerrado");
        Application.Quit();
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music_volume", volume);
        audioMixer.GetFloat("Music_volume", out settingsData.musicVolume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX_volume", volume);
        audioMixer.GetFloat("SFX_volume", out settingsData.SFXVolume);
    }

    //Guarda los valores de saveSettingsData en un Json
    public void SaveSettings()
    {
        string saveSettingsData = JsonUtility.ToJson(settingsData);
        File.WriteAllText(settingsSaveFilePath, saveSettingsData);
    }

    //Le los datos de ajuste guardados y los aplica a los diverson componentes/elementos
    void LoadSettings()
    {
        string loadSettingsData = File.ReadAllText(settingsSaveFilePath);
        settingsData = JsonUtility.FromJson<SettingsData>(loadSettingsData);
        audioMixer.SetFloat("SFX_volume", settingsData.SFXVolume);
        audioMixer.SetFloat("Music_volume", settingsData.musicVolume);
        musicSlider.value = settingsData.musicVolume;
        SFXSlider.value = settingsData.SFXVolume;
    }

    //Clase contenedora de los datos de ajuste
    public class SettingsData
    {
        public float musicVolume;
        public float SFXVolume;
    }
}
