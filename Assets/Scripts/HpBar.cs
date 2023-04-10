using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public float health = 100;
    public Image LineBar;

    public void ConditionalDagame()
    {
        LineBar.fillAmount = health / 100;
    }
}
