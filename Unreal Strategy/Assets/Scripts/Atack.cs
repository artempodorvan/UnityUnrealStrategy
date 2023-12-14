using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class Atack : MonoBehaviour
{
    [NonSerialized] public int health = 100;
    
    public float radius = 70f;
    public GameObject bullet;
    private Coroutine coroutine;

    private void Update(){
        DetectCollistion();
    }

    private void DetectCollistion(){
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        
        if (hitColliders.Length == 0 && coroutine != null){
            StopCoroutine(coroutine);
            coroutine = null;
        }

        foreach(var el in hitColliders){
            if ((gameObject.CompareTag("Player") && el.gameObject.CompareTag("Enemy")) || (gameObject.CompareTag("Enemy") && el.gameObject.CompareTag("Player"))){
                GetComponent<NavMeshAgent>().SetDestination(el.transform.position);
                
                if (coroutine == null){
                    coroutine = StartCoroutine(StartAttack(el));
                }
            }
        }
    }

    IEnumerator StartAttack(Collider enemyPos){
        GameObject obj = Instantiate(bullet, transform.GetChild(1).position, Quaternion.identity);
        obj.GetComponent<Bullet_controler>().position = enemyPos.transform.position;
        yield return new WaitForSeconds(1f);
        StopCoroutine(coroutine);
        coroutine = null;
    }
}
