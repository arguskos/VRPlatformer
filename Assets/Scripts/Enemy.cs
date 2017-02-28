using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private Vector3 _startPosition;
    public Vector3 RelativePos;
    public GameObject Level;
    public float Speed=1;
    private float _percentages = 0;
    private bool IsGoingRight = true;
    private void Start()
    {
        if (Level == null)
        {
            Level = GameObject.Find("Level_001");
        }
        _startPosition = transform.position;

    }

    private void Update()
    {
        transform.position = Vector3.Lerp(_startPosition + Level.transform.position, Level.transform.position + _startPosition + RelativePos, _percentages / 100);
        if (IsGoingRight)
        {
            _percentages+= Speed;
            if (_percentages>=100)
            {
                _percentages = 100;
                IsGoingRight = false;
            }
        }
        else
        {
            _percentages-= Speed;
            if (_percentages<=0)
            {
                _percentages = 0;
                IsGoingRight = true;
            }
        }
    }
}
