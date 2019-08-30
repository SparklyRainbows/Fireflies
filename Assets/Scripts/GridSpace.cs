using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    public Vector3 center;

    private void Start() {
        center = transform.position;
    }
}
