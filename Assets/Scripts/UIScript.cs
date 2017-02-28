using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject FinishScreen;
    public Image ProgressBar;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       //print(Mathf.Abs(Player.transform.position.x) / 11 * 100);
        ProgressBar.GetComponent<RectTransform>().sizeDelta = new Vector2((Mathf.Abs(Player.transform.position.x)/7f*100 )/100.0f*400.0f, 10);

    }
}
