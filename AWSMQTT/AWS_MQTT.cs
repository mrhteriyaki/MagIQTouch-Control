using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;


//NuGet Packages Installed.
//AWSSDK.Core
//AWSSDK.SecurityToken
//AWSSDK.CognitoIdentityProvider
//AWSSDK.CognitoIdentity
//Amazon.Extensions.CognitoAuthentication
//MQTTnet


using Amazon;
using Amazon.Runtime;
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;


namespace AWSMQTT
{
    public class AWS_MQTT
    {
        static string AWS_IOT_GATEWAY = "ab7hzia9uew8g-ats.iot.ap-southeast-2.amazonaws.com";
        static string AWS_USER_POOL_ID = "ap-southeast-2_uw5VVNlib";

        //AWS_CLIENT_ID = "6e1lu9fchv82uefiarsp0290v9"; //Replaced on app update - April 2022.      
        static string AWS_CLIENT_ID = "afh7fftbb0fg2rnagdbgd9b7b";

        //AWS_POOL_ID = "ap-southeast-2:0ed20c23-4af8-4408-86fc-b78689a5c7a7"; //Replaced on app update - April 2022.      
        static string AWS_POOL_ID = "ap-southeast-2:87af6d7b-28ef-4014-88f1-67b19c361221";

        static RegionEndpoint AWS_REGION_ENDPOINT = Amazon.RegionEndpoint.APSoutheast2;

        static ImmutableCredentials AWS_CREDENTIALS;
        static CognitoAWSCredentials COGNITO_AWS_CREDENTIALS;
        static CognitoUser COGNITO_USER;

        static string AWS_Username;
        static string AWS_Password;
        public void SetAuth(string username, string password)
        {
            AWS_Username = username;
            AWS_Password = password;
        }


        public string UpperCaseUrlEncode(string s)
        {
            
            char[] temp = HttpUtility.UrlEncode(s).ToCharArray();
            for (int i = 0; i < temp.Length - 2; i++)
            {
                if (temp[i] == '%')
                {
                    temp[i + 1] = char.ToUpper(temp[i + 1]);
                    temp[i + 2] = char.ToUpper(temp[i + 2]);
                }
            }
            return new string(temp);
        }

        bool first_login = true;
        DateTime tokenexpiry = DateTime.Now;

        public void ResetValidation()
        {
            first_login = true;
        }

        public void LoginUser()
        {
            if (first_login == false)
            {
                RefreshToken();
                return;
            }
                AmazonCognitoIdentityProviderClient _provider = new AmazonCognitoIdentityProviderClient((AWSCredentials)new AnonymousAWSCredentials(), RegionEndpoint.APSoutheast2);
                CognitoUserPool pool = new CognitoUserPool(AWS_USER_POOL_ID, AWS_CLIENT_ID, _provider);
                CognitoUser cognitoUser = new CognitoUser(AWS_Username, AWS_CLIENT_ID, pool, _provider);
                cognitoUser.StartWithSrpAuthAsync(new InitiateSrpAuthRequest()
                {
                    Password = AWS_Password
                }).Wait();
                COGNITO_USER = cognitoUser;

            SetCognitoAWScredentials();
            tokenexpiry = DateTime.Now.AddHours(1); //default 1 hour token.

            first_login = false;

      
        }



        public void RefreshToken()
        {
            if (tokenexpiry > DateTime.Now)
            {
                //Token still valid, skip refresh.
                return;
            }

            COGNITO_USER.SessionTokens = new CognitoUserSession((string)null, COGNITO_USER.SessionTokens.AccessToken, COGNITO_USER.SessionTokens.RefreshToken, DateTime.Now, DateTime.Now.AddDays(3.0));
               COGNITO_USER.StartWithRefreshTokenAuthAsync(new InitiateRefreshTokenAuthRequest()
                {
                    AuthFlowType = AuthFlowType.REFRESH_TOKEN
                }).Wait();

            SetCognitoAWScredentials();
            
            //update expiry
            tokenexpiry = DateTime.Now.AddHours(1);
            
            //Refresh resets this expiration by 1 hour.
            //COGNITO_USER.SessionTokens.ExpirationTime
            
            
        }


        public void SetCognitoAWScredentials()
        {
            COGNITO_AWS_CREDENTIALS = COGNITO_USER.GetCognitoAWSCredentials(AWS_POOL_ID, AWS_REGION_ENDPOINT);
            AWS_CREDENTIALS = COGNITO_AWS_CREDENTIALS.GetCredentials();

        }


        public string GetIDToken()
        {
            return COGNITO_USER.SessionTokens.IdToken;
        }

        public string GetAWSIdToken()
        {
            return AWS_CREDENTIALS.Token;
        }


        public string GetAccessToken()
        {
            return COGNITO_USER.SessionTokens.AccessToken;
        }

        public string GetAWSAccessKey()
        {
            return AWS_CREDENTIALS.AccessKey;
        }

        public string GetAWSSecret()
        {
            return AWS_CREDENTIALS.SecretKey;
            
        }

        public string GetExpiry()
        {
            return COGNITO_USER.SessionTokens.ExpirationTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        

        public string GenerateURI()
        {
            //Validate login first.



            DateTime time = DateTime.UtcNow;
            string dateStamp = DateTime.UtcNow.ToString("yyyyMMdd");
            string amzdate = dateStamp + "T" + time.ToString("HHmmss") + "Z";


            string service = "iotdevicegateway";
            string region = AWS_REGION_ENDPOINT.SystemName;
            string algorithm = "AWS4-HMAC-SHA256";
            string method = "GET";
            string canonicalUri = "/mqtt";
            //string host = "ab7hzia9uew8g-ats.iot.ap-southeast-2.amazonaws.com";
            string credentialScope = dateStamp + "/" + region + "/" + service + "/" + "aws4_request";

            string canonicalQuerystring = "X-Amz-Algorithm=AWS4-HMAC-SHA256";
            canonicalQuerystring += "&X-Amz-Credential=" + UpperCaseUrlEncode(AWS_CREDENTIALS.AccessKey + "/" + credentialScope);
            canonicalQuerystring += "&X-Amz-Date=" + amzdate;
            canonicalQuerystring += "&X-Amz-Expires=86400";
            canonicalQuerystring += "&X-Amz-SignedHeaders=host";
            string canonicalHeaders = "host:" + AWS_IOT_GATEWAY + "\n";

            //Replace original javascript sha256 generate with c# compatible.
            //string payloadHash = SigV4Utils.sha256("");
            string payloadHash = sha256("");


            string canonicalRequest = method +
                "\n" +
                canonicalUri +
                "\n" +
                canonicalQuerystring +
                "\n" +
                canonicalHeaders +
                "\n" + "host" + "\n" +
                payloadHash;

            string stringToSign = algorithm + "\n" + amzdate + "\n" + credentialScope + "\n" + sha256(canonicalRequest);
            byte[] signingKey = getSignatureKey(AWS_CREDENTIALS.SecretKey, dateStamp, region, service);
            byte[] signature_bytes = HmacSHA256(stringToSign, signingKey);

            string signature = convertbyte(signature_bytes);


            canonicalQuerystring += "&X-Amz-Signature=" + signature;
            string requestUrl = "wss://" + AWS_IOT_GATEWAY + canonicalUri + "?" + canonicalQuerystring + "&X-Amz-Security-Token=" + UpperCaseUrlEncode(AWS_CREDENTIALS.Token);

            // Create a signing key.

            // Use the signing key to sign the StringToSign using HMAC-SHA256 signing algorithm.


            return requestUrl;
        }

        String convertbyte(byte[] bytes)
        {
            string hashString = string.Empty;
            foreach (byte x in bytes)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return (hashString);
        }

        string sha256(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return (hashString);
        }


        byte[] HmacSHA256(String data, byte[] key)
        {
            String algorithm = "HmacSHA256";
            KeyedHashAlgorithm kha = KeyedHashAlgorithm.Create(algorithm);
            kha.Key = key;

            return kha.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        byte[] getSignatureKey(String key, String dateStamp, String regionName, String serviceName)
        {
            byte[] kSecret = Encoding.UTF8.GetBytes(("AWS4" + key).ToCharArray());
            byte[] kDate = HmacSHA256(dateStamp, kSecret);
            byte[] kRegion = HmacSHA256(regionName, kDate);
            byte[] kService = HmacSHA256(serviceName, kRegion);
            byte[] kSigning = HmacSHA256("aws4_request", kService);

            return kSigning;
        }


        public DateTime GetLogonExpiry()
        {
            if (COGNITO_USER == null)
            {
                return DateTime.Now;
            }
            return COGNITO_USER.SessionTokens.ExpirationTime;
        }

    }
}
