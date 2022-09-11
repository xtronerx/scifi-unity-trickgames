using System;
using System.Collections;
using UnityEngine;

public class SpeedClass : Ability
{
    private Player.FpsController PlayerMovement;
    //<summery> This function calls in Awake and has job to setup your variables </summery>
    protected override void Setup()
    {
        intMaxHealth = 100;
        intCooldown = 20;
        PlayerMovement = GetComponent<Player.FpsController>();
    }

    //<summery> this function calls in Update and that's your main function </summery>
    protected override bool Worker()
    {
        if (Input.GetKey(KeyCode.E))
        {
            StartCoroutine(BeSpeedy());
            return true;
        }
        return false;
    }

    private IEnumerator BeSpeedy()
    {
        PlayerMovement.walkMaxSpeed = 13f;
        PlayerMovement.sprintMaxSpeed = 13f;
        yield return new WaitForSeconds(5f);
        PlayerMovement.walkMaxSpeed = 5f; 
        PlayerMovement.sprintMaxSpeed = 10f;
    }
}
