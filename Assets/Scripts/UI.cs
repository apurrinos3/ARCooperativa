using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kudan.AR;
public class UI : MonoBehaviour
{
    public KudanTracker _kudanTracker;	// The tracker to be referenced in the inspector. This is the Kudan Camera object.
    public TrackingMethodMarkerless _markerlessTracking;	// The reference to the markerless tracking method that lets the tracker know which method it is using
    public GameObject _building1;
    public GameObject _building2;
    private GameObject _modelActive;
    private bool button1pressed = false;
    public int moveSpeed;

    private void PlaceBuilding()
    {
        if (!_kudanTracker.ArbiTrackIsTracking())
        {
            // from the floor placer.
            Vector3 floorPosition;			// The current position in 3D space of the floor
            Quaternion floorOrientation;	// The current orientation of the floor in 3D space, relative to the device

            _kudanTracker.FloorPlaceGetPose(out floorPosition, out floorOrientation);	// Gets the position and orientation of the floor and assigns the referenced Vector3 and Quaternion those values
            _kudanTracker.ArbiTrackStart(floorPosition, floorOrientation);				// Starts markerless tracking based upon the given floor position and orientations
        }

        else
        {
            _kudanTracker.ArbiTrackStop();
        }
    }

    public void PlaceBuilding1Clicked()
    {
        PlaceBuilding();
        _building1.SetActive(true);
        _building2.SetActive(false);
    }
    public void PlaceBuilding2Clicked()
    {
        PlaceBuilding();
        _building2.SetActive(true);
        _building1.SetActive(false);
    }

    void Update()
    {
        Text text;
        text = GameObject.Find("btnPlaceBuildingText1").GetComponent<Text>();
        if (_building1.activeSelf)
        {
            _modelActive = _building1;
            text.text = "1";
        }
        else
            if (_building2.activeSelf)
            {
            _modelActive = _building2;
            text = GameObject.Find("btnPlaceBuildingText2").GetComponent<Text>();
            text.text = "2";
            }


        if (!_kudanTracker.ArbiTrackIsTracking())
        {
            text.text = "Place building" + text.text;
        }
        else
        {
            text.text = "Stop tracking";

        }
    }

    public void MoveUp()
    {
        _modelActive.transform.localPosition = new Vector3(_modelActive.transform.localPosition.x, _modelActive.transform.localPosition.y + moveSpeed, _modelActive.transform.localPosition.z);
    }

    public void MoveDown()
    {
        _modelActive.transform.localPosition = new Vector3(_modelActive.transform.localPosition.x, _modelActive.transform.localPosition.y - moveSpeed, _modelActive.transform.localPosition.z);

    }

    public void MoveLeft()
    {
        _modelActive.transform.localPosition = new Vector3(_modelActive.transform.localPosition.x + moveSpeed, _modelActive.transform.localPosition.y, _modelActive.transform.localPosition.z);

    }

    public void MoveRight()
    {
        _modelActive.transform.localPosition = new Vector3(_modelActive.transform.localPosition.x - moveSpeed, _modelActive.transform.localPosition.y, _modelActive.transform.localPosition.z);

    }
    public void MoveForward()
    {
        _modelActive.transform.localPosition = new Vector3(_modelActive.transform.localPosition.x, _modelActive.transform.localPosition.y, _modelActive.transform.localPosition.z - moveSpeed);

    }
    public void MoveBackward()
    {
        _modelActive.transform.localPosition = new Vector3(_modelActive.transform.localPosition.x, _modelActive.transform.localPosition.y, _modelActive.transform.localPosition.z + moveSpeed);

    }
}
