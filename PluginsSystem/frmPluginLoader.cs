using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using PluginsPlatform;
namespace PluginsSystem
{
    /*
      # THE PLUGIN LOADER FORM ------------------------------
      # Copyright 2016 Dr. Hazem Ali
      # Facebook : https://www.facebook.com/Haz4m
      # License  : FREE.
      # DateTime : December 28, 2016
      # SHARING IS SEXY, KNOWLEGE IS FOR EVERYONE, ENJOY =:)
    */
    public partial class frmPluginLoader : Form
    {
        public frmPluginLoader()
        {
            InitializeComponent();
        }

        void InstallPlugin()
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Assembly.LoadFile(op.FileName);
                    string filePath = op.FileName;
                    string Filename = op.SafeFileName;
                    txtPath.Text = @filePath;
                    foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        foreach (Type t in a.GetTypes())
                        {
                            if (t.GetInterface("IPlugin") != null)
                            {
                                IPlugin p = Activator.CreateInstance(t) as IPlugin;
                                groupBox1.Enabled = true;
                                button1.Enabled = true;
                                // Get Plugin Details....
                                lblPluginName.Text = p.PluginName();
                                lblPluginPublisher.Text = p.PluginPublisher();
                                lblPluginVersion.Text = p.VersionString();

                                // Perform ( OnLoad(); ) Event When Plugin being Loaded.
                                p.OnLoad();

                            }
                        }
                    }
                }
            }
            catch { }


        }
        private void frmPluginLoader_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InstallPlugin();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type t in a.GetTypes())
                {
                    if (t.GetInterface("IPlugin") != null)
                    {
                        IPlugin p = Activator.CreateInstance(t) as IPlugin;
                        p.OnButtonClick();

                    }
                }
            }
        }
    }
}
