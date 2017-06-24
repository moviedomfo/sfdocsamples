using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Client.servicereference1;
using System.Net;
using Client2;

namespace Client
{
    public partial class Form1 : Form
    {
        Fwk.Caching.FwkSimpleStorageBase<Cache> storage = new Fwk.Caching.FwkSimpleStorageBase<Cache>();
        public Form1()
        {
            InitializeComponent();
        }

      

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (SaveStorage())
                MessageBox.Show("Settings was successfully saved");
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            storage.Load();
            chkUseProxy.Checked = storage.StorageObject.UseProxy;
            txtUserProxy.Text = storage.StorageObject.ProxyUser;
            txtPwdProxy.Text = storage.StorageObject.ProxyPassword;
            cmbDomain.Text = storage.StorageObject.ProxyDomain;
            txtProxyAddress.Text = storage.StorageObject.ProxyAddress;

            txtUser.Text = storage.StorageObject.WCFUser;
            txtPwd.Text = storage.StorageObject.WCFPassword;
            txtDomain.Text = storage.StorageObject.WCFDomain;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            SaveStorage();
            base.OnClosing(e);
        }
        bool SaveStorage()
        {
            try
            {
                storage.StorageObject.UseProxy = chkUseProxy.Checked;
                storage.StorageObject.ProxyUser = txtUserProxy.Text;
                storage.StorageObject.ProxyPassword = txtPwdProxy.Text;
                storage.StorageObject.ProxyDomain = cmbDomain.Text;
                storage.StorageObject.ProxyAddress = txtProxyAddress.Text;

                storage.StorageObject.WCFUser = txtUser.Text;
                storage.StorageObject.WCFPassword = txtPwd.Text;
                storage.StorageObject.WCFDomain = txtDomain.Text;
                storage.Save();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
                return false;
            }
        }

        private void btnSaveSettings_Click_1(object sender, EventArgs e)
        {
            SaveStorage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            try
            {
                CoreSecurity clientProxy = new CoreSecurity();
                

                System.Net.NetworkCredential cr = new System.Net.NetworkCredential(txtUser.Text.Trim(), txtPwd.Text.Trim(), txtDomain.Text.Trim());

                if (chkUseProxy.Checked)
                {
                    WebProxy proxy = new WebProxy(storage.StorageObject.ProxyAddress, false);
                    proxy.Credentials = new NetworkCredential(storage.StorageObject.ProxyUser, storage.StorageObject.ProxyPassword, storage.StorageObject.ProxyDomain);
                    clientProxy.Proxy = proxy;
                    //WebRequest.DefaultWebProxy = proxy;
                }
                clientProxy.Credentials = cr;
                

                 
                string wGetDataResult = clientProxy.GetData(123,false);

                MessageBox.Show(wGetDataResult);
            }
            catch (Exception err)
            {

                textBox1.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(err);
            }
        }

    }
}
