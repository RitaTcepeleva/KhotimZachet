using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

	public Transform shotPrefab;

	public float shootingRate = 0.25f;

	private float shootCooldown;

	// Use this for initialization
	void Start () {
		shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}
		bool shoot = Input.GetButtonDown ("Fire1");
		shoot |= Input.GetButtonDown ("Fire2");
		if (shoot) {
			WeaponScript weapon = GetComponent<WeaponScript> ();
			if (weapon != null) {
				weapon.Attak (false);
			}
		}
	}

	public void Attak(bool isEnemy){
		if (CanAttak) {

            shootCooldown = shootingRate;
			var shotTransform = Instantiate (shotPrefab) as Transform;

            shotTransform.position = transform.position;
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript> ();
			if (shot != null) {
				shot.isEnemyShot = isEnemy;
			}

			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript> ();
			if (move != null) {
				move.direction = this.transform.right;
			}
		}
	}
	public bool CanAttak {get {return shootCooldown <= 0f;}}
}
