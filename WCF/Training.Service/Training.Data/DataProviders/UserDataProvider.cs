using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Training.Data.Entities;

namespace Training.Data.Providers
{
    public class UserDataProvider : IUserDataService
    {
        public void AddUser(UserEntity user)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(Constants.USER_XML_FILE_NAME))
            {
                xmlDoc.Load(Constants.USER_XML_FILE_NAME);
            }
            else
            {
                XmlNode header = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
                xmlDoc.AppendChild(header);
                XmlNode usersNode = xmlDoc.CreateElement(Constants.USER_ROOT);
                xmlDoc.AppendChild(usersNode);
            }
            XmlNode userRoot = xmlDoc.SelectSingleNode(Constants.USER_ROOT);
            XmlNode userNode = xmlDoc.CreateElement(Constants.USER_NODE);
            userRoot.AppendChild(userNode);

            CreateNode(xmlDoc, userNode, Constants.USER_USER_ID, user.UserId.ToString());
            CreateNode(xmlDoc, userNode, Constants.USER_FIRST_NAME, user.FirstName);
            CreateNode(xmlDoc, userNode, Constants.USER_LAST_NAME, user.LastName);
            CreateNode(xmlDoc, userNode, Constants.USER_GENDER, user.Gender);
            CreateNode(xmlDoc, userNode, Constants.USER_MOBILE, user.Mobile);

            xmlDoc.Save(Constants.USER_XML_FILE_NAME);
        }

        public IList<UserEntity> GetAllUsers()
        {
            IList<UserEntity> userList = new List<UserEntity>();

            if (File.Exists(Constants.USER_XML_FILE_NAME))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Constants.USER_XML_FILE_NAME);
                XmlNode userRoot = xmlDoc.SelectSingleNode(Constants.USER_ROOT);
                XmlNodeList rootList = userRoot.SelectNodes(Constants.USER_NODE);
                foreach (XmlNode node in rootList)
                {
                    UserEntity user = new UserEntity();

                    user.UserId = int.Parse(node.SelectSingleNode(Constants.USER_USER_ID).InnerText);
                    user.FirstName = node.SelectSingleNode(Constants.USER_FIRST_NAME).InnerText;
                    user.LastName = node.SelectSingleNode(Constants.USER_LAST_NAME).InnerText;
                    user.Gender = node.SelectSingleNode(Constants.USER_GENDER).InnerText;
                    user.Mobile = node.SelectSingleNode(Constants.USER_MOBILE).InnerText;

                    userList.Add(user);
                }
            }

            return userList;
        }

        /// <summary>
        /// Create Xml document node
        /// </summary>
        private void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string key, string value)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, key, null);
            node.InnerText = value;
            parentNode.AppendChild(node);
        }

    }
}
