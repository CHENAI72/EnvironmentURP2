using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputGameObj : MonoBehaviour
{
    public Slider TheSlider;
    public GameInputValue m_value;
    // Start is called before the first frame update
    void Start()
    {

        TheSlider.onValueChanged.AddListener(e => InputFireValue(e));
        m_value.IsOnSceneLoading(e=> { Debug.Log("场景加载成功:"+e); });
        m_value.IsOnGameQuit(() => { Debug.Log("退出游戏"); });
        m_value.IsOnSceneStatus(e => { Debug.Log("游戏是否暂停："+e); });//true是播放
        m_value.IsOnTimeZero(()=> { Debug.Log("时间结束"); });
        m_value.IsOnIsApplyforsuspension(e => { Debug.Log("申请暂停:" + e); });//true是申请暂停，false是申请播放
        //float Thevalue = value/100;  TerrainFog  (山峰)   VFX_Fire_Floor  (火焰)   TestWater  (水)
        //  m_value.IsGameValue("TerrainFog", value);//参数：标签名，输入值

        // m_value.IsSceneName("SampleScene1"); 字符串   //跳转场景
        //m_value.IsInputMark(value); 浮点数   //得分
        // m_value.IsInputTime(value); 浮点数  //输入时间
        //m_value.IsGameStatus(value);布尔值 //true为播放游戏，反之
        //  m_value.IsTheHost(1);整数 //房主设置，2是成员
        // m_value.IsRenderer(value);//浮点数  调节渲染分辨率，0.1~2，越大效果越好，消耗性能越大，反之。默认是0.9

        //m_value.IsTimePlay(value);布尔值 //true为播放，反之
    }
    public void InputFireValue(float value) //控制火焰大小 0~100的范围
    {

       // m_value.IsGameValue("VFX_Fire_Floor", value);


        // m_value.IsRenderer(value);//浮点数  调节渲染分辨率，0.1~2，越大效果越好，消耗性能越大，反之。默认是0.9

         m_value.IsGameValue("Sandstorm", value);// TerrainFog (雾效)  TerrainSwitch (山峰)

    }

    public void InputSceneName(string name)//跳转场景
    {
        m_value.IsSceneName(name);
    }
    public void InputMark(float value)//得分
    {
        m_value.IsInputMark(value);
    }

    public void InputTime(float value)//输入时间
    {
        
        m_value.IsInputTime(value);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_value.IsTheHost(1);
            // InputSceneName("SampleScene1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_value.IsTheHost(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_value.IsSceneName("SampleScene6");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            m_value.IsSceneName("SampleScene2");

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            m_value.IsGameStatus(false);
        }
    }


}
