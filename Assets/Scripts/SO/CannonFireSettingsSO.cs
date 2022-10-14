using UnityEngine;

[CreateAssetMenu(fileName = "CannonFireSettingsSO", menuName = "GameSO/CannonFireSettingsSO")]
public class CannonFireSettingsSO : ScriptableObject
{
    public float fireForce = 16f;
    public Bullet bulletPrefab;
    public float timeFireReload; //время перезарядки
}