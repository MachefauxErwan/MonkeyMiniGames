using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberPlayerSpawn : MonoBehaviour
{

    [SerializeField]
    private Transform BomberZone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Bomber"))
        // {
            other.gameObject.transform.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.transform.GetComponent<Rigidbody>().isKinematic = true;
       // }
    }


    public Transform getBomberZone()
    {
        return BomberZone;
    }
}
