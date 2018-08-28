﻿using Loamen.WinControls.UI;
using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Kalman.Studio
{
    public partial class StartForm : DockContent
    {
        #region Init
        string url = Config.HOME_PAGE + "/mini/";

        public StartForm()
        {
            try
            {
                InitializeComponent();
                DockHandler.CloseButton = false;
                DockHandler.CloseButtonVisible = false;
                wbStatistics.Visible = false;
                wbStatistics.ScriptErrorsSuppressed = true;
                wbStatistics.ProxyServer = "";
                wbStatistics.IsWebBrowserContextMenuEnabled = false;

                if (url.Contains("?"))
                {
                    url = url + "&n=" + Application.ProductName + "&v=" + Application.ProductVersion;
                }
                else
                {
                    url = url + "?n=" + Application.ProductName + "&v=" + Application.ProductVersion;
                }

                wbStatistics.Navigate(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region 界面操作

        private void wbStatistics_NavigateError(object sender, WebBrowserNavigateErrorEventArgs e)
        {
            int code = e.StatusCode;
            //wbStatistics.DocumentText = Config.GetErrorHtml(code);
        }

        #endregion

        private void wbStatistics_BeforeNewWindow(object sender, EventArgs e)
        {
            var eventArgs = e as WebBrowserExtendedNavigatingEventArgs;
            Help.ShowHelp(this,eventArgs.Url);
            eventArgs.Cancel = true;
        }

        private void wbStatistics_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            wbStatistics.Visible = true;
        }

    }
}