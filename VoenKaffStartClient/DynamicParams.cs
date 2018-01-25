using System;
using System.IO;
using System.Xml.Serialization;

namespace VoenKaffServer
{
    public class DynamicParams
    {
        string Path = "settingsClient.ini"; //Имя файла.

        // С помощью конструктора записываем пусть до файла и его имя.
        public DynamicParams()
        {
            if (!File.Exists(Path))
            {
                File.Create(Path);
            }
        }

        public class Settings
        {
            public string Ip { get; set; } = "127.0.0.1";
            public int Port { get; set; } = 8080;
        }


        //Читаем ini-файл и возвращаем значение указного ключа из заданной секции.
        public Settings Get()
        {
            return ReadFile();
        }

        private Settings ReadFile()
        {
            try
            {
                using (var stream = new FileStream(Path, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    var iniSet = (Settings)serializer.Deserialize(stream);
                    return iniSet;
                }
            }
            catch (Exception)
            {
                return new Settings();
            }
        }
        //Записываем в ini-файл. Запись происходит в выбранную секцию в выбранный ключ.
        public void SetIp(string value)
        {
            var iniFile = ReadFile();
            iniFile.Ip = value;
            using (var stream = new FileStream(Path, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                serializer.Serialize(stream, iniFile);
            }
        }

        public void SetPort(int value)
        {
            try
            {
                var iniFile = ReadFile();
                iniFile.Port = value;
                using (var stream = new FileStream(Path, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    serializer.Serialize(stream, iniFile);
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
