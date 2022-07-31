using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitOnClick : MonoBehaviour
{
    [SerializeField] private Transform hitOrigin;
    [SerializeField] private float strength = 20f;

    private RaycastHit hit;
    private Ray ray;

    private float timeClickDown;
    private float timeClickUp;
    private float timeClickHold;
    
    

    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            timeClickDown = Time.fixedTime;
        }

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonUp(0))
        {
            timeClickUp = Time.fixedTime;
            timeClickHold = timeClickUp - timeClickDown + 1f;
            if (hit.collider.GetComponent<Rigidbody>() != null)
            {
                Vector3 incomingVec = hit.point - hitOrigin.position;
                Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);

                hit.collider.GetComponent<Rigidbody>().AddForce(incomingVec.normalized * strength * timeClickHold, ForceMode.Impulse);
            }
        }
    }
}
