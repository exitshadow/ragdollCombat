using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWhenInvisible : MonoBehaviour
{
    /// <summary>
    /// The target towards the armature has to move
    /// </summary>
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 200;

    /// <summary>
    /// The transform that holds the whole armature together, not just the root joint !
    /// </summary>
    [SerializeField] private GameObject masterArmature;

    private Rigidbody rb;
    private Renderer selfRenderer;

    private void Start()
    {
        selfRenderer = transform.GetComponent<Renderer>();
        rb = masterArmature.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!selfRenderer.isVisible)
        {
            Vector3 targetDir = target.transform.position - transform.position;
            rb.AddForce(targetDir * speed, ForceMode.Force);
        }
    }
}
