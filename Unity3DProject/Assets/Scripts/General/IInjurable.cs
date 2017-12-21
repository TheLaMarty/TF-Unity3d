using UnityEngine;

public interface IInjurable {

    void TakeDamage(float damage);

    void TakeHit(float damage, Vector3 hitPoint, Vector3 hitDirection);

}
