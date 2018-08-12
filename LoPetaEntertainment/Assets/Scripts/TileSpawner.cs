using UnityEngine;
using System.Collections;

public class TileSpawner : MonoBehaviour 
{
	public GameObject tile;
	public float iceHeight;

	public float tileMapBegin;
	public float tileMapEnd;

    public void UpdateNavigation()
    {
        
    }

	public void SpawnIce()
	{
		Renderer rend = tile.transform.GetComponent<Renderer>();
		float width = rend.bounds.extents.x;
		float height = rend.bounds.extents.z*3.0f;

		int childs = transform.childCount;
		for (int i = childs - 1; i >= 0; i--)
		{
			DestroyImmediate(transform.GetChild(i).gameObject);
		}

		bool displace = false;
		for (float x = tileMapBegin; x < tileMapEnd; x += width)
		{
			displace = !displace;
			for (float z = tileMapBegin; z < tileMapEnd; z += height)
			{
				GameObject iceInstance = Instantiate(tile, transform);
				Vector3 icePos = transform.position;
				icePos.y = iceHeight;
				icePos.x += x;
				if (displace)
				{
					icePos.z += height / 2.0f;
				}

				icePos.z += z;

				iceInstance.transform.SetPositionAndRotation(
					icePos,
					iceInstance.transform.rotation
				);
			}
		}	



	}
}