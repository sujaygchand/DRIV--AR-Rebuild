using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScene : MonoBehaviour {

    public GameObject Player;
    public bool IsPlacing = false;

    private bool canBePlaced = false;

    private GameObject gameScene;

	// Use this for initialization
	void Start () {
        gameScene = GameObject.FindGameObjectWithTag("GameScene");
        canBePlaced = false;
	}
	
	// Update is called once per frame
	void Update () {
        // Check if the scene can be placed
        if (canBePlaced) {
            print("Can i place: " + canBePlaced);

            SpatialMapping.Instance.DrawVisualMeshes = true;

            // If yes get the camera poistion and direction
            var gazePosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;
            if (Physics.Raycast(gazePosition, gazeDirection, out hitInfo,
                30.0f, SpatialMapping.PhysicsRaycastMask)) {
                // Move the object to where the raycast hit the Spatial Mapping mesh.
                gameScene.transform.position = hitInfo.point;

                // locks scene y rotation to the camera rotation
                Quaternion sceneRotation = Camera.main.transform.rotation;
                sceneRotation.x = 0;
                sceneRotation.z = 0;

                // set the scene rotation to the cameras rotation
                gameScene.transform.rotation = sceneRotation;
            }
            else {

                // set the scene positon to a certain distance from player camera
                gameScene.transform.position = gazePosition + (gazeDirection * 2.5f);

            }
            if (IsPlacing) {
                Player.GetComponent<GestureAndGazeManager>().isPlacing = true;
            }
        }
        else {
            SpatialMapping.Instance.DrawVisualMeshes = false;
        }
    }

    /// <summary>
    /// Setter for canBePlaced
    /// </summary>
    /// <param name="canbePlaced"> Sets the value for canBePlaced </param>
    public void SetCanbePlaced(bool canbePlaced) {
        this.canBePlaced = canbePlaced;
        print("I am: " + this.canBePlaced);
        IsPlacing = true;
    }

    /// <summary>
    /// Getter for canBePlaced
    /// </summary>
    /// <returns> canBePlaced </returns>
    public bool GetCanbePlaced() {
        return this.canBePlaced;
    }
}
