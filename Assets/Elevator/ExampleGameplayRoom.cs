using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExampleGameplayRoom : MonoBehaviour
{
    public List<Light> RoomLights;

	void Awake()
    {
        KMGameplayRoom gameplayRoom = GetComponent<KMGameplayRoom>();
        Debug.Log("Setting on light change");
        OnLightChange(false);
        gameplayRoom.OnLightChange = OnLightChange;
	}

    public void OnLightChange(bool on)
    {
        foreach (Light light in RoomLights)
        {
            light.enabled = on;
        }
    }
}
