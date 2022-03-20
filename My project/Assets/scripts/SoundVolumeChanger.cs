using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolumeChanger : MonoBehaviour
{

    [HideInInspector] private AudioSource _audio;

    private float _minValue = 0;
    private float _maxValue = 1;
 
    private float _audioLength => _audio.clip.length;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
       if(_audio.isPlaying == true)
       {            
            float normalizedTime = _audio.time / _audioLength;

            if(_audio.volume < 0.5)
                _audio.volume = Mathf.MoveTowards(_minValue, _maxValue, normalizedTime);

            if(_audio.volume > 0.5)
                _audio.volume = Mathf.MoveTowards(_maxValue, _minValue, normalizedTime);
       }
    }

}
