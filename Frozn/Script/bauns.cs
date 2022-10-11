using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bauns : MonoBehaviour
{
    [SerializeField] int force;

    private void Start()
    {
        force = Random.Range(15, 20);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<Rigidbody>().AddForce(new Vector3(0, force, 0), ForceMode.Impulse);
        }
    }
}
