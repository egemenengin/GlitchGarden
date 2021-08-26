// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsController : MonoBehaviour
{
    Slider volumeSlider;
    Slider difficultySlider;
    float defaultVolume = 0.2f;
    float defaultDifficulty = 0.5f;

    // Start is called before the first frame update
    private void Awake()
    {
        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        difficultySlider = GameObject. Find("DifficultySlider").GetComponent<Slider>();
    }
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.getVolume();
        difficultySlider.value = PlayerPrefsController.getDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setDefault()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
    public void saveAndExit()
    {
        PlayerPrefsController.setVolume(volumeSlider.value);
        PlayerPrefsController.setDifficulty(difficultySlider.value);
    }
    public void setValues()
    {
        volumeSlider.value = PlayerPrefsController.getVolume();
        difficultySlider.value = PlayerPrefsController.getDifficulty();
    }
}
