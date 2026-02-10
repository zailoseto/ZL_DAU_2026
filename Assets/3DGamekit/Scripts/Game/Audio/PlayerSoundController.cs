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
            Debug.Log(surfaceRenderer); //this is what prints out to the Console what surface you are stepping on
            if (surfaceRenderer)
            {
                Debug.Log(surfaceRenderer.material.name);
                if (surfaceRenderer.material.name.Contains("Moss") || surfaceRenderer.material.name.Contains("Vegetation"))
                {
                    AkUnitySoundEngine.SetSwitch("SurfaceMaterial", "Grass", player_footstep_source);
                }

                if (surfaceRenderer.material.name.Contains("Mud") || surfaceRenderer.material.name.Contains("Ridge") || surfaceRenderer.material.name.Contains("Cliff") || surfaceRenderer.material.name.Contains("Chunk") || surfaceRenderer.material.name.Contains("Ledge"))
                {
                    AkUnitySoundEngine.SetSwitch("SurfaceMaterial", "Mud", player_footstep_source);
                }

                if (surfaceRenderer.material.name.Contains("Floor")|| surfaceRenderer.material.name.Contains("Platform")|| surfaceRenderer.material.name.Contains("Wall")|| surfaceRenderer.material.name.Contains("Pedestal")|| surfaceRenderer.material.name.Contains("Stairs")|| surfaceRenderer.material.name.Contains("Null")|| surfaceRenderer.material.name.Contains("Rocks")|| surfaceRenderer.material.name.Contains("Box")|| surfaceRenderer.material.name.Contains("Pad"))
                {
                    AkUnitySoundEngine.SetSwitch("SurfaceMaterial", "Rock", player_footstep_source);
                }

                if (surfaceRenderer.material.name.Contains("ship"))
                {
                    AkUnitySoundEngine.SetSwitch("SurfaceMaterial", "Ship", player_footstep_source);
                    Debug.Log("Detected Ship");
                    Debug.Log(gameObject);
                }

            }
        }
    }

}
