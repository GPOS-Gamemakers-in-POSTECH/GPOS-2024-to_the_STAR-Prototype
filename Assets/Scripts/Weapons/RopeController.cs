using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    private LineRenderer lineRenderer;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRenderer.SetPosition(0, transform.parent.localPosition);
        lineRenderer.SetPosition(1, transform.parent.GetChild(0).localPosition);
    }
}
