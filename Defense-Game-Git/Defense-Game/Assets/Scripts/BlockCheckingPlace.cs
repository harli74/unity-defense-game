using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCheckingPlace : MonoBehaviour
{
    public float LocatedX;
    public float LocatedZ;

    // Start is called before the first frame update
    void Start()
    {
        LocatedX = gameObject.transform.position.x;
        LocatedZ = gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
