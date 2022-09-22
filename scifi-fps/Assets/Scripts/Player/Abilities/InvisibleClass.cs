using System.Collections;
using UnityEngine;

public class InvisibleClass : Ability
{
    private GameObject player;

    //<summery> This function calls in Awake and has job to setup your variables </summery>
    protected override void Setup()
    {
        intMaxHealth = 100;
        intCooldown = 60;
        player = GameObject.Find("Mesh");
    }

    //<summery> this function calls in Update and that's your main function </summery>
    protected override bool Worker()
    {
        if (Input.GetKey(KeyCode.E))
        {
            StartCoroutine(BeInvisible());
            return true;
        }
        return false;
    }

    /**
     * <summary>
     *  The function which make the character invisible and work cooldown slider
     * </summary>
     * <example>
     *  StartCoroutine(BeInvisible());
     * </example>
     */
    private IEnumerator BeInvisible()
    {
        intCooldown = 5;
        cooldownHUD.changeColor(new Color(0, 255, 245));
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(5f);
        yield return new WaitUntil(() => !_bolCooldown);
        cooldownHUD.changeColor(new Color(0.67058825f, 0.4f, 0));
        player.GetComponent<Renderer>().enabled = true;
        intCooldown = 60;
        yield return StartCoroutine(StartCooldown());
    }
}
