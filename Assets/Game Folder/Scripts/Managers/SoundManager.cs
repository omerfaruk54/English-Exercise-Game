using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnglishExercise.Scripts
{
    public class SoundManager : MonoBehaviour
    {

        [SerializeField] AudioClip[] audioClips;

        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayTrueSound()
        {
            if (audioClips.Length > 0)
            {
                audioSource.clip = audioClips[0];
                audioSource.Play();
            }
        }

        public void PlayWrongSound()
        {
            if (audioClips.Length > 1)
            {
                audioSource.clip = audioClips[1];
                audioSource.Play();
            }
        }
    }
}
