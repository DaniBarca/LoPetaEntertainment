using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public float curIce = 100;
    public float curHealth = 100;

    public Texture2D healthColor;
    public Texture2D iceColor;

    private float healthBarLength;

    // Use this for initialization
    void Start()
    {
        healthBarLength = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        curIce = Mathf.Clamp(curIce, 0.0f, 100.0f);
        curHealth = Mathf.Clamp(curHealth, 0.0f, 100.0f);
    }

    void OnGUI()
    {


        GUI.DrawTexture(new Rect(10, 10, 0.001f * Screen.width * curHealth, 30), healthColor, ScaleMode.StretchToFill, true, 10.0F);
        GUI.DrawTexture(new Rect(10, 45, 0.001f * Screen.width * curIce, 30), iceColor, ScaleMode.StretchToFill, true, 10.0F);
    }


}