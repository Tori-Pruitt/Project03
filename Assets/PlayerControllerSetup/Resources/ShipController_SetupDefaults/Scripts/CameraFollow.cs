using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject _objectToFollow = null;

    Vector3 _objectOffset;

    // Start is called before the first frame update
    private void Awake()
    {
        _objectToFollow = GameObject.FindGameObjectWithTag("ShipPlayer");
        _objectOffset = this.transform.position - _objectToFollow.transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        this.transform.position = _objectToFollow.transform.position + _objectOffset;
    }
}
