using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model
{
    [Serializable]
    static class DAL
    {
        private static readonly string _FILE_PATH = "infoLista.bin";      //refrens https://www.youtube.com/watch?v=URw86vBWeGE

        private static List<Player> memberList = new List<Player>();

        public static void SaveToFile()                                                 // referens för användning av Serialized 
        {
            using (FileStream fileStream = new FileStream(_FILE_PATH, FileMode.OpenOrCreate))             // object som ska sparas i fil
            {
                BinaryFormatter binFormatter = new BinaryFormatter();
                binFormatter.Serialize(fileStream, memberList);
            }
        }
        public static void removeMember(int choice)
        {
            memberList.RemoveAt(choice);
        }
        public static void AddMemberToList(Player member)
        {
            memberList.Add(member);
        }
        public static IReadOnlyCollection<Player> getMemberList()
        {
            return memberList.AsReadOnly();
        }
        public static List<Player> Initialize()
        {
            memberList = LoadFromFile();
            return memberList;
        }
        public static List<Player> LoadFromFile()
        {
            FileStream fileStream = null;
            List<Player> loadedList = null;
            FileStream file = new FileStream(_FILE_PATH, FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter binFormatter = new BinaryFormatter();
            try
            {
                loadedList = (List<Player>)binFormatter.Deserialize(file);
            }
            catch (Exception e)
            {
                Console.Write("Error occurred while deserializing {0}", _FILE_PATH);
                loadedList = new List<Player>();
            }
            file.Close();
            return loadedList;
        }

      
    }
}
