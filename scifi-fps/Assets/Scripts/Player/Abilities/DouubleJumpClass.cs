using System.Collections;
using UnityEngine;

public class DouubleJumpClass : Ability
{
    private Player.FpsController fpsController;

    // Start is called before the first frame update
    protected override void Setup()
    {
        intMaxHealth = 200;
        intCooldown = 5;
        fpsController = GetComponent<Player.FpsController>();
    }

    protected override bool Worker()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(fpsController.isGrounded == false)
            {
                fpsController.Jump();
                Debug.Log("Worked");
                return true;
            }
        }
        return false;
    }
}
