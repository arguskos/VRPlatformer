using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class SlideLevel : ViveGrip_Grabbable
{

    // Use this for initialization
    public GameObject Level;
    private float _zeroingPos;
    public float LevelStartPos = 0;
    public float LevelEndPos = 10;
    public int[] StopPercentagesArr;
    private float _percentage=0;
    private float _berforePercentage;
    private float _nextPercentage=0;
    private Vector3 _EndPos;

    private Vector3 _grabStartPos;
    private Vector3 _grabEndPos;
    void Start()
    {
        _zeroingPos = transform.position.x;
        _EndPos = new Vector3(_zeroingPos, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log((10 - 1)/100.0f * (transform.position.x - _zeroingPos) * 100);

        Level.transform.position=new Vector3((LevelEndPos-LevelStartPos)/100.0f* (transform.position.x - _zeroingPos) * 100, Level.transform.position.y,Level.transform.position.z);

        if (!Grabbed)
        {
            transform.position = Vector3.Lerp(_EndPos, _EndPos + new Vector3(2, 0, 0), _percentage / 100);

        }
        if (_percentage < _nextPercentage - 1)
        {
            _percentage++;
        }
        else if (_percentage > _nextPercentage + 2)
        {
            _percentage--;
        }
        else
        {
            _percentage = _nextPercentage;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //var tempP = (transform.position.x - _zeroingPos) / (_grabEndPos.x + 2 - _zeroingPos)*100;

            //_percentage = (transform.position.x - _zeroingPos) / (_grabEndPos.x + 2 - _zeroingPos) * 100;

            //_nextPercentage = StopPercentagesArr.OrderBy(v => Math.Abs((long)v - tempP)).First();
            //print("per"+_percentage+" \n next"+ _nextPercentage);

        }
      //  _berforePercentage = (transform.position.x - _zeroingPos) / (_grabEndPos.x + 2) * 100;
    }

    void ViveGripGrabStart(ViveGrip_GripPoint gripPoint)
    {
        Grabbed = true;
        // var temp = Temp.GetComponent<HingeJoint>();

        // temp.useLimits = false;
        //Temp.GetComponent<Rigidbody>().isKinematic = true;
        _berforePercentage = (transform.position.x - _zeroingPos) / (_grabEndPos.x + 2) * 100;
        _grabStartPos = transform.position;
    }
    void ViveGripGrabStop(ViveGrip_GripPoint gripPoint)
    {

        Grabbed = false;
        //var tempP = (transform.position.x - _zeroingPos) / (_grabEndPos.x + 2 - _zeroingPos) * 100;
        
        _percentage = (transform.position.x - _zeroingPos) / (_grabEndPos.x + 2 ) * 100;


        int dir = 0;
        if (_berforePercentage -_percentage>0)
        {
            dir = -1;
        }
        else
        {
            dir =  1;

        }
        Debug.Log(_berforePercentage + "  " + _percentage + "dir:" + dir);

        for (int i = 0; i < StopPercentagesArr.Length - 1; i++)
        {
            if (dir == 1)
            {
                if (_percentage >= StopPercentagesArr[i] && _percentage < StopPercentagesArr[i + 1])
                {


                    _nextPercentage = StopPercentagesArr[i +1];
                }
            }
            else
            {
                if (_percentage >= StopPercentagesArr[i] && _percentage < StopPercentagesArr[i + 1])
                {

                  

                    _nextPercentage = StopPercentagesArr[i ];
                }
            }

        }
    }
}
