using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TileSpawner))]
public class TileSpawnerTools: Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
        
		TileSpawner myScript = (TileSpawner)target;
		if(GUILayout.Button("SpawnIce"))
		{
			myScript.SpawnIce();
		}
		
	}
}