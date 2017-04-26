using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

	// Use this for initialization
    public GameObject Platform;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.S))
	    {
	        Spawn();
	    }
	}
    static public Rect GetWorldRect(RectTransform rt, Vector2 scale )
    {
        // Convert the rectangle to world corners and grab the top left
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);
        Vector3 topLeft = corners[0];

        // Rescale the size appropriately based on the current Canvas scale
        Vector2 scaledSize = new Vector2(scale.x * rt.rect.size.x, scale.y * rt.rect.size.y);

        return new Rect(topLeft, scaledSize);
    }
    void Spawn()
    {
        Bounds bd = GetComponent<BoxCollider>().bounds;
        float x = Random.Range(bd.center.x - bd.extents.x, bd.center.x + bd.extents.x);
        float y = Random.Range(bd.center.y - bd.extents.y, bd.center.y + bd.extents.y);

        float z = Random.Range(bd.center.z - bd.extents.z, bd.center.z + bd.extents.z);
        Instantiate(Platform, new Vector3(x, y, z), Quaternion.identity);

    }
}
