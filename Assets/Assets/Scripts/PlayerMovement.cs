using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AICharacterControl))]
[RequireComponent(typeof(ThirdPersonCharacter))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] const int enemyLayerNumber = 9;
    [SerializeField] const int walkableLayerNumber = 8;
    bool isInDirectMode = false;


    ThirdPersonCharacter thirdPersonCharater = null;  // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster = null;
    Vector3 currentDestination;
    Vector3 clickPoint;
    AICharacterControl aiCharacterControl = null;
    GameObject walkTarget = null;


    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        thirdPersonCharater = GetComponent<ThirdPersonCharacter>();
        currentDestination = transform.position;
        aiCharacterControl = GetComponent<AICharacterControl>();
        walkTarget = new GameObject("WalkTarget");
        cameraRaycaster.notifyMouseClickObservers += ProcessMouseClick;
    }

    void ProcessMouseClick(RaycastHit raycastHit, int layerHit)
    {
        switch (layerHit)
        {
            case enemyLayerNumber:
            {
                GameObject enemy = raycastHit.collider.gameObject;
                aiCharacterControl.SetTarget(enemy.transform);
            }break;

            case walkableLayerNumber:
            {
                walkTarget.transform.position = raycastHit.point;
                aiCharacterControl.SetTarget(walkTarget.transform);
            }break;

            default:
                Debug.LogWarning("PlayerMovment.cs > Dont know how to hanlde mouse click for player movement");
                return;

        }
    }
 

    private void ProcessDirectMovement()
    {
       
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Calculate camera relative direction to move:
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 movement = v * cameraForward + h * Camera.main.transform.right;

        thirdPersonCharater.Move(movement, false, false);
        
    }

  
}

