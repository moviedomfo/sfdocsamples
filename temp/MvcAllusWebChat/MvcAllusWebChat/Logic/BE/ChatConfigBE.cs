﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a allus Code Generator.
//     Runtime Version: 1.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//</auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Fwk.Bases;

namespace WebChat.Common.BE
{
   
	[XmlRoot("ChatConfigList"), SerializableAttribute]
    public class ChatConfigList : Entities<ChatConfigBE>
    {}
    
    [XmlInclude(typeof(ChatConfigBE)), Serializable]
    public class ChatConfigBE:Entity
    {
        #region [Private Members]
                   private System.Int32 _ChatConfigId;

           private System.String _ChatConfigName;

           private System.DateTime _ChatConfigCreated;

           private Guid _ChatConfigGuid;

           private System.Int32? _ChatMailSenderId;

           private System.Boolean _ChatConfigDefault;

           private System.Boolean _EmailAvailable;

           private System.String _ChatSurveyConfigText;

           private System.String _ChatSurveyConfigURL;

           private System.Int32? _ChatSurveyConfigId;
        

        #endregion
             
        #region [Properties]
        	#region [ChatConfigId]
	public System.Int32 ChatConfigId
	{
		get { return _ChatConfigId; }
		set { _ChatConfigId = value;}
	}
	#endregion


	#region [ChatConfigName]
	public System.String ChatConfigName
	{
		get { return _ChatConfigName; }
		set { _ChatConfigName = value;}
	}
	#endregion


	#region [ChatConfigCreated]
	public System.DateTime ChatConfigCreated
	{
		get { return _ChatConfigCreated; }
		set { _ChatConfigCreated = value;}
	}
	#endregion


	#region [ChatConfigGuid]
	public Guid ChatConfigGuid
	{
		get { return _ChatConfigGuid; }
		set { _ChatConfigGuid = value;}
	}
	#endregion


	#region [ChatMailSenderId]
	public System.Int32? ChatMailSenderId
	{
		get { return _ChatMailSenderId; }
		set { _ChatMailSenderId = value;}
	}
	#endregion


	#region [ChatConfigDefault]
	public System.Boolean ChatConfigDefault
	{
		get { return _ChatConfigDefault; }
		set { _ChatConfigDefault = value;}
	}
	#endregion


	#region [ChatConfigTimeOut]
	public System.Double? ChatConfigTimeOut {get;set;}
	
	#endregion

    #region [EmailAvailable]
    public System.Boolean EmailAvailable { get; set; }

    #endregion

    #region [ChatSurveyConfigText]
    public System.String ChatSurveyConfigText { get; set; }

    #endregion


    #region [ChatSurveyConfigURL]
    public System.String ChatSurveyConfigURL { get; set; }

    #endregion

    #region [ChatSurveyConfigId]
    public System.Int32? ChatSurveyConfigId { get; set; }

    #endregion
        

        #endregion
 
    }
    

}
         

   
