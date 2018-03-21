using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    [SerializeField]
    private float zoomSpeed;

    private bool bDragging;
    private Vector3 oldPos;
    private Vector3 panOrigin;
    private float panSpeed = 10.0f;

    private float zoomTo;
    private float curZoomPos;
    private float zoomFrom;


    // Use this for initialization
    void Start () {
        zoomFrom = this.GetComponent<Camera>().orthographicSize;
        zoomTo = 0.0f;
        //curZoomPos = this.GetComponent<Camera>().orthographicSize;
    }
	
	// Update is called once per frame
	void Update () {
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
        Debug.Log(zoomTo);
        //curZoomPos = Mathf.Clamp(curZoomPos, 5f, 35f);

        // Stops "zoomTo" value at the nearest and farthest zoom value you desire
        //zoomTo = Mathf.Clamp(zoomTo, -15f, 30f);

        // Makes the actual change to Field Of View
        //Camera.main.fieldOfView = curZoomPos;
        this.GetComponent<Camera>().orthographicSize = curZoomPos;

        DragControl();
    }

    private void DragControl()

    {
        if (Input.GetMouseButtonDown(0))
        {
            bDragging = true;
            oldPos = transform.position;
            panOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);                    //Get the ScreenVector the mouse clicked
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;    //Get the difference between where the mouse clicked and where it moved
            transform.position = oldPos + -pos * panSpeed;                                         //Move the position of the camera to simulate a drag, speed * 10 for screen to worldspace conversion
        }

        if (Input.GetMouseButtonUp(0))
        {
            bDragging = false;
        }
    }

}
