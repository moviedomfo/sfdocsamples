using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Client2.ServiceReference1;
using System.Net;
using System.ServiceModel;


namespace Client2
{
    public partial class Form1 : Form
    {
        Fwk.Caching.FwkSimpleStorageBase<Cache> storage = new Fwk.Caching.FwkSimpleStorageBase<Cache>();
        //   string usr = "administrador";

        //No importa el dominio cuando el  iis no esta agragada a ningun dominio
        string domain = "192.168.1.116";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            CoreSecurityClient clientProxy = new ServiceReference1.CoreSecurityClient("ws");
            try
            {


                //clientProxy.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.None;
                // clientProxy.ChannelFactory.Credentials.Windows.ClientCredential.UserName = usr;
                //clientProxy.ChannelFactory.Credentials.Windows.ClientCredential.Password = pwd;
                ////clientProxy.ChannelFactory.Credentials.Windows.ClientCredential.Domain = domain;

                //clientProxy.ClientCredentials.UserName.UserName = usr;
                //clientProxy.ClientCredentials.UserName.Password = pwd;

                clientProxy.ClientCredentials.Windows.ClientCredential.UserName = txtUser.Text.Trim();
                clientProxy.ClientCredentials.Windows.ClientCredential.Password = txtPwd.Text.Trim();
                clientProxy.ClientCredentials.Windows.ClientCredential.Domain = txtDomain.Text.Trim();
                if (chkUseProxy.Checked)
                {
                    WebProxy proxy = new WebProxy(storage.StorageObject.ProxyAddress, false);
                    proxy.Credentials = new NetworkCredential(storage.StorageObject.ProxyUser, storage.StorageObject.ProxyPassword, storage.StorageObject.ProxyDomain);
                    WebRequest.DefaultWebProxy = proxy;
                }




                string wGetDataResult = clientProxy.GetData(123);
                clientProxy.Close();
                MessageBox.Show(wGetDataResult);
            }
            catch (FaultException fx)
            {
                textBox1.Text = "FaultException\r\n" + Fwk.Exceptions.ExceptionHelper.GetAllMessageException(fx);
                clientProxy.Abort();

            }
            catch (Exception err)
            {

                textBox1.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(err);
                clientProxy.Abort();
            }
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

        private void Form1_Leave(object sender, EventArgs e)
        {

            SaveStorage();
        }

        private void chkUseProxy_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = chkUseProxy.Checked;

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

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (SaveStorage())
                MessageBox.Show("Settings was successfully saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string wGetDataResult = string.Empty;
            textBox1.Text = string.Empty;
            CoreSecurityClient clientProxy = new ServiceReference1.CoreSecurityClient("ws");
            try
            {


                clientProxy.ClientCredentials.Windows.ClientCredential.UserName = txtUser.Text.Trim();
                clientProxy.ClientCredentials.Windows.ClientCredential.Password = txtPwd.Text.Trim();
                clientProxy.ClientCredentials.Windows.ClientCredential.Domain = txtDomain.Text.Trim();
                if (chkUseProxy.Checked)
                {
                    WebProxy proxy = new WebProxy(storage.StorageObject.ProxyAddress, false);
                    proxy.Credentials = new NetworkCredential(storage.StorageObject.ProxyUser, storage.StorageObject.ProxyPassword, storage.StorageObject.ProxyDomain);
                    WebRequest.DefaultWebProxy = proxy;
                }
                wGetDataResult = clientProxy.GetData(1);

                MessageBox.Show(wGetDataResult);
            }
            //No cierra el canal
            catch (FaultException<WCFServiceError> fx)
            {
                textBox1.Text = "FaultException\r\n" + Fwk.Exceptions.ExceptionHelper.GetAllMessageException(fx);
                //puedo hacer Abort si lo deceo o bien puedo continuar utilizando el proxy
                clientProxy.Abort();
            }
            //Cierra el canal
            catch (Exception err)
            {

                textBox1.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(err);
                clientProxy.Abort();
            }

            wGetDataResult = clientProxy.GetData(111111);

            MessageBox.Show(wGetDataResult);
        }

        private void btnConcurrency_Click(object sender, EventArgs e)
        {
            string wGetDataResult = string.Empty;
            textBox1.Text = string.Empty;
            CoreSecurityClient clientProxy = new ServiceReference1.CoreSecurityClient("ws");
            try
            {


                clientProxy.ClientCredentials.Windows.ClientCredential.UserName = txtUser.Text.Trim();
                clientProxy.ClientCredentials.Windows.ClientCredential.Password = txtPwd.Text.Trim();
                clientProxy.ClientCredentials.Windows.ClientCredential.Domain = txtDomain.Text.Trim();
                if (chkUseProxy.Checked)
                {
                    WebProxy proxy = new WebProxy(storage.StorageObject.ProxyAddress, false);
                    proxy.Credentials = new NetworkCredential(storage.StorageObject.ProxyUser, storage.StorageObject.ProxyPassword, storage.StorageObject.ProxyDomain);
                    WebRequest.DefaultWebProxy = proxy;
                }
                wGetDataResult = clientProxy.GetData(Convert.ToInt32(txtInput.Text));

                MessageBox.Show(wGetDataResult);
            }
            //No cierra el canal
            catch (FaultException<WCFServiceError> fx)
            {
                textBox1.Text = "FaultException\r\n" + Fwk.Exceptions.ExceptionHelper.GetAllMessageException(fx);
                //puedo hacer Abort si lo deceo o bien puedo continuar utilizando el proxy
                clientProxy.Abort();
            }
            //Cierra el canal
            catch (Exception err)
            {

                textBox1.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(err);
                clientProxy.Abort();
            }
        }
    }
}
