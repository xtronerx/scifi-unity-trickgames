using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    //<summery> Each player health goes here </summery>
    protected byte intMaxHealth;

    private byte intHealth;

    //<summery> Cooldown for each special move </summery
    protected ushort intCooldown;

    private Slider _HealthSlider;
    private CanvasRenderer _HealthCanvas;
    [SerializeField]
    public bool _bolCooldown { get; private set; } = false;

    //<summery> This function calls in Awake and has job to setup your variables </summery>
    protected virtual void Setup() { }

    private byte HealthbarSliderSmoothness;

    [Tooltip("CooldownHUD Script for Configuring Cooldown")]
    [SerializeField]
    protected CooldownHUD cooldownHUD;

    public void InteractObjectConstructor(byte SliderSmooth, CooldownHUD cooldownScript)
    {
        HealthbarSliderSmoothness = SliderSmooth;
        cooldownHUD = cooldownScript;
    }

    void Awake()
    {
        Setup();
        _HealthSlider = GameObject.Find("Health Bar").GetComponent<Slider>();
        _HealthCanvas = GameObject.Find("Health Bar Image").GetComponent<CanvasRenderer>();
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
            StartCoroutine(StartCooldown());
        }
    }

    private void LateUpdate()
    {
        if (_HealthSlider.value * (intMaxHealth / 100) != intHealth)
        {
            _HealthSlider.value = Mathf.MoveTowards(_HealthSlider.value,
                intHealth / (intMaxHealth / 100),
                HealthbarSliderSmoothness * Time.deltaTime);
            if (_HealthSlider.value < 50) _HealthCanvas.SetColor(Color.red);
            else _HealthCanvas.SetColor(Color.white);
        }
    }

    protected IEnumerator StartCooldown()
    {
        _bolCooldown = true;
        if (this.intCooldown != ((ushort)cooldownHUD.intCooldownTime))
            cooldownHUD.SetCooldown((byte)intCooldown, true);
        else cooldownHUD.SetCooldown();
        yield return new WaitForSeconds(intCooldown + .1f);
        _bolCooldown = false;
    }

    /**
     * <summary>
     *  This function is for take damage from player health
     * </summary>
     * <param name="intDamage">
     *  The damage that player takes
     * </param>
     */
    public void TakeDamage(byte intDamage)
    {
        intHealth -= intDamage;
    }
}
