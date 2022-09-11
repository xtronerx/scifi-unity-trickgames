using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    private float intCurrentVelocity = 0;

    //<summery> Each player health goes here </summery>
    protected byte intMaxHealth;

    private byte intHealth;

    //<summery> Cooldown for each special move </summery
    protected ushort intCooldown;

    private TextMeshProUGUI _HealthText;
    private Slider _HealthSlider;

    private bool _bolCooldown;
    //<summery> This function calls in Awake and has job to setup your variables </summery>
    protected virtual void Setup() { }

    private byte HealthbarSliderSmoothness;

    public void InteractObjectConstructor(byte SliderSmooth)
    {
        HealthbarSliderSmoothness = SliderSmooth;
    }

    void Awake()
    {
        Setup();
        _HealthText = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
        _HealthSlider = GameObject.Find("Health Bar").GetComponent<Slider>();
        _HealthText.text = intMaxHealth.ToString();
        intHealth = intMaxHealth;
    }

    //<summery> this function calls in Start and you can do your needage of Start here </summery>
    protected virtual void Activation() { }

    void Start()
    {
        Activation();
    }

    //<summery> this function calls in Update and that's your main function </summery>
    protected virtual bool Worker() { return false; }

    void Update()
    {
        if (_bolCooldown) return;
        if (Worker())
        {
            _bolCooldown = true;
            StartCoroutine(StartCooldown());
        }
    }

    private void LateUpdate()
    {
        if(_HealthSlider.value * (intMaxHealth / 100) != intHealth)
        {
            _HealthSlider.value = Mathf.MoveTowards(_HealthSlider.value, intHealth / (intMaxHealth / 100), HealthbarSliderSmoothness * Time.deltaTime);//Mathf.SmoothDamp(_HealthSlider.value, intHealth, ref intCurrentVelocity, 10 * Time.deltaTime);
        }
    }

    private IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(intCooldown);
        _bolCooldown = false;
    }

    /**
     * This function is for take damage from player health
     */
    public void TakeDamage(byte intDamage)
    {
        intHealth -= intDamage;
        _HealthText.text = intHealth.ToString();
    }
}
