using UnityEngine;

[RequireComponent (typeof(HingeJoint))]
[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(MeshCollider))]
public class Flipper : MonoBehaviour
{
    [SerializeField] float startPos = 0f;
    [SerializeField] float endPos = 45f;
    [SerializeField] float strength = 10f;
    [SerializeField] float damper = 1.5f;

    HingeJoint joint;
    JointSpring spring;
    JointLimits limits;

    public enum Sides { LEFT, RIGHT }

    public Sides side;
    int direction = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joint = GetComponent<HingeJoint>();

        //Spring settings
        joint.useSpring = true;
        spring = new JointSpring();
        spring.spring = strength;
        spring.damper = damper;

        //Limits settings
        joint.useLimits = true;
        limits = new JointLimits();
        limits.min = startPos;
        limits.max = endPos * direction;
        joint.limits = limits;
    }

    // Update is called once per frame
    void Update()
    {
        LeftInput();       
        RightInput();
        joint.spring = spring;
    }

    void LeftInput()
    {
        if (side == Sides.LEFT)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                spring.targetPosition = endPos * direction;
                Debug.Log("Left Arrow Pressed");
            }
            else
            {
                spring.targetPosition = startPos;
            }
        }
    }
    void RightInput()
    {
        if (side == Sides.RIGHT)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                spring.targetPosition = endPos * direction;
            }
            else
            {
                spring.targetPosition = startPos;
            }
        }
    }
}
