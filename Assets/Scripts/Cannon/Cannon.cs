using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform _cannonTransform;


    public void SetCannonRotation(Quaternion rotationAngleArg)
    {
        _cannonTransform.rotation = rotationAngleArg;
    }

    public Vector3 GetGunPosition()
    {
        return transform.position;
    }
}