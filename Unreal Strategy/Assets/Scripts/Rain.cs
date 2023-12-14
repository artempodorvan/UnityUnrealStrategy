using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    private bool isRain = false;
    private ParticleSystem ps;
    public Light dirlight;
    public AudioSource src;
    public AudioClip src1;

    private void Start(){
        ps = GetComponent<ParticleSystem>();
        StartCoroutine(Weather());
    }

    private void Update(){
        if(isRain && dirlight.intensity > 0.25f){
            LightIntensity(-1);
        }
        else if(!isRain && dirlight.intensity < 0.5f){
            LightIntensity(1);
        }
    }

    private void LightIntensity(int mult){
        dirlight.intensity += 0.1f * Time.deltaTime * mult;
    }

    IEnumerator Weather(){
        while(true){
            yield return new WaitForSeconds(UnityEngine.Random.Range(25f, 40f));

            if(isRain){
                ps.Stop();
                src.clip = src1;
                src.Stop();
            }
            else{
                ps.Play();
                src.clip = src1;
                src.Play();
            }

            isRain = !isRain;
        }
    }
}
