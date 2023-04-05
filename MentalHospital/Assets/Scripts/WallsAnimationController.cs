using UnityEngine;

public class WallsAnimationController : MonoBehaviour
{
    [SerializeField] private CharacterController character;
    [SerializeField] private Animator wallBackAnimator;
    [SerializeField] private Animator wallFrontAnimator;

    private void Update()
    {
        if (character.isTouchingWall)
        {
            wallFrontAnimator.enabled = true;
            wallBackAnimator.enabled = true;
            wallFrontAnimator.SetBool("isTouch", true);
            wallBackAnimator.SetBool("isTouch", true);
        }
        else
        {
            wallBackAnimator.SetBool("isTouch", false);          
            wallFrontAnimator.SetBool("isTouch", false);
        }
    }
}
