using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Adense.Tool.YouDaoWordBookHelper
{
    public partial class FrmYouDaoWordStyleCreator : Form
    {
        public FrmYouDaoWordStyleCreator()
        {
            InitializeComponent();
        }

        // <wordbook>
        //    <item>
        //        <word>a</word>
        //        <trans>
        //            <![CDATA[(an) art.一（个、件……）]]>
        //        </trans>
        //        <phonetic>
        //            <![CDATA[]]>
        //        </phonetic>
        //        <tags>高中词汇</tags>
        //        <progress>1</progress>
        //    </item>
        //    <item>
        //        <word></word>
        //        <trans>
        //            <![CDATA[ ]]>
        //        </trans>
        //        <phonetic>
        //            <![CDATA[]]>
        //        </phonetic>
        //        <tags>高中词汇</tags>
        //        <progress>0=1</progress>
        //    </item>
        //    <item>
        //        <word>ability</word>
        //        <trans>
        //            <![CDATA[n.能力； 才能]]>
        //        </trans>
        //        <phonetic>
        //            <![CDATA[]]>
        //        </phonetic>
        //        <tags>高中词汇</tags>
        //        <progress>0=1</progress>
        //    </item>
        //</wordbook>


//(?<Word>.+\s*)(?<Phonetic>\[.+\])(?<trans>.+)
//businessman(pl.businessmen) [ˈbɪznɪsmæn] n.商人（男）；男企业家
//或者
//(?<Word>.+\s*)(?<trans>[a-zA-Z]+.+)
//telephone-booth或telephone-box n.公用电话间

        private void btnOpen_Click(object sender, EventArgs e)
        {
            this.txtFilePath.Clear();
            this.txtBookName.Clear();
            this.txtResponse.Clear();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D:\\";//注意这里写路径时要用c:\\而不是c:\
            openFileDialog.Filter = "文本文件|*.txt";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;

            this.txtContent.Clear();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtFilePath.Text = openFileDialog.FileName;

                this.txtBookName.Text = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);

                try
                {
                    using (StreamReader read = new StreamReader(openFileDialog.FileName, Encoding.UTF8))
                    {
                        //string line;

                        //while ((line = read.ReadLine()) != null)
                        //{
                        //    txtContent.AppendText(line);
                        //}

                        txtContent.Text = read.ReadToEnd();
                        txtContent.AppendText("");
                    }
                }
                catch (Exception ex)
                {
                    this.txtResponse.Text = ex.ToString();
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.txtResponse.Clear();
            string book = this.txtContent.Text;

            string bookName = this.txtBookName.Text;

            if (string.IsNullOrEmpty(bookName))
            {
                MessageBox.Show("请输入该文件名称！", "提示");
                return;
            }

            try
            {
                var wordList = Regex.Split(book, "\n");

                var list = CreateModel(wordList);

                //SaveFileDialog sfd = new SaveFileDialog();
                ////设置文件类型
                //sfd.Filter = "有道词典生词格式（*.xml）";
                //sfd.DefaultExt = ".xml";

                ////设置默认文件类型显示顺序
                //sfd.FilterIndex = 1;

                ////保存对话框是否记忆上次打开的目录
                //sfd.RestoreDirectory = true;

                int pageSize = 5000;
                int pageTotal = (int)Math.Ceiling((decimal)list.Count / pageSize);

                if (saveFileDialogCreator.ShowDialog() == DialogResult.OK)
                {
                    for (int pageIndex = 1; pageIndex <= pageTotal; pageIndex++)
                    {
                        var pageList = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

                        var strXml = CreateXmlFile(pageList, System.IO.Path.GetFileNameWithoutExtension(bookName));

                        //点了保存按钮进入
                        //if (saveFileDialogCreator.ShowDialog() == DialogResult.OK)
                        {
                            //string fileName = this.saveFileDialogCreator.FileName + "_" + pageIndex.ToString();

                            string fileName = System.IO.Path.GetDirectoryName(this.saveFileDialogCreator.FileName) + System.IO.Path.GetFileNameWithoutExtension(this.saveFileDialogCreator.FileName) + "_" + pageIndex.ToString() +  System.IO.Path.GetExtension(this.saveFileDialogCreator.FileName);

                            using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8))
                            {
                                sw.Write(strXml);

                                //MessageBox.Show("保存成功！", "提示");
                            }
                        }
                    }
                }

                MessageBox.Show("保存成功！", "提示");
            }
            catch (Exception ex)
            {
                this.txtResponse.Text = ex.ToString();
            }
        }
        private static List<TransferModel> CreateModel(string[] wordList)
        {
            var list = new List<TransferModel>();

            foreach (var wordLine in wordList)
            {
                var matcheResult = Regex.Match(wordLine, @"(?<word>.+\s*)(?<phonetic>\[.+\])(?<trans>.+)");

                if (matcheResult.Success)
                {
                    list.Add(new TransferModel
                    {
                        Word = matcheResult.Groups["word"].Value.Trim(),
                        Phonetic = matcheResult.Groups["phonetic"].Value.Trim(),
                        Trans = matcheResult.Groups["trans"].Value.Trim(),
                    });
                }
                else
                {
                    matcheResult = Regex.Match(wordLine, @"(?<word>.+\s*)(?<trans>[a-zA-Z]+.+)");

                    if (matcheResult.Success)
                    {
                        list.Add(new TransferModel
                        {
                            Word = matcheResult.Groups["word"].Value.Trim(),
                            Trans = matcheResult.Groups["trans"].Value.Trim(),
                        });
                    }
                }
            }


            int n = list.Select(p => p.Word).Distinct().Count();

            var lst = list.GroupBy(x => x.Word).Where(x => x.Count() > 1).Select(x => x.Key).ToList();

            foreach (var word in lst)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine(n);

            return list;
        }

        private static string CreateXmlFile(List<TransferModel> list,string bookName)
        {
            if (list == null || list.Count == 0)
                return string.Empty;

            StringBuilder xmlContent = new StringBuilder(1024);
            xmlContent.AppendLine("<wordbook>");

            int count = 1;

            foreach (var item in list)
            {
                xmlContent.AppendLine(" <item>");

                xmlContent.AppendFormat("        <word>{0}</word>", item.Word);
                xmlContent.AppendLine("");
                xmlContent.Append("        <trans>");

                if (string.IsNullOrEmpty(item.Trans))
                {
                    xmlContent.Append("<![CDATA[]]>");
                }
                else
                {
                    xmlContent.AppendFormat("<![CDATA[{0}]]>", item.Trans);
                }

                xmlContent.Append("</trans>");
                xmlContent.AppendLine("");

                xmlContent.Append("        <phonetic>");

                if (string.IsNullOrEmpty(item.Phonetic))
                {
                    xmlContent.Append("<![CDATA[]]>");
                }
                else
                {
                    xmlContent.AppendFormat("<![CDATA[{0}]]>", item.Phonetic);
                }
                xmlContent.Append("</phonetic>");
                xmlContent.AppendLine("");

                if (string.IsNullOrEmpty(bookName))
                {
                    xmlContent.Append("        <tags></tags>");
                }
                else
                {
                    xmlContent.AppendFormat("        <tags>{0}</tags>", bookName);
                }

                xmlContent.AppendLine("");
                xmlContent.AppendFormat("        <progress>{0}</progress>",count);

                xmlContent.AppendLine(" </item>");

                count++;
            }

            xmlContent.AppendLine("</wordbook>");

            return xmlContent.ToString();
        }

        private void FrmYouDaoWordStyleCreator_Load(object sender, EventArgs e)
        {
            //设置文件类型
            this.saveFileDialogCreator.Filter = "有道词典生词格式（*.xml）|*.xml|文本文件（*.txt）|*.txt|所有文件(*.*)|*.*";
            this.saveFileDialogCreator.DefaultExt = ".txt";

            //设置默认文件类型显示顺序
            this.saveFileDialogCreator.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录
            this.saveFileDialogCreator.RestoreDirectory = true;
        }
    }
}
