using UnityEngine;
using System.Collections;

public class Screen : MonoBehaviour {

    protected Renderer rend;
    public ScreenType type { get; set; }
    public string text {  get; set; }

	// Use this for initialization
	protected void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetTexture(Camera cam) {
        rend.material.mainTexture = cam.targetTexture;
        Debug.Log(rend.material.mainTexture.name);
    }
}
