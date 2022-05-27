using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_Web.DTO
{
    public class User
    {
        private string sUserName;

        public string sUSERNAME
        {
            get { return sUserName; }
            set { sUserName = value; }
        }

        private string sPassWord;

        public string sPASSWORD
        {
            get { return sPassWord; }
            set { sPassWord = value; }
        }

        private string sHoTen;

        public string sHOTEN
        {
            get { return sHoTen; }
            set { sHoTen = value; }
        }

        private int iType;

        public int iTYPE
        {
            get { return iType; }
            set { iType = value; }
        }

        private string sMoTa;

        public string sMOTA
        {
            get { return sMoTa; }
            set { sMoTa = value; }
        }
    }
}