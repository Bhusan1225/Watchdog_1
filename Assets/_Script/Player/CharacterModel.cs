using UnityEngine;

public class CharacterModel
{
    public float Speed = 3f;
    public float MoveX;
    public float MoveZ;
    public float MovementAmount;
    public bool IsGrounded;
    public Vector3 Velocity;
    public Vector3 MovementDirection;
    public Quaternion RequiredRotation;

    public enum CharacterType { Player, Dog }
    public CharacterType Character;
    public bool IsWatchdogActivated = false;

}
