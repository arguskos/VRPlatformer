using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSpawner : MonoBehaviour {

    public GameObject Bridge2Tile;
    public GameObject Bridge3Tile;
    public GameObject Bridge4Tile;
    public int SpawnID;
    public int TeamID;

    public Material Mat1;
    public Material Mat2;

    private GameObject _rotatingMiniature;
    private float _hoverStep;
    private float _miniatureScale = 0.3f;
    private float _startHeight;
    private GameObject _sphere;

    // Use this for initialization
    void Start () {
        _sphere = gameObject.transform.GetChild(0).gameObject;

        _startHeight = transform.position.y;

        if (SpawnID == 0)
        {
            _rotatingMiniature = Instantiate(Bridge2Tile, transform, true);
            _rotatingMiniature.transform.localScale = new Vector3(_miniatureScale, _miniatureScale, _miniatureScale);
            _rotatingMiniature.transform.position = transform.position;
        }
        else if (SpawnID == 1)
        {
            _rotatingMiniature = Instantiate(Bridge3Tile, transform, true);
            _rotatingMiniature.transform.localScale = new Vector3(_miniatureScale, _miniatureScale, _miniatureScale);
            _rotatingMiniature.transform.position = transform.position;
        }
        else if (SpawnID == 2)
        {
            _rotatingMiniature = Instantiate(Bridge4Tile, transform, true);
            _rotatingMiniature.transform.localScale = new Vector3(_miniatureScale, _miniatureScale, _miniatureScale);
            _rotatingMiniature.transform.position = transform.position;
        }


        if (TeamID == 1)
        {
            _sphere.GetComponent<Renderer>().material = Mat1;
            _sphere.transform.GetChild(0).GetComponent<Renderer>().material = Mat1;
        }
        else if (TeamID == 2)
        {
            _sphere.GetComponent<Renderer>().material = Mat2;
            _sphere.transform.GetChild(0).GetComponent<Renderer>().material = Mat2;
        }

    }
	
	// Update is called once per frame
	void Update () {
        //Rotate Miniature
        iTween.RotateAdd(_rotatingMiniature, new Vector3(0, 1, 0), 0.0025f);

        //Move Miniature up and down
        _hoverStep += 0.05f;
        //Make sure Steps value never gets too out of hand 
        if (_hoverStep > 999999) { _hoverStep = 1; }

        //Float up and down along the y axis, 
        _rotatingMiniature.transform.position = new Vector3(_rotatingMiniature.transform.position.x, _startHeight + (Mathf.Sin(_hoverStep)/25), _rotatingMiniature.transform.position.z);
        _sphere.transform.position = new Vector3(_sphere.transform.position.x, _startHeight + (Mathf.Sin(_hoverStep) / 25), _sphere.transform.position.z);
    }
}
