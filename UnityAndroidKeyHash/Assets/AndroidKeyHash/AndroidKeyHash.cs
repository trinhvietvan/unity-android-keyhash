using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidKeyHash
{
    private static AndroidJavaClass pluginClass;
    private static AndroidJavaObject activity;

    public static string KeyHash()
    {
        string key = string.Empty;

        if (pluginClass == null || activity == null)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            pluginClass = new AndroidJavaClass("van.nzt.UnityAndroidKeyHash");
        }

        key = pluginClass.CallStatic<string>("GetKeyHash", activity);

        return key;
    }
}
