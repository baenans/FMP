using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour {

    public Transform player;
    public Text ammoText;
    public Text healthText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ammoText.text = player.GetComponent<PlayerStats>().Ammo.ToString() + "/" + player.GetComponent<PlayerStats>().MaxAmmo.ToString();
        healthText.text = player.GetComponent<PlayerStats>().PlayerHealth.ToString();
    }
}
