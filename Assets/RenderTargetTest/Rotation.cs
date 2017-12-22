using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    // Use this for initialization
    Transform _tr;

    void Start ()
    {
        _tr = transform;
    }
	
    // Update is called once per frame
    void Update ()
    {
        _tr.Rotate (new Vector3 (0, 50f * Time.deltaTime));
        _tr.RotateAround (Vector3.zero, Vector3.forward, Time.deltaTime * 50f);
    }
}
