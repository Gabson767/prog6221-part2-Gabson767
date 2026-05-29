using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows;

namespace ChatBot
{
   public class Sound{
  
        public void PlaySound()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("C:\\Chatbot\\Part2\\ChatBot\\WAVfil.wav");
                player.PlaySync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured when we played the song " + ex.Message);
            }
        }


    }
}
