# EdgeTTS.Framework

**24/11更新**: 支持[额外加密参数 Sec-MS-GEC](#额外加密参数)

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

目前中国大陆使用EdgeTTS需要额外参数, 参见  [issue: 403 error is back/need to implement Sec-MS-GEC token](https://github.com/rany2/edge-tts/issues/290)

### 如何使用

```C#
var etts = new EdgeTTSClient();
//需要额外添加 可以获得额外加密参数的网址
etts.Sec_MS_GEC_UpDate_Url = "http://123.207.46.66:8086/api/getGec";
//剩下的和前面一样
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
fs.Close();w.Dispose();fs.Dispose();
```

### 额外的加密参数网址 (Sec-MS-GEC)

目前只能通过抓包Edge来获得该参数, 而且每600秒过期. 有许多大佬制作了API免费给大家用, 谢谢他们.

[http://123.207.46.66:8086/api/getGec](https://github.com/rany2/edge-tts/issues/url)

by **[@learnin9](https://github.com/learnin9)**

https://edge-sec.myaitool.top/?key=edge

by **[@BG5T](https://github.com/BG5T)**
