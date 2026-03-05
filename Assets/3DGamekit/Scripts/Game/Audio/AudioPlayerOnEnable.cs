using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

namespace Gamekit3D
{
    public class AudioPlayerOnEnable : MonoBehaviour
    {
        //public RandomAudioPlayer player;
        public AK.Wwise.Event Play_GrenadierShield;
        public GameObject GrenadierShield_Source;

        public bool stopOnDisable = false;

        void OnEnable()
        {
            //player.PlayRandomClip();
            Play_GrenadierShield.Post(GrenadierShield_Source);
        }

        //private void OnDisable()
        //{
            //if (stopOnDisable)
                //player.audioSource.Stop();
                //Play_GrenadierShield.GrenadierShield_Source.Stop();
        //}
    } 
}
