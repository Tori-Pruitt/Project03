using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PACPointer : MonoBehaviour
{
    Camera _camera;
    GameObject _cameraObject;

    public GameObject _hitVisuals;

    public PointAndClickMovement _pointAndClickMovement;

    private void Start()
    {
        _pointAndClickMovement = GameObject.FindObjectOfType(typeof(PointAndClickMovement)) as PointAndClickMovement;
        _cameraObject = GameObject.FindGameObjectWithTag("PAC_Camera");
        _camera = _cameraObject.GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        /*
        RaycastHit hit;
        if (Physics.Raycast(_pointer.transform.position, _pointer.transform.forward, out hit))
        {
            GameObject impactObj = Instantiate(_hitVisuals, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObj, 2);
        }
        */
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            GameObject impactObj = Instantiate(_hitVisuals, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObj, 2);

            _pointAndClickMovement.SetDestination(impactObj.transform.position);
        }
    }
}
