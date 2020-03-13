using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BundleLoader : MonoBehaviour
{

    public string assetName;
    public string bundleName;
    // Start is called before the first frame update
    void Start()
    {
        //test();
    }

    private void test(){
        AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));
        if (localAssetBundle == null){
            Debug.LogError("Failed to load assetbundle");
            return;
        }

        GameObject asset = localAssetBundle.LoadAsset<GameObject>(assetName);
        Instantiate(asset);
        localAssetBundle.Unload(false);
    }
}
