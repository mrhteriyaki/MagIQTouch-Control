using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using MQTTnet.Client.Receiving;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;

using AWSMQTT;
using SeeleyControl;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aircon_Control_Windows
{
    public partial class Form1 : Form
    {
        AWS_MQTT AMClient = new AWS_MQTT();
        SCData UnitConfig = new SCData();
        string URI = "";
        string SYSTEM_MAC = "";


        public Form1()
        {
            InitializeComponent();
        }        

      

        private void Form1_Load(object sender, EventArgs e)
        {

            AMClient.AWS_IOT_GATEWAY = "ab7hzia9uew8g-ats.iot.ap-southeast-2.amazonaws.com";
            AMClient.AWS_USER_POOL_ID = "ap-southeast-2_uw5VVNlib";
            AMClient.AWS_CLIENT_ID = "6e1lu9fchv82uefiarsp0290v9";
            AMClient.AWS_POOL_ID = "ap-southeast-2:0ed20c23-4af8-4408-86fc-b78689a5c7a7";
            AMClient.AWS_REGION_ENDPOINT = Amazon.RegionEndpoint.APSoutheast2;

            //Set MQTT Client ID
            Random rnd = new Random();
            AMClient.MQTT_CLIENT_ID = "MagIQ" + rnd.Next().ToString();

        }

        private void rbtOn_CheckedChanged(object sender, EventArgs e)
        {
            UnitConfig.TurnOn();
        }

        private void rbtOff_CheckedChanged(object sender, EventArgs e)
        {
            UnitConfig.TurnOff();
        }

        private void rbtCooler_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCooler.Checked == true)
            {
                UnitConfig.EnableCooler();
                UnitConfig.CoolerFanOnly(false);
            }
            
        }
        private void rbtCoolerFanOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCoolerFanOnly.Checked == true)
            {
                UnitConfig.EnableCooler();
                UnitConfig.CoolerFanOnly(true);
            }
        }

        private void rbtHeater_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtHeater.Checked == true)
            {
                UnitConfig.EnableHeater();
                UnitConfig.HeaterFanOnly(false);
            }

        }

        private void rbtHeaterFanOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtHeaterFanOnly.Checked == true)
            {
                UnitConfig.EnableHeater();
                UnitConfig.HeaterFanOnly(true);
            }
        }

        private void btnSendCommand_Click(object sender, EventArgs e)
        {
                       
            
            string SUBSCRIBE_TOPIC = "SeeleyIoT/" + SYSTEM_MAC + "/MobileRealTime";
            string PUBLISH_TOPIC = "SeeleyIoT/" + SYSTEM_MAC + "/MobileRequest";

            

            //Initialise MQTT Client.
            AMClient.MQTTClientInit((IMqttClientConnectedHandler)null, (IMqttApplicationMessageReceivedHandler)null, (IMqttClientDisconnectedHandler)null);

            AMClient.MQTTClientConnect(URI).Wait(); //Connect MQTT Client.

            //AMClient.MQTTSubscribe("SeeleyIoT/9070652C0B27/MobileRealTime").Wait();
            AMClient.MQTTPublish(PUBLISH_TOPIC, UnitConfig.GetJsonData()).Wait();

            ShowInfo();
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            AMClient.SetAuth(txtUsername.Text, txtPassword.Text);
            AMClient.LoginUser(); //Connect to AWS for Auth Tokens.
            URI = AMClient.GenerateURI(); //Generate AWS URI with Signature V4 Auth.

            btnLogon.Text = "Logon AWS" + Environment.NewLine + "Expires:" + AMClient.GetLogonExpiry().ToString("yyyy-MM-dd HH:mm:ss");
            btnSendCommand.Enabled = true;

            string loadmobiledevice_jsondata = SCData.WebDataQuery("loadmobiledevice", AMClient.GetIDToken());
            loadmobiledevice_jsondata = loadmobiledevice_jsondata.Replace("[", "").Replace("]", "");
            SYSTEM_MAC = JObject.Parse(loadmobiledevice_jsondata)["MacAddressId"].ToString();

            txtMAC.Text = SYSTEM_MAC;
            UnitConfig.SetSystemMAC(SYSTEM_MAC);

            ShowInfo();
            
        }
        private void ShowInfo()
        {
            txtSystemDetails.Text = SCData.WebDataQuery("loadsystemdetails?macAddressId=" + SYSTEM_MAC, AMClient.GetIDToken());
            txtSystemRunning.Text = SCData.WebDataQuery("loadsystemrunning?macAddressId=" + SYSTEM_MAC, AMClient.GetIDToken());
        }

        private void rbtCoolerAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCoolerAuto.Checked ==true )
            {
                UnitConfig.CoolerAuto(true);
            }

        }

        private void rbtCoolerManual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCoolerManual.Checked == true)
            {
                UnitConfig.CoolerAuto(false);
            }
        }

        private void txtCoolerTemp_TextChanged(object sender, EventArgs e)
        {
            if (txtCoolerTemp.Text != "")
            {
                UnitConfig.SetCoolerTemp(int.Parse(txtCoolerTemp.Text));
            }
        }

        private void txtCoolerSpeed_TextChanged(object sender, EventArgs e)
        {
            if (txtCoolerSpeed.Text != "")
            { 
                UnitConfig.SetCoolerFanSpeed(int.Parse(txtCoolerSpeed.Text));
            }
        }

        private void txtHeaterTemp_TextChanged(object sender, EventArgs e)
        {
            if (txtHeaterTemp.Text != "")
            {
                UnitConfig.SetHeaterTemp(int.Parse(txtHeaterTemp.Text));
            }
        }

        private void txtHeaterFanSpeed_TextChanged(object sender, EventArgs e)
        {
            if (txtHeaterFanSpeed.Text != "")
            {
                UnitConfig.SetHeaterFanSpeed(int.Parse(txtHeaterFanSpeed.Text));
            }

        }
    }
}
