using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulumBouns : MonoBehaviour
{ 
    [SerializeField] float force = 4f;
    private Vector3 hitDir;
    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (collision.gameObject.tag == "Player")
            {
                hitDir = contact.normal;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(-hitDir * force, ForceMode.Impulse);
            }
        }
    }
}
