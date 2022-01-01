using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace SeeleyControl
{
    public class SCData
    {
        SLRemoteAccessRequest remoteAccessRequest = new SLRemoteAccessRequest();
        static string APIGateway = "57uh36mbv1.execute-api.ap-southeast-2.amazonaws.com";

        public void SetSystemMAC(string SystemMAC)
        {
            remoteAccessRequest.SerialNo = SystemMAC;
        }

        public string GetSystemMAC()
        {
            if (remoteAccessRequest.SerialNo == "")
            {
                throw new Exception("No MAC Set");
            }
            return remoteAccessRequest.SerialNo;
        }

        public void SetCoolerFanSpeed(int speed)
        {
            if (speed >= 1 && speed <= 10)
            {
                remoteAccessRequest.CFanSpeed = speed;
            }
        }
        public void SetCoolerTemp(int temp)
        {
            //18-35 Range
            if (temp <= 35 && temp >=18)
            {
                remoteAccessRequest.CTemp = temp;
            }
        }

        public void SetZone1OnOff(bool onoff)
        {
            if (onoff == true)
            {
                remoteAccessRequest.OnOffZone1 = 1;
            }
            else
            {
                remoteAccessRequest.OnOffZone1 = 0;

            }
            
        }
        public void SetZone2OnOff(bool onoff)
        {
            if (onoff == true)
            {
                remoteAccessRequest.OnOffZone2 = 1;
            }
            else
            {
                remoteAccessRequest.OnOffZone2 = 0;

            }

        }

        public void SetZone1Temp(int temp)
        {
            //0-37 range
            if (temp <= 37 && temp >= 0)
            {
                //remoteAccessRequest.HTemp = temp;
                remoteAccessRequest.TempZone1 = temp;
            }
        }
        public void SetZone2Temp(int temp)
        {
            if (temp <= 37 && temp >= 0)
            {
                //remoteAccessRequest.HTemp = temp;
                remoteAccessRequest.TempZone2 = temp;
            }
        }



        public void SetHeaterFanSpeed(int speed)
        {
            if (speed >= 1 && speed <= 10)
            {
                remoteAccessRequest.HFanSpeed = speed;
            }
                
        }

        public void TurnOff()
        {
            remoteAccessRequest.StandBy = 1;
        }
        public void TurnOn()
        {
            remoteAccessRequest.StandBy = 0;
        }

        public void EnableCooler()
        {
            remoteAccessRequest.EvapCRunning = 1;
            remoteAccessRequest.HRunning = 0;
            remoteAccessRequest.FAOCRunning = 0;
            remoteAccessRequest.IAOCRunning = 0;
        }

        public void EnableHeater()
        {
            remoteAccessRequest.EvapCRunning = 0;
            remoteAccessRequest.HRunning = 1;
            remoteAccessRequest.FAOCRunning = 0;
            remoteAccessRequest.IAOCRunning = 0;
        }

        public void CoolerFanOnly(bool state)
        {
            if (state == true)
            {
                remoteAccessRequest.CFanOnly = 1;
            }
            else
            {
                remoteAccessRequest.CFanOnly = 0;
            }
            
        }

        public void HeaterFanOnly(bool state)
        {
            if (state == true)
            {
                remoteAccessRequest.HFanOnly = 1;
            }
            else
            {
                remoteAccessRequest.HFanOnly = 0;
            }
        }

        public void CoolerAuto(bool state)
        {
            if (state == true)
            {
                remoteAccessRequest.CThermosOrFan = 1;
            }
            else
            {
                remoteAccessRequest.CThermosOrFan = 0;
            }
            
        }

        public SCData()
        {
            
            //Setup Default Values.

            
            //System MAC Address
            //remoteAccessRequest.SerialNo = "";

            //Request Time.
            remoteAccessRequest.TimeRequest = DateTime.Now.ToString("o");

            //Turn system On/Off.
            //0 turn on, 1 turn off.
            remoteAccessRequest.StandBy = 1; //SystemOn ? 0 : 1;

            //Set Cooper as active unit, set to 0 when other units are in use.
            remoteAccessRequest.EvapCRunning = 1;


            //Evap Cooler Temperature 
            remoteAccessRequest.CTemp = 20;

            //Evap Cooler Fan speed
            remoteAccessRequest.CFanSpeed = 1;

            //Use Evap in Fan only mode. 1 = on, 0 off.
            remoteAccessRequest.CFanOnly = 1;

            //Use Temperature target or manual fan speed. /0 = fan speed, 1 = temp.
            remoteAccessRequest.CThermosOrFan = 0;


            //Set Heater as active unit, 0 = off, 1 = on.
            remoteAccessRequest.HRunning = 0;


            //Heater.Temperature;
            remoteAccessRequest.HTemp = 21;

            //Heater Fan Speed
            remoteAccessRequest.HFanSpeed = 3;

            //Heater Fan Only.
            remoteAccessRequest.HFanOnly = 0;


            //Refridgerated Aircon settings.
            //remoteAccessRequest.FAOCRunning = GetOnOff(FixedAOC.Running);
            remoteAccessRequest.FAOCRunning = 0;
            remoteAccessRequest.FAOCTemp = 19;

            //remoteAccessRequest.IAOCRunning = GetOnOff(InverterAOC.Running);
            remoteAccessRequest.IAOCRunning = 0;
            //remoteAccessRequest.IAOCTemp = InverterAOC.Temperature;
            remoteAccessRequest.IAOCTemp = 0;

            remoteAccessRequest.OnOffZone1 = 0;
            remoteAccessRequest.TempZone1 = 20;
            remoteAccessRequest.Override1 = 0;

            remoteAccessRequest.OnOffZone2 = 0;
            remoteAccessRequest.TempZone2 = 21;
            remoteAccessRequest.Override2 = 0;

            /*
            SLBusinessManager.SetZone1(remoteAccessRequest, 0);
            SLBusinessManager.SetZone2(remoteAccessRequest, 1);
            SLBusinessManager.SetZone3(remoteAccessRequest, 2);
            SLBusinessManager.SetZone4(remoteAccessRequest, 3);
            SLBusinessManager.SetZone5(remoteAccessRequest, 4);
            SLBusinessManager.SetZone6(remoteAccessRequest, 5);
            SLBusinessManager.SetZone7(remoteAccessRequest, 6);
            SLBusinessManager.SetZone8(remoteAccessRequest, 7);
            SLBusinessManager.SetZone9(remoteAccessRequest, 8);
            SLBusinessManager.SetZone10(remoteAccessRequest, 9);
            */
            //remoteAccessRequest.CC3200FW_Major = SystemDetails.CC3200FW_Major;
            remoteAccessRequest.CC3200FW_Major = 0;

            //remoteAccessRequest.CC3200FW_Minor = SystemDetails.CC3200FW_Minor;
            remoteAccessRequest.CC3200FW_Minor = 18;

            //remoteAccessRequest.STM32FW_Major = SystemDetails.STM32FW_Major;
            remoteAccessRequest.STM32FW_Major = 0;

            //remoteAccessRequest.STM32FW_Minor = SystemDetails.STM32FW_Minor;
            remoteAccessRequest.STM32FW_Minor = 12;

        }


        

       
        

        public string GetJsonData()
        {
            return GetJsonData(GenerateData());
        }

        public static string GetJsonData(SLRemoteAccessRequest dataRequest)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return JsonConvert.SerializeObject((object)dataRequest, Formatting.None, settings).Replace("'", "&#39;").Replace("\\string.Empty", "&quot;").Replace("\\n", "<br />");
        }

        SLRemoteAccessRequest GenerateData()
        {            
            return remoteAccessRequest;
        }

        static public string WebDataQuery(string API_QUERY, string AWS_ID_TOKEN)
        {
            string uri = "https://" + APIGateway + "/api/" + API_QUERY;
            HttpWebRequest webreq = WebRequest.Create(uri) as HttpWebRequest;
            webreq.Method = "GET";
            webreq.Headers.Add("Authorization", AWS_ID_TOKEN);
            webreq.ContentLength = 0;
            webreq.Host = APIGateway;
            var response = (HttpWebResponse)webreq.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }



    }



    public class SLComponentInfo
    {
        [JsonProperty("Brands")]
        public int Brands { set; get; }

        [JsonProperty("TemperatureUnits")]
        public int TemperatureUnits { set; get; }

        [JsonProperty("MaximumTemperature")]
        public int MaximumTemperature { set; get; }

        [JsonProperty("MinimumTemperature")]
        public int MinimumTemperature { set; get; }

        [JsonProperty("AOCInstalled")]
        public int AOCInstalled { set; get; }

        [JsonProperty("HumidityControl")]
        public int HumidityControl { set; get; }

        [JsonProperty("Manual")]
        public int Manual { set; get; }

        [JsonProperty("SlaveWallControls")]
        public int SlaveWallControls { set; get; }

        [JsonProperty("TemperatureSensors")]
        public int TemperatureSensors { set; get; }

        [JsonProperty("ModelNo")]
        public string ModelNo { set; get; }

        [JsonProperty("SerialNoPrefix")]
        public string SerialNoPrefix { set; get; }

        [JsonProperty("SerialNo")]
        public string SerialNo { set; get; }

        [JsonProperty("MaxSetFanSpeed")]
        public int MaxSetFanSpeed { set; get; }

        [JsonProperty("DataTableVersion")]
        public string DataTableVersion { set; get; }

        [JsonProperty("ICSSoftwareRev")]
        public string ICSSoftwareRev { set; get; }
    }

    public class SLSystemDetails
    {
        [JsonProperty("MacAddressId")]
        public string MacAddressId { set; get; }


        [JsonProperty("CC3200FW_Major")]
        public int CC3200FW_Major { set; get; }

        [JsonProperty("CC3200FW_Minor")]
        public int CC3200FW_Minor { set; get; }

        [JsonProperty("STM32FW_Major")]
        public int STM32FW_Major { set; get; }

        [JsonProperty("STM32FW_Minor")]
        public int STM32FW_Minor { set; get; }

        [JsonProperty("NoOfEVAPInSystem")]
        public int NoOfEVAPInSystem { set; get; }

        [JsonProperty("HeaterInSystem")]
        public int HeaterInSystem { set; get; }

        [JsonProperty("AOCInverterInSystem")]
        public int AOCInverterInSystem { set; get; }

        [JsonProperty("AOCFixedInSystem")]
        public int AOCFixedInSystem { set; get; }

        [JsonProperty("EVAPCooler")]
        public SLComponentInfo EVAPCooler { set; get; }

        [JsonProperty("Heater")]
        public SLComponentInfo Heater { set; get; }

        [JsonProperty("AOCFixed")]
        public SLComponentInfo AOCFixed { set; get; }

        [JsonProperty("AOCInverter")]
        public SLComponentInfo AOCInverter { set; get; }

        [JsonProperty("NoOfZones")]
        public int NoOfZones { set; get; }

        [JsonProperty("ExternalAirSensor")]
        public int ExternalAirSensor { set; get; }

        [JsonProperty("AirSensorMaster")]
        public int AirSensorMaster { set; get; }

        [JsonProperty("NoAirSensorZones")]
        public int NoAirSensorZones { set; get; }

        [JsonProperty("NoSlaveWC")]
        public int NoSlaveWC { set; get; }

        [JsonProperty("DamperDelay")]
        public int DamperDelay { set; get; }

        [JsonProperty("BMSMS1")]
        public int BMSMS1 { set; get; }

        [JsonProperty("BMSS1")]
        public int BMSS1 { set; get; }

        [JsonProperty("NoOfZonesControl")]
        public int NoOfZonesControl { set; get; }

        [JsonProperty("ZoneName1")]
        public string ZoneName1 { set; get; }

        [JsonProperty("ZoneName2")]
        public string ZoneName2 { set; get; }

        [JsonProperty("ZoneName3")]
        public string ZoneName3 { set; get; }

        [JsonProperty("ZoneName4")]
        public string ZoneName4 { set; get; }

        [JsonProperty("ZoneName5")]
        public string ZoneName5 { set; get; }

        [JsonProperty("ZoneName6")]
        public string ZoneName6 { set; get; }

        [JsonProperty("ZoneName7")]
        public string ZoneName7 { set; get; }

        [JsonProperty("ZoneName8")]
        public string ZoneName8 { set; get; }

        [JsonProperty("ZoneName9")]
        public string ZoneName9 { set; get; }

        [JsonProperty("ZoneName10")]
        public string ZoneName10 { set; get; }

        [JsonProperty("Zones")]
        public SLComponentInfo Zones { set; get; }

        [JsonProperty("C1")]
        public SLCoolerInfo C1 { set; get; }

        [JsonProperty("C2")]
        public SLCoolerInfo C2 { set; get; }

        [JsonProperty("C3")]
        public SLCoolerInfo C3 { set; get; }

        [JsonProperty("C4")]
        public SLCoolerInfo C4 { set; get; }

        [JsonProperty("C5")]
        public SLCoolerInfo C5 { set; get; }

        [JsonProperty("C6")]
        public SLCoolerInfo C6 { set; get; }

        [JsonProperty("C7")]
        public SLCoolerInfo C7 { set; get; }

        [JsonProperty("C8")]
        public SLCoolerInfo C8 { set; get; }

        [JsonProperty("C9")]
        public SLCoolerInfo C9 { set; get; }

        [JsonProperty("C10")]
        public SLCoolerInfo C10 { set; get; }

        [JsonProperty("WCFW")]
        public string WCFW { set; get; }

        public bool IsValid() => !string.IsNullOrEmpty(this.MacAddressId);
    }

    public enum CoolerComponentMode
    {
        Evaporative,
        FixedAOC,
        InverterAOC,
    }

    public class SLSystemRunning
    {
        [JsonProperty("MacAddressId")]
        public string MacAddressId { set; get; }

        [JsonProperty("Timestamp")]
        public string Timestamp { set; get; }

        [JsonProperty("InternalTemp")]
        public float InternalTemp { set; get; }

        [JsonProperty("ExternalTemp")]
        public float ExternalTemp { set; get; }

        [JsonProperty("HumidityActualValue")]
        public int HumidityActualValue { set; get; }

        [JsonProperty("SystemOn")]
        public int SystemOn { set; get; }

        [JsonProperty("CoolerType")]
        public CoolerComponentMode CoolerType { set; get; }

        [JsonProperty("EvapCRunning")]
        public int EvapCRunning { set; get; }

        [JsonProperty("CFanSpeed")]
        public int CFanSpeed { set; get; }

        [JsonProperty("CTemp")]
        public int CTemp { set; get; }

        [JsonProperty("CFanOnlyOrCool")]
        public int CFanOnlyOrCool { set; get; }

        [JsonProperty("FanOrTempControl")]
        public int FanOrTempControl { set; get; }

        [JsonProperty("FaultCodePresent")]
        public int FaultCodePresent { set; get; }

        [JsonProperty("PumpStatus")]
        public int PumpStatus { set; get; }

        [JsonProperty("HRunning")]
        public int HRunning { set; get; }

        [JsonProperty("HActualFanSpeed")]
        public int HActualFanSpeed { set; get; }

        [JsonProperty("HFanSpeed")]
        public int HFanSpeed { set; get; }

        [JsonProperty("HFanOnly")]
        public int HFanOnly { set; get; }

        [JsonProperty("HTemp")]
        public int HTemp { set; get; }

        [JsonProperty("BasicFault")]
        public int BasicFault { set; get; }

        [JsonProperty("Spanner")]
        public int Spanner { set; get; }

        [JsonProperty("HActualGasRate")]
        public int HActualGasRate { set; get; }

        [JsonProperty("FAOCRunning")]
        public int FAOCRunning { set; get; }

        [JsonProperty("FAOCTemp")]
        public int FAOCTemp { set; get; }

        [JsonProperty("FAOCActualCompressorON")]
        public int FAOCActualCompressorON { set; get; }

        [JsonProperty("IAOCRunning")]
        public int IAOCRunning { set; get; }

        [JsonProperty("IAOCSetTemp")]
        public int IAOCSetTemp { set; get; }

        [JsonProperty("IAOCCompressorON")]
        public int IAOCCompressorON { set; get; }

        [JsonProperty("ProgramMode")]
        public int ProgramMode { set; get; }

        [JsonProperty("ProgramModeOverridden")]
        public int ProgramModeOverridden { set; get; }

        [JsonProperty("UpdateMicroProcessor")]
        public int UpdateMicroProcessor { set; get; }

        [JsonProperty("UpdateWiFiModule")]
        public int UpdateWiFiModule { set; get; }

        [JsonProperty("ClearSoftwareUpdate")]
        public int ClearSoftwareUpdate { set; get; }

        [JsonProperty("LoggingFrequency")]
        public int LoggingFrequency { set; get; }

        [JsonProperty("EnableLiveStreaming")]
        public int EnableLiveStreaming { set; get; }

        [JsonProperty("UpdateInPogress")]
        public int UpdateInPogress { set; get; }

        [JsonProperty("UpdateCompleted")]
        public int UpdateCompleted { set; get; }

        [JsonProperty("UpdateFailed")]
        public int UpdateFailed { set; get; }

        [JsonProperty("OnOffZone1")]
        public int OnOffZone1 { set; get; }

        [JsonProperty("SetTempZone1")]
        public int SetTempZone1 { set; get; }

        [JsonProperty("ActualTempZone1")]
        public float ActualTempZone1 { set; get; }

        [JsonProperty("DamperOnOffZone1")]
        public int DamperOnOffZone1 { set; get; }

        [JsonProperty("ProgramModeZone1")]
        public int ProgramModeZone1 { set; get; }

        [JsonProperty("ProgramModeOverriddenZone1")]
        public int ProgramModeOverriddenZone1 { set; get; }

        [JsonProperty("OnOffZone2")]
        public int OnOffZone2 { set; get; }

        [JsonProperty("SetTempZone2")]
        public int SetTempZone2 { set; get; }

        [JsonProperty("ActualTempZone2")]
        public float ActualTempZone2 { set; get; }

        [JsonProperty("DamperOnOffZone2")]
        public int DamperOnOffZone2 { set; get; }

        [JsonProperty("ProgramModeZone2")]
        public int ProgramModeZone2 { set; get; }

        [JsonProperty("ProgramModeOverriddenZone2")]
        public int ProgramModeOverriddenZone2 { set; get; }

        [JsonProperty("OnOffZone3")]
        public int OnOffZone3 { set; get; }

        [JsonProperty("SetTempZone3")]
        public int SetTempZone3 { set; get; }

        [JsonProperty("ActualTempZone3")]
        public float ActualTempZone3 { set; get; }

        [JsonProperty("DamperOnOffZone3")]
        public int DamperOnOffZone3 { set; get; }

        [JsonProperty("ProgramModeZone3")]
        public int ProgramModeZone3 { set; get; }

        [JsonProperty("ProgramModeOverriddenZone3")]
        public int ProgramModeOverriddenZone3 { set; get; }

        [JsonProperty("OnOffZone4")]
        public int OnOffZone4 { set; get; }

        [JsonProperty("SetTempZone4")]
        public int SetTempZone4 { set; get; }

        [JsonProperty("ActualTempZone4")]
        public float ActualTempZone4 { set; get; }

        [JsonProperty("DamperOnOffZone4")]
        public int DamperOnOffZone4 { set; get; }

        [JsonProperty("ProgramModeZone4")]
        public int ProgramModeZone4 { set; get; }

        [JsonProperty("ProgramModeOverriddenZone4")]
        public int ProgramModeOverriddenZone4 { set; get; }

        [JsonProperty("OnOffZone5")]
        public int OnOffZone5 { set; get; }

        [JsonProperty("SetTempZone5")]
        public int SetTempZone5 { set; get; }

        [JsonProperty("ActualTempZone5")]
        public float ActualTempZone5 { set; get; }

        [JsonProperty("DamperOnOffZone5")]
        public int DamperOnOffZone5 { set; get; }

        [JsonProperty("ProgramModeZone5")]
        public int ProgramModeZone5 { set; get; }

        [JsonProperty("ProgramModeOverriddenZone5")]
        public int ProgramModeOverriddenZone5 { set; get; }

        [JsonProperty("OnOffZone6")]
        public int OnOffZone6 { set; get; }

        [JsonProperty("SetTempZone6")]
        public int SetTempZone6 { set; get; }

        [JsonProperty("ActualTempZone6")]
        public float ActualTempZone6 { set; get; }

        [JsonProperty("DamperOnOffZone6")]
        public int DamperOnOffZone6 { set; get; }

        [JsonProperty("ProgramModeZone6")]
        public int ProgramModeZone6 { set; get; }

        [JsonProperty("ProgramModeOverriddenZone6")]
        public int ProgramModeOverriddenZone6 { set; get; }

        [JsonProperty("OnOffZone7")]
        public int OnOffZone7 { set; get; }

        [JsonProperty("SetTempZone7")]
        public int SetTempZone7 { set; get; }

        [JsonProperty("ActualTempZone7")]
        public float ActualTempZone7 { set; get; }

        [JsonProperty("DamperOnOffZone7")]
        public int DamperOnOffZone7 { set; get; }

        [JsonProperty("ProgramModeZone7")]
        public int ProgramModeZone7 { set; get; }

        [JsonProperty("ProgramModeOverriddenZone7")]
        public int ProgramModeOverriddenZone7 { set; get; }

        [JsonProperty("OnOffZone8")]
        public int OnOffZone8 { set; get; }

        [JsonProperty("SetTempZone8")]
        public int SetTempZone8 { set; get; }

        [JsonProperty("ActualTempZone8")]
        public float ActualTempZone8 { set; get; }

        [JsonProperty("DamperOnOffZone8")]
        public int DamperOnOffZone8 { set; get; }

        [JsonProperty("ProgramModeZone8")]
        public int ProgramModeZone8 { set; get; }

        [JsonProperty("ProgramModeOverriddenZone8")]
        public int ProgramModeOverriddenZone8 { set; get; }

        [JsonProperty("OnOffZone9")]
        public int OnOffZone9 { set; get; }

        [JsonProperty("SetTempZone9")]
        public int SetTempZone9 { set; get; }

        [JsonProperty("ActualTempZone9")]
        public float ActualTempZone9 { set; get; }

        [JsonProperty("DamperOnOffZone9")]
        public int DamperOnOffZone9 { set; get; }

        [JsonProperty("ProgramModeZone9")]
        public int ProgramModeZone9 { set; get; }

        [JsonProperty("ProgramModeOverriddenZone9")]
        public int ProgramModeOverriddenZone9 { set; get; }

        [JsonProperty("OnOffZone10")]
        public int OnOffZone10 { set; get; }

        [JsonProperty("SetTempZone10")]
        public int SetTempZone10 { set; get; }

        [JsonProperty("ActualTempZone10")]
        public float ActualTempZone10 { set; get; }

        [JsonProperty("DamperOnOffZone10")]
        public int DamperOnOffZone10 { set; get; }

        [JsonProperty("ProgramModeZone10")]
        public int ProgramModeZone10 { set; get; }

        [JsonProperty("ProgramModeOverriddenZone10")]
        public int ProgramModeOverriddenZone10 { set; get; }

        [JsonProperty("TouchCount")]
        public int TouchCount { set; get; }


        [JsonProperty("ThermistorTemperature")]
        public int ThermistorTemperature { set; get; }


        [JsonProperty("FlameSenseVoltage")]
        public int FlameSenseVoltage { set; get; }

        [JsonProperty("AutoClean")]
        public int AutoClean { set; get;}

        [JsonProperty("DrainDry")]
        public int DrainDry { set; get;}

        [JsonProperty("DrainExternalSensor")]
        public int DrainExternalSensor { set; get;}

        [JsonProperty("Fault")]
        public int Fault { set; get;}

        [JsonProperty("HActualGasRateVariable")]
        public int HActualGasRateVariable { set; get;}

        [JsonProperty("HNewFault")]
        public int HNewFault { set; get;}

        [JsonProperty("HSetGasRate")]
        public int HSetGasRate { set; get;}

        [JsonProperty("HumiditySetPoint")]
        public int HumiditySetPoint { set; get;}

        [JsonProperty("IAOCActualTemp")]
        public int IAOCActualTemp { set; get;}

        [JsonProperty("ManualDrain")]
        public int ManualDrain { set; get;}

        [JsonProperty("NightQuietMode")]
        public int NightQuietMode { set; get;}

        [JsonProperty("PadFlush")]
        public int PadFlush { set; get;}

        [JsonProperty("PumpOffExternalAirSensor")]
        public int PumpOffExternalAirSensor { set; get;}

        [JsonProperty("SignalStrength")]
        public int SignalStrength { set; get;}


    }

    public class SLCoolerInfo
    {
        [JsonProperty("Type")]
        public string Type { set; get; }

        [JsonProperty("CabinetSerialNo")]
        public string CabinetSerialNo { set; get; }

        [JsonProperty("CoolerCabinetSoftRev")]
        public string CoolerCabinetSoftRev { set; get; }

        [JsonProperty("ModelNumber")]
        public string ModelNumber { set; get; }

        [JsonProperty("ElectronicsSerialNo")]
        public string ElectronicsSerialNo { set; get; }
    }

    public class SLModeInfo
    {
        [JsonProperty("Running")]
        public bool Running { set; get; }

        [JsonProperty("Temperature")]
        public int Temperature { set; get; }

        [JsonProperty("FanOnly")]
        public int FanOnly { set; get; }

        [JsonProperty("ActualFanSpeed")]
        public int ActualFanSpeed { set; get; }

        [JsonProperty("FanSpeed")]
        public int FanSpeed { set; get; }

        [JsonProperty("ActualGasRate")]
        public int ActualGasRate { set; get; }

        [JsonProperty("PumpStatus")]
        public bool PumpStatus { set; get; }

        [JsonProperty("IAOCCompressorON")]
        public bool IAOCCompressorON { set; get; }

        [JsonProperty("FAOCActualCompressorON")]
        public bool FAOCActualCompressorON { set; get; }

        [JsonProperty("PreviousTemperature")]
        public int PreviousTemperature { set; get; }

        [JsonProperty("PreviousFanSpeed")]
        public int PreviousFanSpeed { set; get; }
    }

    public class SLRemoteAccessRequest
    {
        public string SerialNo { set; get; }

        public string TimeRequest { set; get; }

        public int StandBy { set; get; }

        [JsonIgnore]
        public bool StandByFlag { set; get; }

        public int EvapCRunning { set; get; }

        [JsonIgnore]
        public bool EvapCRunningFlag { set; get; }

        public int CFanSpeed { set; get; }

        [JsonIgnore]
        public bool CFanSpeedFlag { set; get; }

        public int CTemp { set; get; }

        [JsonIgnore]
        public bool CTempFlag { set; get; }

        public int CThermosOrFan { set; get; }

        [JsonIgnore]
        public bool CThermosOrFanFlag { set; get; }

        public int CFanOnly { set; get; }

        [JsonIgnore]
        public bool CFanOnlyFlag { set; get; }

        public int HRunning { set; get; }

        [JsonIgnore]
        public bool HRunningFlag { set; get; }

        public int HFanSpeed { set; get; }

        [JsonIgnore]
        public bool HFanSpeedFlag { set; get; }

        public int HFanOnly { set; get; }

        [JsonIgnore]
        public bool HFanOnlyFlag { set; get; }

        public int HTemp { set; get; }

        [JsonIgnore]
        public bool HTempFlag { set; get; }

        public int FAOCRunning { set; get; }

        [JsonIgnore]
        public bool FAOCRunningFlag { set; get; }

        public int FAOCTemp { set; get; }

        [JsonIgnore]
        public bool FAOCTempFlag { set; get; }

        public int IAOCRunning { set; get; }

        [JsonIgnore]
        public bool IAOCRunningFlag { set; get; }

        public int IAOCTemp { set; get; }

        [JsonIgnore]
        public bool IAOCTempFlag { set; get; }

        public int OnOffZone1 { set; get; }

        [JsonIgnore]
        public bool OnOffZone1Flag { set; get; }

        public int Override1 { set; get; }

        [JsonIgnore]
        public bool Override1Flag { set; get; }

        public int TempZone1 { set; get; }

        [JsonIgnore]
        public bool TempZone1Flag { set; get; }

        public int OnOffZone2 { set; get; }

        [JsonIgnore]
        public bool OnOffZone2Flag { set; get; }

        public int Override2 { set; get; }

        [JsonIgnore]
        public bool Override2Flag { set; get; }

        public int TempZone2 { set; get; }

        [JsonIgnore]
        public bool TempZone2Flag { set; get; }

        public int OnOffZone3 { set; get; }

        [JsonIgnore]
        public bool OnOffZone3Flag { set; get; }

        public int Override3 { set; get; }

        [JsonIgnore]
        public bool Override3Flag { set; get; }

        public int TempZone3 { set; get; }

        [JsonIgnore]
        public bool TempZone3Flag { set; get; }

        public int OnOffZone4 { set; get; }

        [JsonIgnore]
        public bool OnOffZone4Flag { set; get; }

        public int Override4 { set; get; }

        [JsonIgnore]
        public bool Override4Flag { set; get; }

        public int TempZone4 { set; get; }

        [JsonIgnore]
        public bool TempZone4Flag { set; get; }

        public int OnOffZone5 { set; get; }

        [JsonIgnore]
        public bool OnOffZone5Flag { set; get; }

        public int Override5 { set; get; }

        [JsonIgnore]
        public bool Override5Flag { set; get; }

        public int TempZone5 { set; get; }

        [JsonIgnore]
        public bool TempZone5Flag { set; get; }

        public int OnOffZone6 { set; get; }

        [JsonIgnore]
        public bool OnOffZone6Flag { set; get; }

        public int Override6 { set; get; }

        [JsonIgnore]
        public bool Override6Flag { set; get; }

        public int TempZone6 { set; get; }

        [JsonIgnore]
        public bool TempZone6Flag { set; get; }

        public int OnOffZone7 { set; get; }

        [JsonIgnore]
        public bool OnOffZone7Flag { set; get; }

        public int Override7 { set; get; }

        [JsonIgnore]
        public bool Override7Flag { set; get; }

        public int TempZone7 { set; get; }

        [JsonIgnore]
        public bool TempZone7Flag { set; get; }

        public int OnOffZone8 { set; get; }

        [JsonIgnore]
        public bool OnOffZone8Flag { set; get; }

        public int Override8 { set; get; }

        [JsonIgnore]
        public bool Override8Flag { set; get; }

        public int TempZone8 { set; get; }

        [JsonIgnore]
        public bool TempZone8Flag { set; get; }

        public int OnOffZone9 { set; get; }

        [JsonIgnore]
        public bool OnOffZone9Flag { set; get; }

        public int Override9 { set; get; }

        [JsonIgnore]
        public bool Override9Flag { set; get; }

        public int TempZone9 { set; get; }

        [JsonIgnore]
        public bool TempZone9Flag { set; get; }

        public int OnOffZone10 { set; get; }

        [JsonIgnore]
        public bool OnOffZone10Flag { set; get; }

        public int Override10 { set; get; }

        [JsonIgnore]
        public bool Override10Flag { set; get; }

        public int TempZone10 { set; get; }

        [JsonIgnore]
        public bool TempZone10Flag { set; get; }

        public int MicroprocessorAvailable { set; get; }

        public int WiFiModuleAvailable { set; get; }

        public int CC3200FW_Major { set; get; }

        public int CC3200FW_Minor { set; get; }

        public int STM32FW_Major { set; get; }

        public int STM32FW_Minor { set; get; }

        public int TouchCount { set; get; }

        public string CCL { set; get; }

        public string STL { set; get; }

        public override int GetHashCode() => this.StandBy ^ this.CFanSpeed ^ this.CTemp ^ this.CFanOnly ^ this.HFanOnly ^ this.HFanSpeed ^ this.HTemp ^ this.FAOCTemp ^ this.IAOCTemp ^ this.OnOffZone1 ^ this.Override1 ^ this.TempZone1 ^ this.OnOffZone2 ^ this.Override2 ^ this.TempZone2 ^ this.OnOffZone3 ^ this.Override3 ^ this.TempZone3 ^ this.OnOffZone4 ^ this.Override4 ^ this.TempZone4 ^ this.OnOffZone5 ^ this.Override5 ^ this.TempZone5 ^ this.OnOffZone6 ^ this.Override6 ^ this.TempZone6 ^ this.OnOffZone7 ^ this.Override7 ^ this.TempZone7 ^ this.OnOffZone8 ^ this.Override8 ^ this.TempZone8 ^ this.OnOffZone9 ^ this.Override9 ^ this.TempZone9 ^ this.OnOffZone10 ^ this.Override10 ^ this.TempZone10 ^ this.TouchCount;

        public override bool Equals(object obj)
        {
            if (!(obj is SLRemoteAccessRequest))
                return false;
            SLRemoteAccessRequest remoteAccessRequest = (SLRemoteAccessRequest)obj;
            bool flag = !this.CThermosOrFanFlag || this.CThermosOrFan == remoteAccessRequest.CThermosOrFan;
            return (!this.StandByFlag || this.StandBy == remoteAccessRequest.StandBy) && (!this.CFanSpeedFlag || this.CFanSpeed == remoteAccessRequest.CFanSpeed) && ((!this.CTempFlag || this.CTemp == remoteAccessRequest.CTemp) && (!this.CThermosOrFanFlag || this.CThermosOrFan == remoteAccessRequest.CThermosOrFan)) && ((!this.EvapCRunningFlag || this.EvapCRunning == remoteAccessRequest.EvapCRunning) && (!this.FAOCRunningFlag || this.FAOCRunning == remoteAccessRequest.FAOCRunning) && ((!this.IAOCRunningFlag || this.IAOCRunning == remoteAccessRequest.IAOCRunning) && (!this.HRunningFlag || this.HRunning == remoteAccessRequest.HRunning))) && ((!this.CFanOnlyFlag || this.CFanOnly == remoteAccessRequest.CFanOnly) && (!this.HFanOnlyFlag || this.HFanOnly == remoteAccessRequest.HFanOnly) && ((!this.HFanSpeedFlag || this.HFanSpeed == remoteAccessRequest.HFanSpeed) && (!this.HTempFlag || this.HTemp == remoteAccessRequest.HTemp)) && ((!this.FAOCTempFlag || this.FAOCTemp == remoteAccessRequest.FAOCTemp) && (!this.IAOCTempFlag || this.IAOCTemp == remoteAccessRequest.IAOCTemp) && ((!this.OnOffZone1Flag || this.OnOffZone1 == remoteAccessRequest.OnOffZone1) && (!this.Override1Flag || this.Override1 == remoteAccessRequest.Override1)))) && ((!this.TempZone1Flag || this.TempZone1 == remoteAccessRequest.TempZone1) && (!this.OnOffZone2Flag || this.OnOffZone2 == remoteAccessRequest.OnOffZone2) && ((!this.Override2Flag || this.Override2 == remoteAccessRequest.Override2) && (!this.TempZone2Flag || this.TempZone2 == remoteAccessRequest.TempZone2)) && ((!this.OnOffZone3Flag || this.OnOffZone3 == remoteAccessRequest.OnOffZone3) && (!this.Override3Flag || this.Override3 == remoteAccessRequest.Override3) && ((!this.TempZone3Flag || this.TempZone3 == remoteAccessRequest.TempZone3) && (!this.OnOffZone4Flag || this.OnOffZone4 == remoteAccessRequest.OnOffZone4))) && ((!this.Override4Flag || this.Override4 == remoteAccessRequest.Override4) && (!this.TempZone4Flag || this.TempZone4 == remoteAccessRequest.TempZone4) && ((!this.OnOffZone5Flag || this.OnOffZone5 == remoteAccessRequest.OnOffZone5) && (!this.Override5Flag || this.Override5 == remoteAccessRequest.Override5)) && ((!this.TempZone5Flag || this.TempZone5 == remoteAccessRequest.TempZone5) && (!this.OnOffZone6Flag || this.OnOffZone6 == remoteAccessRequest.OnOffZone6) && ((!this.Override6Flag || this.Override6 == remoteAccessRequest.Override6) && (!this.TempZone6Flag || this.TempZone6 == remoteAccessRequest.TempZone6))))) && ((!this.OnOffZone7Flag || this.OnOffZone7 == remoteAccessRequest.OnOffZone7) && (!this.Override7Flag || this.Override7 == remoteAccessRequest.Override7) && ((!this.TempZone7Flag || this.TempZone7 == remoteAccessRequest.TempZone7) && (!this.OnOffZone8Flag || this.OnOffZone8 == remoteAccessRequest.OnOffZone8)) && ((!this.Override8Flag || this.Override8 == remoteAccessRequest.Override8) && (!this.TempZone8Flag || this.TempZone8 == remoteAccessRequest.TempZone8) && ((!this.OnOffZone9Flag || this.OnOffZone9 == remoteAccessRequest.OnOffZone9) && (!this.Override9Flag || this.Override9 == remoteAccessRequest.Override9))) && ((!this.TempZone9Flag || this.TempZone9 == remoteAccessRequest.TempZone9) && (!this.OnOffZone10Flag || this.OnOffZone10 == remoteAccessRequest.OnOffZone10) && (!this.Override10Flag || this.Override10 == remoteAccessRequest.Override10))) && (!this.TempZone10Flag || this.TempZone10 == remoteAccessRequest.TempZone10);
        }

        

    }

}
