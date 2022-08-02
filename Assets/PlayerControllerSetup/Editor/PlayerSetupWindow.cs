using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerSetupWindow : EditorWindow
{
    public CameraFollow _cameraFollow;

    private MovementSystemChoice _selectedMovementSystem = MovementSystemChoice.Custom;
    // private bool _createFPSLook = true;
    // private bool _createCamera = true;

    [MenuItem("Window/Player Setup")]
    public static void ShowWindow()
    {
        GetWindow<PlayerSetupWindow>("Player Setup");
    }

    private void OnGUI()
    {
        EditorGUILayout.Space(10);
        GUILayout.Label("Select Movement System", EditorStyles.boldLabel);
        _selectedMovementSystem = (MovementSystemChoice)EditorGUILayout.EnumPopup("Movement Systems", _selectedMovementSystem);

        if (_selectedMovementSystem == MovementSystemChoice.FPS_Controller)
        {
            /*
            EditorGUILayout.Space(10);
            
            GUILayout.Label("Required features", EditorStyles.boldLabel);
            GUILayout.Label("All of these are required for the chosen movement system to properly work. \n" +
                "You can choose which ones you want to be automatically created, by default everything will be auto-generated. \n" +
                "Only deselect something if you are certain you will create yourself, or else the player controller may not function as desired.", EditorStyles.boldLabel);
            */

            //_createFPSLook = (bool)EditorGUILayout.Toggle("FPSLook Script", _createFPSLook);
            //_createCamera = (bool)EditorGUILayout.Toggle("Camera", _createCamera);
            // list all of the neccessary extra systems for the character controller to work.
            // iclude bool check boxes for designer to pick and chhose what features to auto generate, with all being default and recomendeda
        }
        if (_selectedMovementSystem == MovementSystemChoice.Ship_Controller)
        {
            // list all of the neccessary extra systems for the character controller to work.
            // iclude bool check boxes for designer to pick and chhose what features to auto generate, with all being default and recomended
        }
        if (_selectedMovementSystem == MovementSystemChoice.Point_And_Click_Controller)
        {
            // list all of the neccessary extra systems for the character controller to work.
            // iclude bool check boxes for designer to pick and chhose what features to auto generate, with all being default and recomended
        }

        EditorGUILayout.Space(20);

        if (GUILayout.Button("Setup"))
        {
            if (_selectedMovementSystem == MovementSystemChoice.FPS_Controller)
            {
                GameObject FPSControllerSetupObject = (GameObject)Resources.Load<GameObject>("FPS_SetupDefaults/---------FPSControllerDefaults---------");
                Instantiate(FPSControllerSetupObject);
                /*
                GameObject groundObject = (GameObject)Resources.Load<GameObject>("FPS_SetupDefaults/FPSGround");
                Instantiate(groundObject);
                GameObject playerObject = (GameObject)Resources.Load<GameObject>("FPS_SetupDefaults/FPSPlayer");
                Instantiate(playerObject);
                GameObject CrosshairCanvas = (GameObject)Resources.Load<GameObject>("FPS_SetupDefaults/FPSCanvas_Cursor");
                Instantiate(CrosshairCanvas);
                */
            }
            if (_selectedMovementSystem == MovementSystemChoice.Ship_Controller)
            {
                GameObject shipControllerSetupObject = (GameObject)Resources.Load<GameObject>("ShipController_SetupDefaults/---------ShipPlayerControllerDefaults---------");
                Instantiate(shipControllerSetupObject);

                /*
                GameObject cameraObject = (GameObject)Resources.Load<GameObject>("ShipController_SetupDefaults/ShipMainCamera");
                Instantiate(cameraObject);
                GameObject playerObject = (GameObject)Resources.Load<GameObject>("ShipController_SetupDefaults/ShipPlayer");
                Instantiate(playerObject);
                GameObject envObject = (GameObject)Resources.Load<GameObject>("ShipController_SetupDefaults/Ship_Environment");
                Instantiate(envObject);
                */
            }
            if (_selectedMovementSystem == MovementSystemChoice.Point_And_Click_Controller)
            {
                GameObject PACControllerSetupObject = (GameObject)Resources.Load<GameObject>("PAC_SetupDefaults/---------PointAndClickControllerDefaults---------");
                Instantiate(PACControllerSetupObject);
                /*
                GameObject cameraObject = (GameObject)Resources.Load<GameObject>("PAC_SetupDefaults/PAC_MainCamera");
                Instantiate(cameraObject);
                GameObject pointerObject = (GameObject)Resources.Load<GameObject>("PAC_SetupDefaults/PAC_Pointer");
                Instantiate(pointerObject);
                GameObject playerObject = (GameObject)Resources.Load<GameObject>("PAC_SetupDefaults/PAC_Player");
                Instantiate(playerObject);
                GameObject envObject = (GameObject)Resources.Load<GameObject>("PAC_SetupDefaults/PAC_Environment");
                Instantiate(envObject);
                */
            }
        }
    }
}
