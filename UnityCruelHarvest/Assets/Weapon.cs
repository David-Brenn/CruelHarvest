using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public GameObject weaponPrefab;
    public int magazineSize;
    public int magazineCount;
    public int currentAmmo;
    bool readyToShoot;
    public int shootCooldown;
    public int reloadCooldown;
    public int weaponDamage;
    bool isScoped = false;


    [Header("Keybinds")]
    public KeyCode shootKey = KeyCode.Mouse0;
    public KeyCode reloadKey = KeyCode.R;
    public KeyCode scopeKey = KeyCode.Mouse1;


    public float range;
    public WeaponType weaponType;

    public enum WeaponType{
        Pistol,
        Rifle,
        Shotgun,
        Sniper,
        Melee
    }

    void Update()
    {

    }

    private void MyInput()
    {
        if (Input.GetKey(shootKey) && readyToShoot && currentAmmo > 0)
        {
            if (currentAmmo > 0)
            {
                readyToShoot = false;
                Attack();
                //Invoke(nameof(ResetShot), shootCooldown);
            }


        }
        if (Input.GetKey(reloadKey) && readyToShoot)
        {
            if (magazineCount > 0)
            {
                readyToShoot = false;
                Reload();
                //Invoke(nameof(ResetShot), shootCooldown);
            }
        }
        if (Input.GetKeyDown(scopeKey) && !isScoped && readyToShoot)
        {
            ToggleScope();
        }
        if (Input.GetKeyUp(scopeKey) && isScoped)
        {
            ToggleScope();
        }
    }

    private void Attack()
    {
        currentAmmo--;
    }

    private void Reload()
    {
        currentAmmo = magazineSize;
        magazineCount--;
           
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void ToggleScope()
    {
        isScoped = !isScoped;
    }


}
