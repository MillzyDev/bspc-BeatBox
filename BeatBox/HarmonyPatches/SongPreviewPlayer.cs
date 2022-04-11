using BeatBox.UI.ViewControllers;
using BeatSaberMarkupLanguage;
using HarmonyLib;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace BeatBox.HarmonyPatches
{
    [HarmonyPatch(typeof(global::SongPreviewPlayer))]
    [HarmonyPatch("Start")]
    class SongPreviewPlayer
    {
        static AudioSource _audioSource;
        static GameObject _beatBoxCanvas = null;

        [HarmonyPostfix]
        public static void Postfix(global::SongPreviewPlayer __instance)
        {
            Plugin.Log.Debug("PostFix Executing");
            _audioSource = Resources.FindObjectsOfTypeAll<AudioSource>().Where(x => x.clip != null).First();

            if (_beatBoxCanvas == null)
                _beatBoxCanvas = CreateBeatBoxCanvas();
        }

        private static GameObject CreateBeatBoxCanvas()
        {
            GameObject go = new GameObject("BeatBoxCanvas");

            Canvas canvas = go.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;

            CanvasScaler scaler = go.AddComponent<CanvasScaler>();
            scaler.scaleFactor = 1f;
            scaler.dynamicPixelsPerUnit = 10f;

            GraphicRaycaster _ = go.AddComponent<GraphicRaycaster>();

            RectTransform rectTransform = go.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(120f, 60f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);

            rectTransform.position = new Vector3(0f, 0.7f, 1f);

            var controller = go.AddComponent<BeatBoxPlayerController>();
            BSMLParser.instance.Parse(Utilities.GetResourceContent(Assembly.GetExecutingAssembly(), "BeatBox.UI.Views.BeatBoxPlayer.bsml"), go, controller);

            return go;
        }
    }
}