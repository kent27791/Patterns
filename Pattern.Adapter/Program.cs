using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Adapter
{
    #region Create interfaces for Media Player and Advanced Media Player.
    public interface IMediaPlayer 
    {
        void play(string audioType, string filename);
    }
    public interface IAdvancedMediaPlayer 
    {
        void playVLC(string filename);
        void playMP4(string filename);
    }
    #endregion

    #region Create concrete classes implementing the AdvancedMediaPlayer interface.
    public class VLCPlayer : IAdvancedMediaPlayer 
    {
        public void playVLC(string filename)
        {
            Console.WriteLine("Playing vlc file. Name : {0}", filename);
        }

        public void playMP4(string filename)
        {
            //do nothing
        }
    }
    public class MP4Player : IAdvancedMediaPlayer 
    {

        public void playVLC(string filename)
        {
           //do nothing
        }

        public void playMP4(string filename)
        {
            Console.WriteLine("Playing mp4 file. Name : {0}", filename);
        }
    }
    #endregion

    #region Create adapter class implementing the MediaPlayer interface.
    public class MediaAdapter : IMediaPlayer 
    {
        IAdvancedMediaPlayer advancedMediaPlayer;
        public MediaAdapter(string audioType) 
        {
            if (audioType.Equals("VLC")) 
            {
                advancedMediaPlayer = new VLCPlayer();
            }
            else if (audioType.Equals("MP4")) 
            {
                advancedMediaPlayer = new MP4Player();
            }
        }

        public void play(string audioType, string filename)
        {
            if (audioType.Equals("VLC"))
            {
                advancedMediaPlayer.playVLC(filename);
            }
            else if (audioType.Equals("MP4"))
            {
                advancedMediaPlayer.playMP4(filename);
            }
        }
    }

    #endregion

    #region Create concrete class implementing the MediaPlayer interface.
    public class AudioPlayer : IMediaPlayer 
    {
        MediaAdapter mediaAdapter;
        public void play(string audioType, string filename)
        {
            if (audioType.Equals("MP3"))
            {
                Console.WriteLine("Playing mp3 file. Name : {0}", filename);
            }
            else if (audioType.Equals("VLC") || audioType.Equals("MP4"))
            {
                mediaAdapter = new MediaAdapter(audioType);
                mediaAdapter.play(audioType, filename);
            }
            else 
            {
                Console.WriteLine("Invalid media {0} format not supported.", audioType);
            }
        }
    }

    #endregion

    #region
    public class StopMotionPlayer : IMediaPlayer 
    {
        AudioPlayer audioPlayer;
        public void play(string audioType, string filename)
        {
            if (audioType.Equals("StopMotion")) 
            {
                Console.WriteLine("Playing stop motion file. Name : {0}", filename);
            }
            else if (audioType.Equals("VLC") || audioType.Equals("MP4") || audioType.Equals("MP3"))
            {
                audioPlayer = new AudioPlayer();
                audioPlayer.play(audioType, filename);
            }
            else 
            {
                Console.WriteLine("Invalid media {0} format not supported.", audioType);
            }
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            AudioPlayer audioPlayer = new AudioPlayer();

            audioPlayer.play("MP3", "far far away");

            audioPlayer.play("MP4", "alone at home");

            audioPlayer.play("AVI", "the spired away");

            Console.ReadKey();
        }
    }
}
