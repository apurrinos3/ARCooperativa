using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kudan.AR;
public class UI : MonoBehaviour
{
    public KudanTracker _kudanTracker;	// The tracker to be referenced in the inspector. This is the Kudan Camera object.
    public TrackingMethodMarkerless _markerlessTracking;	// The reference to the markerless tracking method that lets the tracker know which method it is using
    public GameObject _model;
    public Text buttonText;
    private bool buttonUpPressed;
    private bool buttonDownPressed;
    public int moveSpeed;

    public void PlaceBuildingClicked()
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


    void Update()
    {
        if (!_kudanTracker.ArbiTrackIsTracking())
        {
            buttonText.text = "Place building";
        }
        else
        {
            buttonText.text = "Stop tracking";

        }
    }

    public void MoveUp()
    {
        _model.transform.localPosition = new Vector3(_model.transform.localPosition.x, _model.transform.localPosition.y + moveSpeed, _model.transform.localPosition.z);
    }

    public void MoveDown()
    {
        _model.transform.localPosition = new Vector3(_model.transform.localPosition.x, _model.transform.localPosition.y - moveSpeed, _model.transform.localPosition.z);

    }

    public void MoveLeft()
    {
        _model.transform.localPosition = new Vector3(_model.transform.localPosition.x + moveSpeed, _model.transform.localPosition.y, _model.transform.localPosition.z);

    }

    public void MoveRight()
    {
        _model.transform.localPosition = new Vector3(_model.transform.localPosition.x - moveSpeed, _model.transform.localPosition.y, _model.transform.localPosition.z);

    }
    public void MoveForward()
    {
        _model.transform.localPosition = new Vector3(_model.transform.localPosition.x, _model.transform.localPosition.y, _model.transform.localPosition.z + moveSpeed);

    }
    public void MoveBackward()
    {
        _model.transform.localPosition = new Vector3(_model.transform.localPosition.x , _model.transform.localPosition.y, _model.transform.localPosition.z-moveSpeed);

    }
}
