using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlacementHelper : MonoBehaviour
{
    public GameObject Prefab;
    public float PrefabWidth;
    public float PrefabHeight;
    public float Width;
    public float Height;

    [ContextMenu("Place Prefabs")]
	public void PlacePrefabs()
    {
        foreach(Transform t in GetComponentsInChildren<Transform>())
        {
            if(t != transform)
            {
                Destroy(t.gameObject);
            }
        }

        int numX = (int)(Width / PrefabWidth);
        int numY = (int)(Height / PrefabHeight);

        for(int i = 0; i < numX; i++)
        {
            for(int j = 0; j < numY; j++)
            {
                GameObject inst = Instantiate(Prefab);
                inst.transform.parent = transform;
                inst.transform.localPosition = new Vector3(i * PrefabWidth, 0, -j * PrefabHeight);
            }
        }
    }
}
