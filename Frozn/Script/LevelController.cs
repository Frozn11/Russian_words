using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] List<GameObject> plates = new List<GameObject>();
    [SerializeField] List<GameObject> rbWalls = new List<GameObject>();
    [SerializeField] List<PhysicMaterial> phMat = new List<PhysicMaterial>();
    [SerializeField] List<GameObject> plateMat = new List<GameObject>();
    void Start()
    {
         for (int i  = 0; i < plates.Count; i = i + 3)
        {
            plates[Random.Range(i, i + 3)].GetComponent<Collider>().isTrigger = true;
        }
         for (int i = 0; i < rbWalls.Count; i = i + 4)
        {
            int x = Random.Range(i, i + 4);
            RigidbodyWall(x);
        }
         for (int i = 0; i < plateMat.Count; i++)
        {
            plateMat[i].GetComponent<Collider>().sharedMaterial = phMat[Random.Range(0, phMat.Count)];
        }
        plateMat[Random.Range(0, plateMat.Count)].GetComponent<Collider>().sharedMaterial = phMat[0];
    }
    public void RigidbodyWall(int count)
    {
        Rigidbody rb = rbWalls[count].gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
    }
}
