using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;

public class QRCode : MonoBehaviour
{

    public Image qrcodeImage;
    // Start is called before the first frame update
    void Start()
    {
        string bolt11Invoice = "lnbc50u1pwsyhx9pp57ppqvzwex3qapu0wn63v06jzxqdtt46qypks4pnexwrr2ansz9msdqcgejhxctzd9kxjare23jhxap3cqzysxqy2ljqd47a9cdlnj84cy0a0zg7frd8jnera8fen2du6d2g500wzs7mpsmpqe0c3ddhrrxpehyhj4c9fwj3cfr5mvyxcyaaq98fw39jketl89cq0j9hy2";
        Texture2D tex = generateQR(bolt11Invoice);
        qrcodeImage.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

    }

    public Texture2D generateQR(string text)
    {
        var encoded = new Texture2D(256, 256);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }

    private static Color32[] Encode(string textForEncoding,
  int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
