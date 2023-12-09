using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dukeAnimation : MonoBehaviour
{

    public bool attackIsOver = false;
    public bool midAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackStartAnimationEvent()
    {
        attackIsOver = false;
    }

    public void AttackOverAnimationEvent()
    {
        attackIsOver = true;
    }

    public void MidAttackAnimation()
    {
        midAttack = true;
        player.health--;
    }
}
