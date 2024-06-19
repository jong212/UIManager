using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    // [SerializeField] SimplePopup Popup_SimplePopup;

    public void OnClick_PopupSimpleMsg()
    {
        // Popup_SimplePopup.SetUI();
        UIManager.Instance.OpenSimplePopup("심플 팝업 출력 됨");
    }
}
