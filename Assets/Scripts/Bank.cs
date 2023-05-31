using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    public int priceWall = 5;
    public int priceTurret = 10;
    public int currentBank = 15;
    public TMP_Text Money;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Money.text = "" + currentBank;
    }
}
