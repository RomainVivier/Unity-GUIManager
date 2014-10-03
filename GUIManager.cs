using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour
{

    public static GUIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject singleton = new GameObject();
                _instance = singleton.AddComponent<GUIManager>();
                singleton.name = "GUIManager";
                DontDestroyOnLoad(singleton);
                _instance.InitManager();
            }
            
            return _instance;
        }
    }
   
    private static GUIManager _instance;
    private Dictionary< string, BasicGUI > _guiList = new Dictionary< string, BasicGUI >();
    private Stack<string> _previousGUIs = new Stack<string>();
    private string _currGUI = null;

    private void InitManager()
    {
        //_guiList.Add("keyName", new ClassGUI());

        foreach(var gui in _guiList)
        {
            gui.Value.Init();
        }
    }

    public string CurrentGUI
    { 
        get
        {
            return _currGUI;
        }

        set
        {
            if(_currGUI != null)
            _guiList[CurrentGUI].OnHide();
            _currGUI = value;
            _guiList[CurrentGUI].OnShow();
            _previousGUIs.Push(_currGUI);
        }
    }

    public void Back()
    {
        _guiList[CurrentGUI].OnHide();

        if(_previousGUIs.Count > 0)
            _previousGUIs.Pop();

        if(_previousGUIs.Count > 0)
        {
            _currGUI = _previousGUIs.Peek();
            _guiList[CurrentGUI].OnHide();
        }
        else
            _currGUI = null;
    }

    public void Hide()
    {
        if(_currGUI != null)
            _guiList[CurrentGUI].OnHide();

        foreach(var gui in _guiList)
        {
            gui.Value.Destroy();
        }

        Destroy(this.gameObject);
    }

    void OnGUI()
    {
        if(_currGUI == null)
        {
            Hide();
            return;
        }

        _guiList[CurrentGUI].DrawInterface();
    }

}


