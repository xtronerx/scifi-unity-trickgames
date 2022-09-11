using System.Collections;
using UnityEngine;

public class InvisibleClass : Ability
{
    private GameObject player;

    //<summery> This function calls in Awake and has job to setup your variables </summery>
    protected override void Setup() {
        intMaxHealth = 100;
        intCooldown = 60;
        player = GameObject.Find("Cylinder");
    }

    //<summery> this function calls in Update and that's your main function </summery>
    protected override bool Worker() {
        if (Input.GetKey(KeyCode.E))
        {
            StartCoroutine(BeInvisible());
            return true;
        }
        return false;
    }

    private IEnumerator BeInvisible()
    {
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(5f);
        player.GetComponent<Renderer>().enabled = true;
    }
}
