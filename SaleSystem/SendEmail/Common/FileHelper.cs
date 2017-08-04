using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class FileHelper
    {
        /// <summary>
        /// Create file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool CreateFile(string fileName)
        {
            bool result = false;
            FileStream fs = null;
            try
            {
                fs = System.IO.File.Create(fileName);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                fs.Close();
            }
            return result;
        }

        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool DeleteFile(string fileName)
        {
            bool result = false;
            try
            {
                if (File.Exists(fileName))
                {
                    File.SetAttributes(fileName, FileAttributes.Normal);
                    System.IO.File.Delete(fileName);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Create Directory
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static bool CreateDirectory(string directory)
        {
            bool result = false;
            try
            {
                Directory.CreateDirectory(directory);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Write strign to file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool Write(string fileName, string message)
        {
            bool result = false;
            StreamWriter sw = System.IO.File.AppendText(fileName);
            try
            {
                //lock (this)
                {
                    File.SetAttributes(fileName, FileAttributes.Normal);
                    sw.WriteLine(message);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sw.Close();
            }
            return result;
        }

        public static string GetContent(string filePath)
        {
            StringBuilder bodyText = new StringBuilder();
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(filePath, Encoding.UTF8);
                bodyText.Append(sr.ReadToEnd());
                sr.Close();
            }
            catch { }
            finally
            {
                if (sr != null) sr.Close();
            }
            return bodyText.ToString();
        }
    }
}
