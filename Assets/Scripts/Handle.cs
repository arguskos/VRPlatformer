using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class Handle : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    public Camera Cam;
    public GameObject Platform;
    private float _startY;

    public void Start()
    {
        _startY = transform.position.y;
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
        transform.position = new Vector3(temp.x ,curPosition.y,temp.z);
        Platform.transform.position  =new Vector3(Platform.transform.position.x, _startY-transform.position.y+0.7f, transform.position.z);
        
        //15
        //1


       
    }

}