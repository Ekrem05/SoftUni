﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, string[]fields)
        {
            StringBuilder stringBuilder= new StringBuilder();
            Type type=Type.GetType(className);
            FieldInfo[]classFields = type.GetFields(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.Static);
            Object instance=Activator.CreateInstance(type);
            stringBuilder.AppendLine($"Class under investigation: {type.Name}");

            foreach (var classField in classFields.Where(x=>fields.Contains(x.Name)))
            {
                stringBuilder.AppendLine($"{classField.Name} = {classField.GetValue(instance)}");
            }
              
            
            return stringBuilder.ToString().TrimEnd();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Type type=Type.GetType(className);
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.Static|BindingFlags.Instance);
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            foreach (var item in fields)
            {
                if (!item.IsPrivate)
                {
                    stringBuilder.AppendLine($"{item.Name} must be private!");
                }
            }
            foreach (var item in methods.Where(x => x.Name.Contains("set") || x.Name.Contains("get")))
            {

                if (item.Name.Contains("set")&&item.IsPublic)
                {
                    stringBuilder.AppendLine($"{item.Name} have to be private!");
                }
                if (item.Name.Contains("get") && item.IsPrivate)
                {
                    stringBuilder.AppendLine($"{item.Name} have to be public!");
                }
            }
            return stringBuilder.ToString().TrimEnd();
        }
        public string RevealPrivateMethods(string className)
        {
            Type type= Type.GetType(className);
            StringBuilder sb = new();
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance).Where(x => x.IsPrivate).ToArray();
            MethodInfo[] baseMethods = type.BaseType.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance).Where(x => !x.IsPublic).ToArray();

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");
            foreach (var item in methods)
            {
                sb.AppendLine(item.Name);
            }
            foreach (var item in baseMethods)
            {
                sb.AppendLine(item.Name);
            }
            return sb.ToString().TrimEnd();
        }
        public string FindGettersAndSetters(string className)
        {
            Type type = Type.GetType(className);
            StringBuilder sb = new();
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance).Where(x => x.Name.Contains("get")||x.Name.Contains("set")).ToArray();          
            foreach (var item in methods.Where(x => x.Name.Contains("get")))
            {
               
                    sb.AppendLine($"{item.Name} will return {item.ReturnType}");
              
            }
            foreach (var item in methods.Where(x => x.Name.Contains("set")))
            {
                sb.AppendLine($"{item.Name} will set field of {item.ReturnType}");
            
            }
            
              

            return sb.ToString().TrimEnd();
        }
    }
}
