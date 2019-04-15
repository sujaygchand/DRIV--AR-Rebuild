using UnityEngine;

/// <summary>
/// Class for the world cursor
/// </summary>
public class WorldCursor : MonoBehaviour
{
    private MeshRenderer meshRender;

    /// <summary>
    /// Initialisation
    /// </summary>
    void Start()
    {
        // Grabs the mesh renderer that is a child of this object
        meshRender = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    /// <summary>
    /// Called every frame
    /// </summary>
    void Update()
    {
        SearchForHologram();
    }

    /// <summary>
    /// Looks for Holograms
    /// </summary>
    void SearchForHologram()
    {
        // Does a raycast based on the users head position and forward orientation
        var gazePosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        // For Debugging
        //Debug.DrawRay(gazePosition, gazeDirection, Color.green);

        if (Physics.Raycast(gazePosition, gazeDirection, out hitInfo))
        {
            // Show cursor mesh when it hits a meshs
            meshRender.enabled = true;

            // Move cursor to where the raycasy hit
            this.transform.position = hitInfo.point;

            // Rotate the cursor to hug hologram surface
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
        else
        {
            // Hide cursor mesh
            meshRender.enabled = false;
        }
    }
}