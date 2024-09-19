using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHeght : MonoBehaviour
{
    [SerializeField] GameObject TheWater;
    [SerializeField] float Speed;
    [SerializeField] float Max;
    [SerializeField] float Min;

    [HideInInspector]
    public bool IsUp;
    [HideInInspector]
    public bool IsDown;

    private float Heght;
    private float time;



    //private GameInputValue TheValue;
    //private float IsValue;
    //private float IsValue2;
    //private void OnEnable()
    //{
    //    TheValue = GameObject.Find("GameCtrl").GetComponent<GameInputValue>();
    //}
    // Start is called before the first frame update
    void Start()
    {
        
        //TheValue.m_InputData.Thevalue += PosValue;
       
    }

    private void OnDisable()
    {
       // TheValue.m_InputData.Thevalue -= PosValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (TheWater != null )
        {
            time += Time.deltaTime;
            if (IsDown && time >= 4)
            {

                Heght += (Time.deltaTime * Speed) / 1000f;
                TheWater.transform.position = Vector3.Lerp(TheWater.transform.position, new Vector3(TheWater.transform.position.x, TheWater.transform.position.y - Heght, TheWater.transform.position.z), 2);
                if (TheWater.transform.position.y < Min)
                {
                 
                    time = 0;
                    Heght = 0;
                    IsDown = false;
                    IsUp = true;
                }

            }
            else if (IsUp && time >= 4)
            {

                Heght += (Time.deltaTime * Speed) / 1000f;
                TheWater.transform.position = Vector3.Lerp(TheWater.transform.position, new Vector3(TheWater.transform.position.x, TheWater.transform.position.y + Heght, TheWater.transform.position.z), 2);
                if (TheWater.transform.position.y > Max)
                {
                  
                    time = 0;
                    Heght = 0;
                    IsDown = true;
                    IsUp = false;
                }

            }
        }
            //    if (IsValue== IsValue2)
            //    {
            //        IsDown = false;
            //        IsUp = false;
            //    }

            //    if (IsDown)
            //    {


            //        TheWater.transform.position = Vector3.Lerp(TheWater.transform.position, new Vector3(TheWater.transform.position.x, TheWater.transform.position.y +( 0.01f* IsValue), TheWater.transform.position.z), 2);

            //    }
            //    else if (IsUp)
            //    {


            //        TheWater.transform.position = Vector3.Lerp(TheWater.transform.position, new Vector3(TheWater.transform.position.x, TheWater.transform.position.y - (0.01f * IsValue), TheWater.transform.position.z), 2);

            //    }
            //    TheWater.transform.position =new Vector3(TheWater.transform.position.x, Mathf.Clamp(TheWater.transform.position.y, Min, Max), TheWater.transform.position.z);
            //    IsValue2 = IsValue;
            //}
        }
    //    private void PosValue(float Value)
    //{
    //    IsValue = Value;
    //}
}
