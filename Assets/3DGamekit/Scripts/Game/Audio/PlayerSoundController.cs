using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

public class PlayerSoundController : MonoBehaviour
{

    [SerializeField]
    private AK.Wwise.Event player_footstep;

    [SerializeField]
    private GameObject player_footstep_source;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void anim_player_footstep()
    {
        GroundSwitch();
        AkUnitySoundEngine.SetSwitch("SurfaceMaterial", "Dirt", gameObject);
        player_footstep.Post(player_footstep_source);
    }

    private void GroundSwitch()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position + Vector3.up * 0.5f, -Vector3.up);
        Material surfaceMaterial;

        if (Physics.Raycast(ray, out hit, 1.0f, Physics.AllLayers, QueryTriggerInteraction.Ignore))
        {
            Renderer surfaceRenderer = hit.collider.GetComponentInChildren<Renderer>();
            if (surfaceRenderer)
            {
                Debug.Log(surfaceRenderer.material.name);
                if (surfaceRenderer.material.name.Contains("dirt"))
                {
                    AkUnitySoundEngine.SetSwitch("SurfaceMaterial", "Dirt", gameObject);
                }

                if (surfaceRenderer.material.name.Contains("mud"))
                {
                    AkUnitySoundEngine.SetSwitch("SurfaceMaterial", "Mud", gameObject);
                }

                if (surfaceRenderer.material.name.Contains("Stone"))
                {
                    AkUnitySoundEngine.SetSwitch("SurfaceMaterial", "Stone", gameObject);
                }

                if (surfaceRenderer.material.name.Contains("Ship"))
                {
                    AkUnitySoundEngine.SetSwitch("SurfaceMaterial", "Ship", gameObject);
                }

            }
        }
    }

}
