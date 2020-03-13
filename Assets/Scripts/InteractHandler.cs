using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class InteractHandler : MonoBehaviour {

    [SerializeField] private GameObject spawnPoint;
    private GameObject spawnedObject;
    [SerializeField] private ObjectHandler[] _objectHandler;

    [SerializeField] private GameObject objectView;

    [SerializeField] private TMP_Text objectNameText, objectDescText, objectAgeText;
    [SerializeField] private TextMesh objectNameTM, objectDescTM, objectAgeTM;


    [SerializeField] private string assetName;
    [SerializeField] private string bundleName;

    [SerializeField] private string bundleUrl;
    [SerializeField] private string assetWebName;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("loadFromBundleWeb");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getRandomObject() {
        //loadFromBundle();
        
        int indexRand = 0;
        //indexRand = UnityEngine.Random.Range(-1, 3);
        /*objectNameText.text = _objectHandler[indexRand].ObjectName;
        objectDescText.text = _objectHandler[indexRand].ObjectDescription;
        objectAgeText.text = _objectHandler[indexRand].ObjectAge.ToString();*/
        
        objectNameTM.text = _objectHandler[indexRand].ObjectName;
        objectDescTM.text = _objectHandler[indexRand].ObjectDescription;
        objectAgeTM.text = _objectHandler[indexRand].ObjectAge.ToString();
        
        //objectView.GetComponent<Renderer>().material = _objectHandler[indexRand].ObjectMaterial;
        //spawnedObject.GetComponent<Renderer>().material = _objectHandler[indexRand].ObjectMaterial;


    }

    /*private void loadFromBundle(){
        AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));
        if (localAssetBundle == null){
            objectNameTM.text = "cannot load assetbunde";
        }
        GameObject asset = localAssetBundle.LoadAsset<GameObject>(assetName);
        objectView = asset;
        localAssetBundle.Unload(false);

    }*/

    private IEnumerator loadFromBundleWeb(){
        using (WWW web = new WWW(bundleUrl)){
            yield return web;
            AssetBundle remoteAssetBundle = web.assetBundle;
            if (remoteAssetBundle == null){
                objectNameTM.text = "cannot load web assetbundle";
                yield break;
            }
            spawnedObject = (GameObject) Instantiate(remoteAssetBundle.LoadAsset(assetWebName), spawnPoint.transform.position, spawnPoint.transform.rotation);
            Debug.Log("success spawn object");
            spawnedObject.transform.parent = spawnPoint.transform;
            //spawnedObject.transform.position = spawnPoint.transform.position;
            remoteAssetBundle.Unload(false);
        }
    }
    
}
