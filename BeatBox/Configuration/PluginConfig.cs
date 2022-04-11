using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using UnityEngine;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace BeatBox.Configuration
{
    internal class PluginConfig
    {
        public virtual float Amplifier { get; set; } = 27f;
        public virtual float Original { get; set; } = 1.5f;
        public virtual int SampleSize { get; set; } = 64;
        public virtual int Channel { get; set; } = 0;
        public virtual FFTWindow FFTWindow { get; set; } = FFTWindow.Rectangular;
    }
}