using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using System.Xml.Linq;

public class MyXml : MonoBehaviour
{
    

    private void Start()
    {
        WriteXml();
        //InputXml();
    }

    private void InputXml()
    {
        //*
        XDocument xdoc = new XDocument();
        XElement Persons = new XElement("GameConfig"); //创建根节点
        Persons.Add(new XElement("STR_SERVER_ADDR", "192.168.0.1")); //在ptom下再增加子节点
        Persons.Add(new XElement("STR_SERVER_PORT", "2020"));
        Persons.Add(new XElement("STR_SERVER_PORT", 5.5f));
        XElement Person2 = new XElement("Person");
        Person2.Add(new XElement("NameId", "002855"));
        Person2.Add(new XElement("Age", 25));
        Person2.Add(new XElement("Note", 9527));
        Persons.Add(Person2);
        xdoc.Add(Persons);//把根元素添加到文档中
        xdoc.Save(Application.streamingAssetsPath + "/GameConfigs.xml");//保存
        Debug.Log("GameConfigs.xml文件一生成成功！");
        //*/
        XDocument xd = XDocument.Load(Application.streamingAssetsPath + "/GameConfigs.xml");
        if (xd == null) 
        {
            Debug.LogError("Error");
        }
        foreach (XElement item in xd.Root.Descendants("Person"))//得到每一个Person节点,得到这个节点再取他的Name的这个节点的值
        {
            Debug.LogFormat("姓名：{0} 年龄：{1}", item.Element("NameId").Value, item.Element("Age").Value);//Person的节点的下得节点为Name的
        }

        foreach (XElement item in xd.Root.Descendants())//得到每一个节点,得到这个节点再取他的的这个节点的值
        {
            switch (item.Name.ToString())
            {
                case "STR_SERVER_ADDR":
                    Debug.Log("输出得到的STR_SERVER_ADDR值：" + item.Value);
                    break;
                case "NameId":
                    Debug.Log("输出得到的NameId值：" + item.Value);
                    break;
                default:
                    Debug.Log("输出得到的值：" + item.Value);
                    break;
            }
        }

    }

#if !UNITY_EDITOR

#else
    private void WriteXml()
    {
    #region 写文件一(生成节点性质的)
        XDocument xdoc = new XDocument();
        XElement Persons = new XElement("Persons");
        XElement Peorson1 = new XElement("Person"); //增加一个Person节点
        Peorson1.Add(new XElement("Name", "Tom"));//在ptom下再增加子节点
        Peorson1.Add(new XElement("Age", "18"));
        Persons.Add(Peorson1);
        XElement Person2 = new XElement("Person");
        Person2.Add(new XElement("Name", "Jack"));
        Person2.Add(new XElement("Age", "20"));
        Persons.Add(Person2);

        xdoc.Add(Persons);//把根元素添加到文档中
        xdoc.Save("myXml1.xml");//保存

        Debug.Log("xml文件一生成成功！");

        /* 生成myXml.xml内容如下  
         * 
            <?xml version="1.0" encoding="utf-8"?>
            <Persons>
              <Person>
                <Name>Tom</Name>
                <Age>18</Age>
              </Person>
              <Person>
                <Name>Jack</Name>
                <Age>20</Age>
              </Person>
            </Persons>
         */
    #endregion

    #region 读XML 读取节点格式的值
        XDocument xd = XDocument.Load("myXml1.xml");
        foreach (XElement item in xd.Root.Descendants("Person"))//得到每一个Person节点,得到这个节点再取他的Name的这个节点的值
        {
            Debug.LogFormat("姓名：{0} 年龄：{1}", item.Element("Name").Value, item.Element("Age").Value);//Person的节点的下得节点为Name的
        }
    #endregion

    #region 带节点格式的XML查找数据
        var result = xd.Descendants("Person")
             .Where(p => p.Element("Name").Value.ToLower().Equals("tom"))
             .Select(p => new { name = p.Element("Name").Value, age = p.Element("Age").Value }).FirstOrDefault(); //若要筛选就用上这个语句  
        Debug.LogFormat("姓名：{0} 年龄：{1}", result.name, result.age);
    #endregion

    #region 写文件二(生成属性性质的)
        XDocument xdoc1 = new XDocument();
        XElement Pers = new XElement("Persons");
        XElement p1 = new XElement("Person");
        p1.Add(new XAttribute("Name", "tom"));//添加XAttribute就生成属性
        p1.Add(new XAttribute("Age", "18"));
        Pers.Add(p1);

        XElement p2 = new XElement("Person");
        p2.Add(new XAttribute("Name", "jack"));
        p2.Add(new XAttribute("Age", "20"));
        Pers.Add(p2);

        xdoc1.Add(Pers);//把根元素添加到文档中
        xdoc1.Save("myXml2.xml");//保存

        Debug.Log("xml文件二生成成功！");

        /* 生成myXml.xml内容如下  
         * 
            <?xml version="1.0" encoding="utf-8"?>
            <Persons>
              <Person Name="tom" Age="18" />
              <Person Name="jack" Age="20" />
            </Persons>
         */
    #endregion

    #region 读XML 读取属性格式的值
        XDocument xd1 = XDocument.Load("myXml2.xml");
        foreach (XElement item in xd1.Root.Descendants("Person"))//得到每一个Person节点,得到这个节点再取他的Name的这个节点的值
        {
            Debug.LogFormat("姓名：{0} 年龄：{1}", item.Attribute("Name").Value, item.Attribute("Age").Value);//Person的节点的下得节点为Name的
        }
    #endregion

    #region 带属性格式的XML查找数据
        var result1 = xd1.Descendants("Person")
             .Where(p => p.Attribute("Name").Value.Equals("tom"))
             .Select(p => new { name = p.Attribute("Name").Value, age = p.Attribute("Age").Value }).FirstOrDefault(); //若要筛选就用上这个语句  
        Debug.LogFormat("姓名：{0} 年龄：{1}", result1.name, result1.age);
    #endregion
    }

#endif


}