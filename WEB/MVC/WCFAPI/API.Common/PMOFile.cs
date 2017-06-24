using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace API.Common.BE
{
    [XmlRoot("PMOList"), SerializableAttribute]
    public class PMOFileList : List<PMOFile>
    { }
    public class PMOFile 
    {
        /// <summary>
        /// 
        /// </summary>
        public global::System.String Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
        }

        private global::System.String _Code;



        /// <summary>
        /// 
        /// </summary>
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        private global::System.String _Description;
        public bool HasChild { get; set; }

        public global::System.String ParentCode
        {
            get
            {
                return _ParentCode;
            }
            set
            {
                _ParentCode = value;
            }
        }

        private global::System.String _ParentCode;

        public int Id { get; set; }

        public int Type { get; set; }

        [XmlIgnore()]
        public Boolean Checked { get; set; }
    }
}
