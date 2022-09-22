using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownHUD : MonoBehaviour
{
    #region Public Properites 
    [HideInInspector]
    public byte intCooldownTime { get; private set; } = 7;
    [Header("Reference Properties")]
    [SerializeField] private Slider slider;
    [SerializeField] private Image FillImage;
    [Space(15)]

    [Header("Countdown Properties")]
    [Space(3)]
    [SerializeField] private bool bolRestartCooldown;
    #endregion

    #region Private Properties
    float timer;
    #endregion

    #region Built-In Functions
    private void Update()
    {
        //Counting down...
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            slider.value = timer;
            if(timer < 0)
            {
                slider.gameObject.SetActive(false);
            }
        }
        //Restarting the countdown...
        if (bolRestartCooldown)
        {
            Debug.Log("Reset Cooldown");
            slider.maxValue = intCooldownTime; 
            timer = intCooldownTime;
            slider.gameObject.SetActive(true);
            bolRestartCooldown = false;
        }
    }
    #endregion

    #region Custom Functions
    public void SetCooldown()
    {
        this.bolRestartCooldown = true;
    }
    public void SetCooldown(byte cooldownTime, bool restartCooldown)
    {
        this.intCooldownTime = cooldownTime;
        if (restartCooldown)
        {
            this.bolRestartCooldown = restartCooldown;
        }
    }
    public void changeColor(Color FillImageColor)
    {
        FillImage.color = FillImageColor;
    }
    #endregion
}
