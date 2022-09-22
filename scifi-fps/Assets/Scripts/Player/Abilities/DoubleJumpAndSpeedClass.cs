using System.Collections;
using UnityEngine;

public class DoubleJumpAndSpeedClass : Ability
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
            if (fpsController.isGrounded == false)
            {
                fpsController.Jump();
                Debug.Log("Worked");
                intCooldown = 5;
                return true;
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            StartCoroutine(BeSpeedy());
            return true;
        }
        return false;
    }
    private IEnumerator BeSpeedy()
    {
        intCooldown = 5;
        fpsController.walkMaxSpeed = 13f;
        fpsController.sprintMaxSpeed = 13f;
        cooldownHUD.changeColor(new Color(0, 255, 245));
        yield return new WaitForSeconds(5);
        yield return new WaitUntil(() => !_bolCooldown);
        cooldownHUD.changeColor(new Color(0.67058825f, 0.4f, 0));
        intCooldown = 60;
        fpsController.walkMaxSpeed = 5f;
        fpsController.sprintMaxSpeed = 10f;
        yield return StartCoroutine(StartCooldown());
    }
}
