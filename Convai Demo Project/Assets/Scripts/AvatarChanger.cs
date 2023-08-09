using Unity.LiveCapture.ARKitFaceCapture;
using UnityEngine;

public class AvatarChanger : MonoBehaviour
{
    /// <summary>
    /// ARKit Face Device Component under Take Recorder gameobject
    /// Choose which actor to animate based on iphone input
    /// </summary>
    [SerializeField] private FaceDevice faceDevice;

    /// <summary>
    /// The outer look of male player
    /// </summary>
    [SerializeField] private GameObject malePlayer;

    /// <summary>
    /// Y coordinate of camera position for male player.
    /// Basically higher than famale's setup.
    /// </summary>
    [SerializeField] private float cameraHeightForMalePlayer = 1.7f;

    /// <summary>
    /// The outer look of female player
    /// </summary>
    [SerializeField] private GameObject femalePlayer;

    /// <summary>
    /// Y coordinate of camera position for female player.
    /// Basically lower than male's setup.
    /// </summary>
    [SerializeField] private float cameraHeightForFemalePlayer = 1.63f;

    /// <summary>
    /// The transform of the camera to display player
    /// </summary>
    [SerializeField] private Transform playerCameraTransform;

    /// <summary>
    /// Face Actor Component for male player
    /// </summary>
    private FaceActor maleFaceActor;

    /// <summary>
    /// Face Actor Component for female player
    /// </summary>
    private FaceActor femaleFaceActor;

    private void Start()
    {
        maleFaceActor = malePlayer.GetComponent<FaceActor>();
        femaleFaceActor = femalePlayer.GetComponent<FaceActor>();
    }

    /// <summary>
    /// The process to switch between 2 genders
    /// </summary>
    /// <param name="gender">0 for male, 1 for female</param>
    private void ApplyGenderSetup(int gender)
    {
        if (gender == 0)
        {
            faceDevice.Actor = maleFaceActor;

            malePlayer.SetActive(true);
            femalePlayer.SetActive(false);

            playerCameraTransform.position = new Vector3(
                x: playerCameraTransform.position.x,
                y: cameraHeightForMalePlayer,
                z: playerCameraTransform.position.z
                );
        }
        else if (gender == 1)
        {
            faceDevice.Actor = femaleFaceActor;

            malePlayer.SetActive(false);
            femalePlayer.SetActive(true);

            playerCameraTransform.position = new Vector3(
                x: playerCameraTransform.position.x,
                y: cameraHeightForFemalePlayer,
                z: playerCameraTransform.position.z
                );
        }
        else
        {
            throw new System.Exception("Specify gender with 0 or 1.");
        }
    }

    /// <summary>
    /// Change the outer look of player gameobject between male and female
    /// </summary>
    public void SwitchAvatar()
    {
        if(faceDevice.Actor == null)
        {
            ApplyGenderSetup(0);

            return;
        }

        if(faceDevice.Actor == maleFaceActor) // male -> female
        {
            ApplyGenderSetup(1);
        }
        else // female -> male
        {
            ApplyGenderSetup(0);
        }
    }
}
