using Kino;
using UnityEngine;

public class CameraEffectChanger : MonoBehaviour
{
    /// <summary>
    /// The class for adding glitch effect to camera
    /// </summary>
    [SerializeField] private AnalogGlitch analogGlitch;

    /// <summary>
    /// Turn on/off the effect on the camera
    /// </summary>
    public void SwitchCameraEffect()
    {
        analogGlitch.enabled = !analogGlitch.enabled;
    }
}
