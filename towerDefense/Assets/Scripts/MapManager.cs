using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapManager : MonoBehaviour
{
    public Image hpBar;
    public static MapManager Instance;
    //public List<Transform> controlPoints = new List<Transform>(); // hareket edilecek noktalar yol
    public Transform castle; // düþmanlarýn gideceði yer 

    private float castleHp = 100f;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {


    }

    public void DamageCastle()
    {
        castleHp -= 5;
        hpBar.fillAmount = castleHp / 100;
    }

}
