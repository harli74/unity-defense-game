using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public RaycastHit hit;
    public Camera cam;

    public float greenX, greenZ;

    public GameObject map;
    public GameObject greenBox;
    public GameObject redBox;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        greenX = Mathf.Round(hit.point.x);
        greenZ = Mathf.Round(hit.point.z);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.point.x <= map.transform.localScale.x && hit.point.z <= map.transform.localScale.z && hit.point.x >= -map.transform.localScale.x && hit.point.z >= -map.transform.localScale.z)
            {
                Debug.Log("im In");
            }

        }
    }
    void GreenOrRedBoxChecked()
    {

    }
}
