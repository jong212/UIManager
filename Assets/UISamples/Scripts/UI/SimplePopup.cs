using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimplePopup : MonoBehaviour
{
    [SerializeField] Text Text_Msg;

    //WaitForSeconds _waitForSec = new WaitForSeconds(1.5f)

    // 기능 확장
    private void OnEnable()
    {
        StartCoroutine(CoCloseSelf());
    }

    public void SetUI(string msg)
    {
        Text_Msg.text = msg;
        CheckAndChangeColor(msg);
    }

    private void CheckAndChangeColor(string msg)
    {
        if (msg.Contains("출력"))
        {
            Text_Msg.color = Color.red;
        }
    }

    IEnumerator CoCloseSelf()
    {
        yield return new WaitForSeconds(1.5f);
        UIManager.Instance.CloseSpecificUI(UIType.SimplePopup);
        // 이상한 짓 -> this.gameObject.SetActive(false);
    } 


    // UIBase 만들면 거기에 OnBeforeEnable() //
    // Awake랑 OnEnable가 순서를 보장하지 않는 경우가 있어서
    // 확실하게 OnEnable하기 전에 데이터 관련 처리가 필요한 경우를 위함

}
