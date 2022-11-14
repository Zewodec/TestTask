using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class BackgroundLoader : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private int _backgroundIndex = 0;

    private AssetBundle bundle;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        LoadAndSetBackgrounds();
    }

    public void nextBackground()
    {
        if (_backgroundIndex == 4)
        {
            _backgroundIndex = 0;
            setBackground();
            return;
        }
        _backgroundIndex++;
        setBackground();
    }

    private void setBackground()
    {
        Sprite backgroundLoaded = bundle.LoadAsset<Sprite>(bundle.GetAllAssetNames()[_backgroundIndex]);
        _spriteRenderer.sprite = backgroundLoaded;
    }

    private void LoadAndSetBackgrounds()
    {
        StartCoroutine(LoadBackground());
    }

    IEnumerator LoadBackground()
    {
        string assetBundleName = "background";
        string uri = "http://muniverse.ga/AssetBundles/" + assetBundleName;
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri, 0);
        yield return request.SendWebRequest();
        bundle = DownloadHandlerAssetBundle.GetContent(request);
        Sprite backgroundLoaded = bundle.LoadAsset<Sprite>(bundle.GetAllAssetNames()[_backgroundIndex]);
        _spriteRenderer.sprite = backgroundLoaded;
    }
}
