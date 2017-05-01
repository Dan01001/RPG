using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraRaycaster))]

public class CursorAffordance : MonoBehaviour 
{

    [SerializeField] Texture2D walkCursor = null; 
    [SerializeField] Texture2D enemyCursor = null;
    [SerializeField] Texture2D errorCursor = null;
    [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);
    [SerializeField] const int walkableLayerNumber = 8;
    [SerializeField] const int enemyLayerNumber = 9;

    CameraRaycaster cameraRaycaster;
	
	void Start () 
	{
        cameraRaycaster = FindObjectOfType<CameraRaycaster>();
        cameraRaycaster.notifyLayerChangeObservers += OnLayerChange; // registering onlayerChange function
	}
	
	void OnLayerChange(int layer) 
	{
                
        switch (layer)
        {
            case walkableLayerNumber:
            {
                Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
            }break;

            case enemyLayerNumber:
            {
                Cursor.SetCursor(enemyCursor, cursorHotspot, CursorMode.Auto);
            }break;

            default:
            {
                Cursor.SetCursor(errorCursor, cursorHotspot, CursorMode.Auto);
            }
                return;
        }
        

	}
}
