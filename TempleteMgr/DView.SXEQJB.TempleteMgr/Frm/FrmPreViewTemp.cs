//created by lib
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DView.SXEQJB.TempleteMgr.Dal;
using System.IO;

namespace DView.SXEQJB.TempleteMgr
{
    /// <summary>
    /// Ԥ��wordģ���ĵ�
    /// </summary>
    public partial class FrmPreViewTemp : DevExpress.XtraEditors.XtraForm
    {
        #region ˽�г�Ա����

        /// <summary>
        /// ģ�������
        /// </summary>
        private TempleteMgr _tempMgr = new TempleteMgr();
        /// <summary>
        /// ģ���fguid
        /// </summary>
        private string _fguid;
        /// <summary>
        /// ģ���ļ�����ȫ·�����������ʱĿ¼��
        /// </summary>
        private string _fileName;

        #endregion

        #region ���캯��
        public FrmPreViewTemp()
        {
            InitializeComponent();
            axFramerControlPreView.Titlebar = false;
            axFramerControlPreView.Toolbars = false;
            axFramerControlPreView.Menubar = false;
            this.Visible = false;
        }
        #endregion


        #region UI�ؼ��¼�����
        private void FrmPreViewTemp_Load(object sender, EventArgs e)
        {
            this.loadDoc();
        }

        private void FrmPreViewTemp_Shown(object sender, EventArgs e)
        {
            this.axFramerControlPreView.PrintPreview();
            this.Visible = true;
        }

        private void FrmPreViewTemp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.deleteTempFile();
        }
        #endregion
        
        /// <summary>
        /// ���ü���Ԥ��ģ���fguid
        /// </summary>
        /// <param name="fguid"></param>
        public void SetFguid(string fguid)
        {
            this._fguid = fguid;
        }

        /// <summary>
        /// ɾ����ʱ�ļ�
        /// </summary>
        private void deleteTempFile()
        {
            //System.Net.WebRequestMethods.File
            //ɾ����ʱ�ļ�
            File.Delete(this._fileName);
        }

        /// <summary>
        /// ����doc�ļ���Ԥ������
        /// </summary>
        private void loadDoc()
        {
            try
            {
                SXEQ_JBMB model = new SXEQ_JBMB();
                this._fileName = this._tempMgr.GetWord(this._fguid, out model);
                object readStyle = true;
                this.axFramerControlPreView.Open(this._fileName, readStyle, "Word.Document", "", "");
                this.Text = model.name + " - ģ��Ԥ��";
            }
            catch (Exception ex)
            {
                string info = string.Format(@"����word�ļ�ʧ�ܣ�����ԭ��\r\n�ٱ���û�а�װoffice������
                    �ڱ�������װ��wsp��������ͬʱװ��office��wps���������б�����\r\n{0}", ex);
                XtraMessageBox.Show(info, "����", MessageBoxButtons.OK);      
            }
        }
        
    }
}