using UnityEngine;
using System.Collections;

public class CameraBG : MonoBehaviour {
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 10.0F;
    void Update() {
        float t = Mathf.PingPong(Time.time/5, duration) / duration;
        camera.backgroundColor = Color.Lerp(color1, color2, t);
    }
    // void Example() {
    //     camera.clearFlags = CameraClearFlags.SolidColor;
    // }
}