using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour {

    public Text coodinates;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        coodinates.text = "Lat: " + GPS.Instance.latitude.ToString() + " Lon: " + GPS.Instance.longitude.ToString(); 
		
	}
}
