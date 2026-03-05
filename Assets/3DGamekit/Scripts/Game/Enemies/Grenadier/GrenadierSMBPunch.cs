using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;


namespace Gamekit3D
{
    public class GrenadierSMBPunch : SceneLinkedSMB<GrenadierBehaviour>
    {
        public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (m_MonoBehaviour.punchAudioPlayer)
                m_MonoBehaviour.punchAudioPlayer.PlayRandomClip();
            //if (m_MonoBehaviour.grenadier_punch)
                //m_MonoBehaviour.grenadier_punch.Post(grenadier_punch_source);
        }
    }
}