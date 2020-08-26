using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kudan.AR
{ 
public class AxisScript : TransformDriverBase
    {
        private TrackingMethodMarkerless _tracker;

        /// <summary>
        /// Finds the tracker.
        /// </summary>
        protected override void FindTracker()
        {
            _trackerBase = _tracker = (TrackingMethodMarkerless)Object.FindObjectOfType(typeof(TrackingMethodMarkerless));
        }

        /// <summary>
        /// Register this instance with the Tracking Method class for event handling.
        /// </summary>
        protected override void Register()
        {
            if (_tracker != null)
            {
                _tracker._updateMarkerEvent.AddListener(OnTrackingUpdate);
            }
            this.gameObject.SetActive(false);

        }

        /// <summary>
        /// Unregister this instance with the Tracking Method class for event handling.
        /// </summary>
        protected override void Unregister()
        {
            if (_tracker != null)
            {
                _tracker._updateMarkerEvent.RemoveListener(OnTrackingUpdate);
            }
        }

        /// <summary>
        /// Method called every frame ArbiTrack is running.
        /// Updates the position and orientation of the trackable.
        /// </summary>s
        /// <param name="trackable">Trackable.</param>
        public void OnTrackingUpdate(Trackable trackable)
        {
            this.transform.localRotation = trackable.orientation;

            this.gameObject.SetActive(trackable.isDetected);
        }
    }

}
