using System.Collections;
using System.Collections.Generic;
//using Unity.PlasticSCM.Editor.WebApi; // doesnt work with windows build
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class UI_HP : MonoBehaviour
{
    public static UI_HP instance;
    public float CurrentHP = 50;
    public float TargetHP = 50;
    public float MaxHP = 50;
    float StartHP;
    float lerpTime = 3;
    public float elapsedTime = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        StartHP = CurrentHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHP != TargetHP)
        {
            // Calculate the time since the start of the interpolation
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / lerpTime;
            CurrentHP = Mathf.Lerp(StartHP, TargetHP, t);

            // Update the HP bar
            GetComponent<Image>().fillAmount = CurrentHP/MaxHP;

            // If the interpolation is complete, reset the start value
            if (elapsedTime >= lerpTime)
            {
                StartHP = TargetHP;
                elapsedTime = 0f;
            }
        }
    }

    public void UpdateHP(int DeltaHP)
    {
        TargetHP += DeltaHP;
        Debug.Log(CurrentHP);
    }
}
