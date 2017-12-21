using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask collisionMask;
    float speed = 10;
    float damage = 1;

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

       if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit.collider, hit.point);
        }
    }

    private void OnHitObject(Collider hit, Vector3 hitPoint)
    {
        IInjurable injurableObject = hit.GetComponent<IInjurable>();
        if (injurableObject != null)
        {
            injurableObject.TakeHit(damage, hitPoint, transform.forward);
        }

        DestroyObject(gameObject);
    }
}
