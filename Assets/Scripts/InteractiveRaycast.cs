using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InteractiveRaycast : MonoBehaviour
{
    private GameObject box;
    private GameObject next;

    [SerializeField]
    private GameObject prefab;

    private Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit))
        {
            if(hit.collider.gameObject.CompareTag("InteractivePlane"))
            {
                Vector3 pos = hit.collider.gameObject.transform.position;
                Instantiate(prefab, new Vector3(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y + prefab.transform.localScale.y / 2, hit.collider.gameObject.transform.position.z), Quaternion.identity);
            }
            if(hit.collider.gameObject.GetComponent<InteractiveBox>())
            {
                if(box == null)
                {
                    box = hit.collider.gameObject;
                }
                else
                {
                    next = hit.collider.gameObject;
                    box.GetComponent<InteractiveBox>()
                }
            }
        }
    }
}
