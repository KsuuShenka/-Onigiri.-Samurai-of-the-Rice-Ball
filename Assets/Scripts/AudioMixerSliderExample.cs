using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerSliderExample : MonoBehaviour
{
    private const float disabledVolume = -80;
    [SerializeField] private Slider mixerSlider;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string mixerParameter;
    [SerializeField] private float minVolume;

    private void Start()
    {   
        mixerSlider.SetValueWithoutNotify(GetMixerVolume());
    }

    public void UpdateMixerVolume(float volumeValue)
    {
        SetMixerVolume(volumeValue);
    }
    private void SetMixerVolume(float volumeValue)
    {
        float mixerVolume;
        if (volumeValue == 0)
            mixerVolume = disabledVolume;
        else
            mixerVolume = Mathf.Lerp(minVolume, 0, volumeValue);
        audioMixer.SetFloat(mixerParameter, mixerVolume);
    }

    private float GetMixerVolume()
    {
        audioMixer.GetFloat(mixerParameter, out float mixerVolume);
        if (mixerVolume == disabledVolume)
            return 0;
        else
            return Mathf.Lerp(1, 0, mixerVolume / minVolume);
    }

}
