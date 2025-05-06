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

    public void UpdateAnimation(CharacterModel.CharacterType type, float movementAmount)
    {
        if (type == CharacterModel.CharacterType.Player)
        {
            playerAnimator?.SetFloat("MOVEVALUE", movementAmount);
        }
        else if (type == CharacterModel.CharacterType.Dog)
        {
            dogAnimator?.SetFloat("DOGMOVEVALUE", movementAmount);
        }
    }
}
