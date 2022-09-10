using System;
using System.Collections;
using UnityEngine;

public class SpeedClass : Ability
{
    private Player.Movement PlayerMovement;
    //<summery> This function calls in Awake and has job to setup your variables </summery>
    public override void Setup()
    {
        intHealth = 100;
        intCooldown = 20;
        PlayerMovement = GetComponent<Player.Movement>();
    }

    //<summery> this function calls in Update and that's your main function </summery>
    public override bool Worker()
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
        PlayerMovement.playerSpeed = new float[3] { 8f, 8f, 8f};
        yield return new WaitForSeconds(5f);
        PlayerMovement.playerSpeed = new float[3] { 2f, 4f, 1f };
    }
}
