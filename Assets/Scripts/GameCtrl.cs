using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using AtmosphericHeightFog;

public class GameCtrl : MonoBehaviour
{
    [Header("此组件来自CHENAI7")]
    [Space]
    [SerializeField] GameInputValue TestValue;

    [SerializeField] Text MarkText;
    [SerializeField] Text TimeText;

    [SerializeField] Image ToastImage;
    [SerializeField] Text ToastText;

    [SerializeField] Button PauseButton;
    [SerializeField] Button PlayButton;
    [SerializeField] Button QuitButton;

    private Dictionary<string,GameObject> GameThePath = new Dictionary<string, GameObject>();
    private Dictionary<string, AudioSource> AudioThePath = new Dictionary<string, AudioSource>();
    [HideInInspector]
    UnityEvent gameValue=new UnityEvent();

    private string Gamename;
    private float GameValue;

    //天空盒
    [Header("天空盒")]
    [SerializeField] bool Flicker;
    [SerializeField] bool Rotate;
    [SerializeField] float Speed = 1f;
    [SerializeField] float Max = 3;
    [SerializeField] float Min = 0.7f;
    [SerializeField] float RateSpeed = 0.7f;
    private float rot = 0;
    private float m_rot = 0;
    private bool Isbool1 = true;
    private bool Isbool2;

    //渲染
    [Header("渲染资源")]
    [SerializeField] UniversalRenderPipelineAsset URPRe;
    [SerializeField] UniversalRendererData renderData;
    //水设置
    [Header("水设置")]
    [SerializeField] AnimationCurve positionCurve;
    float h;
    float str;
    float Lang;
    private float time;


    private bool TimePlay = true;

    private GameObject TheGame;
    private int HosetInbool=1;
    //private string Tags;
    // Start is called before the first frame update
    void Start()
    {
        // Application.targetFrameRate = 60;
        Screen.SetResolution(1920, 1080, true);

        TestValue.m_InputData.RendererValue += URPRenderer;
        TestValue.m_InputData.ToastText += TheToast;
         
        TestValue. m_InputData.GameName += TheName;
        TestValue.m_InputData.SceneName += SwitchScene;
        TestValue.m_InputData.Thevalue += TheValue;
        TestValue.m_InputData.MarkTextvalue += TheMarkTextvalue;
        TestValue.m_InputData.TimeTextvalue += TheTimeTextvalue;
        TestValue.m_InputData.Hosts += ThehostIs;
        TestValue.m_InputData.GameStatus += TheGameStatus;
        TestValue.m_InputData.TimePlay += TestCountdown;
        PauseButton.onClick.AddListener(ThePauseButton2);//ThePauseButton2
        PlayButton.onClick.AddListener(ThePlayButton2);//ThePlayButton2
        QuitButton.onClick.AddListener(TheQuitButton);
        if (Flicker)
        {
            m_rot = RenderSettings.skybox.GetFloat("_Exposure");
        }
        if (Rotate)
        {
            rot = RenderSettings.skybox.GetFloat("_Rotation");
        }
        gameValue.AddListener(() => {  GameControls(Gamename, GameValue);  });
    }

   
    private void FixedUpdate()
    {
        if (RenderSettings.skybox == null)
            return;


        if (Flicker)
        {

            if (Isbool1)
            {
                m_rot += Time.deltaTime * Speed;
                RenderSettings.skybox.SetFloat("_Exposure", m_rot);
                if (m_rot > Max)
                {
                    Isbool1 = false;
                    Isbool2 = true;
                }

            }
            else if (Isbool2)
            {
                m_rot -= Time.deltaTime * Speed;
                RenderSettings.skybox.SetFloat("_Exposure", m_rot);
                if (m_rot < Min)
                {
                    Isbool1 = true;
                    Isbool2 = false;
                }

            } 
        }


        if (Rotate)
        {
            rot += RateSpeed * Time.deltaTime;
            rot %= 360;
            RenderSettings.skybox.SetFloat("_Rotation", rot); 
        }

        //if (time > 0) 
        //{
        //    time -= Time.deltaTime;
        //    TimeText.text = time.ToString("f0");
        //}


    }

    private void TheName(string name)
    {
        Gamename = name;
    
     
    }
    private void TheValue(float value)
    {
       
           GameValue = value;
        gameValue?.Invoke();
    }
    private void TheMarkTextvalue(float value)
    {
        MarkText.text = value.ToString("f0");
    }
    private void TheTimeTextvalue(float value)
    {
        StopCoroutine("Countdown");
        time = value;
        UpdateTimeDisplay();
       
    }
    private void TestCountdown(bool value)
    {
        if (value)
        {
            if (time > 0&& TimePlay)///
            {
                Invoke("TimeIsplay", 0.05f);
                TimePlay = false;
            }
        }
        else
        {
            StopCoroutine("Countdown");
            TimePlay = true;
        }
      
    }
    private void TimeIsplay()
    {
        StartCoroutine("Countdown");
    }
    private void URPRenderer(float Value)
    {
        float TheValue = Mathf.Clamp(Value, 0.1f, 2f);
        URPRe.renderScale = TheValue;
    }
    private void TheGameStatus(bool value)
    {
        if (value)
        {
            ThePlayButton();
        }
        else
        {
            ThePauseButton();
        }
    }
    IEnumerator Countdown()
    {
       
            while (time > 0)
            {
                yield return new WaitForSeconds(1);
                time -= 1;
               UpdateTimeDisplay();
        }
            TimeText.text = "时间到";
            TestValue.m_InputData.IsTimeZero = true;
        
    }
    private void ThehostIs(int value)
    {
        HosetInbool = value;
        switch (value)
        {

            case 1:
                if (Time.timeScale==1)
                {
                    ButtonStatus(PlayButton, false);
                    ButtonStatus(PauseButton, true);
                }
                else if (Time.timeScale == 0)
                {
                    ButtonStatus(PlayButton, true);
                    ButtonStatus(PauseButton, false);
                }
               
                break;
            case 2:
                ButtonStatus(PlayButton, false);
                ButtonStatus(PauseButton, false);
                break;
            default:
                break;
        }
    }
   private void UpdateTimeDisplay()
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        string formattedTime = string.Format("{0}分{1:D2}秒", minutes, seconds);
        TimeText.text = formattedTime;
    }
    private void ThePauseButton2()
    {
        TestValue.m_InputData.IsApplyforsuspension = true;
        ButtonStatus(PauseButton, false);
    }
    private void ThePauseButton()
    {
        TestValue.m_InputData.IsSceneStatus = false;
        StopCoroutine("Countdown");
        if (HosetInbool==1)
        {
            ButtonStatus(PauseButton, false);
            ButtonStatus(PlayButton, true);
        }
     
        AudioAllPlay(false);
        Time.timeScale = 0;
    }
    private void ThePlayButton2()
    {
        TestValue.m_InputData.IsApplyforsuspension = false;
        ButtonStatus(PlayButton, false);
    }
    private void ThePlayButton()
    {
        TestValue.m_InputData.IsSceneStatus = true;
        if (time>0)
        {
            Invoke("TimeIsplay", 0.05f);
        }
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        if (HosetInbool == 1)
        {
            ButtonStatus(PauseButton, true);
            ButtonStatus(PlayButton, false);
        }
        AudioAllPlay(true);
       
    }
    private void TheQuitButton()
    {
      TestValue.m_InputData.IsGameQuit=true;
     // Application.Quit();
    }

    public void SwitchScene(string SceneName)
    {
        if (SceneName != SceneManager.GetActiveScene().name)
        {
            GameThePath.Clear();
            AudioThePath.Clear();
            if (renderData.rendererFeatures[1].isActive)
            {
                renderData.rendererFeatures[1].SetActive(false);
            }
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
            asyncLoad.completed += asyncLoad =>
            {
                TestValue.m_InputData.IsSceneLoading = SceneName;
            }; 
            
        }
        else
        {
            Debug.Log("已在当前场景");
        }
       
    }


    private void GameControls(string name,float value)
    {
       
           
                if ( GameThePath.Count!=0)
                {
                   if (GameThePath.ContainsKey(name))
                   {
                       TheGameCtrl(name, value);
                   }
                   
                }
                else
                {
                  if (GameObject.FindGameObjectWithTag(name))
                  {
                      TheGame = GameObject.FindGameObjectWithTag(name);
                  }
               
                if (TheGame != null)
                {
                    GameThePath.Add(name, TheGame);
                    if (TheGame.GetComponent<AudioSource>())
                    {
                        AudioThePath.Add(name, TheGame.GetComponent<AudioSource>());

                    }
                    TheGameCtrl(name, value);
                }
            
               
                }
            
        
    }


    private void TheGameCtrl(string name,float Value)
    {
      
        switch (name)
        {
            case "VFX_Fire_Floor":
                GameThePath[name].gameObject.transform.localScale = TheGamelocalScale(Value);
                break;

            case "TestWater":
                float TestValue1 = Mathf.Clamp(Value, 0f, 2f);
                float complement = 1 - TestValue1;
      
                if (h==0&&str==0&& Lang==0)
                {
                   
                     h = GameThePath[name].gameObject.GetComponent<Renderer>().material.GetFloat("_WaveHeight");
                    str = GameThePath[name].gameObject.GetComponent<Renderer>().material.GetFloat("_WaveNormalStr");
                    Lang = GameThePath[name].gameObject.GetComponent<Renderer>().material.GetFloat("_WaveSpeed");
                }
              
                float newWaveHeight = Mathf.Clamp(h * complement * 1f, 0.1f, 1.7f);
               // float newWaveNormalStr = Mathf.Clamp(str * complement * 1f, 0.1f, 10f);
               
                float curveValue = positionCurve.Evaluate(Value*10);
                GameThePath[name].gameObject.GetComponent<Renderer>().material.SetFloat("_WaveNormalStr", curveValue);
               GameThePath[name].gameObject.GetComponent<Renderer>().material.SetFloat("_WaveHeight",newWaveHeight);
             
              
                if (Value<0.96)
                {
                    GameThePath[name].gameObject.GetComponent<Renderer>().material.SetFloat("_WaveSpeed", 2f);
                }
                else
                {
                    GameThePath[name].gameObject.GetComponent<Renderer>().material.SetFloat("_WaveSpeed", 0f);
                }
              
                break;

            case "TerrainFog":
                float scaledValue = (Value - 0) / (1 - 0) * (1 - 0.55f) + 0.55f;
                float   complement0 = Mathf.Min(1, scaledValue / 0.9f);
                float complement1 = 1 - complement0;

                    GameThePath[name].gameObject.GetComponent<HeightFogGlobal>().fogIntensity = complement1;
                    GameThePath[name].gameObject.GetComponent<HeightFogGlobal>().skyboxFogIntensity = complement1; 
                

                break;
            case "Sandstorm":
                if (renderData.rendererFeatures[1].isActive==false)
                {
                    renderData.rendererFeatures[1].SetActive(true);
                }
                float SandstormValue = (Value - 0) / (1 - 0) * (1 - 0.3f) + 0.3f;
                float Sandstorm1 = Mathf.Min(1, SandstormValue / 0.9f);
                float Sandstorm2 = 1 - Sandstorm1;

                GameThePath[name].gameObject.GetComponent<HeightFogGlobal>().fogIntensity = Sandstorm2;
                GameThePath[name].gameObject.GetComponent<HeightFogGlobal>().skyboxFogIntensity = Sandstorm2;


                break;

            case "TerrainSwitch":
                TerrainController.Instance.SetSceneValue01(Value);
                break;
            default:
                break;
        }
        if (AudioThePath.ContainsKey(name))
        {
            AudioThePath[name].volume = Value;
        }
    }

    private Vector3 TheGamelocalScale(float value)
    {
        return new Vector3(value, value, value);
    }

    private void ButtonStatus(Button But,bool value)
    {
        But.gameObject.SetActive(value);
    }
    public void AudioAllPlay(bool value)
    {

        if (AudioThePath.Count!=0)
        {

            foreach (var kvp in AudioThePath)
            {
                if (value)
                {

                    kvp.Value.Play();
                }
                else
                {
                    kvp.Value.Pause();
                }

            }  
        }
        
    }

    private void TheToast(string value)//弹窗
    {
        ToastText.text = value;
        if (ToastImage.color.a<=0f)
        {
            StartCoroutine("OffToastImageUI");
        }
    }
   
    private IEnumerator OffToastImageUI()
    {
      
        float startTime = Time.time;
        float fadeDuration = 0.5f; 

       
        while (ToastImage.color.a < 1)
        {
            float t = (Time.time - startTime) / fadeDuration;
            t = Mathf.Clamp01(t);
            ToastImage.color = new Color(1, 1, 1, Mathf.Lerp(ToastImage.color.a, 1, t));
            ToastText.color = new Color(0, 0, 0, Mathf.Lerp(ToastText.color.a, 1, t));
            yield return null;
        }

        yield return new WaitForSeconds(5);


        startTime = Time.time;
        while (ToastImage.color.a > 0)
        {
            float t = (Time.time - startTime) / fadeDuration;
            t = Mathf.Clamp01(t);
            ToastImage.color = new Color(1, 1, 1, Mathf.Lerp(ToastImage.color.a, 0, t));
            ToastText.color = new Color(0, 0, 0, Mathf.Lerp(ToastText.color.a, 0, t));
            yield return null;
        }

    }

}
