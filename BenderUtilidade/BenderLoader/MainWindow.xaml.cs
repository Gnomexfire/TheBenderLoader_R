//-----------------------------------------------------------------------
// <copyright file="MainWindow.cs" company="OSE Solution Inc.">
//     Copyright (c) OSE Solution Inc.  All rights reserved.
// </copyright>
// <summary>Contains the MainWindow class.</summary>
//-----------------------------------------------------------------------
        
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using BenderLoader.Class;
using BenderLoader.View;
using MahApps.Metro;
using MahApps.Metro.Controls;

namespace BenderLoader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        #region Declare
        public readonly BackgroundWorker InicializarCore = new BackgroundWorker();
        public readonly BackgroundWorker Traduzir = new BackgroundWorker();
        public readonly DispatcherTimer DispatcherTimer = new DispatcherTimer();
        private Mutex _mutex;
        public static string DefaultLanguage { get; set; }

        public static MeCore Core = new MeCore();
        /// <summary>
        /// MeCore
        /// </summary>
        public struct MeCore
        {
            /*  Habilitado 
             *  Versao Core
             *  Versao Jogo
             *  Versao Jogo em MD5
             *  About
             *  Suporte
             *  DownloadNewFile
             *  Data Compilado
            */
        }


        

        #endregion

        

        public MainWindow()
        {
            InitializeComponent();

            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Teal"),
                                        ThemeManager.GetAppTheme("BaseLight"));
            
        }
        
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            #region Mutex
            var m = false;
            _mutex = new Mutex(false,Application.Current.MainWindow.Title, out m);
            if (!m) { Application.Current.Shutdown();}
            #endregion
            
            Helper.LoadConfigFile();
            LoadCore();

            LoadTranslate();

        }
        public static MeTranslate XTranslate = new MeTranslate();
        public struct MeTranslate
        {
            public string TNovaNoticia { get; set; }
            public string TSuporte { get; set; }
            public string TDonate { get; set; }
            public string TConfig { get; set; }

            public string LblSelIdioma { get; set; }
            public string ChkMinInject { get; set; }
            public string ChkNotInject { get; set; }
            public string CmdConfirmar { get; set; }
            public string TUpdateManual { get; set; }

            public string LblStatusFerramenta { get; set; }
            public string LblCoreVersion { get; set; }
            public string LblCompilado { get; set; }
            public string LblVersaoDisponivel { get; set; }
            public string LblEstadoJogo { get; set; }

        }
        private void LoadTranslate()
        {
            switch (DefaultLanguage)
            {
                case "pt":
                    XTranslate.TNovaNoticia = FindResource("PtTNovaNoticia").ToString();
                    XTranslate.TSuporte = FindResource("PtTSuporte").ToString();
                    XTranslate.TDonate = FindResource("PtTDonate").ToString();
                    XTranslate.TConfig = FindResource("PtTConfig").ToString();

                    XTranslate.LblSelIdioma = FindResource("PtLblSelIdioma").ToString();
                    XTranslate.ChkMinInject = FindResource("PtChkMinInject").ToString();
                    XTranslate.ChkNotInject = FindResource("PtChkNotInject").ToString();
                    XTranslate.CmdConfirmar = FindResource("PtCmdConfirmar").ToString();
                    XTranslate.TUpdateManual = FindResource("PtTUpdateManual").ToString();

                    XTranslate.LblStatusFerramenta = FindResource("PtLblStatusFerramenta").ToString();
                    XTranslate.LblCoreVersion = FindResource("PtLblCoreVersion").ToString();
                    XTranslate.LblCompilado = FindResource("PtLblCompilado").ToString();
                    XTranslate.LblVersaoDisponivel = FindResource("PtLblVersaoDisponivel").ToString();
                    XTranslate.LblEstadoJogo = FindResource("PtLblEstadoJogo").ToString();
                    break;

                case "en":
                    XTranslate.TNovaNoticia = FindResource("EnTNovaNoticia").ToString();
                    XTranslate.TSuporte = FindResource("EnTSuporte").ToString();
                    XTranslate.TDonate = FindResource("EnTDonate").ToString();
                    XTranslate.TConfig = FindResource("EnTConfig").ToString();

                    XTranslate.LblSelIdioma = FindResource("EnLblSelIdioma").ToString();
                    XTranslate.ChkMinInject = FindResource("EnChkMinInject").ToString();
                    XTranslate.ChkNotInject = FindResource("EnChkNotInject").ToString();
                    XTranslate.CmdConfirmar = FindResource("EnCmdConfirmar").ToString();
                    XTranslate.TUpdateManual = FindResource("EnTUpdateManual").ToString();

                    XTranslate.LblStatusFerramenta = FindResource("EnLblStatusFerramenta").ToString();
                    XTranslate.LblCoreVersion = FindResource("EnLblCoreVersion").ToString();
                    XTranslate.LblCompilado = FindResource("EnLblCompilado").ToString();
                    XTranslate.LblVersaoDisponivel = FindResource("EnLblVersaoDisponivel").ToString();
                    XTranslate.LblEstadoJogo = FindResource("EnLblEstadoJogo").ToString();
                    break;


                case "fr":
                    XTranslate.TNovaNoticia = FindResource("frTNovaNoticia").ToString();
                    XTranslate.TSuporte = FindResource("frTSuporte").ToString();
                    XTranslate.TDonate = FindResource("frTDonate").ToString();
                    XTranslate.TConfig = FindResource("frTConfig").ToString();

                    XTranslate.LblSelIdioma = FindResource("frLblSelIdioma").ToString();
                    XTranslate.ChkMinInject = FindResource("frChkMinInject").ToString();
                    XTranslate.ChkNotInject = FindResource("frChkNotInject").ToString();
                    XTranslate.CmdConfirmar = FindResource("frCmdConfirmar").ToString();
                    XTranslate.TUpdateManual = FindResource("frTUpdateManual").ToString();

                    XTranslate.LblStatusFerramenta = FindResource("frLblStatusFerramenta").ToString();
                    XTranslate.LblCoreVersion = FindResource("frLblCoreVersion").ToString();
                    XTranslate.LblCompilado = FindResource("frLblCompilado").ToString();
                    XTranslate.LblVersaoDisponivel = FindResource("frLblVersaoDisponivel").ToString();
                    XTranslate.LblEstadoJogo = FindResource("frLblEstadoJogo").ToString();
                    break;


                case "ko":
                    XTranslate.TNovaNoticia = FindResource("KoTNovaNoticia").ToString();
                    XTranslate.TSuporte = FindResource("KoTSuporte").ToString();
                    XTranslate.TDonate = FindResource("KoTDonate").ToString();
                    XTranslate.TConfig = FindResource("KoTConfig").ToString();

                    XTranslate.LblSelIdioma = FindResource("KoLblSelIdioma").ToString();
                    XTranslate.ChkMinInject = FindResource("KoChkMinInject").ToString();
                    XTranslate.ChkNotInject = FindResource("KoChkNotInject").ToString();
                    XTranslate.CmdConfirmar = FindResource("KoCmdConfirmar").ToString();
                    XTranslate.TUpdateManual = FindResource("KoTUpdateManual").ToString();

                    XTranslate.LblStatusFerramenta = FindResource("KoLblStatusFerramenta").ToString();
                    XTranslate.LblCoreVersion = FindResource("KoLblCoreVersion").ToString();
                    XTranslate.LblCompilado = FindResource("KoLblCompilado").ToString();
                    XTranslate.LblVersaoDisponivel = FindResource("KoLblVersaoDisponivel").ToString();
                    XTranslate.LblEstadoJogo = FindResource("KoLblEstadoJogo").ToString();
                    break;
            }
            TNovaNoticia.Text = XTranslate.TNovaNoticia;
            TSuporte.Text = XTranslate.TSuporte;
            TDonate.Text = XTranslate.TDonate;
            TConfig.Text = XTranslate.TConfig;
            LblStatusFerramenta.Content = XTranslate.LblStatusFerramenta;
            LblCoreVersion.Content = XTranslate.LblCoreVersion;
            LblCompilado.Content = XTranslate.LblCompilado;
            LblVersaoDisponivel.Content = XTranslate.LblVersaoDisponivel;
            LblEstadoJogo.Content = XTranslate.LblEstadoJogo;
        }

        private void CmdConfig_OnClick(object sender, RoutedEventArgs e)
        {
            var frmConfig = new Config()
            {
                Title = Title
            };
           
            frmConfig.ShowDialog();
            LoadTranslate();

        }
        
        protected virtual void LoadCore()
        {
            // Update | Title
            Title = @"Bender.Loader.Dev";
        }

    }
}
