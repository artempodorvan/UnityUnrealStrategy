using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Bullet_controler : MonoBehaviour
{
    [NonSerialized] public Vector3 position;  
    public float speed = 30f;
    public int damage = 20;

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, position, step);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            Atack attack = other.GetComponent<Atack>();
            attack.health -= damage;

            Transform bar = other.transform.GetChild(0).transform;
            bar.localScale = new Vector3(
                bar.localScale.x - 0.3f,
                bar.localScale.y,
                bar.localScale.z
            );

            if (attack.health < 0)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
