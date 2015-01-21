﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Data;


namespace WebChat.Common.Models
{
    public class ChatRoomGridModel : BaseModel

    {
        public  List<tblChatRoom>  ChatRoomList{ get; set; }

        //public DomainBEList Domains { get; set; }


        //public SelectList DomainsSelectList
        //{
        //    get { return new SelectList(Domains, "DomainId", "DomainName");}

             
        //}

        
    }

    public class ChatRoomModel
    {
        
        

        public String Name { get; set; }
        public tblChatRoom ChatRoom { get; set; }

        

        public String ClientName { get; set; }
        public String ClientEmail{ get; set; }
        public Int32 ChatConfigId { get; set; }
        

    }
     public class ChatRoomCreationModel
    {

         public Guid? ChatConfigId { get; set; }
        public String Phone { get; set; }
        public String InitialMessage { get; set; }
         public Guid ChatRoomID { get; set; }

        public String ClientName { get; set; }
        public String ClientEmail { get; set; }
    }

}