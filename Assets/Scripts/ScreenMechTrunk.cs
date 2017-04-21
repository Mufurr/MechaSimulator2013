using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScreenMechTrunk : MonoBehaviour {

    public Camera cam;

    public int MechHp { set; get; }
    public int energy { set; get; }
    public int reserveEnergy { set; get; }

    public RectTransform HiderLife;
    public RectTransform HiderEnergy;
    public RectTransform HiderReserve;

	public float EnergyCoef;
	public float LifeCoef;

    private float HiderLifeMax;
    private float HiderEnergyMax;
    private float HiderReserveMax;

    void Start () {
        HiderLifeMax = HiderLife.position.z;
        HiderEnergyMax = HiderEnergy.position.z;
        HiderReserveMax = HiderReserve.position.z;
    }
	
	void Update ()
    {
		//PIERRE : Si tu change les valeurs de Health ou Tanker, applique à chaque coefficient le calcul : coef = coef * OldValue / NewValue
        HiderLife.position = new Vector3(HiderLife.position.x, HiderLife.position.y, HiderLifeMax + MechHp * LifeCoef);
		HiderEnergy.position = new Vector3(HiderEnergy.position.x, HiderEnergy.position.y, HiderEnergyMax  + energy * EnergyCoef);
		HiderReserve.position = new Vector3(HiderReserve.position.x, HiderEnergy.position.y, HiderReserveMax + reserveEnergy * EnergyCoef);
    }
}
