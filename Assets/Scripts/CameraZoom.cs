using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    [SerializeField]
    private float zoomSpeed;
    [SerializeField]
    private float maxZoom;
    [SerializeField]
    private float minZoom;

    private float zoomTo;
    private float curZoomPos;
    private float zoomFrom;

    // Use this for initialization
    void Start()
    {
        zoomFrom = this.GetComponent<Camera>().orthographicSize;
        zoomTo = 0.0f;
        //curZoomPos = this.GetComponent<Camera>().orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {

        zoomFrom = this.GetComponent<Camera>().orthographicSize;
        zoomTo = 0.0f;
        // Attaches the float y to scrollwheel up or down
        float y = Input.mouseScrollDelta.y;
        Debug.Log(y);

        // If the wheel goes up it, decrement 5 from "zoomTo"
        if (y >= 1)
        {
            zoomTo = -zoomSpeed;
            //Debug.Log("Zoomed In");
        }

        // If the wheel goes down, increment 5 to "zoomTo"
        else if (y <= -1)
        {
            zoomTo = zoomSpeed;
            //Debug.Log("Zoomed Out");
        }

        // creates a value to raise and lower the camera's field of view
        curZoomPos = zoomFrom + zoomTo;
        curZoomPos = Mathf.Min(maxZoom, curZoomPos);
        curZoomPos = Mathf.Max(minZoom, curZoomPos);
        Debug.Log(zoomTo);
        //curZoomPos = Mathf.Clamp(curZoomPos, 5f, 35f);

        // Stops "zoomTo" value at the nearest and farthest zoom value you desire
        //zoomTo = Mathf.Clamp(zoomTo, -15f, 30f);

        // Makes the actual change to Field Of View
        //Camera.main.fieldOfView = curZoomPos;
        this.GetComponent<Camera>().orthographicSize = curZoomPos;

    }
}
