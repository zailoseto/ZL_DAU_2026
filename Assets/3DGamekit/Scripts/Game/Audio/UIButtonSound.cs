using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    // Update is called once per frame
   public void onClick()
    {
        AkUnitySoundEngine.PostEvent("Play_Confirm", gameObject);
    }
}

