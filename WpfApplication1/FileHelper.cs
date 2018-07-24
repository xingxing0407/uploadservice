using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Xps;
using System.Windows.Documents;
using System.IO;
using System.Xaml;
using System.Windows.Markup;
using System.Windows.Xps.Packaging;
using System.Windows;
using System.IO.Packaging;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication1
{
    public class FileHelper
    {
        public static string GetXPSFromDialog(bool isSaved, string strType)
        {
            if (isSaved)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "XPS Document files (*.xps)|*.xps|Txt Document files(*.txt)|*.txt";
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == true)
                {
                    return saveFileDialog.FileName;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return string.Format("{0}\\" + strType + ".xps", Environment.CurrentDirectory);
            }
        }

        public static string OpenXPSFileFromDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XPS Document Files(*.xps)|*.xps";

            if (openFileDialog.ShowDialog() == true)
                return openFileDialog.FileName;
            else
                return null;
        }

        //FixedPage
        public static string SaveXPS(FlowDocument page, bool isSaved, string strType)
        {
            string containerName = GetXPSFromDialog(isSaved, strType);
            if (containerName != null)
            {
                try
                {
                    File.Delete(containerName);
                }
                catch (Exception e)
                {
                    MessageWindow2.Show(e.Message);
                }
                XpsDocument _xpsDocument = new XpsDocument(containerName, FileAccess.Write);
                XpsDocumentWriter xpsdw = XpsDocument.CreateXpsDocumentWriter(_xpsDocument);
                //xpsdw.Write(page);//写入XPS文件
                xpsdw.Write(((IDocumentPaginatorSource)page).DocumentPaginator);
                _xpsDocument.Close();
            }
            return containerName;
        }

        public static string SaveXPS1(Visual page, bool isSaved, string strType)
        {
            //bool isExit = false;
            //DependencyObject parent = page.Parent;
            //if (parent != null)
            //{
            //    if (strType == "printPage" && page.Name == "printPage")
            //    {
            //        isExit = true;
            //        return true;
            //    }
            //    if (strType == "w2" && page.Name == "w2")
            //    {
            //        isExit = true;
            //        return true;
            //    }
            //    return false;
            //}
            //else 
            //{
            //    if (!isExit)
            //    {
            //创建一个文档
            //FixedDocument fixedDoc = new FixedDocument();
            //fixedDoc.DocumentPaginator.PageSize = new Size(96 * 8.5, 96 * 11);

            //PageContent pageContent = new PageContent();
            //page.Name = strType;
            //((IAddChild)pageContent).AddChild(page);
            //fixedDoc.Pages.Add(pageContent);//将对象加入到当前文档中


            string containerName = GetXPSFromDialog(isSaved, strType);
            if (containerName != null)
            {
                try
                {
                    File.Delete(containerName);
                }
                catch (Exception e)
                {
                  //  MessageWindow3.Show(e.Message);
                }

                XpsDocument _xpsDocument = new XpsDocument(containerName, FileAccess.Write);
                XpsDocumentWriter xpsdw = XpsDocument.CreateXpsDocumentWriter(_xpsDocument);
                //VisualsToXpsDocument xpsdw1 = (VisualsToXpsDocument)xpsdw.CreateVisualsCollator();


                xpsdw.Write(page);//写入XPS文件
                //xpsdw1.Write(page);
                //xpsdw1.EndBatchWrite();
                //xpsdw.Write(((IDocumentPaginatorSource)page).DocumentPaginator);


                _xpsDocument.Close();
               
            }
            return containerName;
            //}
            //else
            //{
            //    return false;
            //}
            //}
        }
        public static string SaveXPS2(Visual page, Visual page1, bool isSaved, string strType)
        {
       

            string containerName = GetXPSFromDialog(isSaved, strType);
            if (containerName != null)
            {
                try
                {
                    File.Delete(containerName);
                }
                catch (Exception e)
                {
                    //  MessageWindow3.Show(e.Message);
                }

                XpsDocument _xpsDocument = new XpsDocument(containerName, FileAccess.Write);
                XpsDocumentWriter xpsdw = XpsDocument.CreateXpsDocumentWriter(_xpsDocument);
                VisualsToXpsDocument xpsdw1 = (VisualsToXpsDocument)xpsdw.CreateVisualsCollator();

                xpsdw1.Write(page);
                xpsdw1.Write(page1);//写入XPS文件
                //xpsdw1.Write(page);
                xpsdw1.EndBatchWrite();
                //xpsdw.Write(((IDocumentPaginatorSource)page).DocumentPaginator);
                _xpsDocument.Close();
            }
            return containerName;
            //}
            //else
            //{
            //    return false;
            //}
            //}
        }
        static XpsDocument xpsPackage = null;
        public static void LoadDocumentViewer(string xpsFileName, DocumentViewer viewer)
        {
            XpsDocument oldXpsPackage = xpsPackage;//保存原来的XPS包
            xpsPackage = new XpsDocument(xpsFileName, FileAccess.Read, CompressionOption.Fast);//从文件中读取XPS文档
            FixedDocumentSequence fixedDocumentSequence = xpsPackage.GetFixedDocumentSequence();//从XPS文档对象得到FixedDocumentSequence
            viewer.Document = fixedDocumentSequence as IDocumentPaginatorSource;
            if (oldXpsPackage != null)
                oldXpsPackage.Close();
            xpsPackage.Close();
        }
    }
}
