using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    Vector3 velocity;
    Rigidbody myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        this.velocity = _velocity;
    }

    public void LookAt(Vector3 lookDirection)
    {
        Vector3 lockHeight = new Vector3(lookDirection.x, transform.position.y, lookDirection.z);
        transform.LookAt(lockHeight);
    }

    void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}

