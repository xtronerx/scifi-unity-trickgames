using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    
    private readonly string AbilityClass;
    private void Awake()
    {
        gameObject.AddComponent(System.Type.GetType("DouubleJumpClass"));
    }
}
