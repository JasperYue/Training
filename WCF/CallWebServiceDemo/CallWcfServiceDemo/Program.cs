using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CallWcfServiceDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Initilize

            Weather.WeatherWebService w = new Weather.WeatherWebService();

            int[] validInfoIndex = new int[13] { 0, 1, 5, 6, 7, 10, 11, 12, 13, 14, 17, 18, 19 };
            string[] a = w.getSupportProvince();
            string[] cityArr = w.getSupportCity(Constants.PROVINCE_JIANGSU);

            Console.WriteLine("This is a weather webservice demo for trainee!");
            Console.WriteLine("In this case, we take Jiangsu Province for example.");
            Console.WriteLine("City list is as below, Here we go!");
            //Print city list
            for (int i = 0; i < cityArr.Length; i++)
            {
                Console.Write(cityArr[i] + "\t");
                if (0 == (i + 1) % 5 || i == cityArr.Length - 1)
                {
                    Console.WriteLine();
                }
            }

            #endregion
            
            while (true)
            {
                Console.ResetColor();
                Console.Write("Please input the chinese name or city code to get weather info : ");
                bool hasError = true;

                #region Logic

                string cityName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(cityName) &&
                   (Regex.IsMatch(cityName, Constants.REGULAR_ALL_NUMBER) ||
                    Regex.IsMatch(cityName, Constants.REGULAR_ALL_CHINESE_CHARACTERS))
                   )
                {
                    string[] weatherInfo = w.getWeatherbyCityName(cityName);

                    if (null != weatherInfo &&
                        weatherInfo.Length > 0 &&
                        !Constants.EMPTY_RESULT.Equals(weatherInfo[0]))
                    {
                        hasError = false;
                        for (int i = 0; i < weatherInfo.Length; i++)
                        {
                            if (validInfoIndex.Contains(i))
                            {
                                Console.WriteLine(weatherInfo[i]);
                            }
                        }
                    }
                }

                #endregion

                #region PrintErrorMessage

                if (hasError)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(string.Format(Constants.ERROR_MESSAGE, cityName));
                }

                #endregion
            }
        }

    }
}
