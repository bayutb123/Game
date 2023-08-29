using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    GameObject fireFlare;
	[SerializeField]
	GameObject projectile;
	[SerializeField]
	GameObject cameraRig;
    
    private KeyCode fire = KeyCode.Mouse0;
    
	private float fireRate = 0.1f;
	private bool canFire = true;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.rotation = cameraRig.transform.rotation * Quaternion.Euler(-5f, -1f, 0f);
        if (Input.GetKey(fire) && canFire)
        {
            fireFlare.SetActive(true);
			StartCoroutine(Fire());
        }
        else
        {
            fireFlare.SetActive(false);
        }
    }
	
	IEnumerator Fire()
    {
		canFire = false;
     	GameObject obj = Instantiate(projectile, fireFlare.transform.position, Quaternion.Euler(90f, 0f, 90f));
	    obj.GetComponent<Rigidbody>().AddForce(transform.forward * 3000f);
		yield return new WaitForSeconds(fireRate);
		canFire = true;
    }	
}
