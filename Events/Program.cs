using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Events
{
 public class Program
    {
        static void Main(string[] args)
        {
            var video = new Video { Title = "Video1" };
            var videoEncoder = new VideoEncoder();
            var mailService = new MailService();

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;

            videoEncoder.Encode(video);

           

        }
    }
 public  class Video
    {

        public string Title { get; set; }
        
    }
   public class VideoEncoder
    {
        public delegate void VideoEncodedEventHandler();

        public event VideoEncodedEventHandler VideoEncoded;

        public void Encode(Video vid)
        {
            Console.WriteLine("Encoding Video");
            Thread.Sleep(3000);
            OnVideoEncoded();
        }
        protected virtual void OnVideoEncoded()
        {
            if (VideoEncoded != null)
                VideoEncoded();
        }
    }
    public class MailService
    {
        public void OnVideoEncoded()
        {
            Console.WriteLine("MailService: Sending an email");
        }
    }



}
