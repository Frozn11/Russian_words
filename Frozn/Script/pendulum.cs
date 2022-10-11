using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulum : MonoBehaviour
{
    [SerializeField] float limit = 30f;

    // Update is called once per frame
    void Update()
    {
        float angle = limit * Mathf.Sin(Time.time);
        transform.localRotation = Quaternion.Euler(0, 0 , angle);
    }
}
