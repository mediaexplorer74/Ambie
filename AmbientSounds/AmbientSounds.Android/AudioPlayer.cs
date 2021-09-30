using AmbientSounds.Native;
using Android.Media;
using Android.Content.Res;
using Xamarin.Forms;

[assembly: Dependency(typeof(IAudioPlayer))]
namespace AmbientSounds.Droid
{
    public class MIAudioPlayer : IAudioPlayer
    {
        private MediaPlayer _player;

        public MIAudioPlayer()
        {
        }

        /*
        public void PlayAudioFile(string fileName)
        {
            var player = new MediaPlayer();
            var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
            player.Prepared += (s, e) =>
            {
                player.Start();
            };
            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();
        }
        */

        public bool IsLoopingEnabled
        {
            get => _player.Looping;//.IsLoopingEnabled;
            set
            {
                if (_player is null)
                {
                    return;
                }

                // negative number represents infinite loops.
                // ref: https://stackoverflow.com/a/6804267
                //_player.NumberOfLoops = value ? -1 : 0;
                _player.Looping = true;//IsLoopingEnabled = true;
            }
        }

        public bool SystemIntegratedControlsEnabled { get; set; }

        public double Volume
        {
            get => 3;//_player?.Volume ?? 0d;
            set
            {
                if (_player != null)
                {
                    _player.SetVolume(3, 3); //= (float)value;
                }
            }
        }

        public void Dispose()
        {
            _player?.Dispose();
            _player = null;
        }

        public void Pause()
        {
            _player?.Pause();
        }

        public void Play()
        {
            _player?.Start();//.Play();
        }

        public void SetSource(object source)
        {
            if (source is string fileName)
            {
                //    _player = _player.SetSource(NSUrl.FromString(fileName));//AVAudioPlayer.FromUrl(NSUrl.FromString(fileName));

                //var player = new MediaPlayer();
                /*
                var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
                _player.Prepared += (s, e) =>
                {
                    _player.Start(); // ?
                };
                _player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
                _player.Prepare();
                */

            }
        }
    }
}

/*
[assembly: Dependency(typeof(IAudioPlayer))]
namespace AmbientSounds.Droid
{
    public class AudioPlayer : IAudioPlayer
    {
        private AVAudioPlayer _player;

        public AudioPlayer()
        {
        }

        public bool IsLoopingEnabled
        {
            get => !(_player?.NumberOfLoops is null) && _player.NumberOfLoops < 0;
            set
            {
                if (_player is null)
                {
                    return;
                }

                // negative number represents infinite loops.
                // ref: https://stackoverflow.com/a/6804267
                _player.NumberOfLoops = value ? -1 : 0;
            }
        }

        public bool SystemIntegratedControlsEnabled { get; set; }

        public double Volume
        {
            get => _player?.Volume ?? 0d;
            set
            {
                if (_player != null)
                {
                    _player.Volume = (float)value;
                }
            }
        }

        public void Dispose()
        {
            _player?.Dispose();
            _player = null;
        }

        public void Pause()
        {
            _player?.Pause();
        }

        public void Play()
        {
            _player?.Play();
        }

        public void SetSource(object source)
        {
            if (source is string s)
            {
                _player = AVAudioPlayer.FromUrl(NSUrl.FromString(s));
            }
        }
    }
}
*/