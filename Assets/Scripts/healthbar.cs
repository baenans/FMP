using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour {

    public Image healthBar;
    float maxHealth = 50;
    public static float playerHealth;

    // Use this for initialization
    void Start () {
        healthBar = GetComponent<Image>();
        playerHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = playerHealth ;
	}
}
