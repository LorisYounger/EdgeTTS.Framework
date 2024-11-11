# EdgeTTS.Framework

**24/11更新**: 支持[额外加密参数 Sec-MS-GEC](#额外加密参数) 并支持自动生成

---

Fork来自 https://github.com/Loskh/EdgeTTS.Net, 本Fork版本支持.Net Framework

![icon是我自己画的](README.assets/icon.png)

## 如何使用

```C#
var etts = new EdgeTTSClient();
var result = etts.SynthesisAsync("这是一个测试", "zh-CN-XiaoyiNeural").Result;
if (ms.Code != ResultCode.Success)
{
    Console.WriteLine("生成失败");
    return;
}
var path = "test.mp3";
FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
BinaryWriter w = new BinaryWriter(fs);
w.Write(result.Data.ToArray());
fs.Close();
w.Dispose();
fs.Dispose();
//Path 是生成的tts文件
```

## 额外加密参数

在之前的版本中,只能通过捕捉EdgeTTS来获取加密秘钥
后面经过[大佬破解了加密方法](https://github.com/rany2/edge-tts/issues/290#issuecomment-2464956570), 现在不需要额外的加密参数网址了 

之前版本更新的开发者删掉 `etts.Sec_MS_GEC_UpDate_Url = "***";`即可.
