using System;
using System.IO;
using System.IO.Packaging;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Threading;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for PrintPreviewWindow.xaml
    /// </summary>
    public partial class PrintPreviewWindow : Window
    {
        private delegate void LoadXpsMethod();
        //private readonly object m_data;
        private readonly FlowDocument m_doc;

        //public static FlowDocument LoadDocumentAndRender(string strTmplName,TabControlPage tabc)
        //{
        //    FlowDocument doc = (FlowDocument)Application.LoadComponent(new Uri(strTmplName, UriKind.RelativeOrAbsolute));
        //    //((OrderDocument)doc).TabPage = tabc;
        //    ((OrderDocument)doc).Initialize();
        //    //doc.PagePadding = new Thickness(45,50,70,0);
        //    doc.PagePadding = new Thickness(0,100,0,50);
        //    //doc.DataContext = data;
        //    doc.PageHeight = 1108;
        //    doc.PageWidth = 794;
        //    return doc;
        //}

        //public PrintPreviewWindow(string strTmplName, TabControlPage tabc)
        //{
        //    InitializeComponent();
        //    //m_data = data;
        //    m_doc = LoadDocumentAndRender(strTmplName, tabc);
        //    Dispatcher.BeginInvoke(new LoadXpsMethod(LoadXps), DispatcherPriority.ApplicationIdle);
        //}

        public void LoadXps()
        {
            //构造一个基于内存的xps document
            MemoryStream ms = new MemoryStream();
            Package package = Package.Open(ms, FileMode.Create, FileAccess.ReadWrite);
            Uri DocumentUri = new Uri("pack://InMemoryDocument.xps");
            PackageStore.RemovePackage(DocumentUri);
            PackageStore.AddPackage(DocumentUri, package);
            XpsDocument xpsDocument = new XpsDocument(package, CompressionOption.Fast, DocumentUri.AbsoluteUri);

            //将flow document写入基于内存的xps document中去
            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
            writer.Write(((IDocumentPaginatorSource)m_doc).DocumentPaginator);

            //获取这个基于内存的xps document的fixed document
            docViewer.Document = xpsDocument.GetFixedDocumentSequence();

            //关闭基于内存的xps document
            xpsDocument.Close();
        }
    }
}
