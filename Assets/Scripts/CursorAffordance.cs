using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffordance : MonoBehaviour 
{

    [SerializeField] Texture2D walkCursor = null; 
    [SerializeField] Texture2D enemyCursor = null;
    [SerializeField] Texture2D errorCursor = null;
    [SerializeField] Vector2 cursorHotspot = new Vector2(96, 96);


    CameraRaycaster cameraRaycaster;
	
	void Start () 
	{
        cameraRaycaster = FindObjectOfType<CameraRaycaster>();
	}
	
	void LateUpdate () 
	{
        
        switch (cameraRaycaster.layerHit)
        {
            case Layer.Walkable:
            {
                Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
            }break;

            case Layer.Enemy:
            {
                Cursor.SetCursor(enemyCursor, cursorHotspot, CursorMode.Auto);
            }break;

            case Layer.RaycastEndStop:
            {
                Cursor.SetCursor(errorCursor, cursorHotspot, CursorMode.Auto);
            }break;
            default:
            {
                    Debug.Log("Cursor does not know what it is looking at");
            }return;
        }
        

	}
}
