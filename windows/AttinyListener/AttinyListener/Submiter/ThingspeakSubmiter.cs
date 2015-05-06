using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace AttinyListener
{
    class ThingspeakSubmiter : ISubmiter
    {
        public string FieldName
        {
            get;
            set;
        }

        public string ApiKey
        {
            get;
            set;
        }
        
        public string ChannelId
        {
            get;
            set;
        }
        
        public int SubmitInterval
        {
            get;
            set;
        }

        private const string API_URL = "http://api.thingspeak.com/";
        private const string API_COMMAND_RETRIEVE = "channels";
        private const string API_COMMAND_UPDATE = "update";

        private const string API_PARAM_KEY = "key";
        
        private WebClient webClient
        {
            get
            {
                WebClient client = new WebClient();

                // url encode the request
                client.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");

                // add api key
                client.QueryString.Add(API_PARAM_KEY, this.ApiKey);

                return client;
            }            
        }

    
        public ThingspeakSubmiter(string apiKey, string channelId, string fieldName, int submitInterval)
        {
            this.FieldName = fieldName;
            this.ChannelId = channelId;
            this.ApiKey = apiKey;
            this.SubmitInterval = submitInterval;
        }

        public bool TestApi()
        {
            WebClient request = this.webClient;

            // retrieve data from thingspeak            
            try
            {
                string result = request.DownloadString(API_URL + API_COMMAND_RETRIEVE + "/" + this.ChannelId + "/feed/last.json");

                request.Dispose();

                if (String.IsNullOrEmpty(result) || result == "0")
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }           
            return true;
        }

        public bool UpdateChannel(string data) {            
            //MessageBox.Show(data);
            WebClient request = this.webClient;

            // add data for field
            request.QueryString.Add(this.FieldName, data);
            
            // submit data to thingspeak
            string result = request.DownloadString(API_URL + API_COMMAND_UPDATE);

            request.Dispose();

            // result is 0, if the update was not successfull
            if (String.IsNullOrEmpty(result) || result == "0") 
            {
                return false;
            }

            return true;           
        }

        public bool SubmitData(string data)
        {
            return this.UpdateChannel(data);
        }

        public bool TestConnection()
        {
            return this.TestApi();
        }
    }
}
