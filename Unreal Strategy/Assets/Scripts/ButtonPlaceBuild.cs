using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlaceBuild : MonoBehaviour
{
    public GameObject building;
    public AudioSource src;
    public AudioClip src1;
    public Adding_score script;

    public void PlaceBuild(){
        int money = script.money;
        if (money >= 5000){
            Instantiate(building, Vector3.zero, Quaternion.identity);
            script.money -= 5000;

            src.clip = src1;
            src.Play();
        }
        else if (money < 5000){
            script.Warning();
            StartCoroutine(Warnings());
        }
    }

    IEnumerator Warnings(){
        yield return new WaitForSeconds(3);
        script.Warning1();
    }
}
