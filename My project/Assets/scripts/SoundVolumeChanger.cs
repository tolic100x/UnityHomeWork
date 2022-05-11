using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolumeChanger : MonoBehaviour
{

    [HideInInspector] private AudioSource _audio;
    private PlayerChecker playerChecker;
 
    private float _audioLength => _audio.clip.length;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        playerChecker = GetComponent<PlayerChecker>();
        _audio.volume = 0;
    }
    private void Update()
    {
        float normalizedTime = _audio.time / _audioLength;

        if (playerChecker.isInHouse)
        {
                if(_audio.volume < 0.9f)
                _audio.volume = Mathf.MoveTowards(0, 0.9f, normalizedTime);      
        }

        if (playerChecker.isInHouse == false)
        {
            _audio.volume = Mathf.MoveTowards(0.8f, 0, normalizedTime);
            if (_audio.volume <= 0.1)
                _audio.Stop();
        }
    }


}
