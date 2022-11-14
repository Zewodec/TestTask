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

    /// <summary>
    /// When method called, id of background change and load the image.
    /// </summary>
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

    /// <summary>
    /// Set sprite to sprite renderer.
    /// </summary>
    private void setBackground()
    {
        Sprite backgroundLoaded = bundle.LoadAsset<Sprite>(bundle.GetAllAssetNames()[_backgroundIndex]);
        _spriteRenderer.sprite = backgroundLoaded;
        _spriteRenderer.gameObject.SetActive(false);
        _spriteRenderer.gameObject.SetActive(true);
    }

    private void LoadAndSetBackgrounds()
    {
        StartCoroutine(LoadBackground());
    }
    /// <summary>
    /// Load bundle from personal web server.
    /// Set first sprite to background.
    /// </summary>
    private IEnumerator LoadBackground()
    {
        string assetBundleName = "background";
        string uri = "http://muniverse.ga/AssetBundles/";
#if UNITY_STANDALONE
        uri += "StandaloneWindows/" + assetBundleName;
#elif UNITY_ANDROID
        uri += "Android/" + assetBundleName;
#elif UNITY_IOS
        uri += "Android/" + assetBundleName;
#endif
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri, 0);
        yield return request.SendWebRequest();
        bundle = DownloadHandlerAssetBundle.GetContent(request);
        Sprite backgroundLoaded = bundle.LoadAsset<Sprite>(bundle.GetAllAssetNames()[_backgroundIndex]);
        _spriteRenderer.sprite = backgroundLoaded;
    }
}