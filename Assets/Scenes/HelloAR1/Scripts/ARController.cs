using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

#if UNITY_EDITOR
using input= GoogleARCore.InstantPreviewInput;
#endif
public class ARController : MonoBehaviour
{
    //We will fill this list with planes that ARCore deteced in the current frame
    private List<DetectedPlane> m_newTrackedPlanes = new List<DetectedPlane>();
    public GameObject GridPrefab;
    public GameObject Portal;
    public GameObject ARCamera;
    void Start()
    {

    }

    void Update()
    {   //Check ARCore session status
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }
        //The following function will fill m_newTrackedPlanes with the planes that ARcore detected in the current frame
        Session.GetTrackables<DetectedPlane>(m_newTrackedPlanes, TrackableQueryFilter.New);
        
        for (int i = 0; i < m_newTrackedPlanes.Count; ++i)
        {
            GameObject grid = Instantiate(GridPrefab, Vector3.zero, Quaternion.identity, transform);
            //this function will set the positon of grid and modify the verices of attached mesh
            grid.GetComponent<GridVisulaizer>().Initialize(m_newTrackedPlanes[i]);
        }
        //check if uses touches the screen
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }
        TrackableHit hit;
        if (Frame.Raycast(touch.position.x, touch.position.y, TrackableHitFlags.PlaneWithinPolygon, out hit))
        {
            //lets now place the portal on top of the tracked plane that we touche
            // enable portal
            Portal.SetActive(true);
            // create a new anchor
            Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);
            Portal.transform.position = hit.Pose.position;
            Portal.transform.rotation= hit.Pose.rotation;
            
            Vector3 cameraposition =ARCamera.transform.position;

            cameraposition.y = hit.Pose.position.y;
            Portal.transform.LookAt(cameraposition,Portal.transform.up);
            Portal.transform.parent =anchor.transform;
        }

    }
}
