using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginsPlatform
{
    /*
      # THE PLATFORM FOR THE PLUGINS, THIS DLL MUST BE ADDED TO EACH PLUGIN AS REFERENCE.
      # Copyright 2016 Dr. Hazem Ali
      # Facebook : https://www.facebook.com/Haz4m
      # License  : FREE.
      # DateTime : December 28, 2016
      # SHARING IS SEXY, KNOWLEGE IS FOR EVERYONE, ENJOY =:)
    */
    public interface IPlugin
    {
        String PluginName();
        String VersionString();
        String PluginPublisher();

        void OnLoad();
        void OnButtonClick();

    }
}
