using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHeght : MonoBehaviour
{
 
    [SerializeField] float TheTime=4f;
    [SerializeField] float Max;
    [SerializeField] float Min;

    private bool movingUp = true;

    void Start()
    {
        StartCoroutine("MoveBetweenPoints");
    }
    private void OnDestroy()
    {
        StopCoroutine("MoveBetweenPoints");
    }
    IEnumerator MoveBetweenPoints()
    {
        while (true)
        {
            if (movingUp)
            {
            
                float startTime = Time.time;
                float elapsed = 0.0f;
               
                while (elapsed < TheTime)
                {
                    float t = elapsed / TheTime;
             
                    transform.position = new Vector3(transform.position.x, Mathf.Lerp(Min, Max, t), transform.position.z);
                    elapsed = Time.time - startTime;
                    yield return null; 
                }

                movingUp = false; 
            }
            else
            {
              
                float startTime = Time.time;
                float elapsed = 0.0f;

                while (elapsed < TheTime)
                {
                    float t = elapsed / TheTime;
                    transform.position = new Vector3(transform.position.x, Mathf.Lerp(Max, Min, t), transform.position.z);
                    elapsed = Time.time - startTime;
                    yield return null; 
                }

                movingUp = true; 
            }
          
        }
    }

}
