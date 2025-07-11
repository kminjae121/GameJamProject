using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Monosingleton<AudioManager>
    {
        private Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
        [Header("오디오클립리스트")]
        [SerializeField] private List<AudioClip> clipList;
        [Space(10)]

        [Header("오디오믹서")]
        public AudioMixer audioMixer;

        [Space(10)]
        [Header("오디오프리팹")]
        [SerializeField] private GameObject sfxSourcePrefab;
        [SerializeField] private GameObject HitSourcePrefab;


        private List<AudioSource> sfxPool = new List<AudioSource>();
        private List<AudioSource> HitPool = new List<AudioSource>();

        [Space(10)]
        [Header("BGM소스")]
        [SerializeField] private AudioSource bgmSource;

        protected override void Awake()
        {
            base.Awake();
            clipList.ForEach(Clip => clips.Add(Clip.name, Clip));
        }
        /// <summary>
        /// BGM을 재생시키는 메서드
        /// </summary>
        /// <param name="clipName">클립이름</param>
        public void PlayBGM(string clipName)
        {
            AudioClip clip = clips.GetValueOrDefault(clipName);
            bgmSource.clip = clip;

            bgmSource.Play();
        }
        /// <summary>
        /// SFX(효과음)을 재생시키는 메서드
        /// </summary>
        /// <param name="clipName">클립이름</param>
        /// <param name="volume">볼륨</param>
        public void PlaySFX(string clipName, float volume = 1f)
        {
            AudioClip clip = clips.GetValueOrDefault(clipName);

            AudioSource source = GetAvailableSFXSource();
            source.spatialBlend = 0f;
            source.clip = clip;
            source.PlayOneShot(clip, volume);
        }

        /// <summary>
        /// 피격효과음을 재생시키는 메서드
        /// </summary>
        /// <param name="clipName">클립이름</param>
        /// <param name="volume">볼륨</param>
        public void PlayHitSFX(string clipName, float volume = 1f)
        {
            AudioClip clip = clips.GetValueOrDefault(clipName);
            if (clip == null) return;

            foreach (var src in HitPool)
            {
                if (src.isPlaying && src.clip == clip)
                    return;
            }

            AudioSource source = GetAvailableHitSource();

            source.spatialBlend = 0f;
            source.clip = clip;
            source.PlayOneShot(clip, volume);
        }

        /// <summary>
        /// 효과음을 재생시키는 프리팹을 생성시키는 메서드
        /// </summary>
        /// <returns></returns>
        private AudioSource GetAvailableSFXSource()
        {
            foreach (var src in sfxPool)
            {
                if (!src.isPlaying)
                    return src;
            }

            var obj = Instantiate(sfxSourcePrefab, transform);
            var newSrc = obj.GetComponent<AudioSource>();
            sfxPool.Add(newSrc);
            return newSrc;
        }
        /// <summary>
        /// 피격사운드를 재생시키는 프리팹을 생성시키는 메서드
        /// </summary>
        /// <returns></returns>
        private AudioSource GetAvailableHitSource()
        {
            foreach (var src in HitPool)
            {
                if (!src.isPlaying)
                    return src;
            }

            var obj = Instantiate(HitSourcePrefab, transform);
            var newSrc = obj.GetComponent<AudioSource>();
            HitPool.Add(newSrc);
            return newSrc;
        }

        /// <summary>
        /// BGM을 중단시키는 메서드
        /// </summary>
        public void StopBGM()
        {
            bgmSource.Stop();
        }
    }