using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place_objects : MonoBehaviour
{
    public LayerMask layer;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, layer)){
            transform.position = hit.point;
        }

        if (Input.GetMouseButtonDown(0)){
            gameObject.GetComponent<Spawn_point>().enabled = true;
            Destroy(gameObject.GetComponent<Place_objects>());
        }
    }
}
