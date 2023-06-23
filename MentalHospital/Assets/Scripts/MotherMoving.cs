using UnityEngine;
using UnityEngine.EventSystems;

public class MotherMoving : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] Transform leftEdge;
    [SerializeField] Transform rightEdge;

    [Header("Mom")]
    [SerializeField] private Transform mom;

    [Header("Movement Parametrs")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behavior")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator animator;

    private void Awake()
    {
        initScale = mom.localScale;
    }

    private void OnDisable()
    {
        //animator.SetBool("moving", false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (mom.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (mom.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
        
    }
    private void DirectionChange()
    {
        animator.SetBool("isMoving", false);

        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        animator.SetBool("isMoving", true);

        mom.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);
        mom.position = new Vector3(mom.position.x + Time.deltaTime * _direction * speed,
            mom.position.y,mom.position.z);
    }
}