using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private void Update()
    {
        Vector3 targetPos = target.transform.position;
        transform.LookAt(targetPos, Vector3.up);
        //Quaternion targetRot = Quaternion.LookRotation(targetPos);

        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime);

    }
}
