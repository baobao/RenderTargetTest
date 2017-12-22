using UnityEngine;
using UnityEngine.UI;

public class RenderTargetTest : MonoBehaviour
{
    [SerializeField]
    RawImage _rawImage;
    bool _isRenderTargetNull;
    bool _isOutputDisplay;
    [SerializeField]
    Text _textIsRenderTargetNull;
    [SerializeField]
    Text _textIsOutputDisplay;
    [SerializeField]
    Button _btnSetTargetBuffers;

    RenderTexture _rt1;
    Camera _cam;
    Material _mat;

    #region Unity Method

    void Start ()
    {
        _cam = GetComponent<Camera> ();
        _rt1 = new RenderTexture (600, 300, 24, RenderTextureFormat.ARGB32);
        _rt1.Create ();

        // RenderTextureに初期カラーをセット
        var tex = new Texture2D (1, 1, TextureFormat.RGB24, false, false);
        tex.SetPixel (1, 1, Color.red);
        tex.Apply ();
        Graphics.Blit (tex, _rt1);

        _rawImage.texture = _rt1;
        _textIsRenderTargetNull.text = "isRenderTargetNull is : " + _isRenderTargetNull;
        _textIsOutputDisplay.text = "isOutputDisplay is : " + _isOutputDisplay;
    }

    void OnPostRender ()
    {
        if (_mat == null) {
            _mat = new Material (Shader.Find ("Hidden/RenderTargetTest"));
            _mat.hideFlags = HideFlags.DontSave;
        }
        if (_isRenderTargetNull)
            Graphics.SetRenderTarget (null);

        if (_isOutputDisplay)
            Graphics.Blit (_rt1, _mat);
    }

    #endregion

    public void SetTargetBuffers ()
    {
        Debug.Log ("SetTargetBuffers");
        _cam.SetTargetBuffers (_rt1.colorBuffer, _rt1.depthBuffer);
        _btnSetTargetBuffers.interactable = false;
    }

    public void ChangeRenderTarget ()
    {
        Debug.Log ("ChangeRenderTarget");
        _isRenderTargetNull = !_isRenderTargetNull;
        _textIsRenderTargetNull.text = "isRenderTarget is null : " + _isRenderTargetNull;
    }

    public void ChangeOutputDisplay ()
    {
        Debug.Log ("ChangeOutputDisplay");
        _isOutputDisplay = !_isOutputDisplay;
        _textIsOutputDisplay.text = "isOutputDisplay is : " + _isOutputDisplay;
    }
}