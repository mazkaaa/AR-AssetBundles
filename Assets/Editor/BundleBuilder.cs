using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class BundleBuilder : Editor
{
    
    [MenuItem("Assets/Build AssetBundles")]
    private static void BuildAllAssetBundles(){
        string assetBundlesDirectory = "Assets/Prefabs/StreamingAssets";
        if (!Directory.Exists(Application.streamingAssetsPath)){
            Directory.CreateDirectory(assetBundlesDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundlesDirectory, BuildAssetBundleOptions.ChunkBasedCompression, EditorUserBuildSettings.activeBuildTarget);

    }
}
