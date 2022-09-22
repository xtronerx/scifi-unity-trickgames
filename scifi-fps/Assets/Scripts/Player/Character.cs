using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    
    private readonly string AbilityClass;
    private Ability CharacterType;
    [Header("Smoothness")]
    [Range(0, 90)]
    [Tooltip("Smoothness Speed of Health Slider")]
    [SerializeField]
    private byte HealthBarSmoothness = 70;
    [Tooltip("The Script That Control Cooldown")]
    [SerializeField]
    private CooldownHUD cooldownHUD;
    private void Awake()
    {
        CharacterType = gameObject.AddComponent(System.Type.GetType("InvisibleClass")) as Ability;
        CharacterType.InteractObjectConstructor(HealthBarSmoothness, cooldownHUD);
        cooldownHUD = null;
        HealthBarSmoothness = 0;
    }

    public void Damage(byte intDamage)
    {
        CharacterType.TakeDamage(intDamage);
    }
}
