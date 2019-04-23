using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        projectile = Resources.Load("Prefabs/Projectile") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
            Instantiate(projectile, firePoint.position, firePoint.rotation);
    }
}
