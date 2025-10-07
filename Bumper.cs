using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
public class Bumper : MonoBehaviour
{
    public static Bumper instance;

    public float bumperForce = 1f;
    public AnimationController animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        instance = this;
        animator = GetComponentInParent<AnimationController>();
    }
}
