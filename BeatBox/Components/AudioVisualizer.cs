using System.Collections.Generic;
using UnityEngine;

namespace BeatBox.Components
{
    public class AudioVisualizer : MonoBehaviour
    {
        public AudioSource audioSource;
        public GameObject barPrefab;
        public float amplifier;
        public float original;
        public int sampleSize;
        public int channel;
        public FFTWindow fFTWindow;
        public float[] samples;

        List<RectTransform> children = new List<RectTransform>();

        void Start()
        {
            samples = new float[sampleSize];

            foreach (var _ in samples)
            {
                var bar = Instantiate(barPrefab);
                bar.transform.SetParent(transform);
                bar.SetActive(true);
                children.Add(bar.GetComponent<RectTransform>());
            }
        }

        void Update()
        {
            audioSource.GetSpectrumData(samples, channel, fFTWindow);

            for (int i = 0; i < sampleSize; i++)
            {
                var scale = children[i].localScale;
                scale.y = samples[i] * amplifier + original;
                children[i].localScale = scale;
            }

            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
