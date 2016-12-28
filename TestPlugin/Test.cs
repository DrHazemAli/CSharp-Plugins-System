using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluginsPlatform;
using System.Windows.Forms;
namespace TestPlugin
{
    /*
      # TEST PLUGIN ------------------------------
      # Copyright 2016 Dr. Hazem Ali
      # Facebook : https://www.facebook.com/Haz4m
      # License  : FREE.
      # DateTime : December 28, 2016
      # SHARING IS SEXY, KNOWLEDGE IS FOR EVERYONE, ENJOY =:)
    */
    public class TestPlugin : IPlugin
    {
        public void OnButtonClick()
        {
            MessageBox.Show(
                String.Format("Hello!, I'm the Plugin!\r\nPlugin Name : {0} v{1}\r\nDeveloped by : {2}\r\nThanks for installing me!",
                PluginName(), VersionString(), PluginPublisher()), "Plugin Message");
        }

        public void OnLoad()
        {
            MessageBox.Show("Hi, Thanks for Installing Me!");
        }

        public string PluginName()
        {
            return "Test";
        }

        public string PluginPublisher()
        {
            return "Hazem Ali";
        }

        public string VersionString()
        {
            return "1.0";
        }
    }
}
