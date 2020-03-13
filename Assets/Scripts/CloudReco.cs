using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CloudReco : MonoBehaviour, IObjectRecoEventHandler {

    public CloudRecoBehaviour cloudRecoBehaviour;
    private bool isScanning = false;
    private string mTargetData = "";
    
    public ImageTargetBehaviour ImageTargetTemplate;



    // Start is called before the first frame update
    void Start() {
        if (cloudRecoBehaviour) {
            cloudRecoBehaviour.RegisterEventHandler(this);
        }
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

    // Update is called once per frame
    void Update() {
        
    }


    public void OnInitError(TargetFinder.InitState initError) {

    }

    public void OnInitialized(TargetFinder targetFinder) {

    }

    public void OnNewSearchResult(TargetFinder.TargetSearchResult targetSearchResult) {
        TargetFinder.CloudRecoSearchResult cloudRecoSearchResult = (TargetFinder.CloudRecoSearchResult)targetSearchResult;
        mTargetData = cloudRecoSearchResult.MetaData;
        this.cloudRecoBehaviour.CloudRecoEnabled = false;

        if (this.ImageTargetTemplate) {
            ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
            tracker.GetTargetFinder<ImageTargetFinder>().EnableTracking(targetSearchResult, ImageTargetTemplate.gameObject);
        } else {

        }
    }

    public void OnStateChanged(bool scanning) {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        isScanning = scanning;
        var tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        tracker.GetTargetFinder<ImageTargetFinder>().ClearTrackables(false);
    }

    public void OnUpdateError(TargetFinder.UpdateState updateError) {

    }

    private void OnGUI() {

    }

    public void scanAgain() {
        this.cloudRecoBehaviour.CloudRecoEnabled = true;
    }
    
}
