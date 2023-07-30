using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public GameObject weaponPrefab;
    public int magazineSize;
    public int magazineCount;
    public int currentAmmo;

    public float range;
    public WeaponType weaptonType;

    public enum WeaponType{
        Pistol,
        Rifle,
        Shotgun,
        Sniper,
        Melee
    }


}
