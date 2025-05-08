using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView 
{
   
    private Animator playerAnimator;
    private Animator dogAnimator;

    public CharacterView(Animator playerAnim, Animator dogAnim)
    {
        playerAnimator = playerAnim;
        dogAnimator = dogAnim;
    }

    public void UpdateAnimation(CharacterController1.CharacterType type, float movementAmount)
    {
        if (type == CharacterController1.CharacterType.Player)
        {
            playerAnimator?.SetFloat("MOVEVALUE", movementAmount);
        }
        else if (type == CharacterController1.CharacterType.Dog)
        {
            dogAnimator?.SetFloat("DOGMOVEVALUE", movementAmount);
        }
    }
}
