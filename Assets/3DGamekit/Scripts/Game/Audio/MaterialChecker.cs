using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise; // Needed if using the AkSoundEngine.SetSwitch method

public class MaterialChecker : MonoBehaviour
{
    // Define the Wwise Switch Group name
    public string surfaceSwitchGroup = "SurfaceMaterial";

    // You can also use a Wwise Switch type directly if preferred
    // public AK.Wwise.Switch surfaceSwitch; 

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // This function is called when the character controller hits a collider
        CheckMaterial(hit.collider);
    }

    private void CheckMaterial(Collider collider)
    {
        // Check if the collider has a PhysicMaterial assigned
        if (collider.sharedMaterial != null)
        {
            string materialName = collider.sharedMaterial.name;

            // Set the Wwise Switch based on the material name
            // Note: The material name in Unity must exactly match the Switch name in Wwise
            AkUnitySoundEngine.SetSwitch(surfaceSwitchGroup, materialName, gameObject);
        }
        else
        {
            // Fallback for objects without a specific PhysicMaterial
            // Consider a default surface type in Wwise
            // AkSoundEngine.SetSwitch(surfaceSwitchGroup, "Default", gameObject);
        }
    }

    // Example function to call from an Animation Event to post the actual footstep sound
    public void PlayFootstepSound()
    {
        // Post the general footstep event, Wwise will handle which sound to play 
        // based on the currently active Switch set by CheckMaterial()
        AkUnitySoundEngine.PostEvent("Footstep", gameObject);
    }
}
