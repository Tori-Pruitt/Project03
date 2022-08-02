using UnityEngine;

public class FPSPointer : MonoBehaviour
{
    public float _damage = 5f;
    public float _range = 20f;

    public Camera _fpsCam;

    public GameObject _hit;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_fpsCam.transform.position, _fpsCam.transform.forward, out hit, _range))
        {
            GameObject impactObj = Instantiate(_hit, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObj, 2);
        }
    }
}
