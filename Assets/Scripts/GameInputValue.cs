using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputValue : MonoBehaviour
{

    [HideInInspector]
    public InputData m_InputData;
  
    void Awake()
    {
        m_InputData = new InputData();
    }
    public void IsGameStatus(bool value)
    {
        m_InputData.IsGameStatus = value;
    }
    public void IsTimePlay(bool value)
    {
        m_InputData.IsTimePlay = value;
    }
    public void IsGameValue(string Name,float Value)
    {
        m_InputData.IsGameName = Name;
        m_InputData.IsThevalue = Value;
    }
    public void IsInputTime(float value)
    {
        m_InputData.IsTimeTextvalue = value;
    }

    public void IsInputMark(float value)
    {
        m_InputData.IsMarkTextvalue = value;
    }
    public void IsSceneName(string name)
    {
        m_InputData.IsSceneName = name;
    }
    public void IsTheHost(int value)
    {
        m_InputData.IsHost = value;
    }

    public void IsRenderer(float value)
    {
        m_InputData.IsRendererValue = value;
    }
    public void IsToastText(string value)
    {
        m_InputData.IsToastText = value;
    }





    public void IsOnSceneLoading(Action<string> OnScene)
    {
        m_InputData.SceneLoading += OnScene;
    }
    public void IsOnGameQuit(Action OnQuit)
    {
        m_InputData.GameQuit += OnQuit;
    }
    public void IsOnSceneStatus(Action<bool> OnStatus)
    {
        m_InputData.SceneStatus += OnStatus;
    }
    public void IsOnTimeZero(Action OnTime)
    {
        m_InputData.TimeZero += OnTime;
    }
    public void IsOnIsApplyforsuspension(Action<bool> Onsuspension)
    {
        m_InputData.Applyforsuspension += Onsuspension;
    }

}

public class InputData
{
    public event Action<string> GameName;
    public event Action<string> SceneName;
    public event Action<float> Thevalue;
    public event Action<float> MarkTextvalue;
    public event Action<float> TimeTextvalue;
    public event Action<int> Hosts;
    public event Action<bool> GameStatus;
    public event Action<bool> TimePlay;

  

    public event Action<float> RendererValue;
    public event Action<string> ToastText;

    public event Action<string> SceneLoading;
    public event Action GameQuit;
    public event Action<bool> SceneStatus;
    public event Action TimeZero;
    public event Action<bool> Applyforsuspension;

    private string m_GameName;
    private string m_SceneName;
    private float m_Thevalue;
    private float m_MarkTextvalue;
    private float m_TimeTextvalue;
    private int m_Host;
    private bool m_GameStatus;
    private bool m_TimePlay;


    private float m_RendererValue;
    private string m_ToastText;


    private string m_SceneLoading;
    private bool m_GameQuit;
    private bool m_SceneStatus;
    private bool m_TimeZero;
    private bool m_Applyforsuspension;
    public string IsGameName
    {
        set
        {
         
            m_GameName = value;
            GameName?.Invoke(m_GameName);
   
        }
    }
    public string IsSceneName
    {
        set
        {

            m_SceneName = value;
            SceneName?.Invoke(m_SceneName);

        }
    }
    public float IsThevalue
    {
        set
        {
            m_Thevalue = value;
            Thevalue?.Invoke(m_Thevalue);

        }
    }
    public float IsMarkTextvalue
    {
        set
        {
            m_MarkTextvalue = value;
            MarkTextvalue?.Invoke(m_MarkTextvalue);

        }
    }
    public float IsTimeTextvalue
    {

   
        set
        {
            m_TimeTextvalue = value;
            TimeTextvalue?.Invoke(m_TimeTextvalue);

        }

    }
    public string IsSceneLoading
    {
        set
        {
            m_SceneLoading = value;
            SceneLoading?.Invoke(m_SceneLoading);

        }
    }
    public bool IsGameQuit
    {
        set
        {
            m_GameQuit = value;
            GameQuit?.Invoke();

        }
    }
    public bool IsSceneStatus
    {
        set
        {
            m_SceneStatus = value;
            SceneStatus?.Invoke(m_SceneStatus);

        }
    }
    public bool IsTimePlay
    {
        set
        {
            m_TimePlay = value;
            TimePlay?.Invoke(m_TimePlay);
        }
    }
    public int IsHost
    {
        set
        {
            m_Host = value;
            Hosts?.Invoke(m_Host);

        }
    }
    public bool IsTimeZero
    {
        set
        {
            m_TimeZero = value;
            TimeZero?.Invoke();

        }
    }
    public bool IsGameStatus
    {
        set
        {
            m_GameStatus = value;
            GameStatus?.Invoke(m_GameStatus);

        }
    }
    public float IsRendererValue
    {
        set
        {
            m_RendererValue = value;
            RendererValue?.Invoke(m_RendererValue);

        }
    }
    public string IsToastText
    {
        set
        {
            m_ToastText = value;
            ToastText?.Invoke(m_ToastText);
        }
    }
    public bool IsApplyforsuspension
    {
        set
        {
            m_Applyforsuspension = value;
            Applyforsuspension?.Invoke(m_Applyforsuspension);
        }
    }

}