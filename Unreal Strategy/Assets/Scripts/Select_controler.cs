using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Select_controler : MonoBehaviour
{
    public GameObject cube;
    public LayerMask layer, layerMask;
    public List<GameObject> cars;
    private Camera cam;
    private GameObject cubeSelection;
    private RaycastHit hit;

    private void Awake(){
        cam = GetComponent<Camera>();
    }

    private void Update(){

        if (Input.GetMouseButtonDown(1) && cars.Count > 0){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
              
            if (Physics.Raycast(ray, out RaycastHit agentTarget, 1000f, layer)){
                foreach (var el in cars){
                    el.GetComponent<NavMeshAgent>().SetDestination(agentTarget.point);
                }
            }
            cars.Clear();
        }

        if (Input.GetMouseButtonDown(0)){
            foreach (var el in cars){
                el.transform.GetChild(0).gameObject.SetActive(false);
            }
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            cars.Clear();
            
            if (Physics.Raycast(ray, out hit, 1000f, layer)){
                
                cubeSelection = Instantiate(cube, new Vector3(hit.point.x, 5, hit.point.z), Quaternion.identity);
            }
        }

        // if (cubeSelection){
        //     Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        //     if (Physics.Raycast(ray, out RaycastHit hitDrag, 1000f, layer)){
        //         float xScale = (hit.point.x - hitDrag.point.x * -1);
        //         float zScale = (hit.point.z - hitDrag.point.z * -1);

        //         if (xScale < 0.0f && zScale < 0.0f){
        //             cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        //         }
                
        //         cubeSelection.transform.localScale = new Vector3(Mathf.Abs(xScale), 1, Mathf.Abs(xScale));
        //     }
        // }

        if (Input.GetMouseButtonUp(0) && cubeSelection){
            RaycastHit[] hits = Physics.BoxCastAll(
                cubeSelection.transform.position,
                cubeSelection.transform.localScale,  // Size of selector_cube
                Vector3.up,  // All objects which will be upstairs will be choosen
                Quaternion.identity,
                0,  // Distance of selection
                layerMask  // All objects which have this layer will be choosen
                );

            foreach (var el in hits){
                cars.Add(el.transform.gameObject);
                el.transform.GetChild(0).gameObject.SetActive(true);
            }
            Destroy(cubeSelection);
        }
    }
}
