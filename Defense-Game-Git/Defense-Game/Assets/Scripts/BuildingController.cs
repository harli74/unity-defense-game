using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildingController : MonoBehaviour
{
    public RaycastHit hit;
    public Camera cam;

    public float greenX, greenZ;
    public float mapSpace;
    public float MapSpaceLeft;
    public float[] TakenPlaces;
    public float[] TakenPlacesZ;
    public double[,] shit;
    public int PlacesArray;
    public int integerArray;

    public GameObject map;
    public GameObject SpawnableObj;
    public GameObject gmobj;
    public GameObject greenBox;
    public GameObject greenClone;
    public GameObject redBox;
    public GameObject redClone;

    public bool RedMapCheck;
    public bool SpawnedGreenAlready;
    public bool SpawnedRedAlready;
    public bool SpawnableObjOn;
   

    // Start is called before the first frame update
    void Start()
    {
        shit = new double[2, 3];
        mapSpace = (map.transform.localScale.x-1) * (map.transform.localScale.z-1); /// maths.....I know The problem
        MapSpaceLeft = mapSpace;
        PlacesArray = Mathf.RoundToInt((float)mapSpace);
        TakenPlaces = new float[PlacesArray];
        TakenPlacesZ = new float[PlacesArray];
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
                RedMapCheck = false;
                for (int i = 0; i < PlacesArray; i++)
                {
                    
                    if (greenX != TakenPlaces[i] || greenZ != TakenPlacesZ[i])
                    {
                        Debug.Log("You can place");
                    }
                    else
                    {
                        Debug.Log("You cant place");
                        i++;
                    }
                   
                }
               
                if (RedMapCheck == false)
                {
                    SpawnedRedAlready = false;
                    ///Debug.Log("im In");
                    Destroy(redClone);

                    
                    if (SpawnedGreenAlready == false)
                    {
                        GreenBoxChecked();
                    }
                  greenClone.transform.position = new Vector3(greenX, 1, greenZ);
                    if(SpawnableObjOn == false)
                    {
                        SpawnObject();
                        
                        SpawnableObjOn = false;


                    }
                  
                }

            }
            }
            else
            {
                RedMapCheck = true;
            SpawnedGreenAlready = false;
                ///Debug.Log("im out");
            
            Destroy(greenClone);
            if (SpawnedRedAlready == false)
            {
                RedBoxChecked();
            }
            else
            {
                ///redClone.transform.position = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.z);
              
                ///Debug.Log("im out");
            }
        }
        }
        void GreenBoxChecked()
        {
            greenClone = Instantiate(greenBox, new Vector3(greenX, 1, greenZ), Quaternion.identity);
        SpawnedGreenAlready = true;
            
        }
    void SpawnObject()
    {
        if(Input.GetMouseButtonDown(0))
        {
           gmobj = Instantiate(SpawnableObj, new Vector3(greenX, 1, greenZ), Quaternion.identity);

            TakenPlaces[integerArray] = gmobj.transform.position.x;
            TakenPlacesZ[integerArray] = gmobj.transform.position.z;
            integerArray++;
            SpawnableObjOn = true;
            MapSpaceLeft--;

            
               
                   
               
            
        }
    }
        void RedBoxChecked()
        {
            redClone = Instantiate(redBox, new Vector3(greenX, 1, greenZ), Quaternion.identity);
        SpawnedRedAlready = true;
    }
    
}

