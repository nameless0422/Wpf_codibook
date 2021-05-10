using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using codibook.MVVM.Model;
using Newtonsoft.Json;

namespace codibook.MVVM.ViewModel
{
    public class WeatherAPI : INotifyPropertyChanged
    {
        public const string API_KEY = "d2wIDf8yoetktCQH1M68MZakZUgM5HSxP2%2BRyIxIcPEsCqYV81A9kYWkIKnA7m1B8jRAy2eDpvAgh%2BFPc7xWUw%3D%3D";
        public const string BASE_URL = "http://apis.data.go.kr/1360000/VilageFcstInfoService/getVilageFcst?serviceKey={0}&pageNo=1&numOfRows=200&dataType=JSON&base_date={1}&base_time={2}&nx={3}&ny={4}";
        protected KakaoLocal kakaoLocal;

        WeatherModel Weather_Model;

        string cityname = "";

        public WeatherAPI()
        {
            kakaoLocal = new KakaoLocal();
            cityname = "전북대학교"; // config 파일에 저장해두기
            Weather_Model = OrganizeWeatherModel(GetWetherInformation(cityname));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        //공공 API 호출밑 WeatherModel 컨버트
        public WeatherModel GetWetherInformation(string cityname)
        {

            WeatherModel result = new WeatherModel();

            if (cityname.Length == 0)
            {
                return result;
            }
            //현재 날짜와 시간을 바탕으로 데이터 호출
            int time = int.Parse(DateTime.Now.ToString("HH"));
            string nowDate = DateTime.Now.ToString("yyyyMMdd");

            string base_time = "0200";


            List<int> xy = kakaoLocal.kakao(cityname);

            string url = string.Format(BASE_URL, API_KEY, nowDate, base_time, xy[0], xy[1]);

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url);
                string json = response.Result.Content.ReadAsStringAsync().Result;

                result = JsonConvert.DeserializeObject<WeatherModel>(json);
            }

            return result;
        }

        //데이터 정리용
        public WeatherModel OrganizeWeatherModel(WeatherModel model)
        {
            WeatherModel result = new WeatherModel();
            int time = int.Parse(DateTime.Now.AddHours(-1).ToString("HH"));
            string Time;
            switch (time)
            {
                case 2:
                case 3:
                case 4:
                    Time = "0200";
                    break;
                case 5:
                case 6:
                case 7:
                    Time = "0500";
                    break;
                case 8:
                case 9:
                case 10:
                    Time = "0800";
                    break;
                case 11:
                case 12:
                case 13:
                    Time = "1100";
                    break;
                case 14:
                case 15:
                case 16:
                    Time = "1400";
                    break;
                case 17:
                case 18:
                case 19:
                    Time = "1700";
                    break;
                case 20:
                case 21:
                case 22:
                    Time = "2000";
                    break;
                case 23:
                case 24:
                case 1:
                    Time = "2300";
                    break;

                default:
                    Time = "0500";
                    break;
            }
            for (int i = 0; i < model.Items.item.Count(); i++)
            {
                // 날짜가 같고 시간이 같거나, 카테고리가 TMN, TMX 라면
                if (model.Items.item[i].baseDate.Equals(DateTime.Now.ToString("yyyyMMdd")) && (model.Items.item[i].fcstTime.Equals(Time) || (model.Items.item[i].category.Equals("TMN") || model.Items.item[i].category.Equals("TMX"))))
                {
                    result.Items.item.Add(model.Items.item[i]);
                }
            }
                return result;
        }

        public class KakaoLocal
        {
            LonLatConverter lonlatconverter;
            public List<int> kakao(string input)
            {
                string site = "https://dapi.kakao.com/v2/local/search/keyword.json";

                string query = string.Format("{0}?query={1}", site, input);

                string API_KEY = "3f0e0ba6fdc9e2d30f5eefd8bc537ac6";

                string header = "KakaoAK " + API_KEY;

                WebRequest request = WebRequest.Create(query);

                request.Headers.Add("Authorization", header);



                WebResponse response = request.GetResponse();

                Stream stream = response.GetResponseStream();

                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                String json = reader.ReadToEnd();

                stream.Close();



                JavaScriptSerializer js = new JavaScriptSerializer();

                dynamic dob = js.Deserialize<dynamic>(json);

                dynamic docs = dob["documents"];

                object[] buf = docs;

                int length = buf.Length;

                string lname = docs[0]["place_name"];

                string x = docs[0]["x"];

                string y = docs[0]["y"];

                lonlatconverter = new LonLatConverter();
                Dictionary<string, double> xy = lonlatconverter.dfs_xy_conf(double.Parse(y), double.Parse(x));
                List<int> result = new List<int>();
                result.Add(int.Parse(xy["x"].ToString()));
                result.Add(int.Parse(xy["y"].ToString()));
                return result;

            }
        }

        public class LonLatConverter
        {
            // 위도 경도 좌표 변환
            double RE = 6371.00877; // 지구 반경(km)
            double GRID = 5.0; // 격자 간격(km)
            double SLAT1 = 30.0; // 투영 위도1(degree)
            double SLAT2 = 60.0; // 투영 위도2(degree)
            double OLON = 126.0; // 기준점 경도(degree)
            double OLAT = 38.0; // 기준점 위도(degree)
            double XO = 43.0; // 기준점 X좌표(GRID)
            double YO = 136.0; // 기준점 Y좌표(GRID)

            public Dictionary<string, double> dfs_xy_conf(double v1, double v2)
            {
                double DEGRAD = Math.PI / 180.0;

                double re = RE / GRID;
                double slat1 = SLAT1 * DEGRAD;
                double slat2 = SLAT2 * DEGRAD;
                double olon = OLON * DEGRAD;
                double olat = OLAT * DEGRAD;

                double sn = Math.Tan((Math.PI * 0.25f + slat2 * 0.5f)) / Math.Tan(Math.PI * 0.25f + slat1 * 0.5f);
                sn = Math.Log(Math.Cos(slat1) / Math.Cos(slat2)) / Math.Log(sn);
                double sf = Math.Tan(Math.PI * 0.25f + slat1 * 0.5f);
                sf = Math.Pow(sf, sn) * Math.Cos(slat1) / sn;
                double ro = Math.Tan(Math.PI * 0.25f + olat * 0.5f);
                ro = re * sf / Math.Pow(ro, sn);

                Dictionary<string, double> rs = new Dictionary<string, double>();
                double theta;

                rs["lat"] = v1;
                rs["lng"] = v2;
                //sn = Math.Round(sn, 5);
                var ra = Math.Tan(Math.PI * 0.25f + (v1) * DEGRAD * 0.5f);
                //ra = Math.Round(ra, 5);
                ra = (re * sf / Math.Pow(ra, sn)); // ra가 NaN 값이 됨 이거 해결해야됨 // 해결 완료
                theta = v2 * DEGRAD - olon;
                //theta = Math.Round(theta, 5);
                if (theta > Math.PI) theta -= 2.0f * Math.PI;
                if (theta < -Math.PI) theta += 2.0f * Math.PI;
                theta *= sn;
                rs["x"] = Math.Floor(ra * Math.Sin(theta) + XO + 0.5f);
                rs["y"] = Math.Floor(ro - ra * Math.Cos(theta) + YO + 0.5f);

                return rs;
            }
        }

    }
}
