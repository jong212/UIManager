using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIType
{
    SimplePopup,
    MainUI,
}

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject UIRoot;

    public static UIManager Instance { get; set; }

    // 얘는 생성과 제거에 관한 부분 -> Instancing과 가비지컬렉터와 연관이 있는 애
    private Dictionary<UIType, GameObject> _createdUIDic = new Dictionary<UIType, GameObject>();
    // 얘는 활성과 비활성에 관한 부분 -> SetActive
    private HashSet<UIType> _openedUIDic = new HashSet<UIType>();

    private void Awake()
    {
        Instance = this;
    }

    private void OpenUI(UIType uiType, GameObject uiObject)
    {
        if (_openedUIDic.Contains(uiType) == false)
        {
            uiObject.SetActive(true);
            _openedUIDic.Add(uiType);
        }
    }

    private void CloseUI(UIType uiType)
    {
        if (_openedUIDic.Contains(uiType))
        {
            var uiObject = _createdUIDic[uiType];
            uiObject.SetActive(false);
            _openedUIDic.Remove(uiType);
        }
    }

    private void CreateUI(UIType uiType)
    {
        if (_createdUIDic.ContainsKey(uiType) == false)
        {
            string path = GetUIPath(uiType);
            GameObject loadedObj = (GameObject)Resources.Load(path);
            GameObject gObj = Instantiate(loadedObj, UIRoot.transform);
            if (gObj != null)
            {
                _createdUIDic.Add(uiType, gObj);
            }
        }
    }

    private GameObject GetCreatedUI(UIType uiType)
    {
        if (_createdUIDic.ContainsKey(uiType) == false)
        {
            CreateUI(uiType);
        }

        return _createdUIDic[uiType];
    }
    private string GetUIPath(UIType uiType)
    {
        string path = string.Empty; // "" == string.Empty
        switch (uiType)
        {
            case UIType.SimplePopup:
                path = "Prefabs/UI/SimplePopup";
                break;
        }

        return path;
    }

    public void OpenSimplePopup(string msg)
    {
        var gObj = GetCreatedUI(UIType.SimplePopup);

        if(gObj != null)
        {
            OpenUI(UIType.SimplePopup, gObj);
            // _simplePopup.gameObject.SetActive(true); -> OpenUI로 역할 이전

            var simplePopup = gObj.GetComponent<SimplePopup>();
            simplePopup.SetUI(msg);
        }
    }



    public void CloseSpecificUI(UIType uiType)
    {
        CloseUI(uiType);
    }



}
