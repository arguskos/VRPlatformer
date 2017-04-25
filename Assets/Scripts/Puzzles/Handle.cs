using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class Handle : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    public Camera Cam;
    public GameObject Platform;
    public Transform Low;
    public Transform High;
    private float _startY;
    private float _startPY;
    public void Start()
    {
        _startY = transform.position.y;
        _startPY = Platform.transform.position.y;
    }
    void OnMouseDown()
    {
        screenPoint = Cam.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Cam.ScreenToWorldPoint(curScreenPoint) + offset;
        Vector3 temp = transform.position;
        if (curPosition.y > Low.position.y && curPosition.y  < High.position.y)
        {
            transform.position = new Vector3(temp.x, curPosition.y, temp.z);

            Platform.transform.position = new Vector3(Platform.transform.position.x, _startY - transform.position.y+ _startPY,
                transform.position.z);
        }
        //15
        //1


       
    }

}