using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace MCAssetsDOWNA
{
    
    public class DIcA
    {
        public System.Collections.Generic.Dictionary<string, HashAndFile> objects { get; set; }
    }
    public class HashAndFile
    {
        public string hash { get; set; }
        
    }
    public struct HastFileName
    {
        public string Filename;
        public HashAndFile hashData;

    } 
    public class Core
    {

        public string patha1; 
        public void Assets(string ver,string outpath)
        {
            string patha = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // Appdataを取得
            string patha2 = patha + "\\.minecraft\\assets\\"; //assetsディレクトリを取得
            string JSONpath = patha2 + "indexes\\" + ver + ".json"; //jsonのパスを取得
            patha1 = JSONpath;
            StreamReader sr = new StreamReader(JSONpath); //Stream作成
           
            string text = sr.ReadToEnd(); //読み込み!
            //デシリアライズ
            var deserialized = JsonConvert.DeserializeObject<DIcA>(text);
            System.Collections.Generic.Dictionary<string, HashAndFile> Jsondicto = deserialized.objects;
            List<string> keysList = new List<string>(Jsondicto.Keys);
            List<HashAndFile> valsList = new List<HashAndFile>(Jsondicto.Values);
            //構造体の作成
            HastFileName[] hastFileN = new HastFileName[keysList.Count];
            patha1 = keysList[0] + valsList[0].hash;
            //データを入れてる
            for(int i=0;i < keysList.Count; i++)
            {
                hastFileN[i].Filename = keysList[i];
                hastFileN[i].hashData = valsList[i];
            }
            
            CopyAndrename(hastFileN, outpath);
            //patha1 = text;
        
        }
        private void CopyAndrename(HastFileName[] hastfName,string outpath)
        {
            //実際の処理を行っています。
            string patha = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string patha2 = patha + "\\.minecraft\\assets\\objects\\"; //objectsディレクトリ取得
            System.IO.Directory.SetCurrentDirectory(outpath);
            string outnopath = System.IO.Directory.GetCurrentDirectory();

            foreach (HastFileName hasf in hastfName)
            {

                string hashsaisyo2 = hasf.hashData.hash.Substring(0, 2); //ハッシュファイルのディレクトリ名取得
                string path3 = patha2 + hashsaisyo2 + "\\" + hasf.hashData.hash;//実際のパスを取得
                Console.Write(path3);//表示
                Console.WriteLine();

                string outoldpath = outnopath + "\\" + hasf.Filename; //出力先のパスを取得
                string outdapath = outoldpath.Replace('/', '\\'); // /を\に置き換える
                Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(path3, outdapath, true); //コピー
                Console.Write(outdapath); //表示
                Console.WriteLine();
            }


        }
    }
}
