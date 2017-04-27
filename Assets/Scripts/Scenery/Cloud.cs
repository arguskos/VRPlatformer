using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    private float _lifeTime;
    private float _scale;
    private float _speed;
    private float _lifeTimeMax;
    private Vector3 _direction;
    private CloudSpawner _spawner;

    public Cloud(float maxlifetime, float scale, float speed, Vector3 direction, CloudSpawner spawner)
    {
        _lifeTimeMax = maxlifetime;
        _scale = scale;
        _speed = speed;
        _direction = direction;
        _spawner = spawner;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _lifeTime += Time.deltaTime;

        if (_lifeTimeMax > _lifeTime)
        {
            _spawner.Generate();
            Destroy(this);
        }
	}
}
