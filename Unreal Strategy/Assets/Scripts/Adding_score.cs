using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Adding_score : MonoBehaviour
{
    public Text moneyText;
    public Text warning_text;
    public int money = 0;

    private Coroutine coroutine;

    void Start()
    {
        coroutine = StartCoroutine(SMS());
        warning_text.enabled = false;
    }

    void Update(){
        moneyText.text = money.ToString();
    }

    public void Add_score()
    {
        int i = UnityEngine.Random.Range(1000, 3000);
        money += i;
        moneyText.text = money.ToString();
    }

    public void Warning()
    {
        warning_text.enabled = true;
    }

    public void Warning1()
    {
        warning_text.enabled = false;
    }

    IEnumerator SMS()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            Add_score();
        }
    }
}
