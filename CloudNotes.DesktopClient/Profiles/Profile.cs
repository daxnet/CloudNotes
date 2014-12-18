using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CloudNotes.DesktopClient.Profiles
{
    [XmlRoot("profiles")]
    public class Profile
    {
        [XmlArray("userProfiles")]
        [XmlArrayItem("userProfile")]
        public List<UserProfile> UserProfiles { get; set; }

        [XmlArray("serverProfiles")]
        [XmlArrayItem("serverProfile")]
        public List<ServerProfile> ServerProfiles { get; set; }

        public Profile()
        {
            this.UserProfiles = new List<UserProfile>();
            this.ServerProfiles = new List<ServerProfile>();
        }

        public static Profile Load(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var xmlSerializer = new XmlSerializer(typeof(Profile));
                return (Profile)xmlSerializer.Deserialize(stream);
            }
        }

        public static void Save(string fileName, Profile profile)
        {
            using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var xmlSerializer = new XmlSerializer(typeof(Profile));
                xmlSerializer.Serialize(stream, profile);
            }
        }
    }
}
