using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_enemies : MonoBehaviour
{
    public Transform[] points;
    public GameObject factory;
    public AudioSource src;
    public AudioClip src1;


    private void Start(){
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies(){
        for (int i = 0; i < points.Length; i++){
            yield return new WaitForSeconds(10);
            GameObject spawn = Instantiate(factory);
            Destroy(spawn.GetComponent<Place_objects>());
            spawn.transform.position = points[i].position;
            spawn.transform.rotation = Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(0f, 180f), 0));
            src.clip = src1;
            src.Play();
        }
    }
}
