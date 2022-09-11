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
    private void Awake()
    {
        CharacterType = gameObject.AddComponent(System.Type.GetType("DouubleJumpClass")) as Ability;
        CharacterType.InteractObjectConstructor(HealthBarSmoothness);
    }

    public void TakeDamage(byte intDamage)
    {
        CharacterType.TakeDamage(intDamage);
    }
}
