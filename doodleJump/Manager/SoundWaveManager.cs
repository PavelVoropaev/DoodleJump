namespace doodleJump.Manager
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
            this.xAudio = new XAudio2();
            var mastering = new MasteringVoice(this.xAudio);
            mastering.SetVolume(0.1F);
            this.xAudio.StartEngine();
        }

        public void LoadWave(Stream stream, string key)
        {
            var buffer = GetBuffer(stream);
            this.waves.Add(new Wave { Buffer = buffer, Key = key });
        }

        public void PlayWave(string key)
        {
            var wave = this.waves.FirstOrDefault(x => x.Key == key);
            if (wave != null)
            {
                var voice = new SourceVoice(this.xAudio, wave.Buffer.WaveFormat, true);
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