namespace doodleJump
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using SharpDX.Multimedia;
    using SharpDX.XAudio2;

    public class WaveManager
    {
        private readonly XAudio2 xAudio;
        private readonly List<Wave> waves = new List<Wave>();

        public WaveManager()
        {
            xAudio = new XAudio2();
            var mastering = new MasteringVoice(xAudio);
            mastering.SetVolume(0.1F);
            xAudio.StartEngine();
        }

        public void LoadWave(Stream stream, string key)
        {
            var buffer = GetBuffer(stream);
            waves.Add(new Wave { Buffer = buffer, Key = key });
        }

        public void PlayWave(string key)
        {
            var wave = waves.FirstOrDefault(x => x.Key == key);
            if (wave != null)
            {
                var voice = new SourceVoice(xAudio, wave.Buffer.WaveFormat, true);
                voice.SubmitSourceBuffer(wave.Buffer, wave.Buffer.DecodedPacketsInfo);
                voice.Start();
            }
        }

        private static AudioBufferAndMetaData GetBuffer(Stream soundStream)
        {
            var soundstream = new SoundStream(soundStream);
            var buffer = new AudioBufferAndMetaData
            {
                Stream = soundstream.ToDataStream(),
                AudioBytes = (int)soundstream.Length,
                Flags = BufferFlags.EndOfStream,
                WaveFormat = soundstream.Format,
                DecodedPacketsInfo = soundstream.DecodedPacketsInfo
            };
            return buffer;
        }

        private sealed class AudioBufferAndMetaData : AudioBuffer
        {
            public WaveFormat WaveFormat { get; set; }

            public uint[] DecodedPacketsInfo { get; set; }
        }

        private sealed class Wave
        {
            public AudioBufferAndMetaData Buffer { get; set; }

            public string Key { get; set; }
        }
    }
}