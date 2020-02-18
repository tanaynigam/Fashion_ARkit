using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringToFront : MonoBehaviour
{

    public float distance;
    private bool isObjectInFront;
    private GameObject objectInFront;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        isObjectInFront = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            if (isObjectInFront)
            {
                objectInFront.transform.position = originalPosition;
                isObjectInFront = false;
            }
            else
            {
                Touch touch = Input.GetTouch(0);
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit, 2000))
                {
                    if (hit.transform.tag == "Frames")
                    {
                        originalPosition = hit.transform.position;
                        hit.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
                        objectInFront = hit.transform.gameObject;
                    }
                }
                isObjectInFront = true;
            }
        }

    }
}
