using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class CountDownCode : MonoBehaviour
{

    Text countDown;
    public delegate void CountDownDone();
    public static event CountDownDone OnCountDownDone;

    private void OnEnable()
    {
        countDown = GetComponent<Text>();
        countDown.text = "3";
        StartCoroutine("count_down");
    }
    IEnumerator count_down()
    {
        int i, count = 3;
        for (i = 0; i < count; i++)
        {
            countDown.text = (count - i).ToString();
            yield return new WaitForSeconds(1);
        }
        OnCountDownDone();
    }

}
