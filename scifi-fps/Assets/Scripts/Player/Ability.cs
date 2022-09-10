using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ability : MonoBehaviour
{
    //<summery> Each player health goes here </summery>
    protected int intMaxHealth;

    private int intHealth;

    //<summery> Cooldown for each special move </summery
    protected int intCooldown;

    private TextMeshProUGUI _HealthText;

    private bool _bolCooldown;
    //<summery> This function calls in Awake and has job to setup your variables </summery>
    public virtual void Setup() { }

    void Awake()
    {
        Setup();
        _HealthText = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
        _HealthText.text = intMaxHealth.ToString();
        intHealth = intMaxHealth;
    }

    //<summery> this function calls in Start and you can do your needage of Start here </summery>
    public virtual void Activation() { }

    void Start()
    {
        Activation();
    }

    //<summery> this function calls in Update and that's your main function </summery>
    public virtual bool Worker() { return false; }

    void Update()
    {
        if (_bolCooldown) return;
        if (Worker())
        {
            _bolCooldown = true;
            StartCoroutine(StartCooldown());
        }

    }

    private IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(intCooldown);
        _bolCooldown = false;
    }
}
