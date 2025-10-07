using UnityEngine;

public class BumperController : Bumper
{
    [SerializeField] int bumperAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }   
    private void OnCollisionEnter(Collision collider)
    {
        foreach (ContactPoint contact in collider.contacts)
        {
            contact.otherCollider.attachedRigidbody.AddForce(-1 * contact.normal * instance.bumperForce, ForceMode.Impulse);
        }

        if (instance.animator != null)
        {
            animator.PlayAnimation(bumperAnim);
        }
    }
}
