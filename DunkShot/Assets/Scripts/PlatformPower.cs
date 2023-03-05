using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPower : MonoBehaviour
{
    [SerializeField] private float Bevel;
    [SerializeField] private float Power;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Bevel, 90, 0) * Power, ForceMode.Force);
    }
}
