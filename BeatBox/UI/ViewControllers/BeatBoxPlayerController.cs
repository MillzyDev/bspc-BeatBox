using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace BeatBox.UI.ViewControllers
{
    class BeatBoxPlayerController : MonoBehaviour
    {
        [UIObject("bars")]
        GameObject bars;

        [UIObject("duration")]
        GameObject duration;

        [UIObject("barPrefab")]
        GameObject barPrefab;

        [UIComponent("durationSlider")]
        SliderSetting durationSlider;

        [UIComponent("time")]
        TextMeshProUGUI time;

        [UIComponent("length")]
        TextMeshProUGUI length;

        [UIAction("#post-parse")]
        public void PostParse()
        {

        }
    }
}
