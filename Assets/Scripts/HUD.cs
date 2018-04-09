using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour {

    public Transform player;
    public Text ammoText;
    public Text healthText;
    public Text soulsText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ammoText.text = player.GetComponent<PlayerStats>().Ammo.ToString() + "/" + player.GetComponent<PlayerStats>().MaxAmmo.ToString();
        healthText.text = player.GetComponent<PlayerStats>().PlayerHealth.ToString("N0");
        soulsText.text = player.GetComponent<PlayerStats>().currency.ToString("N0");
    }
}
