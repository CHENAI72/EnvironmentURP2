using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NoDestroy : MonoBehaviour
{
    private static NoDestroy _instance;
    public static NoDestroy Instance { get { return _instance; } }

    private void Awake()
    {

        if (_instance != null)
        {
            Destroy(this.gameObject); return;
        }
        else
        {
            _instance = this;
        }
    }

   


    //void OnApplicationQuit()
    //{

    //    Debug.Log("Unity编辑器已退出");

    //}

    void Start()
    {
        DontDestroyOnLoad(gameObject);
       
    }
   

  
}
