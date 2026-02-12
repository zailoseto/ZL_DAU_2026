using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class PostWwiseEvent : MonoBehaviour
{
    public AK.Wwise.Event MyEvent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayEvent()
    {
        MyEvent.Post(gameObject);
    }
}
