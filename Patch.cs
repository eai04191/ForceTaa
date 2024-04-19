using HarmonyLib;
using UnityEngine.Rendering.Universal;

namespace ForceTaa;

[HarmonyPatch]
[HarmonyPatch(
    typeof(UniversalAdditionalCameraData),
    nameof(UniversalAdditionalCameraData.antialiasing),
    MethodType.Setter
)]
public static class CameraSetPatch
{
    [HarmonyPostfix]
    static void Prefix(ref AntialiasingMode value)
    {
        ForceTaaPlugin.Log.LogMessage(
            "intercepted UnityEngine.Rendering.Universal.UniversalAdditionalCameraData antialiasing setter"
        );
        value = AntialiasingMode.TemporalAntiAliasing;
    }
}
