using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsClub.Common.BE
{
    public  class PersonFullViewBE
    {
        public System.String Name{get;set;}
        public System.Int32 PersonId { get; set; }
        public System.String Lastname { get; set; }
        public System.String DocNumber { get; set; }
        

        

    }
    public partial class PersonFullViewBE3
    {
        #region [Private Members]
        private System.Int32 _MaritalStatusId;

        private System.Int32 _FamilyGroupMemberType;

        private System.Int32? _FamilyGroupId;

        private System.Boolean _IsMember;

        private Guid? _LastAccessUserId;

        private System.DateTime? _LastAccessTime;

        private System.String _ZipCode;

        private System.String _City;

        private System.String _Province;

        private System.String _Phone2;

        private System.String _Phone1;

        private System.String _mail;

        private System.String _Neighborhood;

        private System.Int32? _CityId;

        private System.Int32? _ProvinceId;

        private System.Int32? _CountryId;

        private System.String _Floor;

        private System.Int32? _StreetNumber;

        private System.String _Street;

        private System.Boolean _IsUserActive;

        private System.Byte[] _Photo;

        private System.DateTime _DateOfBirth;

        private System.DateTime? _CreatedDate;

        private System.Int32 _Sex;

        private System.String _Name;

        private System.String _Lastname;

        private System.String _DocNumber;

        private System.String _DocType;

        private Guid? _UserId;

        private System.String _FamilyGroupName;

        private System.Int32 _PersonId;

        private System.Int32? _MemberState;

        private System.Int32? _MemberCategoryCode;


        #endregion

        #region [Properties]

        #region [MaritalStatusId]
        public System.Int32 MaritalStatusId
        {
            get { return _MaritalStatusId; }
            set { _MaritalStatusId = value; }
        }
        #endregion


        #region [FamilyGroupMemberType]
        public System.Int32 FamilyGroupMemberType
        {
            get { return _FamilyGroupMemberType; }
            set { _FamilyGroupMemberType = value; }
        }
        #endregion


        #region [FamilyGroupId]
        public System.Int32? FamilyGroupId
        {
            get { return _FamilyGroupId; }
            set { _FamilyGroupId = value; }
        }
        #endregion


        #region [IsMember]
        public System.Boolean IsMember
        {
            get { return _IsMember; }
            set { _IsMember = value; }
        }
        #endregion


        #region [LastAccessUserId]
        public Guid? LastAccessUserId
        {
            get { return _LastAccessUserId; }
            set { _LastAccessUserId = value; }
        }
        #endregion


        #region [LastAccessTime]
        public System.DateTime? LastAccessTime
        {
            get { return _LastAccessTime; }
            set { _LastAccessTime = value; }
        }
        #endregion


        #region [ZipCode]
        public System.String ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }
        #endregion


        #region [City]
        public System.String City
        {
            get { return _City; }
            set { _City = value; }
        }
        #endregion


        #region [Province]
        public System.String Province
        {
            get { return _Province; }
            set { _Province = value; }
        }
        #endregion


        #region [Phone2]
        public System.String Phone2
        {
            get { return _Phone2; }
            set { _Phone2 = value; }
        }
        #endregion


        #region [Phone1]
        public System.String Phone1
        {
            get { return _Phone1; }
            set { _Phone1 = value; }
        }
        #endregion


        #region [mail]
        public System.String mail
        {
            get { return _mail; }
            set { _mail = value; }
        }
        #endregion


        #region [Neighborhood]
        public System.String Neighborhood
        {
            get { return _Neighborhood; }
            set { _Neighborhood = value; }
        }
        #endregion


        #region [CityId]
        public System.Int32? CityId
        {
            get { return _CityId; }
            set { _CityId = value; }
        }
        #endregion


        #region [ProvinceId]
        public System.Int32? ProvinceId
        {
            get { return _ProvinceId; }
            set { _ProvinceId = value; }
        }
        #endregion


        #region [CountryId]
        public System.Int32? CountryId
        {
            get { return _CountryId; }
            set { _CountryId = value; }
        }
        #endregion


        #region [Floor]
        public System.String Floor
        {
            get { return _Floor; }
            set { _Floor = value; }
        }
        #endregion


        #region [StreetNumber]
        public System.Int32? StreetNumber
        {
            get { return _StreetNumber; }
            set { _StreetNumber = value; }
        }
        #endregion


        #region [Street]
        public System.String Street
        {
            get { return _Street; }
            set { _Street = value; }
        }
        #endregion


        #region [IsUserActive]
        public System.Boolean IsUserActive
        {
            get { return _IsUserActive; }
            set { _IsUserActive = value; }
        }
        #endregion


        #region [Photo]
        [System.Xml.Serialization.XmlElementAttribute("Photo", DataType = "[SCHEMATYPENAME]")]
        public Byte[] Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
        }
        #endregion


        #region [DateOfBirth]
        public System.DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }
        #endregion


        #region [CreatedDate]
        public System.DateTime? CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        #endregion


        #region [Sex]
        public System.Int32 Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        #endregion


        #region [Name]
        public System.String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        #endregion


        #region [Lastname]
        public System.String Lastname
        {
            get { return _Lastname; }
            set { _Lastname = value; }
        }
        #endregion


        #region [DocNumber]
        public System.String DocNumber
        {
            get { return _DocNumber; }
            set { _DocNumber = value; }
        }
        #endregion


        #region [DocType]
        public System.String DocType
        {
            get { return _DocType; }
            set { _DocType = value; }
        }
        #endregion


        #region [UserId]
        public Guid? UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        #endregion


        #region [FamilyGroupName]
        public System.String FamilyGroupName
        {
            get { return _FamilyGroupName; }
            set { _FamilyGroupName = value; }
        }
        #endregion


        #region [PersonId]
        public System.Int32 PersonId
        {
            get { return _PersonId; }
            set { _PersonId = value; }
        }
        #endregion


        #region [MemberState]
        public System.Int32? MemberState
        {
            get { return _MemberState; }
            set { _MemberState = value; }
        }
        #endregion


        #region [MemberCategoryCode]
        public System.Int32? MemberCategoryCode
        {
            get { return _MemberCategoryCode; }
            set { _MemberCategoryCode = value; }
        }
        #endregion



        #endregion

    }
}