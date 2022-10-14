using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public Vector3 GetSpawnerPoint()
    {
        return transform.position;
    }
    
    public Transform GetSpawnerTransform()
    {
        return transform;
    }
}