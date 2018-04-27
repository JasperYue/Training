using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallWcfServiceDemo
{
    public static class Constants
    {
        public const string WEATHER_WEBSERVICE_SOAP = "WeatherWebServiceSoap";
        public const string PROVINCE_JIANGSU = "江苏";
        public const string REGULAR_ALL_NUMBER = "^[0-9]{5}$";
        public const string REGULAR_ALL_CHINESE_CHARACTERS = "^[\u4e00-\u9fa5]+$";
        public const string ERROR_MESSAGE = "[Error Message] Expected valid city code or chinese name, but given '{0}'";
        public const string EMPTY_RESULT = "查询结果为空！";
    }
}
