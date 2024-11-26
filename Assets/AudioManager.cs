using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetMasterVolume(float value)
    {
        float volumen = Mathf.Log10(value) * 50;
        if (volumen < -80)
            volumen = -80;
        mixer.SetFloat("Master", volumen); // Convierte a escala logarítmica

    }
    public void SetMusicVolume(float value)
    {
        float volumen = Mathf.Log10(value) * 50;
        if (volumen < -80)
            volumen = -80;
        mixer.SetFloat("Musica", volumen); // Convierte a escala logarítmica
    }

    public void SetSFXVolume(float value)
    {
        float volumen = Mathf.Log10(value) * 50;
        if (volumen < -80)
            volumen = -80;
        mixer.SetFloat("Efectos", volumen); // Convierte a escala logarítmica
    }
}
