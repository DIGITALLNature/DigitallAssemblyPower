using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Runtime.Serialization;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query; 
using AttributeCollection = Microsoft.Xrm.Sdk.AttributeCollection;

// ReSharper disable All
namespace dgt.Model.Dataverse
{
	/// <inheritdoc />
	/// <summary>
	/// Person with whom a business unit has a relationship, such as customer, supplier, and colleague.
	/// </summary>
	[DataContractAttribute()]
	[EntityLogicalNameAttribute("contact")]
	[System.CodeDom.Compiler.GeneratedCode("dgtp", "2023")]
    [ExcludeFromCodeCoverage]
	public partial class Contact : Entity, INotifyPropertyChanging, INotifyPropertyChanged
    {
	    #region ctor
		[DebuggerNonUserCode]
		public Contact() : this(false)
        {
        }

        [DebuggerNonUserCode]
		public Contact(bool trackChanges = false) : base(EntityLogicalName)
        {
			_trackChanges = trackChanges;
        }

        [DebuggerNonUserCode]
		public Contact(Guid id, bool trackChanges = false) : base(EntityLogicalName,id)
        {
			_trackChanges = trackChanges;
        }

        [DebuggerNonUserCode]
		public Contact(KeyAttributeCollection keyAttributes, bool trackChanges = false) : base(EntityLogicalName,keyAttributes)
        {
			_trackChanges = trackChanges;
        }

        [DebuggerNonUserCode]
		public Contact(string keyName, object keyValue, bool trackChanges = false) : base(EntityLogicalName, keyName, keyValue)
        {
			_trackChanges = trackChanges;
        }
        #endregion

		#region fields
        private readonly bool _trackChanges;
        private readonly Lazy<HashSet<string>> _changedProperties = new Lazy<HashSet<string>>();
        #endregion

        #region consts
        public const string EntityLogicalName = "contact";
        public const string PrimaryNameAttribute = "fullname";
        public const int EntityTypeCode = 2;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        [DebuggerNonUserCode]
		private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (_trackChanges)
            {
                _changedProperties.Value.Add(propertyName);
            }
        }

        [DebuggerNonUserCode]
		private void OnPropertyChanging([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanging != null) PropertyChanging.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        #endregion

		#region Attributes
		[AttributeLogicalNameAttribute("contactid")]
		public new System.Guid Id
		{
		    [DebuggerNonUserCode]
			get
			{
				return base.Id;
			}
            [DebuggerNonUserCode]
			set
			{
				ContactId = value;
			}
		}

		/// <summary>
		/// Unique identifier for address 1.
		/// </summary>
		[AttributeLogicalName("address1_addressid")]
        public Guid? Address1AddressId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Guid?>("address1_addressid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1AddressId));
                SetAttributeValue("address1_addressid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
                OnPropertyChanged(nameof(Address1AddressId));
            }
        }

		/// <summary>
		/// Unique identifier for address 2.
		/// </summary>
		[AttributeLogicalName("address2_addressid")]
        public Guid? Address2AddressId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Guid?>("address2_addressid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2AddressId));
                SetAttributeValue("address2_addressid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
                OnPropertyChanged(nameof(Address2AddressId));
            }
        }

		/// <summary>
		/// Unique identifier for address 3.
		/// </summary>
		[AttributeLogicalName("address3_addressid")]
        public Guid? Address3AddressId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Guid?>("address3_addressid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3AddressId));
                SetAttributeValue("address3_addressid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
                OnPropertyChanged(nameof(Address3AddressId));
            }
        }

		/// <summary>
		/// Unique identifier of the contact.
		/// </summary>
		[AttributeLogicalName("contactid")]
        public Guid? ContactId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Guid?>("contactid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ContactId));
                SetAttributeValue("contactid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
                OnPropertyChanged(nameof(ContactId));
            }
        }

		/// <summary>
		/// Unique identifier of the account with which the contact is associated.
		/// </summary>
		[AttributeLogicalName("accountid")]
        public EntityReference AccountId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("accountid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AccountId));
                SetAttributeValue("accountid", value);
                OnPropertyChanged(nameof(AccountId));
            }
        }

		/// <summary>
		/// Select the contact's role within the company or sales process, such as decision maker, employee, or influencer.
		/// </summary>
		[AttributeLogicalName("accountrolecode")]
        public OptionSetValue AccountRoleCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("accountrolecode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AccountRoleCode));
                SetAttributeValue("accountrolecode", value);
                OnPropertyChanged(nameof(AccountRoleCode));
            }
        }

		/// <summary>
		/// Select the primary address type.
		/// </summary>
		[AttributeLogicalName("address1_addresstypecode")]
        public OptionSetValue Address1AddressTypeCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("address1_addresstypecode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1AddressTypeCode));
                SetAttributeValue("address1_addresstypecode", value);
                OnPropertyChanged(nameof(Address1AddressTypeCode));
            }
        }

		/// <summary>
		/// Enter the location for the primary address.
		/// </summary>
		[AttributeLogicalName("address1_city")]
        public string Address1City
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_city");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1City));
                SetAttributeValue("address1_city", value);
                OnPropertyChanged(nameof(Address1City));
            }
        }

		/// <summary>
		/// Shows the complete primary address.
		/// </summary>
		[AttributeLogicalName("address1_composite")]
        public string Address1Composite
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_composite");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1Composite));
                SetAttributeValue("address1_composite", value);
                OnPropertyChanged(nameof(Address1Composite));
            }
        }

		/// <summary>
		/// Enter the country or region for the primary address.
		/// </summary>
		[AttributeLogicalName("address1_country")]
        public string Address1Country
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_country");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1Country));
                SetAttributeValue("address1_country", value);
                OnPropertyChanged(nameof(Address1Country));
            }
        }

		/// <summary>
		/// Type the county for the primary address.
		/// </summary>
		[AttributeLogicalName("address1_county")]
        public string Address1County
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_county");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1County));
                SetAttributeValue("address1_county", value);
                OnPropertyChanged(nameof(Address1County));
            }
        }

		/// <summary>
		/// Type the fax number associated with the primary address.
		/// </summary>
		[AttributeLogicalName("address1_fax")]
        public string Address1Fax
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_fax");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1Fax));
                SetAttributeValue("address1_fax", value);
                OnPropertyChanged(nameof(Address1Fax));
            }
        }

		/// <summary>
		/// Select the freight terms for the primary address to make sure shipping orders are processed correctly.
		/// </summary>
		[AttributeLogicalName("address1_freighttermscode")]
        public OptionSetValue Address1FreightTermsCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("address1_freighttermscode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1FreightTermsCode));
                SetAttributeValue("address1_freighttermscode", value);
                OnPropertyChanged(nameof(Address1FreightTermsCode));
            }
        }

		/// <summary>
		/// Type the latitude value for the primary address for use in mapping and other applications.
		/// </summary>
		[AttributeLogicalName("address1_latitude")]
        public double? Address1Latitude
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<double?>("address1_latitude");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1Latitude));
                SetAttributeValue("address1_latitude", value);
                OnPropertyChanged(nameof(Address1Latitude));
            }
        }

		/// <summary>
		/// Type the first line of the primary address.
		/// </summary>
		[AttributeLogicalName("address1_line1")]
        public string Address1Line1
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_line1");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1Line1));
                SetAttributeValue("address1_line1", value);
                OnPropertyChanged(nameof(Address1Line1));
            }
        }

		/// <summary>
		/// Type the second line of the primary address.
		/// </summary>
		[AttributeLogicalName("address1_line2")]
        public string Address1Line2
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_line2");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1Line2));
                SetAttributeValue("address1_line2", value);
                OnPropertyChanged(nameof(Address1Line2));
            }
        }

		/// <summary>
		/// Type the third line of the primary address.
		/// </summary>
		[AttributeLogicalName("address1_line3")]
        public string Address1Line3
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_line3");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1Line3));
                SetAttributeValue("address1_line3", value);
                OnPropertyChanged(nameof(Address1Line3));
            }
        }

		/// <summary>
		/// Type the longitude value for the primary address for use in mapping and other applications.
		/// </summary>
		[AttributeLogicalName("address1_longitude")]
        public double? Address1Longitude
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<double?>("address1_longitude");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1Longitude));
                SetAttributeValue("address1_longitude", value);
                OnPropertyChanged(nameof(Address1Longitude));
            }
        }

		/// <summary>
		/// Type a descriptive name for the primary address, such as Corporate Headquarters.
		/// </summary>
		[AttributeLogicalName("address1_name")]
        public string Address1Name
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_name");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1Name));
                SetAttributeValue("address1_name", value);
                OnPropertyChanged(nameof(Address1Name));
            }
        }

		/// <summary>
		/// Type the ZIP Code or postal code for the primary address.
		/// </summary>
		[AttributeLogicalName("address1_postalcode")]
        public string Address1PostalCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_postalcode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1PostalCode));
                SetAttributeValue("address1_postalcode", value);
                OnPropertyChanged(nameof(Address1PostalCode));
            }
        }

		/// <summary>
		/// Type the post office box number of the primary address.
		/// </summary>
		[AttributeLogicalName("address1_postofficebox")]
        public string Address1PostOfficeBox
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_postofficebox");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1PostOfficeBox));
                SetAttributeValue("address1_postofficebox", value);
                OnPropertyChanged(nameof(Address1PostOfficeBox));
            }
        }

		/// <summary>
		/// Type the name of the main contact at the account's primary address.
		/// </summary>
		[AttributeLogicalName("address1_primarycontactname")]
        public string Address1PrimaryContactName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_primarycontactname");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1PrimaryContactName));
                SetAttributeValue("address1_primarycontactname", value);
                OnPropertyChanged(nameof(Address1PrimaryContactName));
            }
        }

		/// <summary>
		/// Select a shipping method for deliveries sent to this address.
		/// </summary>
		[AttributeLogicalName("address1_shippingmethodcode")]
        public OptionSetValue Address1ShippingMethodCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("address1_shippingmethodcode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1ShippingMethodCode));
                SetAttributeValue("address1_shippingmethodcode", value);
                OnPropertyChanged(nameof(Address1ShippingMethodCode));
            }
        }

		/// <summary>
		/// Type the state or province of the primary address.
		/// </summary>
		[AttributeLogicalName("address1_stateorprovince")]
        public string Address1StateOrProvince
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_stateorprovince");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1StateOrProvince));
                SetAttributeValue("address1_stateorprovince", value);
                OnPropertyChanged(nameof(Address1StateOrProvince));
            }
        }

		/// <summary>
		/// Type the main phone number associated with the primary address.
		/// </summary>
		[AttributeLogicalName("address1_telephone1")]
        public string Address1Telephone1
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_telephone1");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1Telephone1));
                SetAttributeValue("address1_telephone1", value);
                OnPropertyChanged(nameof(Address1Telephone1));
            }
        }

		/// <summary>
		/// Type a second phone number associated with the primary address.
		/// </summary>
		[AttributeLogicalName("address1_telephone2")]
        public string Address1Telephone2
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_telephone2");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1Telephone2));
                SetAttributeValue("address1_telephone2", value);
                OnPropertyChanged(nameof(Address1Telephone2));
            }
        }

		/// <summary>
		/// Type a third phone number associated with the primary address.
		/// </summary>
		[AttributeLogicalName("address1_telephone3")]
        public string Address1Telephone3
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_telephone3");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1Telephone3));
                SetAttributeValue("address1_telephone3", value);
                OnPropertyChanged(nameof(Address1Telephone3));
            }
        }

		/// <summary>
		/// Type the UPS zone of the primary address to make sure shipping charges are calculated correctly and deliveries are made promptly, if shipped by UPS.
		/// </summary>
		[AttributeLogicalName("address1_upszone")]
        public string Address1UPSZone
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address1_upszone");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1UPSZone));
                SetAttributeValue("address1_upszone", value);
                OnPropertyChanged(nameof(Address1UPSZone));
            }
        }

		/// <summary>
		/// Select the time zone, or UTC offset, for this address so that other people can reference it when they contact someone at this address.
		/// </summary>
		[AttributeLogicalName("address1_utcoffset")]
        public int? Address1UTCOffset
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<int?>("address1_utcoffset");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address1UTCOffset));
                SetAttributeValue("address1_utcoffset", value);
                OnPropertyChanged(nameof(Address1UTCOffset));
            }
        }

		/// <summary>
		/// Select the secondary address type.
		/// </summary>
		[AttributeLogicalName("address2_addresstypecode")]
        public OptionSetValue Address2AddressTypeCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("address2_addresstypecode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2AddressTypeCode));
                SetAttributeValue("address2_addresstypecode", value);
                OnPropertyChanged(nameof(Address2AddressTypeCode));
            }
        }

		/// <summary>
		/// Type the city for the secondary address.
		/// </summary>
		[AttributeLogicalName("address2_city")]
        public string Address2City
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_city");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2City));
                SetAttributeValue("address2_city", value);
                OnPropertyChanged(nameof(Address2City));
            }
        }

		/// <summary>
		/// Shows the complete secondary address.
		/// </summary>
		[AttributeLogicalName("address2_composite")]
        public string Address2Composite
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_composite");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2Composite));
                SetAttributeValue("address2_composite", value);
                OnPropertyChanged(nameof(Address2Composite));
            }
        }

		/// <summary>
		/// Type the country or region for the secondary address.
		/// </summary>
		[AttributeLogicalName("address2_country")]
        public string Address2Country
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_country");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2Country));
                SetAttributeValue("address2_country", value);
                OnPropertyChanged(nameof(Address2Country));
            }
        }

		/// <summary>
		/// Type the county for the secondary address.
		/// </summary>
		[AttributeLogicalName("address2_county")]
        public string Address2County
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_county");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2County));
                SetAttributeValue("address2_county", value);
                OnPropertyChanged(nameof(Address2County));
            }
        }

		/// <summary>
		/// Type the fax number associated with the secondary address.
		/// </summary>
		[AttributeLogicalName("address2_fax")]
        public string Address2Fax
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_fax");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2Fax));
                SetAttributeValue("address2_fax", value);
                OnPropertyChanged(nameof(Address2Fax));
            }
        }

		/// <summary>
		/// Select the freight terms for the secondary address to make sure shipping orders are processed correctly.
		/// </summary>
		[AttributeLogicalName("address2_freighttermscode")]
        public OptionSetValue Address2FreightTermsCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("address2_freighttermscode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2FreightTermsCode));
                SetAttributeValue("address2_freighttermscode", value);
                OnPropertyChanged(nameof(Address2FreightTermsCode));
            }
        }

		/// <summary>
		/// Type the latitude value for the secondary address for use in mapping and other applications.
		/// </summary>
		[AttributeLogicalName("address2_latitude")]
        public double? Address2Latitude
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<double?>("address2_latitude");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2Latitude));
                SetAttributeValue("address2_latitude", value);
                OnPropertyChanged(nameof(Address2Latitude));
            }
        }

		/// <summary>
		/// Type the first line of the secondary address.
		/// </summary>
		[AttributeLogicalName("address2_line1")]
        public string Address2Line1
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_line1");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2Line1));
                SetAttributeValue("address2_line1", value);
                OnPropertyChanged(nameof(Address2Line1));
            }
        }

		/// <summary>
		/// Type the second line of the secondary address.
		/// </summary>
		[AttributeLogicalName("address2_line2")]
        public string Address2Line2
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_line2");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2Line2));
                SetAttributeValue("address2_line2", value);
                OnPropertyChanged(nameof(Address2Line2));
            }
        }

		/// <summary>
		/// Type the third line of the secondary address.
		/// </summary>
		[AttributeLogicalName("address2_line3")]
        public string Address2Line3
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_line3");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2Line3));
                SetAttributeValue("address2_line3", value);
                OnPropertyChanged(nameof(Address2Line3));
            }
        }

		/// <summary>
		/// Type the longitude value for the secondary address for use in mapping and other applications.
		/// </summary>
		[AttributeLogicalName("address2_longitude")]
        public double? Address2Longitude
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<double?>("address2_longitude");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2Longitude));
                SetAttributeValue("address2_longitude", value);
                OnPropertyChanged(nameof(Address2Longitude));
            }
        }

		/// <summary>
		/// Type a descriptive name for the secondary address, such as Corporate Headquarters.
		/// </summary>
		[AttributeLogicalName("address2_name")]
        public string Address2Name
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_name");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2Name));
                SetAttributeValue("address2_name", value);
                OnPropertyChanged(nameof(Address2Name));
            }
        }

		/// <summary>
		/// Type the ZIP Code or postal code for the secondary address.
		/// </summary>
		[AttributeLogicalName("address2_postalcode")]
        public string Address2PostalCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_postalcode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2PostalCode));
                SetAttributeValue("address2_postalcode", value);
                OnPropertyChanged(nameof(Address2PostalCode));
            }
        }

		/// <summary>
		/// Type the post office box number of the secondary address.
		/// </summary>
		[AttributeLogicalName("address2_postofficebox")]
        public string Address2PostOfficeBox
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_postofficebox");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2PostOfficeBox));
                SetAttributeValue("address2_postofficebox", value);
                OnPropertyChanged(nameof(Address2PostOfficeBox));
            }
        }

		/// <summary>
		/// Type the name of the main contact at the account's secondary address.
		/// </summary>
		[AttributeLogicalName("address2_primarycontactname")]
        public string Address2PrimaryContactName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_primarycontactname");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2PrimaryContactName));
                SetAttributeValue("address2_primarycontactname", value);
                OnPropertyChanged(nameof(Address2PrimaryContactName));
            }
        }

		/// <summary>
		/// Select a shipping method for deliveries sent to this address.
		/// </summary>
		[AttributeLogicalName("address2_shippingmethodcode")]
        public OptionSetValue Address2ShippingMethodCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("address2_shippingmethodcode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2ShippingMethodCode));
                SetAttributeValue("address2_shippingmethodcode", value);
                OnPropertyChanged(nameof(Address2ShippingMethodCode));
            }
        }

		/// <summary>
		/// Type the state or province of the secondary address.
		/// </summary>
		[AttributeLogicalName("address2_stateorprovince")]
        public string Address2StateOrProvince
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_stateorprovince");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2StateOrProvince));
                SetAttributeValue("address2_stateorprovince", value);
                OnPropertyChanged(nameof(Address2StateOrProvince));
            }
        }

		/// <summary>
		/// Type the main phone number associated with the secondary address.
		/// </summary>
		[AttributeLogicalName("address2_telephone1")]
        public string Address2Telephone1
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_telephone1");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2Telephone1));
                SetAttributeValue("address2_telephone1", value);
                OnPropertyChanged(nameof(Address2Telephone1));
            }
        }

		/// <summary>
		/// Type a second phone number associated with the secondary address.
		/// </summary>
		[AttributeLogicalName("address2_telephone2")]
        public string Address2Telephone2
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_telephone2");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2Telephone2));
                SetAttributeValue("address2_telephone2", value);
                OnPropertyChanged(nameof(Address2Telephone2));
            }
        }

		/// <summary>
		/// Type a third phone number associated with the secondary address.
		/// </summary>
		[AttributeLogicalName("address2_telephone3")]
        public string Address2Telephone3
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_telephone3");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2Telephone3));
                SetAttributeValue("address2_telephone3", value);
                OnPropertyChanged(nameof(Address2Telephone3));
            }
        }

		/// <summary>
		/// Type the UPS zone of the secondary address to make sure shipping charges are calculated correctly and deliveries are made promptly, if shipped by UPS.
		/// </summary>
		[AttributeLogicalName("address2_upszone")]
        public string Address2UPSZone
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address2_upszone");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2UPSZone));
                SetAttributeValue("address2_upszone", value);
                OnPropertyChanged(nameof(Address2UPSZone));
            }
        }

		/// <summary>
		/// Select the time zone, or UTC offset, for this address so that other people can reference it when they contact someone at this address.
		/// </summary>
		[AttributeLogicalName("address2_utcoffset")]
        public int? Address2UTCOffset
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<int?>("address2_utcoffset");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address2UTCOffset));
                SetAttributeValue("address2_utcoffset", value);
                OnPropertyChanged(nameof(Address2UTCOffset));
            }
        }

		/// <summary>
		/// Select the third address type.
		/// </summary>
		[AttributeLogicalName("address3_addresstypecode")]
        public OptionSetValue Address3AddressTypeCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("address3_addresstypecode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3AddressTypeCode));
                SetAttributeValue("address3_addresstypecode", value);
                OnPropertyChanged(nameof(Address3AddressTypeCode));
            }
        }

		/// <summary>
		/// Type the city for the 3rd address.
		/// </summary>
		[AttributeLogicalName("address3_city")]
        public string Address3City
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_city");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3City));
                SetAttributeValue("address3_city", value);
                OnPropertyChanged(nameof(Address3City));
            }
        }

		/// <summary>
		/// Shows the complete third address.
		/// </summary>
		[AttributeLogicalName("address3_composite")]
        public string Address3Composite
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_composite");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3Composite));
                SetAttributeValue("address3_composite", value);
                OnPropertyChanged(nameof(Address3Composite));
            }
        }

		/// <summary>
		/// the country or region for the 3rd address.
		/// </summary>
		[AttributeLogicalName("address3_country")]
        public string Address3Country
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_country");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3Country));
                SetAttributeValue("address3_country", value);
                OnPropertyChanged(nameof(Address3Country));
            }
        }

		/// <summary>
		/// Type the county for the third address.
		/// </summary>
		[AttributeLogicalName("address3_county")]
        public string Address3County
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_county");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3County));
                SetAttributeValue("address3_county", value);
                OnPropertyChanged(nameof(Address3County));
            }
        }

		/// <summary>
		/// Type the fax number associated with the third address.
		/// </summary>
		[AttributeLogicalName("address3_fax")]
        public string Address3Fax
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_fax");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3Fax));
                SetAttributeValue("address3_fax", value);
                OnPropertyChanged(nameof(Address3Fax));
            }
        }

		/// <summary>
		/// Select the freight terms for the third address to make sure shipping orders are processed correctly.
		/// </summary>
		[AttributeLogicalName("address3_freighttermscode")]
        public OptionSetValue Address3FreightTermsCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("address3_freighttermscode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3FreightTermsCode));
                SetAttributeValue("address3_freighttermscode", value);
                OnPropertyChanged(nameof(Address3FreightTermsCode));
            }
        }

		/// <summary>
		/// Type the latitude value for the third address for use in mapping and other applications.
		/// </summary>
		[AttributeLogicalName("address3_latitude")]
        public double? Address3Latitude
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<double?>("address3_latitude");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3Latitude));
                SetAttributeValue("address3_latitude", value);
                OnPropertyChanged(nameof(Address3Latitude));
            }
        }

		/// <summary>
		/// the first line of the 3rd address.
		/// </summary>
		[AttributeLogicalName("address3_line1")]
        public string Address3Line1
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_line1");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3Line1));
                SetAttributeValue("address3_line1", value);
                OnPropertyChanged(nameof(Address3Line1));
            }
        }

		/// <summary>
		/// the second line of the 3rd address.
		/// </summary>
		[AttributeLogicalName("address3_line2")]
        public string Address3Line2
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_line2");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3Line2));
                SetAttributeValue("address3_line2", value);
                OnPropertyChanged(nameof(Address3Line2));
            }
        }

		/// <summary>
		/// the third line of the 3rd address.
		/// </summary>
		[AttributeLogicalName("address3_line3")]
        public string Address3Line3
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_line3");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3Line3));
                SetAttributeValue("address3_line3", value);
                OnPropertyChanged(nameof(Address3Line3));
            }
        }

		/// <summary>
		/// Type the longitude value for the third address for use in mapping and other applications.
		/// </summary>
		[AttributeLogicalName("address3_longitude")]
        public double? Address3Longitude
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<double?>("address3_longitude");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3Longitude));
                SetAttributeValue("address3_longitude", value);
                OnPropertyChanged(nameof(Address3Longitude));
            }
        }

		/// <summary>
		/// Type a descriptive name for the third address, such as Corporate Headquarters.
		/// </summary>
		[AttributeLogicalName("address3_name")]
        public string Address3Name
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_name");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3Name));
                SetAttributeValue("address3_name", value);
                OnPropertyChanged(nameof(Address3Name));
            }
        }

		/// <summary>
		/// the ZIP Code or postal code for the 3rd address.
		/// </summary>
		[AttributeLogicalName("address3_postalcode")]
        public string Address3PostalCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_postalcode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3PostalCode));
                SetAttributeValue("address3_postalcode", value);
                OnPropertyChanged(nameof(Address3PostalCode));
            }
        }

		/// <summary>
		/// the post office box number of the 3rd address.
		/// </summary>
		[AttributeLogicalName("address3_postofficebox")]
        public string Address3PostOfficeBox
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_postofficebox");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3PostOfficeBox));
                SetAttributeValue("address3_postofficebox", value);
                OnPropertyChanged(nameof(Address3PostOfficeBox));
            }
        }

		/// <summary>
		/// Type the name of the main contact at the account's third address.
		/// </summary>
		[AttributeLogicalName("address3_primarycontactname")]
        public string Address3PrimaryContactName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_primarycontactname");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3PrimaryContactName));
                SetAttributeValue("address3_primarycontactname", value);
                OnPropertyChanged(nameof(Address3PrimaryContactName));
            }
        }

		/// <summary>
		/// Select a shipping method for deliveries sent to this address.
		/// </summary>
		[AttributeLogicalName("address3_shippingmethodcode")]
        public OptionSetValue Address3ShippingMethodCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("address3_shippingmethodcode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3ShippingMethodCode));
                SetAttributeValue("address3_shippingmethodcode", value);
                OnPropertyChanged(nameof(Address3ShippingMethodCode));
            }
        }

		/// <summary>
		/// the state or province of the third address.
		/// </summary>
		[AttributeLogicalName("address3_stateorprovince")]
        public string Address3StateOrProvince
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_stateorprovince");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3StateOrProvince));
                SetAttributeValue("address3_stateorprovince", value);
                OnPropertyChanged(nameof(Address3StateOrProvince));
            }
        }

		/// <summary>
		/// Type the main phone number associated with the third address.
		/// </summary>
		[AttributeLogicalName("address3_telephone1")]
        public string Address3Telephone1
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_telephone1");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3Telephone1));
                SetAttributeValue("address3_telephone1", value);
                OnPropertyChanged(nameof(Address3Telephone1));
            }
        }

		/// <summary>
		/// Type a second phone number associated with the third address.
		/// </summary>
		[AttributeLogicalName("address3_telephone2")]
        public string Address3Telephone2
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_telephone2");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3Telephone2));
                SetAttributeValue("address3_telephone2", value);
                OnPropertyChanged(nameof(Address3Telephone2));
            }
        }

		/// <summary>
		/// Type a third phone number associated with the primary address.
		/// </summary>
		[AttributeLogicalName("address3_telephone3")]
        public string Address3Telephone3
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_telephone3");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3Telephone3));
                SetAttributeValue("address3_telephone3", value);
                OnPropertyChanged(nameof(Address3Telephone3));
            }
        }

		/// <summary>
		/// Type the UPS zone of the third address to make sure shipping charges are calculated correctly and deliveries are made promptly, if shipped by UPS.
		/// </summary>
		[AttributeLogicalName("address3_upszone")]
        public string Address3UPSZone
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("address3_upszone");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3UPSZone));
                SetAttributeValue("address3_upszone", value);
                OnPropertyChanged(nameof(Address3UPSZone));
            }
        }

		/// <summary>
		/// Select the time zone, or UTC offset, for this address so that other people can reference it when they contact someone at this address.
		/// </summary>
		[AttributeLogicalName("address3_utcoffset")]
        public int? Address3UTCOffset
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<int?>("address3_utcoffset");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Address3UTCOffset));
                SetAttributeValue("address3_utcoffset", value);
                OnPropertyChanged(nameof(Address3UTCOffset));
            }
        }

		
		[AttributeLogicalName("adx_confirmremovepassword")]
        public bool? AdxConfirmRemovePassword
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("adx_confirmremovepassword");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxConfirmRemovePassword));
                SetAttributeValue("adx_confirmremovepassword", value);
                OnPropertyChanged(nameof(AdxConfirmRemovePassword));
            }
        }

		
		[AttributeLogicalName("adx_createdbyipaddress")]
        public string AdxCreatedByIPAddress
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("adx_createdbyipaddress");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxCreatedByIPAddress));
                SetAttributeValue("adx_createdbyipaddress", value);
                OnPropertyChanged(nameof(AdxCreatedByIPAddress));
            }
        }

		
		[AttributeLogicalName("adx_createdbyusername")]
        public string AdxCreatedByUsername
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("adx_createdbyusername");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxCreatedByUsername));
                SetAttributeValue("adx_createdbyusername", value);
                OnPropertyChanged(nameof(AdxCreatedByUsername));
            }
        }

		/// <summary>
		/// Shows the current count of failed password attempts for the contact.
		/// </summary>
		[AttributeLogicalName("adx_identity_accessfailedcount")]
        public int? AdxIdentityAccessfailedcount
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<int?>("adx_identity_accessfailedcount");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxIdentityAccessfailedcount));
                SetAttributeValue("adx_identity_accessfailedcount", value);
                OnPropertyChanged(nameof(AdxIdentityAccessfailedcount));
            }
        }

		/// <summary>
		/// Determines if the email is confirmed by the contact.
		/// </summary>
		[AttributeLogicalName("adx_identity_emailaddress1confirmed")]
        public bool? AdxIdentityEmailaddress1confirmed
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("adx_identity_emailaddress1confirmed");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxIdentityEmailaddress1confirmed));
                SetAttributeValue("adx_identity_emailaddress1confirmed", value);
                OnPropertyChanged(nameof(AdxIdentityEmailaddress1confirmed));
            }
        }

		/// <summary>
		/// Indicates the last date and time the user successfully signed in to a portal.
		/// </summary>
		[AttributeLogicalName("adx_identity_lastsuccessfullogin")]
        public DateTime? AdxIdentityLastsuccessfullogin
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("adx_identity_lastsuccessfullogin");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxIdentityLastsuccessfullogin));
                SetAttributeValue("adx_identity_lastsuccessfullogin", value);
                OnPropertyChanged(nameof(AdxIdentityLastsuccessfullogin));
            }
        }

		/// <summary>
		/// Indicates that the contact can no longer sign in to the portal using the local account.
		/// </summary>
		[AttributeLogicalName("adx_identity_locallogindisabled")]
        public bool? AdxIdentityLocallogindisabled
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("adx_identity_locallogindisabled");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxIdentityLocallogindisabled));
                SetAttributeValue("adx_identity_locallogindisabled", value);
                OnPropertyChanged(nameof(AdxIdentityLocallogindisabled));
            }
        }

		/// <summary>
		/// Determines if this contact will track failed access attempts and become locked after too many failed attempts. To prevent the contact from becoming locked, you can disable this setting.
		/// </summary>
		[AttributeLogicalName("adx_identity_lockoutenabled")]
        public bool? AdxIdentityLockoutenabled
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("adx_identity_lockoutenabled");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxIdentityLockoutenabled));
                SetAttributeValue("adx_identity_lockoutenabled", value);
                OnPropertyChanged(nameof(AdxIdentityLockoutenabled));
            }
        }

		/// <summary>
		/// Shows the moment in time when the locked contact becomes unlocked again.
		/// </summary>
		[AttributeLogicalName("adx_identity_lockoutenddate")]
        public DateTime? AdxIdentityLockoutenddate
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("adx_identity_lockoutenddate");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxIdentityLockoutenddate));
                SetAttributeValue("adx_identity_lockoutenddate", value);
                OnPropertyChanged(nameof(AdxIdentityLockoutenddate));
            }
        }

		/// <summary>
		/// Determines if web authentication is enabled for the contact.
		/// </summary>
		[AttributeLogicalName("adx_identity_logonenabled")]
        public bool? AdxIdentityLogonenabled
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("adx_identity_logonenabled");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxIdentityLogonenabled));
                SetAttributeValue("adx_identity_logonenabled", value);
                OnPropertyChanged(nameof(AdxIdentityLogonenabled));
            }
        }

		/// <summary>
		/// Determines if the phone number is confirmed by the contact.
		/// </summary>
		[AttributeLogicalName("adx_identity_mobilephoneconfirmed")]
        public bool? AdxIdentityMobilephoneconfirmed
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("adx_identity_mobilephoneconfirmed");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxIdentityMobilephoneconfirmed));
                SetAttributeValue("adx_identity_mobilephoneconfirmed", value);
                OnPropertyChanged(nameof(AdxIdentityMobilephoneconfirmed));
            }
        }

		
		[AttributeLogicalName("adx_identity_newpassword")]
        public string AdxIdentityNewpassword
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("adx_identity_newpassword");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxIdentityNewpassword));
                SetAttributeValue("adx_identity_newpassword", value);
                OnPropertyChanged(nameof(AdxIdentityNewpassword));
            }
        }

		
		[AttributeLogicalName("adx_identity_passwordhash")]
        public string AdxIdentityPasswordhash
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("adx_identity_passwordhash");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxIdentityPasswordhash));
                SetAttributeValue("adx_identity_passwordhash", value);
                OnPropertyChanged(nameof(AdxIdentityPasswordhash));
            }
        }

		/// <summary>
		/// A token used to manage the web authentication session.
		/// </summary>
		[AttributeLogicalName("adx_identity_securitystamp")]
        public string AdxIdentitySecuritystamp
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("adx_identity_securitystamp");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxIdentitySecuritystamp));
                SetAttributeValue("adx_identity_securitystamp", value);
                OnPropertyChanged(nameof(AdxIdentitySecuritystamp));
            }
        }

		/// <summary>
		/// Determines if two-factor authentication is enabled for the contact.
		/// </summary>
		[AttributeLogicalName("adx_identity_twofactorenabled")]
        public bool? AdxIdentityTwofactorenabled
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("adx_identity_twofactorenabled");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxIdentityTwofactorenabled));
                SetAttributeValue("adx_identity_twofactorenabled", value);
                OnPropertyChanged(nameof(AdxIdentityTwofactorenabled));
            }
        }

		/// <summary>
		/// Shows the user identity for local web authentication.
		/// </summary>
		[AttributeLogicalName("adx_identity_username")]
        public string AdxIdentityUsername
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("adx_identity_username");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxIdentityUsername));
                SetAttributeValue("adx_identity_username", value);
                OnPropertyChanged(nameof(AdxIdentityUsername));
            }
        }

		
		[AttributeLogicalName("adx_modifiedbyipaddress")]
        public string AdxModifiedByIPAddress
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("adx_modifiedbyipaddress");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxModifiedByIPAddress));
                SetAttributeValue("adx_modifiedbyipaddress", value);
                OnPropertyChanged(nameof(AdxModifiedByIPAddress));
            }
        }

		
		[AttributeLogicalName("adx_modifiedbyusername")]
        public string AdxModifiedByUsername
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("adx_modifiedbyusername");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxModifiedByUsername));
                SetAttributeValue("adx_modifiedbyusername", value);
                OnPropertyChanged(nameof(AdxModifiedByUsername));
            }
        }

		
		[AttributeLogicalName("adx_organizationname")]
        public string AdxOrganizationName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("adx_organizationname");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxOrganizationName));
                SetAttributeValue("adx_organizationname", value);
                OnPropertyChanged(nameof(AdxOrganizationName));
            }
        }

		/// <summary>
		/// User’s preferred portal LCID
		/// </summary>
		[AttributeLogicalName("adx_preferredlcid")]
        public int? AdxPreferredlcid
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<int?>("adx_preferredlcid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxPreferredlcid));
                SetAttributeValue("adx_preferredlcid", value);
                OnPropertyChanged(nameof(AdxPreferredlcid));
            }
        }

		
		[AttributeLogicalName("adx_profilealert")]
        public bool? AdxProfilealert
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("adx_profilealert");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxProfilealert));
                SetAttributeValue("adx_profilealert", value);
                OnPropertyChanged(nameof(AdxProfilealert));
            }
        }

		
		[AttributeLogicalName("adx_profilealertdate")]
        public DateTime? AdxProfilealertdate
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("adx_profilealertdate");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxProfilealertdate));
                SetAttributeValue("adx_profilealertdate", value);
                OnPropertyChanged(nameof(AdxProfilealertdate));
            }
        }

		
		[AttributeLogicalName("adx_profilealertinstructions")]
        public string AdxProfilealertinstructions
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("adx_profilealertinstructions");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxProfilealertinstructions));
                SetAttributeValue("adx_profilealertinstructions", value);
                OnPropertyChanged(nameof(AdxProfilealertinstructions));
            }
        }

		
		[AttributeLogicalName("adx_profileisanonymous")]
        public bool? AdxProfileIsAnonymous
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("adx_profileisanonymous");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxProfileIsAnonymous));
                SetAttributeValue("adx_profileisanonymous", value);
                OnPropertyChanged(nameof(AdxProfileIsAnonymous));
            }
        }

		
		[AttributeLogicalName("adx_profilelastactivity")]
        public DateTime? AdxProfileLastActivity
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("adx_profilelastactivity");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxProfileLastActivity));
                SetAttributeValue("adx_profilelastactivity", value);
                OnPropertyChanged(nameof(AdxProfileLastActivity));
            }
        }

		
		[AttributeLogicalName("adx_profilemodifiedon")]
        public DateTime? AdxProfilemodifiedon
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("adx_profilemodifiedon");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxProfilemodifiedon));
                SetAttributeValue("adx_profilemodifiedon", value);
                OnPropertyChanged(nameof(AdxProfilemodifiedon));
            }
        }

		
		[AttributeLogicalName("adx_publicprofilecopy")]
        public string AdxPublicProfileCopy
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("adx_publicprofilecopy");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxPublicProfileCopy));
                SetAttributeValue("adx_publicprofilecopy", value);
                OnPropertyChanged(nameof(AdxPublicProfileCopy));
            }
        }

		
		[AttributeLogicalName("adx_timezone")]
        public int? AdxTimeZone
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<int?>("adx_timezone");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AdxTimeZone));
                SetAttributeValue("adx_timezone", value);
                OnPropertyChanged(nameof(AdxTimeZone));
            }
        }

		/// <summary>
		/// For system use only.
		/// </summary>
		[AttributeLogicalName("aging30")]
        public Money Aging30
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Money>("aging30");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Aging30));
                SetAttributeValue("aging30", value);
                OnPropertyChanged(nameof(Aging30));
            }
        }

		/// <summary>
		/// Shows the Aging 30 field converted to the system's default base currency. The calculations use the exchange rate specified in the Currencies area.
		/// </summary>
		[AttributeLogicalName("aging30_base")]
        public Money Aging30Base
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Money>("aging30_base");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Aging30Base));
                SetAttributeValue("aging30_base", value);
                OnPropertyChanged(nameof(Aging30Base));
            }
        }

		/// <summary>
		/// For system use only.
		/// </summary>
		[AttributeLogicalName("aging60")]
        public Money Aging60
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Money>("aging60");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Aging60));
                SetAttributeValue("aging60", value);
                OnPropertyChanged(nameof(Aging60));
            }
        }

		/// <summary>
		/// Shows the Aging 60 field converted to the system's default base currency. The calculations use the exchange rate specified in the Currencies area.
		/// </summary>
		[AttributeLogicalName("aging60_base")]
        public Money Aging60Base
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Money>("aging60_base");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Aging60Base));
                SetAttributeValue("aging60_base", value);
                OnPropertyChanged(nameof(Aging60Base));
            }
        }

		/// <summary>
		/// For system use only.
		/// </summary>
		[AttributeLogicalName("aging90")]
        public Money Aging90
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Money>("aging90");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Aging90));
                SetAttributeValue("aging90", value);
                OnPropertyChanged(nameof(Aging90));
            }
        }

		/// <summary>
		/// Shows the Aging 90 field converted to the system's default base currency. The calculations use the exchange rate specified in the Currencies area.
		/// </summary>
		[AttributeLogicalName("aging90_base")]
        public Money Aging90Base
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Money>("aging90_base");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Aging90Base));
                SetAttributeValue("aging90_base", value);
                OnPropertyChanged(nameof(Aging90Base));
            }
        }

		/// <summary>
		/// Enter the date of the contact's wedding or service anniversary for use in customer gift programs or other communications.
		/// </summary>
		[AttributeLogicalName("anniversary")]
        public DateTime? Anniversary
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("anniversary");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Anniversary));
                SetAttributeValue("anniversary", value);
                OnPropertyChanged(nameof(Anniversary));
            }
        }

		/// <summary>
		/// Type the contact's annual income for use in profiling and financial analysis.
		/// </summary>
		[AttributeLogicalName("annualincome")]
        public Money AnnualIncome
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Money>("annualincome");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AnnualIncome));
                SetAttributeValue("annualincome", value);
                OnPropertyChanged(nameof(AnnualIncome));
            }
        }

		/// <summary>
		/// Shows the Annual Income field converted to the system's default base currency. The calculations use the exchange rate specified in the Currencies area.
		/// </summary>
		[AttributeLogicalName("annualincome_base")]
        public Money AnnualIncomeBase
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Money>("annualincome_base");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AnnualIncomeBase));
                SetAttributeValue("annualincome_base", value);
                OnPropertyChanged(nameof(AnnualIncomeBase));
            }
        }

		/// <summary>
		/// Type the name of the contact's assistant.
		/// </summary>
		[AttributeLogicalName("assistantname")]
        public string AssistantName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("assistantname");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AssistantName));
                SetAttributeValue("assistantname", value);
                OnPropertyChanged(nameof(AssistantName));
            }
        }

		/// <summary>
		/// Type the phone number for the contact's assistant.
		/// </summary>
		[AttributeLogicalName("assistantphone")]
        public string AssistantPhone
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("assistantphone");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(AssistantPhone));
                SetAttributeValue("assistantphone", value);
                OnPropertyChanged(nameof(AssistantPhone));
            }
        }

		/// <summary>
		/// Enter the contact's birthday for use in customer gift programs or other communications.
		/// </summary>
		[AttributeLogicalName("birthdate")]
        public DateTime? BirthDate
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("birthdate");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(BirthDate));
                SetAttributeValue("birthdate", value);
                OnPropertyChanged(nameof(BirthDate));
            }
        }

		/// <summary>
		/// Type a second business phone number for this contact.
		/// </summary>
		[AttributeLogicalName("business2")]
        public string Business2
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("business2");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Business2));
                SetAttributeValue("business2", value);
                OnPropertyChanged(nameof(Business2));
            }
        }

		/// <summary>
		/// Stores Image of the Business Card
		/// </summary>
		[AttributeLogicalName("businesscard")]
        public string BusinessCard
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("businesscard");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(BusinessCard));
                SetAttributeValue("businesscard", value);
                OnPropertyChanged(nameof(BusinessCard));
            }
        }

		/// <summary>
		/// Stores Business Card Control Properties.
		/// </summary>
		[AttributeLogicalName("businesscardattributes")]
        public string BusinessCardAttributesField
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("businesscardattributes");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(BusinessCardAttributesField));
                SetAttributeValue("businesscardattributes", value);
                OnPropertyChanged(nameof(BusinessCardAttributesField));
            }
        }

		/// <summary>
		/// Type a callback phone number for this contact.
		/// </summary>
		[AttributeLogicalName("callback")]
        public string Callback
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("callback");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Callback));
                SetAttributeValue("callback", value);
                OnPropertyChanged(nameof(Callback));
            }
        }

		/// <summary>
		/// Type the names of the contact's children for reference in communications and client programs.
		/// </summary>
		[AttributeLogicalName("childrensnames")]
        public string ChildrensNames
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("childrensnames");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ChildrensNames));
                SetAttributeValue("childrensnames", value);
                OnPropertyChanged(nameof(ChildrensNames));
            }
        }

		/// <summary>
		/// Type the company phone of the contact.
		/// </summary>
		[AttributeLogicalName("company")]
        public string Company
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("company");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Company));
                SetAttributeValue("company", value);
                OnPropertyChanged(nameof(Company));
            }
        }

		/// <summary>
		/// Shows who created the record.
		/// </summary>
		[AttributeLogicalName("createdby")]
        public EntityReference CreatedBy
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("createdby");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(CreatedBy));
                SetAttributeValue("createdby", value);
                OnPropertyChanged(nameof(CreatedBy));
            }
        }

		/// <summary>
		/// Shows the external party who created the record.
		/// </summary>
		[AttributeLogicalName("createdbyexternalparty")]
        public EntityReference CreatedByExternalParty
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("createdbyexternalparty");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(CreatedByExternalParty));
                SetAttributeValue("createdbyexternalparty", value);
                OnPropertyChanged(nameof(CreatedByExternalParty));
            }
        }

		/// <summary>
		/// Shows the date and time when the record was created. The date and time are displayed in the time zone selected in Microsoft Dynamics 365 options.
		/// </summary>
		[AttributeLogicalName("createdon")]
        public DateTime? CreatedOn
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("createdon");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(CreatedOn));
                SetAttributeValue("createdon", value);
                OnPropertyChanged(nameof(CreatedOn));
            }
        }

		/// <summary>
		/// Shows who created the record on behalf of another user.
		/// </summary>
		[AttributeLogicalName("createdonbehalfby")]
        public EntityReference CreatedOnBehalfBy
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("createdonbehalfby");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(CreatedOnBehalfBy));
                SetAttributeValue("createdonbehalfby", value);
                OnPropertyChanged(nameof(CreatedOnBehalfBy));
            }
        }

		/// <summary>
		/// Type the credit limit of the contact for reference when you address invoice and accounting issues with the customer.
		/// </summary>
		[AttributeLogicalName("creditlimit")]
        public Money CreditLimit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Money>("creditlimit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(CreditLimit));
                SetAttributeValue("creditlimit", value);
                OnPropertyChanged(nameof(CreditLimit));
            }
        }

		/// <summary>
		/// Shows the Credit Limit field converted to the system's default base currency for reporting purposes. The calculations use the exchange rate specified in the Currencies area.
		/// </summary>
		[AttributeLogicalName("creditlimit_base")]
        public Money CreditLimitBase
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Money>("creditlimit_base");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(CreditLimitBase));
                SetAttributeValue("creditlimit_base", value);
                OnPropertyChanged(nameof(CreditLimitBase));
            }
        }

		/// <summary>
		/// Select whether the contact is on a credit hold, for reference when addressing invoice and accounting issues.
		/// </summary>
		[AttributeLogicalName("creditonhold")]
        public bool? CreditOnHold
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("creditonhold");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(CreditOnHold));
                SetAttributeValue("creditonhold", value);
                OnPropertyChanged(nameof(CreditOnHold));
            }
        }

		/// <summary>
		/// Select the size of the contact's company for segmentation and reporting purposes.
		/// </summary>
		[AttributeLogicalName("customersizecode")]
        public OptionSetValue CustomerSizeCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("customersizecode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(CustomerSizeCode));
                SetAttributeValue("customersizecode", value);
                OnPropertyChanged(nameof(CustomerSizeCode));
            }
        }

		/// <summary>
		/// Select the category that best describes the relationship between the contact and your organization.
		/// </summary>
		[AttributeLogicalName("customertypecode")]
        public OptionSetValue CustomerTypeCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("customertypecode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(CustomerTypeCode));
                SetAttributeValue("customertypecode", value);
                OnPropertyChanged(nameof(CustomerTypeCode));
            }
        }

		/// <summary>
		/// Choose the default price list associated with the contact to make sure the correct product prices for this customer are applied in sales opportunities, quotes, and orders.
		/// </summary>
		[AttributeLogicalName("defaultpricelevelid")]
        public EntityReference DefaultPriceLevelId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("defaultpricelevelid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DefaultPriceLevelId));
                SetAttributeValue("defaultpricelevelid", value);
                OnPropertyChanged(nameof(DefaultPriceLevelId));
            }
        }

		/// <summary>
		/// Type the department or business unit where the contact works in the parent company or business.
		/// </summary>
		[AttributeLogicalName("department")]
        public string Department
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("department");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Department));
                SetAttributeValue("department", value);
                OnPropertyChanged(nameof(Department));
            }
        }

		/// <summary>
		/// Type additional information to describe the contact, such as an excerpt from the company's website.
		/// </summary>
		[AttributeLogicalName("description")]
        public string Description
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("description");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Description));
                SetAttributeValue("description", value);
                OnPropertyChanged(nameof(Description));
            }
        }

		
		[AttributeLogicalName("dgt_address1_country_id")]
        public EntityReference DgtAddress1CountryId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("dgt_address1_country_id");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtAddress1CountryId));
                SetAttributeValue("dgt_address1_country_id", value);
                OnPropertyChanged(nameof(DgtAddress1CountryId));
            }
        }

		
		[AttributeLogicalName("dgt_address1_fx")]
        public string DgtAddress1Fx
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("dgt_address1_fx");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtAddress1Fx));
                SetAttributeValue("dgt_address1_fx", value);
                OnPropertyChanged(nameof(DgtAddress1Fx));
            }
        }

		
		[AttributeLogicalName("dgt_advertisingnotallowed_bit")]
        public bool? DgtAdvertisingnotallowedBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgt_advertisingnotallowed_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtAdvertisingnotallowedBit));
                SetAttributeValue("dgt_advertisingnotallowed_bit", value);
                OnPropertyChanged(nameof(DgtAdvertisingnotallowedBit));
            }
        }

		
		[AttributeLogicalName("dgt_consent_business_phone_bit")]
        public bool? DgtConsentBusinessPhoneBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgt_consent_business_phone_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtConsentBusinessPhoneBit));
                SetAttributeValue("dgt_consent_business_phone_bit", value);
                OnPropertyChanged(nameof(DgtConsentBusinessPhoneBit));
            }
        }

		
		[AttributeLogicalName("dgt_consent_business_phone_dt")]
        public DateTime? DgtConsentBusinessPhoneDt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("dgt_consent_business_phone_dt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtConsentBusinessPhoneDt));
                SetAttributeValue("dgt_consent_business_phone_dt", value);
                OnPropertyChanged(nameof(DgtConsentBusinessPhoneDt));
            }
        }

		
		[AttributeLogicalName("dgt_consent_email_bit")]
        public bool? DgtConsentEmailBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgt_consent_email_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtConsentEmailBit));
                SetAttributeValue("dgt_consent_email_bit", value);
                OnPropertyChanged(nameof(DgtConsentEmailBit));
            }
        }

		
		[AttributeLogicalName("dgt_consent_email_dt")]
        public DateTime? DgtConsentEmailDt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("dgt_consent_email_dt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtConsentEmailDt));
                SetAttributeValue("dgt_consent_email_dt", value);
                OnPropertyChanged(nameof(DgtConsentEmailDt));
            }
        }

		
		[AttributeLogicalName("dgt_consent_fax_bit")]
        public bool? DgtConsentFaxBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgt_consent_fax_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtConsentFaxBit));
                SetAttributeValue("dgt_consent_fax_bit", value);
                OnPropertyChanged(nameof(DgtConsentFaxBit));
            }
        }

		
		[AttributeLogicalName("dgt_consent_fax_dt")]
        public DateTime? DgtConsentFaxDt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("dgt_consent_fax_dt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtConsentFaxDt));
                SetAttributeValue("dgt_consent_fax_dt", value);
                OnPropertyChanged(nameof(DgtConsentFaxDt));
            }
        }

		
		[AttributeLogicalName("dgt_consent_mail_bit")]
        public bool? DgtConsentMailBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgt_consent_mail_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtConsentMailBit));
                SetAttributeValue("dgt_consent_mail_bit", value);
                OnPropertyChanged(nameof(DgtConsentMailBit));
            }
        }

		
		[AttributeLogicalName("dgt_consent_mail_dt")]
        public DateTime? DgtConsentMailDt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("dgt_consent_mail_dt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtConsentMailDt));
                SetAttributeValue("dgt_consent_mail_dt", value);
                OnPropertyChanged(nameof(DgtConsentMailDt));
            }
        }

		
		[AttributeLogicalName("dgt_consent_mobile_phone_bit")]
        public bool? DgtConsentMobilePhoneBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgt_consent_mobile_phone_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtConsentMobilePhoneBit));
                SetAttributeValue("dgt_consent_mobile_phone_bit", value);
                OnPropertyChanged(nameof(DgtConsentMobilePhoneBit));
            }
        }

		
		[AttributeLogicalName("dgt_consent_mobile_phone_dt")]
        public DateTime? DgtConsentMobilePhoneDt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("dgt_consent_mobile_phone_dt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtConsentMobilePhoneDt));
                SetAttributeValue("dgt_consent_mobile_phone_dt", value);
                OnPropertyChanged(nameof(DgtConsentMobilePhoneDt));
            }
        }

		
		[AttributeLogicalName("dgt_consent_private_phone_bit")]
        public bool? DgtConsentPrivatePhoneBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgt_consent_private_phone_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtConsentPrivatePhoneBit));
                SetAttributeValue("dgt_consent_private_phone_bit", value);
                OnPropertyChanged(nameof(DgtConsentPrivatePhoneBit));
            }
        }

		
		[AttributeLogicalName("dgt_consent_private_phone_dt")]
        public DateTime? DgtConsentPrivatePhoneDt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("dgt_consent_private_phone_dt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtConsentPrivatePhoneDt));
                SetAttributeValue("dgt_consent_private_phone_dt", value);
                OnPropertyChanged(nameof(DgtConsentPrivatePhoneDt));
            }
        }

		
		[AttributeLogicalName("dgt_customerclassification_id")]
        public EntityReference DgtCustomerclassificationId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("dgt_customerclassification_id");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtCustomerclassificationId));
                SetAttributeValue("dgt_customerclassification_id", value);
                OnPropertyChanged(nameof(DgtCustomerclassificationId));
            }
        }

		/// <summary>
		/// Feld wird verwendet, um nach dem Import die Pesonen über ein Segment oder einen Flow einer Marketing Liste hinzufügen zu können.
		/// </summary>
		[AttributeLogicalName("dgt_importname_txt")]
        public string DgtImportNameTxt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("dgt_importname_txt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtImportNameTxt));
                SetAttributeValue("dgt_importname_txt", value);
                OnPropertyChanged(nameof(DgtImportNameTxt));
            }
        }

		
		[AttributeLogicalName("dgt_job_id")]
        public EntityReference DgtJobId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("dgt_job_id");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtJobId));
                SetAttributeValue("dgt_job_id", value);
                OnPropertyChanged(nameof(DgtJobId));
            }
        }

		
		[AttributeLogicalName("dgt_partnerid_txt")]
        public string DgtPartneridTxt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("dgt_partnerid_txt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtPartneridTxt));
                SetAttributeValue("dgt_partnerid_txt", value);
                OnPropertyChanged(nameof(DgtPartneridTxt));
            }
        }

		
		[AttributeLogicalName("dgt_preferred_communication_channel_set")]
        public OptionSetValue DgtPreferredCommunicationChannelSet
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("dgt_preferred_communication_channel_set");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtPreferredCommunicationChannelSet));
                SetAttributeValue("dgt_preferred_communication_channel_set", value);
                OnPropertyChanged(nameof(DgtPreferredCommunicationChannelSet));
            }
        }

		
		[AttributeLogicalName("dgt_salutation_set")]
        public OptionSetValue DgtSalutationSet
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("dgt_salutation_set");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtSalutationSet));
                SetAttributeValue("dgt_salutation_set", value);
                OnPropertyChanged(nameof(DgtSalutationSet));
            }
        }

		
		[AttributeLogicalName("dgt_supportingagency_id")]
        public EntityReference DgtSupportingagencyId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("dgt_supportingagency_id");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtSupportingagencyId));
                SetAttributeValue("dgt_supportingagency_id", value);
                OnPropertyChanged(nameof(DgtSupportingagencyId));
            }
        }

		
		[AttributeLogicalName("dgt_svmid_txt")]
        public string DgtSvmidTxt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("dgt_svmid_txt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtSvmidTxt));
                SetAttributeValue("dgt_svmid_txt", value);
                OnPropertyChanged(nameof(DgtSvmidTxt));
            }
        }

		
		[AttributeLogicalName("dgt_title_set")]
        public OptionSetValue DgtTitleSet
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("dgt_title_set");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtTitleSet));
                SetAttributeValue("dgt_title_set", value);
                OnPropertyChanged(nameof(DgtTitleSet));
            }
        }

		
		[AttributeLogicalName("dgt_wagegroup_set")]
        public OptionSetValue DgtWagegroupSet
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("dgt_wagegroup_set");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtWagegroupSet));
                SetAttributeValue("dgt_wagegroup_set", value);
                OnPropertyChanged(nameof(DgtWagegroupSet));
            }
        }

		
		[AttributeLogicalName("dgti_active_policy_bit")]
        public bool? DgtiActivePolicyBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgti_active_policy_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiActivePolicyBit));
                SetAttributeValue("dgti_active_policy_bit", value);
                OnPropertyChanged(nameof(DgtiActivePolicyBit));
            }
        }

		
		[AttributeLogicalName("dgti_active_policy_exists_bit")]
        public bool? DgtiActivePolicyExistsBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgti_active_policy_exists_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiActivePolicyExistsBit));
                SetAttributeValue("dgti_active_policy_exists_bit", value);
                OnPropertyChanged(nameof(DgtiActivePolicyExistsBit));
            }
        }

		
		[AttributeLogicalName("dgti_advisory_team_id")]
        public EntityReference DgtiAdvisoryTeamId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("dgti_advisory_team_id");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiAdvisoryTeamId));
                SetAttributeValue("dgti_advisory_team_id", value);
                OnPropertyChanged(nameof(DgtiAdvisoryTeamId));
            }
        }

		/// <summary>
		/// Appointment with the (potential customer) has taken place
		/// </summary>
		[AttributeLogicalName("dgti_appointment_took_place")]
        public bool? DgtiAppointmentTookPlace
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgti_appointment_took_place");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiAppointmentTookPlace));
                SetAttributeValue("dgti_appointment_took_place", value);
                OnPropertyChanged(nameof(DgtiAppointmentTookPlace));
            }
        }

		
		[AttributeLogicalName("dgti_churn_risk_int")]
        public int? DgtiChurnRiskInt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<int?>("dgti_churn_risk_int");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiChurnRiskInt));
                SetAttributeValue("dgti_churn_risk_int", value);
                OnPropertyChanged(nameof(DgtiChurnRiskInt));
            }
        }

		
		[AttributeLogicalName("dgti_consent_call_recording_set")]
        public OptionSetValue DgtiConsentCallRecordingSet
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("dgti_consent_call_recording_set");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiConsentCallRecordingSet));
                SetAttributeValue("dgti_consent_call_recording_set", value);
                OnPropertyChanged(nameof(DgtiConsentCallRecordingSet));
            }
        }

		
		[AttributeLogicalName("dgti_consentmarketingandproductinformation")]
        public OptionSetValue DgtiConsentMarketingandProductInformation
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("dgti_consentmarketingandproductinformation");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiConsentMarketingandProductInformation));
                SetAttributeValue("dgti_consentmarketingandproductinformation", value);
                OnPropertyChanged(nameof(DgtiConsentMarketingandProductInformation));
            }
        }

		
		[AttributeLogicalName("dgti_customer_rating_set")]
        public OptionSetValue DgtiCustomerRatingSet
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("dgti_customer_rating_set");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiCustomerRatingSet));
                SetAttributeValue("dgti_customer_rating_set", value);
                OnPropertyChanged(nameof(DgtiCustomerRatingSet));
            }
        }

		
		[AttributeLogicalName("dgti_customer_satisfaction_set")]
        public OptionSetValue DgtiCustomerSatisfactionSet
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("dgti_customer_satisfaction_set");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiCustomerSatisfactionSet));
                SetAttributeValue("dgti_customer_satisfaction_set", value);
                OnPropertyChanged(nameof(DgtiCustomerSatisfactionSet));
            }
        }

		
		[AttributeLogicalName("dgti_customer_type_set")]
        public OptionSetValue DgtiCustomerTypeSet
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("dgti_customer_type_set");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiCustomerTypeSet));
                SetAttributeValue("dgti_customer_type_set", value);
                OnPropertyChanged(nameof(DgtiCustomerTypeSet));
            }
        }

		
		[AttributeLogicalName("dgti_dashboard_360_contact_txt")]
        public string DgtiDashboard360ContactTxt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("dgti_dashboard_360_contact_txt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiDashboard360ContactTxt));
                SetAttributeValue("dgti_dashboard_360_contact_txt", value);
                OnPropertyChanged(nameof(DgtiDashboard360ContactTxt));
            }
        }

		
		[AttributeLogicalName("dgti_dashboard_360_missing_information_txt")]
        public string DgtiDashboard360MissingInformationTxt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("dgti_dashboard_360_missing_information_txt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiDashboard360MissingInformationTxt));
                SetAttributeValue("dgti_dashboard_360_missing_information_txt", value);
                OnPropertyChanged(nameof(DgtiDashboard360MissingInformationTxt));
            }
        }

		
		[AttributeLogicalName("dgti_data_protection_consent_set")]
        public OptionSetValue DgtiDataProtectionConsentSet
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("dgti_data_protection_consent_set");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiDataProtectionConsentSet));
                SetAttributeValue("dgti_data_protection_consent_set", value);
                OnPropertyChanged(nameof(DgtiDataProtectionConsentSet));
            }
        }

		
		[AttributeLogicalName("dgti_donotallowsms")]
        public bool? DgtiDonotallowSMS
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgti_donotallowsms");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiDonotallowSMS));
                SetAttributeValue("dgti_donotallowsms", value);
                OnPropertyChanged(nameof(DgtiDonotallowSMS));
            }
        }

		
		[AttributeLogicalName("dgti_donotpushappportal")]
        public bool? DgtiDonotpushAppPortal
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgti_donotpushappportal");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiDonotpushAppPortal));
                SetAttributeValue("dgti_donotpushappportal", value);
                OnPropertyChanged(nameof(DgtiDonotpushAppPortal));
            }
        }

		
		[AttributeLogicalName("dgti_donotwhatsapp")]
        public bool? DgtiDonotwhatsapp
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgti_donotwhatsapp");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiDonotwhatsapp));
                SetAttributeValue("dgti_donotwhatsapp", value);
                OnPropertyChanged(nameof(DgtiDonotwhatsapp));
            }
        }

		
		[AttributeLogicalName("dgti_employer_role_set")]
        public OptionSetValue DgtiEmployerRoleSet
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("dgti_employer_role_set");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiEmployerRoleSet));
                SetAttributeValue("dgti_employer_role_set", value);
                OnPropertyChanged(nameof(DgtiEmployerRoleSet));
            }
        }

		/// <summary>
		/// Emloyer information of the Contact
		/// </summary>
		[AttributeLogicalName("dgti_employer_txt")]
        public string DgtiEmployerTxt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("dgti_employer_txt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiEmployerTxt));
                SetAttributeValue("dgti_employer_txt", value);
                OnPropertyChanged(nameof(DgtiEmployerTxt));
            }
        }

		
		[AttributeLogicalName("dgti_external_coverage_bit")]
        public bool? DgtiExternalCoverageBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgti_external_coverage_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiExternalCoverageBit));
                SetAttributeValue("dgti_external_coverage_bit", value);
                OnPropertyChanged(nameof(DgtiExternalCoverageBit));
            }
        }

		
		[AttributeLogicalName("dgti_four_active_contracts_bit")]
        public bool? DgtiFourActiveContractsBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgti_four_active_contracts_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiFourActiveContractsBit));
                SetAttributeValue("dgti_four_active_contracts_bit", value);
                OnPropertyChanged(nameof(DgtiFourActiveContractsBit));
            }
        }

		
		[AttributeLogicalName("dgti_income_captured_bit")]
        public bool? DgtiIncomeCapturedBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgti_income_captured_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiIncomeCapturedBit));
                SetAttributeValue("dgti_income_captured_bit", value);
                OnPropertyChanged(nameof(DgtiIncomeCapturedBit));
            }
        }

		
		[AttributeLogicalName("dgti_income_cur")]
        public Money DgtiIncomeCur
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Money>("dgti_income_cur");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiIncomeCur));
                SetAttributeValue("dgti_income_cur", value);
                OnPropertyChanged(nameof(DgtiIncomeCur));
            }
        }

		/// <summary>
		/// Value of the Income in base currency.
		/// </summary>
		[AttributeLogicalName("dgti_income_cur_base")]
        public Money DgtiIncomeCurBase
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Money>("dgti_income_cur_base");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiIncomeCurBase));
                SetAttributeValue("dgti_income_cur_base", value);
                OnPropertyChanged(nameof(DgtiIncomeCurBase));
            }
        }

		
		[AttributeLogicalName("dgti_life_relationship_bit")]
        public bool? DgtiLifeRelationshipBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgti_life_relationship_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiLifeRelationshipBit));
                SetAttributeValue("dgti_life_relationship_bit", value);
                OnPropertyChanged(nameof(DgtiLifeRelationshipBit));
            }
        }

		
		[AttributeLogicalName("dgti_managed_by_partnersystem_bit")]
        public bool? DgtiManagedByPartnersystemBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgti_managed_by_partnersystem_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiManagedByPartnersystemBit));
                SetAttributeValue("dgti_managed_by_partnersystem_bit", value);
                OnPropertyChanged(nameof(DgtiManagedByPartnersystemBit));
            }
        }

		
		[AttributeLogicalName("dgti_opportunity_won_bit")]
        public bool? DgtiOpportunityWonBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgti_opportunity_won_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiOpportunityWonBit));
                SetAttributeValue("dgti_opportunity_won_bit", value);
                OnPropertyChanged(nameof(DgtiOpportunityWonBit));
            }
        }

		
		[AttributeLogicalName("dgti_part_of_household_id")]
        public EntityReference DgtiPartOfHouseholdId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("dgti_part_of_household_id");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiPartOfHouseholdId));
                SetAttributeValue("dgti_part_of_household_id", value);
                OnPropertyChanged(nameof(DgtiPartOfHouseholdId));
            }
        }

		
		[AttributeLogicalName("dgti_partner_system_id_txt")]
        public string DgtiPartnerSystemIdTxt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("dgti_partner_system_id_txt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiPartnerSystemIdTxt));
                SetAttributeValue("dgti_partner_system_id_txt", value);
                OnPropertyChanged(nameof(DgtiPartnerSystemIdTxt));
            }
        }

		/// <summary>
		/// Unique number as an identifier for a contact
		/// </summary>
		[AttributeLogicalName("dgti_partnerid_txt")]
        public string DgtiPartneridTxt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("dgti_partnerid_txt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiPartneridTxt));
                SetAttributeValue("dgti_partnerid_txt", value);
                OnPropertyChanged(nameof(DgtiPartneridTxt));
            }
        }

		
		[AttributeLogicalName("dgti_partnersystem_last_change_dat")]
        public DateTime? DgtiPartnersystemLastChangeDat
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("dgti_partnersystem_last_change_dat");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiPartnersystemLastChangeDat));
                SetAttributeValue("dgti_partnersystem_last_change_dat", value);
                OnPropertyChanged(nameof(DgtiPartnersystemLastChangeDat));
            }
        }

		
		[AttributeLogicalName("dgti_professional_experience_set")]
        public OptionSetValue DgtiProfessionalExperienceSet
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("dgti_professional_experience_set");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiProfessionalExperienceSet));
                SetAttributeValue("dgti_professional_experience_set", value);
                OnPropertyChanged(nameof(DgtiProfessionalExperienceSet));
            }
        }

		
		[AttributeLogicalName("dgti_public_health_insurance_bit")]
        public bool? DgtiPublicHealthInsuranceBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgti_public_health_insurance_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiPublicHealthInsuranceBit));
                SetAttributeValue("dgti_public_health_insurance_bit", value);
                OnPropertyChanged(nameof(DgtiPublicHealthInsuranceBit));
            }
        }

		
		[AttributeLogicalName("dgti_remark_household_relation_txt")]
        public string DgtiRemarkHouseholdRelationTxt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("dgti_remark_household_relation_txt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiRemarkHouseholdRelationTxt));
                SetAttributeValue("dgti_remark_household_relation_txt", value);
                OnPropertyChanged(nameof(DgtiRemarkHouseholdRelationTxt));
            }
        }

		
		[AttributeLogicalName("dgti_salutation_set")]
        public OptionSetValue DgtiSalutationSet
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("dgti_salutation_set");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiSalutationSet));
                SetAttributeValue("dgti_salutation_set", value);
                OnPropertyChanged(nameof(DgtiSalutationSet));
            }
        }

		
		[AttributeLogicalName("dgti_two_or_more_active_contracts_bit")]
        public bool? DgtiTwoOrMoreActiveContractsBit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("dgti_two_or_more_active_contracts_bit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiTwoOrMoreActiveContractsBit));
                SetAttributeValue("dgti_two_or_more_active_contracts_bit", value);
                OnPropertyChanged(nameof(DgtiTwoOrMoreActiveContractsBit));
            }
        }

		
		[AttributeLogicalName("dgti_type_of_employment_set")]
        public OptionSetValue DgtiTypeOfEmploymentSet
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("dgti_type_of_employment_set");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiTypeOfEmploymentSet));
                SetAttributeValue("dgti_type_of_employment_set", value);
                OnPropertyChanged(nameof(DgtiTypeOfEmploymentSet));
            }
        }

		
		[AttributeLogicalName("dgti_type_of_household_relation_txt")]
        public string DgtiTypeOfHouseholdRelationTxt
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("dgti_type_of_household_relation_txt");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DgtiTypeOfHouseholdRelationTxt));
                SetAttributeValue("dgti_type_of_household_relation_txt", value);
                OnPropertyChanged(nameof(DgtiTypeOfHouseholdRelationTxt));
            }
        }

		/// <summary>
		/// Select whether the contact accepts bulk email sent through marketing campaigns or quick campaigns. If Do Not Allow is selected, the contact can be added to marketing lists, but will be excluded from the email.
		/// </summary>
		[AttributeLogicalName("donotbulkemail")]
        public bool? DoNotBulkEMail
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("donotbulkemail");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DoNotBulkEMail));
                SetAttributeValue("donotbulkemail", value);
                OnPropertyChanged(nameof(DoNotBulkEMail));
            }
        }

		/// <summary>
		/// Select whether the contact accepts bulk postal mail sent through marketing campaigns or quick campaigns. If Do Not Allow is selected, the contact can be added to marketing lists, but will be excluded from the letters.
		/// </summary>
		[AttributeLogicalName("donotbulkpostalmail")]
        public bool? DoNotBulkPostalMail
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("donotbulkpostalmail");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DoNotBulkPostalMail));
                SetAttributeValue("donotbulkpostalmail", value);
                OnPropertyChanged(nameof(DoNotBulkPostalMail));
            }
        }

		/// <summary>
		/// Select whether the contact allows direct email sent from Microsoft Dynamics 365. If Do Not Allow is selected, Microsoft Dynamics 365 will not send the email.
		/// </summary>
		[AttributeLogicalName("donotemail")]
        public bool? DoNotEMail
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("donotemail");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DoNotEMail));
                SetAttributeValue("donotemail", value);
                OnPropertyChanged(nameof(DoNotEMail));
            }
        }

		/// <summary>
		/// Wählen Sie aus, ob der Kontakt den Versand von Faxnachrichten zulässt. Bei 'Nicht zulassen' kann der Kontakt zwar Marketinglisten hinzugefügt werden, ist aber von Faxaktivitäten im Rahmen von Marketingkampagnen ausgenommen.
		/// </summary>
		[AttributeLogicalName("donotfax")]
        public bool? DoNotFax
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("donotfax");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DoNotFax));
                SetAttributeValue("donotfax", value);
                OnPropertyChanged(nameof(DoNotFax));
            }
        }

		/// <summary>
		/// Select whether the contact accepts phone calls. If Do Not Allow is selected, the contact will be excluded from any phone call activities distributed in marketing campaigns.
		/// </summary>
		[AttributeLogicalName("donotphone")]
        public bool? DoNotPhone
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("donotphone");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DoNotPhone));
                SetAttributeValue("donotphone", value);
                OnPropertyChanged(nameof(DoNotPhone));
            }
        }

		/// <summary>
		/// Wählen Sie aus, ob der Kontakt adressierte Werbesendungen zulässt. Bei 'Nicht zulassen' kann der Kontakt zwar Marketinglisten hinzugefügt werden, ist aber von Briefaktivitäten im Rahmen von Marketingkampagnen ausgenommen.
		/// </summary>
		[AttributeLogicalName("donotpostalmail")]
        public bool? DoNotPostalMail
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("donotpostalmail");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DoNotPostalMail));
                SetAttributeValue("donotpostalmail", value);
                OnPropertyChanged(nameof(DoNotPostalMail));
            }
        }

		/// <summary>
		/// Select whether the contact accepts marketing materials, such as brochures or catalogs. Contacts that opt out can be excluded from marketing initiatives.
		/// </summary>
		[AttributeLogicalName("donotsendmm")]
        public bool? DoNotSendMM
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("donotsendmm");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(DoNotSendMM));
                SetAttributeValue("donotsendmm", value);
                OnPropertyChanged(nameof(DoNotSendMM));
            }
        }

		/// <summary>
		/// Select the contact's highest level of education for use in segmentation and analysis.
		/// </summary>
		[AttributeLogicalName("educationcode")]
        public OptionSetValue EducationCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("educationcode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(EducationCode));
                SetAttributeValue("educationcode", value);
                OnPropertyChanged(nameof(EducationCode));
            }
        }

		/// <summary>
		/// Type the primary email address for the contact.
		/// </summary>
		[AttributeLogicalName("emailaddress1")]
        public string EMailAddress1
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("emailaddress1");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(EMailAddress1));
                SetAttributeValue("emailaddress1", value);
                OnPropertyChanged(nameof(EMailAddress1));
            }
        }

		/// <summary>
		/// Type the secondary email address for the contact.
		/// </summary>
		[AttributeLogicalName("emailaddress2")]
        public string EMailAddress2
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("emailaddress2");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(EMailAddress2));
                SetAttributeValue("emailaddress2", value);
                OnPropertyChanged(nameof(EMailAddress2));
            }
        }

		/// <summary>
		/// Type an alternate email address for the contact.
		/// </summary>
		[AttributeLogicalName("emailaddress3")]
        public string EMailAddress3
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("emailaddress3");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(EMailAddress3));
                SetAttributeValue("emailaddress3", value);
                OnPropertyChanged(nameof(EMailAddress3));
            }
        }

		/// <summary>
		/// Type the employee ID or number for the contact for reference in orders, service cases, or other communications with the contact's organization.
		/// </summary>
		[AttributeLogicalName("employeeid")]
        public string EmployeeId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("employeeid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(EmployeeId));
                SetAttributeValue("employeeid", value);
                OnPropertyChanged(nameof(EmployeeId));
            }
        }

		/// <summary>
		/// Shows the default image for the record.
		/// </summary>
		[AttributeLogicalName("entityimage")]
        public byte[] EntityImage
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<byte[]>("entityimage");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(EntityImage));
                SetAttributeValue("entityimage", value);
                OnPropertyChanged(nameof(EntityImage));
            }
        }

		
		[AttributeLogicalName("entityimage_timestamp")]
        public long? EntityImageTimestamp
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<long?>("entityimage_timestamp");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(EntityImageTimestamp));
                SetAttributeValue("entityimage_timestamp", value);
                OnPropertyChanged(nameof(EntityImageTimestamp));
            }
        }

		
		[AttributeLogicalName("entityimage_url")]
        public string EntityImageURL
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("entityimage_url");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(EntityImageURL));
                SetAttributeValue("entityimage_url", value);
                OnPropertyChanged(nameof(EntityImageURL));
            }
        }

		/// <summary>
		/// For internal use only.
		/// </summary>
		[AttributeLogicalName("entityimageid")]
        public Guid? EntityImageId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Guid?>("entityimageid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(EntityImageId));
                SetAttributeValue("entityimageid", value);
                OnPropertyChanged(nameof(EntityImageId));
            }
        }

		/// <summary>
		/// Shows the conversion rate of the record's currency. The exchange rate is used to convert all money fields in the record from the local currency to the system's default currency.
		/// </summary>
		[AttributeLogicalName("exchangerate")]
        public decimal? ExchangeRate
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<decimal?>("exchangerate");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ExchangeRate));
                SetAttributeValue("exchangerate", value);
                OnPropertyChanged(nameof(ExchangeRate));
            }
        }

		/// <summary>
		/// Identifier for an external user.
		/// </summary>
		[AttributeLogicalName("externaluseridentifier")]
        public string ExternalUserIdentifier
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("externaluseridentifier");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ExternalUserIdentifier));
                SetAttributeValue("externaluseridentifier", value);
                OnPropertyChanged(nameof(ExternalUserIdentifier));
            }
        }

		/// <summary>
		/// Select the marital status of the contact for reference in follow-up phone calls and other communications.
		/// </summary>
		[AttributeLogicalName("familystatuscode")]
        public OptionSetValue FamilyStatusCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("familystatuscode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(FamilyStatusCode));
                SetAttributeValue("familystatuscode", value);
                OnPropertyChanged(nameof(FamilyStatusCode));
            }
        }

		/// <summary>
		/// Type the fax number for the contact.
		/// </summary>
		[AttributeLogicalName("fax")]
        public string Fax
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("fax");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Fax));
                SetAttributeValue("fax", value);
                OnPropertyChanged(nameof(Fax));
            }
        }

		/// <summary>
		/// Type the contact's first name to make sure the contact is addressed correctly in sales calls, email, and marketing campaigns.
		/// </summary>
		[AttributeLogicalName("firstname")]
        public string FirstName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("firstname");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(FirstName));
                SetAttributeValue("firstname", value);
                OnPropertyChanged(nameof(FirstName));
            }
        }

		/// <summary>
		/// Information about whether to allow following email activity like opens, attachment views and link clicks for emails sent to the contact.
		/// </summary>
		[AttributeLogicalName("followemail")]
        public bool? FollowEmail
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("followemail");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(FollowEmail));
                SetAttributeValue("followemail", value);
                OnPropertyChanged(nameof(FollowEmail));
            }
        }

		/// <summary>
		/// Type the URL for the contact's FTP site to enable users to access data and share documents.
		/// </summary>
		[AttributeLogicalName("ftpsiteurl")]
        public string FtpSiteUrl
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("ftpsiteurl");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(FtpSiteUrl));
                SetAttributeValue("ftpsiteurl", value);
                OnPropertyChanged(nameof(FtpSiteUrl));
            }
        }

		/// <summary>
		/// Combines and shows the contact's first and last names so that the full name can be displayed in views and reports.
		/// </summary>
		[AttributeLogicalName("fullname")]
        public string FullName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("fullname");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(FullName));
                SetAttributeValue("fullname", value);
                OnPropertyChanged(nameof(FullName));
            }
        }

		/// <summary>
		/// Select the contact's gender to make sure the contact is addressed correctly in sales calls, email, and marketing campaigns.
		/// </summary>
		[AttributeLogicalName("gendercode")]
        public OptionSetValue GenderCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("gendercode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(GenderCode));
                SetAttributeValue("gendercode", value);
                OnPropertyChanged(nameof(GenderCode));
            }
        }

		/// <summary>
		/// Type the passport number or other government ID for the contact for use in documents or reports.
		/// </summary>
		[AttributeLogicalName("governmentid")]
        public string GovernmentId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("governmentid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(GovernmentId));
                SetAttributeValue("governmentid", value);
                OnPropertyChanged(nameof(GovernmentId));
            }
        }

		/// <summary>
		/// Select whether the contact has any children for reference in follow-up phone calls and other communications.
		/// </summary>
		[AttributeLogicalName("haschildrencode")]
        public OptionSetValue HasChildrenCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("haschildrencode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(HasChildrenCode));
                SetAttributeValue("haschildrencode", value);
                OnPropertyChanged(nameof(HasChildrenCode));
            }
        }

		/// <summary>
		/// Type a second home phone number for this contact.
		/// </summary>
		[AttributeLogicalName("home2")]
        public string Home2
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("home2");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Home2));
                SetAttributeValue("home2", value);
                OnPropertyChanged(nameof(Home2));
            }
        }

		/// <summary>
		/// Unique identifier of the data import or data migration that created this record.
		/// </summary>
		[AttributeLogicalName("importsequencenumber")]
        public int? ImportSequenceNumber
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<int?>("importsequencenumber");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ImportSequenceNumber));
                SetAttributeValue("importsequencenumber", value);
                OnPropertyChanged(nameof(ImportSequenceNumber));
            }
        }

		/// <summary>
		/// Select whether the contact exists in a separate accounting or other system, such as Microsoft Dynamics GP or another ERP database, for use in integration processes.
		/// </summary>
		[AttributeLogicalName("isbackofficecustomer")]
        public bool? IsBackofficeCustomer
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("isbackofficecustomer");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(IsBackofficeCustomer));
                SetAttributeValue("isbackofficecustomer", value);
                OnPropertyChanged(nameof(IsBackofficeCustomer));
            }
        }

		/// <summary>
		/// Type the job title of the contact to make sure the contact is addressed correctly in sales calls, email, and marketing campaigns.
		/// </summary>
		[AttributeLogicalName("jobtitle")]
        public string JobTitle
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("jobtitle");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(JobTitle));
                SetAttributeValue("jobtitle", value);
                OnPropertyChanged(nameof(JobTitle));
            }
        }

		/// <summary>
		/// Type the contact's last name to make sure the contact is addressed correctly in sales calls, email, and marketing campaigns.
		/// </summary>
		[AttributeLogicalName("lastname")]
        public string LastName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("lastname");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(LastName));
                SetAttributeValue("lastname", value);
                OnPropertyChanged(nameof(LastName));
            }
        }

		/// <summary>
		/// Contains the date and time stamp of the last on hold time.
		/// </summary>
		[AttributeLogicalName("lastonholdtime")]
        public DateTime? LastOnHoldTime
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("lastonholdtime");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(LastOnHoldTime));
                SetAttributeValue("lastonholdtime", value);
                OnPropertyChanged(nameof(LastOnHoldTime));
            }
        }

		/// <summary>
		/// Shows the date when the contact was last included in a marketing campaign or quick campaign.
		/// </summary>
		[AttributeLogicalName("lastusedincampaign")]
        public DateTime? LastUsedInCampaign
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("lastusedincampaign");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(LastUsedInCampaign));
                SetAttributeValue("lastusedincampaign", value);
                OnPropertyChanged(nameof(LastUsedInCampaign));
            }
        }

		/// <summary>
		/// Select the primary marketing source that directed the contact to your organization.
		/// </summary>
		[AttributeLogicalName("leadsourcecode")]
        public OptionSetValue LeadSourceCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("leadsourcecode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(LeadSourceCode));
                SetAttributeValue("leadsourcecode", value);
                OnPropertyChanged(nameof(LeadSourceCode));
            }
        }

		/// <summary>
		/// Type the name of the contact's manager for use in escalating issues or other follow-up communications with the contact.
		/// </summary>
		[AttributeLogicalName("managername")]
        public string ManagerName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("managername");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ManagerName));
                SetAttributeValue("managername", value);
                OnPropertyChanged(nameof(ManagerName));
            }
        }

		/// <summary>
		/// Type the phone number for the contact's manager.
		/// </summary>
		[AttributeLogicalName("managerphone")]
        public string ManagerPhone
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("managerphone");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ManagerPhone));
                SetAttributeValue("managerphone", value);
                OnPropertyChanged(nameof(ManagerPhone));
            }
        }

		/// <summary>
		/// Whether is only for marketing
		/// </summary>
		[AttributeLogicalName("marketingonly")]
        public bool? MarketingOnly
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("marketingonly");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MarketingOnly));
                SetAttributeValue("marketingonly", value);
                OnPropertyChanged(nameof(MarketingOnly));
            }
        }

		/// <summary>
		/// Unique identifier of the master contact for merge.
		/// </summary>
		[AttributeLogicalName("masterid")]
        public EntityReference MasterId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("masterid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MasterId));
                SetAttributeValue("masterid", value);
                OnPropertyChanged(nameof(MasterId));
            }
        }

		/// <summary>
		/// Shows whether the account has been merged with a master contact.
		/// </summary>
		[AttributeLogicalName("merged")]
        public bool? Merged
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("merged");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Merged));
                SetAttributeValue("merged", value);
                OnPropertyChanged(nameof(Merged));
            }
        }

		/// <summary>
		/// Type the contact's middle name or initial to make sure the contact is addressed correctly.
		/// </summary>
		[AttributeLogicalName("middlename")]
        public string MiddleName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("middlename");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MiddleName));
                SetAttributeValue("middlename", value);
                OnPropertyChanged(nameof(MiddleName));
            }
        }

		/// <summary>
		/// Type the mobile phone number for the contact.
		/// </summary>
		[AttributeLogicalName("mobilephone")]
        public string MobilePhone
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("mobilephone");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MobilePhone));
                SetAttributeValue("mobilephone", value);
                OnPropertyChanged(nameof(MobilePhone));
            }
        }

		/// <summary>
		/// Shows who last updated the record.
		/// </summary>
		[AttributeLogicalName("modifiedby")]
        public EntityReference ModifiedBy
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("modifiedby");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ModifiedBy));
                SetAttributeValue("modifiedby", value);
                OnPropertyChanged(nameof(ModifiedBy));
            }
        }

		/// <summary>
		/// Shows the external party who modified the record.
		/// </summary>
		[AttributeLogicalName("modifiedbyexternalparty")]
        public EntityReference ModifiedByExternalParty
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("modifiedbyexternalparty");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ModifiedByExternalParty));
                SetAttributeValue("modifiedbyexternalparty", value);
                OnPropertyChanged(nameof(ModifiedByExternalParty));
            }
        }

		/// <summary>
		/// Shows the date and time when the record was last updated. The date and time are displayed in the time zone selected in Microsoft Dynamics 365 options.
		/// </summary>
		[AttributeLogicalName("modifiedon")]
        public DateTime? ModifiedOn
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("modifiedon");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ModifiedOn));
                SetAttributeValue("modifiedon", value);
                OnPropertyChanged(nameof(ModifiedOn));
            }
        }

		/// <summary>
		/// Shows who last updated the record on behalf of another user.
		/// </summary>
		[AttributeLogicalName("modifiedonbehalfby")]
        public EntityReference ModifiedOnBehalfBy
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("modifiedonbehalfby");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ModifiedOnBehalfBy));
                SetAttributeValue("modifiedonbehalfby", value);
                OnPropertyChanged(nameof(ModifiedOnBehalfBy));
            }
        }

		
		[AttributeLogicalName("ms_tarifrechneraddin")]
        public string MsTarifrechnerAddin
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("ms_tarifrechneraddin");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsTarifrechnerAddin));
                SetAttributeValue("ms_tarifrechneraddin", value);
                OnPropertyChanged(nameof(MsTarifrechnerAddin));
            }
        }

		/// <summary>
		/// Unique identifier for Account associated with Contact.
		/// </summary>
		[AttributeLogicalName("msa_managingpartnerid")]
        public EntityReference MsaManagingpartnerid
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msa_managingpartnerid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsaManagingpartnerid));
                SetAttributeValue("msa_managingpartnerid", value);
                OnPropertyChanged(nameof(MsaManagingpartnerid));
            }
        }

		/// <summary>
		/// Maps to contact KPI records
		/// </summary>
		[AttributeLogicalName("msdyn_contactkpiid")]
        public EntityReference MsdynContactkpiid
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msdyn_contactkpiid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdynContactkpiid));
                SetAttributeValue("msdyn_contactkpiid", value);
                OnPropertyChanged(nameof(MsdynContactkpiid));
            }
        }

		/// <summary>
		/// Indicate buying influence using labels
		/// </summary>
		[AttributeLogicalName("msdyn_decisioninfluencetag")]
        public OptionSetValue MsdynDecisioninfluencetag
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("msdyn_decisioninfluencetag");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdynDecisioninfluencetag));
                SetAttributeValue("msdyn_decisioninfluencetag", value);
                OnPropertyChanged(nameof(MsdynDecisioninfluencetag));
            }
        }

		/// <summary>
		/// Indicates that the contact has opted out of web tracking.
		/// </summary>
		[AttributeLogicalName("msdyn_disablewebtracking")]
        public bool? MsdynDisablewebtracking
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("msdyn_disablewebtracking");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdynDisablewebtracking));
                SetAttributeValue("msdyn_disablewebtracking", value);
                OnPropertyChanged(nameof(MsdynDisablewebtracking));
            }
        }

		/// <summary>
		/// Describes whether contact is opted out or not
		/// </summary>
		[AttributeLogicalName("msdyn_gdproptout")]
        public bool? MsdynGdproptout
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("msdyn_gdproptout");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdynGdproptout));
                SetAttributeValue("msdyn_gdproptout", value);
                OnPropertyChanged(nameof(MsdynGdproptout));
            }
        }

		/// <summary>
		/// Describes if the contact is an assistant in org chart
		/// </summary>
		[AttributeLogicalName("msdyn_isassistantinorgchart")]
        public bool? MsdynIsassistantinorgchart
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("msdyn_isassistantinorgchart");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdynIsassistantinorgchart));
                SetAttributeValue("msdyn_isassistantinorgchart", value);
                OnPropertyChanged(nameof(MsdynIsassistantinorgchart));
            }
        }

		/// <summary>
		/// Indicates that the contact is considered a minor in their jurisdiction.
		/// </summary>
		[AttributeLogicalName("msdyn_isminor")]
        public bool? MsdynIsminor
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("msdyn_isminor");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdynIsminor));
                SetAttributeValue("msdyn_isminor", value);
                OnPropertyChanged(nameof(MsdynIsminor));
            }
        }

		/// <summary>
		/// Indicates that the contact is considered a minor in their jurisdiction and has parental consent.
		/// </summary>
		[AttributeLogicalName("msdyn_isminorwithparentalconsent")]
        public bool? MsdynIsminorwithparentalconsent
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("msdyn_isminorwithparentalconsent");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdynIsminorwithparentalconsent));
                SetAttributeValue("msdyn_isminorwithparentalconsent", value);
                OnPropertyChanged(nameof(MsdynIsminorwithparentalconsent));
            }
        }

		/// <summary>
		/// Whether or not the contact belongs to the associated account
		/// </summary>
		[AttributeLogicalName("msdyn_orgchangestatus")]
        public OptionSetValue MsdynOrgchangestatus
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("msdyn_orgchangestatus");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdynOrgchangestatus));
                SetAttributeValue("msdyn_orgchangestatus", value);
                OnPropertyChanged(nameof(MsdynOrgchangestatus));
            }
        }

		/// <summary>
		/// Indicates the date and time that the person agreed to the portal terms and conditions.
		/// </summary>
		[AttributeLogicalName("msdyn_portaltermsagreementdate")]
        public DateTime? MsdynPortaltermsagreementdate
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("msdyn_portaltermsagreementdate");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdynPortaltermsagreementdate));
                SetAttributeValue("msdyn_portaltermsagreementdate", value);
                OnPropertyChanged(nameof(MsdynPortaltermsagreementdate));
            }
        }

		/// <summary>
		/// Unique identifier for Segment associated with contact.
		/// </summary>
		[AttributeLogicalName("msdyn_segmentid")]
        public EntityReference MsdynSegmentid
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msdyn_segmentid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdynSegmentid));
                SetAttributeValue("msdyn_segmentid", value);
                OnPropertyChanged(nameof(MsdynSegmentid));
            }
        }

		/// <summary>
		/// Unique identifier for Quick Send Email associated with Contact.
		/// </summary>
		[AttributeLogicalName("msdyncrm_contactid")]
        public EntityReference MsdyncrmContactId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msdyncrm_contactid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdyncrmContactId));
                SetAttributeValue("msdyncrm_contactid", value);
                OnPropertyChanged(nameof(MsdyncrmContactId));
            }
        }

		
		[AttributeLogicalName("msdyncrm_customerjourneyid")]
        public EntityReference MsdyncrmCustomerjourneyid
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msdyncrm_customerjourneyid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdyncrmCustomerjourneyid));
                SetAttributeValue("msdyncrm_customerjourneyid", value);
                OnPropertyChanged(nameof(MsdyncrmCustomerjourneyid));
            }
        }

		
		[AttributeLogicalName("msdyncrm_emailid")]
        public EntityReference MsdyncrmEmailid
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msdyncrm_emailid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdyncrmEmailid));
                SetAttributeValue("msdyncrm_emailid", value);
                OnPropertyChanged(nameof(MsdyncrmEmailid));
            }
        }

		
		[AttributeLogicalName("msdyncrm_insights_placeholder")]
        public string MsdyncrmInsightsPlaceholder
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("msdyncrm_insights_placeholder");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdyncrmInsightsPlaceholder));
                SetAttributeValue("msdyncrm_insights_placeholder", value);
                OnPropertyChanged(nameof(MsdyncrmInsightsPlaceholder));
            }
        }

		
		[AttributeLogicalName("msdyncrm_marketingformid")]
        public EntityReference MsdyncrmMarketingformid
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msdyncrm_marketingformid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdyncrmMarketingformid));
                SetAttributeValue("msdyncrm_marketingformid", value);
                OnPropertyChanged(nameof(MsdyncrmMarketingformid));
            }
        }

		
		[AttributeLogicalName("msdyncrm_marketingformsubmissiondateprecise")]
        public string MsdyncrmMarketingformsubmissiondateprecise
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("msdyncrm_marketingformsubmissiondateprecise");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdyncrmMarketingformsubmissiondateprecise));
                SetAttributeValue("msdyncrm_marketingformsubmissiondateprecise", value);
                OnPropertyChanged(nameof(MsdyncrmMarketingformsubmissiondateprecise));
            }
        }

		
		[AttributeLogicalName("msdyncrm_marketingpageid")]
        public EntityReference MsdyncrmMarketingpageid
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msdyncrm_marketingpageid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdyncrmMarketingpageid));
                SetAttributeValue("msdyncrm_marketingpageid", value);
                OnPropertyChanged(nameof(MsdyncrmMarketingpageid));
            }
        }

		
		[AttributeLogicalName("msdyncrm_rememberme")]
        public bool? MsdyncrmRememberMe
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("msdyncrm_rememberme");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdyncrmRememberMe));
                SetAttributeValue("msdyncrm_rememberme", value);
                OnPropertyChanged(nameof(MsdyncrmRememberMe));
            }
        }

		/// <summary>
		/// Unique identifier for Segment associated with Contact.
		/// </summary>
		[AttributeLogicalName("msdyncrm_segmentmemberid")]
        public EntityReference MsdyncrmSegmentMemberId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msdyncrm_segmentmemberid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdyncrmSegmentMemberId));
                SetAttributeValue("msdyncrm_segmentmemberid", value);
                OnPropertyChanged(nameof(MsdyncrmSegmentMemberId));
            }
        }

		
		[AttributeLogicalName("msdynmkt_customerjourneyid")]
        public EntityReference MsdynmktCustomerjourneyid
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msdynmkt_customerjourneyid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdynmktCustomerjourneyid));
                SetAttributeValue("msdynmkt_customerjourneyid", value);
                OnPropertyChanged(nameof(MsdynmktCustomerjourneyid));
            }
        }

		
		[AttributeLogicalName("msdynmkt_emailid")]
        public EntityReference MsdynmktEmailid
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msdynmkt_emailid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdynmktEmailid));
                SetAttributeValue("msdynmkt_emailid", value);
                OnPropertyChanged(nameof(MsdynmktEmailid));
            }
        }

		
		[AttributeLogicalName("msdynmkt_marketingformid")]
        public EntityReference MsdynmktMarketingformid
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msdynmkt_marketingformid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsdynmktMarketingformid));
                SetAttributeValue("msdynmkt_marketingformid", value);
                OnPropertyChanged(nameof(MsdynmktMarketingformid));
            }
        }

		
		[AttributeLogicalName("msevtmgt_aadobjectid")]
        public string MsevtmgtAadobjectid
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("msevtmgt_aadobjectid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsevtmgtAadobjectid));
                SetAttributeValue("msevtmgt_aadobjectid", value);
                OnPropertyChanged(nameof(MsevtmgtAadobjectid));
            }
        }

		/// <summary>
		/// Unique identifier for the check-in associated with the contact
		/// </summary>
		[AttributeLogicalName("msevtmgt_contactid")]
        public EntityReference MsevtmgtContactId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msevtmgt_contactid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsevtmgtContactId));
                SetAttributeValue("msevtmgt_contactid", value);
                OnPropertyChanged(nameof(MsevtmgtContactId));
            }
        }

		/// <summary>
		/// For contacts created by registering for an event in Microsoft Dynamics 365, this identifies the relevant event. This is used to relate the contact to the data on the originating event.
		/// </summary>
		[AttributeLogicalName("msevtmgt_originatingeventid")]
        public EntityReference MsevtmgtOriginatingeventid
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msevtmgt_originatingeventid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsevtmgtOriginatingeventid));
                SetAttributeValue("msevtmgt_originatingeventid", value);
                OnPropertyChanged(nameof(MsevtmgtOriginatingeventid));
            }
        }

		
		[AttributeLogicalName("msgdpr_consentchangesourceformid")]
        public EntityReference MsgdprConsentchangesourceformId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msgdpr_consentchangesourceformid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsgdprConsentchangesourceformId));
                SetAttributeValue("msgdpr_consentchangesourceformid", value);
                OnPropertyChanged(nameof(MsgdprConsentchangesourceformId));
            }
        }

		/// <summary>
		/// Select whether contact allows tracking interaction data. If Do Not Allow is selected, Microsoft Dynamics 365 will not save interaction data for the contact.
		/// </summary>
		[AttributeLogicalName("msgdpr_donottrack")]
        public bool? MsgdprDonottrack
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("msgdpr_donottrack");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsgdprDonottrack));
                SetAttributeValue("msgdpr_donottrack", value);
                OnPropertyChanged(nameof(MsgdprDonottrack));
            }
        }

		
		[AttributeLogicalName("msgdpr_gdprconsent")]
        public OptionSetValue MsgdprGdprconsent
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("msgdpr_gdprconsent");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsgdprGdprconsent));
                SetAttributeValue("msgdpr_gdprconsent", value);
                OnPropertyChanged(nameof(MsgdprGdprconsent));
            }
        }

		
		[AttributeLogicalName("msgdpr_gdprischild")]
        public bool? MsgdprGdprischild
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("msgdpr_gdprischild");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsgdprGdprischild));
                SetAttributeValue("msgdpr_gdprischild", value);
                OnPropertyChanged(nameof(MsgdprGdprischild));
            }
        }

		/// <summary>
		/// Unique identifier for the contact associated with the contact
		/// </summary>
		[AttributeLogicalName("msgdpr_gdprparentid")]
        public EntityReference MsgdprGDPRParentId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("msgdpr_gdprparentid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsgdprGDPRParentId));
                SetAttributeValue("msgdpr_gdprparentid", value);
                OnPropertyChanged(nameof(MsgdprGDPRParentId));
            }
        }

		/// <summary>
		/// User’s preferred portal language
		/// </summary>
		[AttributeLogicalName("mspp_userpreferredlcid")]
        public OptionSetValue MsppUserpreferredlcid
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("mspp_userpreferredlcid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(MsppUserpreferredlcid));
                SetAttributeValue("mspp_userpreferredlcid", value);
                OnPropertyChanged(nameof(MsppUserpreferredlcid));
            }
        }

		/// <summary>
		/// Type the contact's nickname.
		/// </summary>
		[AttributeLogicalName("nickname")]
        public string NickName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("nickname");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(NickName));
                SetAttributeValue("nickname", value);
                OnPropertyChanged(nameof(NickName));
            }
        }

		/// <summary>
		/// Type the number of children the contact has for reference in follow-up phone calls and other communications.
		/// </summary>
		[AttributeLogicalName("numberofchildren")]
        public int? NumberOfChildren
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<int?>("numberofchildren");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(NumberOfChildren));
                SetAttributeValue("numberofchildren", value);
                OnPropertyChanged(nameof(NumberOfChildren));
            }
        }

		/// <summary>
		/// Shows how long, in minutes, that the record was on hold.
		/// </summary>
		[AttributeLogicalName("onholdtime")]
        public int? OnHoldTime
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<int?>("onholdtime");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(OnHoldTime));
                SetAttributeValue("onholdtime", value);
                OnPropertyChanged(nameof(OnHoldTime));
            }
        }

		/// <summary>
		/// Shows the lead that the contact was created if the contact was created by converting a lead in Microsoft Dynamics 365. This is used to relate the contact to the data on the originating lead for use in reporting and analytics.
		/// </summary>
		[AttributeLogicalName("originatingleadid")]
        public EntityReference OriginatingLeadId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("originatingleadid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(OriginatingLeadId));
                SetAttributeValue("originatingleadid", value);
                OnPropertyChanged(nameof(OriginatingLeadId));
            }
        }

		/// <summary>
		/// Date and time that the record was migrated.
		/// </summary>
		[AttributeLogicalName("overriddencreatedon")]
        public DateTime? OverriddenCreatedOn
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<DateTime?>("overriddencreatedon");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(OverriddenCreatedOn));
                SetAttributeValue("overriddencreatedon", value);
                OnPropertyChanged(nameof(OverriddenCreatedOn));
            }
        }

		/// <summary>
		/// Enter the user or team who is assigned to manage the record. This field is updated every time the record is assigned to a different user.
		/// </summary>
		[AttributeLogicalName("ownerid")]
        public EntityReference OwnerId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("ownerid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(OwnerId));
                SetAttributeValue("ownerid", value);
                OnPropertyChanged(nameof(OwnerId));
            }
        }

		/// <summary>
		/// Unique identifier of the business unit that owns the contact.
		/// </summary>
		[AttributeLogicalName("owningbusinessunit")]
        public EntityReference OwningBusinessUnit
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("owningbusinessunit");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(OwningBusinessUnit));
                SetAttributeValue("owningbusinessunit", value);
                OnPropertyChanged(nameof(OwningBusinessUnit));
            }
        }

		/// <summary>
		/// Unique identifier of the team who owns the contact.
		/// </summary>
		[AttributeLogicalName("owningteam")]
        public EntityReference OwningTeam
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("owningteam");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(OwningTeam));
                SetAttributeValue("owningteam", value);
                OnPropertyChanged(nameof(OwningTeam));
            }
        }

		/// <summary>
		/// Unique identifier of the user who owns the contact.
		/// </summary>
		[AttributeLogicalName("owninguser")]
        public EntityReference OwningUser
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("owninguser");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(OwningUser));
                SetAttributeValue("owninguser", value);
                OnPropertyChanged(nameof(OwningUser));
            }
        }

		/// <summary>
		/// Type the pager number for the contact.
		/// </summary>
		[AttributeLogicalName("pager")]
        public string Pager
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("pager");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Pager));
                SetAttributeValue("pager", value);
                OnPropertyChanged(nameof(Pager));
            }
        }

		/// <summary>
		/// Unique identifier of the parent contact.
		/// </summary>
		[AttributeLogicalName("parentcontactid")]
        public EntityReference ParentContactId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("parentcontactid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ParentContactId));
                SetAttributeValue("parentcontactid", value);
                OnPropertyChanged(nameof(ParentContactId));
            }
        }

		/// <summary>
		/// Select the parent account or parent contact for the contact to provide a quick link to additional details, such as financial information, activities, and opportunities.
		/// </summary>
		[AttributeLogicalName("parentcustomerid")]
        public EntityReference ParentCustomerId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("parentcustomerid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ParentCustomerId));
                SetAttributeValue("parentcustomerid", value);
                OnPropertyChanged(nameof(ParentCustomerId));
            }
        }

		/// <summary>
		/// Shows whether the contact participates in workflow rules.
		/// </summary>
		[AttributeLogicalName("participatesinworkflow")]
        public bool? ParticipatesInWorkflow
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<bool?>("participatesinworkflow");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ParticipatesInWorkflow));
                SetAttributeValue("participatesinworkflow", value);
                OnPropertyChanged(nameof(ParticipatesInWorkflow));
            }
        }

		/// <summary>
		/// Select the payment terms to indicate when the customer needs to pay the total amount.
		/// </summary>
		[AttributeLogicalName("paymenttermscode")]
        public OptionSetValue PaymentTermsCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("paymenttermscode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(PaymentTermsCode));
                SetAttributeValue("paymenttermscode", value);
                OnPropertyChanged(nameof(PaymentTermsCode));
            }
        }

		/// <summary>
		/// Select the preferred day of the week for service appointments.
		/// </summary>
		[AttributeLogicalName("preferredappointmentdaycode")]
        public OptionSetValue PreferredAppointmentDayCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("preferredappointmentdaycode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(PreferredAppointmentDayCode));
                SetAttributeValue("preferredappointmentdaycode", value);
                OnPropertyChanged(nameof(PreferredAppointmentDayCode));
            }
        }

		/// <summary>
		/// Select the preferred time of day for service appointments.
		/// </summary>
		[AttributeLogicalName("preferredappointmenttimecode")]
        public OptionSetValue PreferredAppointmentTimeCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("preferredappointmenttimecode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(PreferredAppointmentTimeCode));
                SetAttributeValue("preferredappointmenttimecode", value);
                OnPropertyChanged(nameof(PreferredAppointmentTimeCode));
            }
        }

		/// <summary>
		/// Select the preferred method of contact.
		/// </summary>
		[AttributeLogicalName("preferredcontactmethodcode")]
        public OptionSetValue PreferredContactMethodCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("preferredcontactmethodcode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(PreferredContactMethodCode));
                SetAttributeValue("preferredcontactmethodcode", value);
                OnPropertyChanged(nameof(PreferredContactMethodCode));
            }
        }

		/// <summary>
		/// Choose the contact's preferred service facility or equipment to make sure services are scheduled correctly for the customer.
		/// </summary>
		[AttributeLogicalName("preferredequipmentid")]
        public EntityReference PreferredEquipmentId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("preferredequipmentid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(PreferredEquipmentId));
                SetAttributeValue("preferredequipmentid", value);
                OnPropertyChanged(nameof(PreferredEquipmentId));
            }
        }

		/// <summary>
		/// Choose the contact's preferred service to make sure services are scheduled correctly for the customer.
		/// </summary>
		[AttributeLogicalName("preferredserviceid")]
        public EntityReference PreferredServiceId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("preferredserviceid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(PreferredServiceId));
                SetAttributeValue("preferredserviceid", value);
                OnPropertyChanged(nameof(PreferredServiceId));
            }
        }

		/// <summary>
		/// Choose the regular or preferred customer service representative for reference when scheduling service activities for the contact.
		/// </summary>
		[AttributeLogicalName("preferredsystemuserid")]
        public EntityReference PreferredSystemUserId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("preferredsystemuserid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(PreferredSystemUserId));
                SetAttributeValue("preferredsystemuserid", value);
                OnPropertyChanged(nameof(PreferredSystemUserId));
            }
        }

		/// <summary>
		/// Shows the ID of the process.
		/// </summary>
		[AttributeLogicalName("processid")]
        public Guid? ProcessId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Guid?>("processid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ProcessId));
                SetAttributeValue("processid", value);
                OnPropertyChanged(nameof(ProcessId));
            }
        }

		/// <summary>
		/// Type the salutation of the contact to make sure the contact is addressed correctly in sales calls, email messages, and marketing campaigns.
		/// </summary>
		[AttributeLogicalName("salutation")]
        public string Salutation
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("salutation");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Salutation));
                SetAttributeValue("salutation", value);
                OnPropertyChanged(nameof(Salutation));
            }
        }

		/// <summary>
		/// Select a shipping method for deliveries sent to this address.
		/// </summary>
		[AttributeLogicalName("shippingmethodcode")]
        public OptionSetValue ShippingMethodCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("shippingmethodcode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(ShippingMethodCode));
                SetAttributeValue("shippingmethodcode", value);
                OnPropertyChanged(nameof(ShippingMethodCode));
            }
        }

		/// <summary>
		/// Choose the service level agreement (SLA) that you want to apply to the Contact record.
		/// </summary>
		[AttributeLogicalName("slaid")]
        public EntityReference SLAId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("slaid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(SLAId));
                SetAttributeValue("slaid", value);
                OnPropertyChanged(nameof(SLAId));
            }
        }

		/// <summary>
		/// Last SLA that was applied to this case. This field is for internal use only.
		/// </summary>
		[AttributeLogicalName("slainvokedid")]
        public EntityReference SLAInvokedId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("slainvokedid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(SLAInvokedId));
                SetAttributeValue("slainvokedid", value);
                OnPropertyChanged(nameof(SLAInvokedId));
            }
        }

		/// <summary>
		/// Type the name of the contact's spouse or partner for reference during calls, events, or other communications with the contact.
		/// </summary>
		[AttributeLogicalName("spousesname")]
        public string SpousesName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("spousesname");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(SpousesName));
                SetAttributeValue("spousesname", value);
                OnPropertyChanged(nameof(SpousesName));
            }
        }

		/// <summary>
		/// Shows the ID of the stage.
		/// </summary>
		[AttributeLogicalName("stageid")]
        public Guid? StageId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<Guid?>("stageid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(StageId));
                SetAttributeValue("stageid", value);
                OnPropertyChanged(nameof(StageId));
            }
        }

		/// <summary>
		/// Shows whether the contact is active or inactive. Inactive contacts are read-only and can't be edited unless they are reactivated.
		/// </summary>
		[AttributeLogicalName("statecode")]
        public OptionSetValue StateCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("statecode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(StateCode));
                SetAttributeValue("statecode", value);
                OnPropertyChanged(nameof(StateCode));
            }
        }

		/// <summary>
		/// Select the contact's status.
		/// </summary>
		[AttributeLogicalName("statuscode")]
        public OptionSetValue StatusCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("statuscode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(StatusCode));
                SetAttributeValue("statuscode", value);
                OnPropertyChanged(nameof(StatusCode));
            }
        }

		/// <summary>
		/// For internal use only.
		/// </summary>
		[AttributeLogicalName("subscriptionid")]
        public Guid? SubscriptionId
        {
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(SubscriptionId));
                SetAttributeValue("subscriptionid", value);
                OnPropertyChanged(nameof(SubscriptionId));
            }
        }

		/// <summary>
		/// Type the suffix used in the contact's name, such as Jr. or Sr. to make sure the contact is addressed correctly in sales calls, email, and marketing campaigns.
		/// </summary>
		[AttributeLogicalName("suffix")]
        public string Suffix
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("suffix");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Suffix));
                SetAttributeValue("suffix", value);
                OnPropertyChanged(nameof(Suffix));
            }
        }

		/// <summary>
		/// Number of users or conversations followed the record
		/// </summary>
		[AttributeLogicalName("teamsfollowed")]
        public int? TeamsFollowed
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<int?>("teamsfollowed");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(TeamsFollowed));
                SetAttributeValue("teamsfollowed", value);
                OnPropertyChanged(nameof(TeamsFollowed));
            }
        }

		/// <summary>
		/// Type the main phone number for this contact.
		/// </summary>
		[AttributeLogicalName("telephone1")]
        public string Telephone1
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("telephone1");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Telephone1));
                SetAttributeValue("telephone1", value);
                OnPropertyChanged(nameof(Telephone1));
            }
        }

		/// <summary>
		/// Type a second phone number for this contact.
		/// </summary>
		[AttributeLogicalName("telephone2")]
        public string Telephone2
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("telephone2");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Telephone2));
                SetAttributeValue("telephone2", value);
                OnPropertyChanged(nameof(Telephone2));
            }
        }

		/// <summary>
		/// Type a third phone number for this contact.
		/// </summary>
		[AttributeLogicalName("telephone3")]
        public string Telephone3
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("telephone3");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(Telephone3));
                SetAttributeValue("telephone3", value);
                OnPropertyChanged(nameof(Telephone3));
            }
        }

		/// <summary>
		/// Select a region or territory for the contact for use in segmentation and analysis.
		/// </summary>
		[AttributeLogicalName("territorycode")]
        public OptionSetValue TerritoryCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<OptionSetValue>("territorycode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(TerritoryCode));
                SetAttributeValue("territorycode", value);
                OnPropertyChanged(nameof(TerritoryCode));
            }
        }

		/// <summary>
		/// Total time spent for emails (read and write) and meetings by me in relation to the contact record.
		/// </summary>
		[AttributeLogicalName("timespentbymeonemailandmeetings")]
        public string TimeSpentByMeOnEmailAndMeetings
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("timespentbymeonemailandmeetings");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(TimeSpentByMeOnEmailAndMeetings));
                SetAttributeValue("timespentbymeonemailandmeetings", value);
                OnPropertyChanged(nameof(TimeSpentByMeOnEmailAndMeetings));
            }
        }

		/// <summary>
		/// For internal use only.
		/// </summary>
		[AttributeLogicalName("timezoneruleversionnumber")]
        public int? TimeZoneRuleVersionNumber
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<int?>("timezoneruleversionnumber");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(TimeZoneRuleVersionNumber));
                SetAttributeValue("timezoneruleversionnumber", value);
                OnPropertyChanged(nameof(TimeZoneRuleVersionNumber));
            }
        }

		/// <summary>
		/// Choose the local currency for the record to make sure budgets are reported in the correct currency.
		/// </summary>
		[AttributeLogicalName("transactioncurrencyid")]
        public EntityReference TransactionCurrencyId
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<EntityReference>("transactioncurrencyid");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(TransactionCurrencyId));
                SetAttributeValue("transactioncurrencyid", value);
                OnPropertyChanged(nameof(TransactionCurrencyId));
            }
        }

		/// <summary>
		/// For internal use only.
		/// </summary>
		[AttributeLogicalName("traversedpath")]
        public string TraversedPath
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("traversedpath");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(TraversedPath));
                SetAttributeValue("traversedpath", value);
                OnPropertyChanged(nameof(TraversedPath));
            }
        }

		/// <summary>
		/// Time zone code that was in use when the record was created.
		/// </summary>
		[AttributeLogicalName("utcconversiontimezonecode")]
        public int? UTCConversionTimeZoneCode
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<int?>("utcconversiontimezonecode");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(UTCConversionTimeZoneCode));
                SetAttributeValue("utcconversiontimezonecode", value);
                OnPropertyChanged(nameof(UTCConversionTimeZoneCode));
            }
        }

		/// <summary>
		/// Version number of the contact.
		/// </summary>
		[AttributeLogicalName("versionnumber")]
        public long? VersionNumber
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<long?>("versionnumber");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(VersionNumber));
                SetAttributeValue("versionnumber", value);
                OnPropertyChanged(nameof(VersionNumber));
            }
        }

		/// <summary>
		/// Type the contact's professional or personal website or blog URL.
		/// </summary>
		[AttributeLogicalName("websiteurl")]
        public string WebSiteUrl
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("websiteurl");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(WebSiteUrl));
                SetAttributeValue("websiteurl", value);
                OnPropertyChanged(nameof(WebSiteUrl));
            }
        }

		/// <summary>
		/// Type the phonetic spelling of the contact's first name, if the name is specified in Japanese, to make sure the name is pronounced correctly in phone calls with the contact.
		/// </summary>
		[AttributeLogicalName("yomifirstname")]
        public string YomiFirstName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("yomifirstname");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(YomiFirstName));
                SetAttributeValue("yomifirstname", value);
                OnPropertyChanged(nameof(YomiFirstName));
            }
        }

		/// <summary>
		/// Shows the combined Yomi first and last names of the contact so that the full phonetic name can be displayed in views and reports.
		/// </summary>
		[AttributeLogicalName("yomifullname")]
        public string YomiFullName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("yomifullname");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(YomiFullName));
                SetAttributeValue("yomifullname", value);
                OnPropertyChanged(nameof(YomiFullName));
            }
        }

		/// <summary>
		/// Type the phonetic spelling of the contact's last name, if the name is specified in Japanese, to make sure the name is pronounced correctly in phone calls with the contact.
		/// </summary>
		[AttributeLogicalName("yomilastname")]
        public string YomiLastName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("yomilastname");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(YomiLastName));
                SetAttributeValue("yomilastname", value);
                OnPropertyChanged(nameof(YomiLastName));
            }
        }

		/// <summary>
		/// Type the phonetic spelling of the contact's middle name, if the name is specified in Japanese, to make sure the name is pronounced correctly in phone calls with the contact.
		/// </summary>
		[AttributeLogicalName("yomimiddlename")]
        public string YomiMiddleName
        {
            [DebuggerNonUserCode]
			get
            {
                return GetAttributeValue<string>("yomimiddlename");
            }
            [DebuggerNonUserCode]
			set
            {
                OnPropertyChanging(nameof(YomiMiddleName));
                SetAttributeValue("yomimiddlename", value);
                OnPropertyChanged(nameof(YomiMiddleName));
            }
        }


		#endregion

		#region NavigationProperties
		/// <summary>
		/// 1:N account_primary_contact
		/// </summary>	
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("account_primary_contact")]
		public System.Collections.Generic.IEnumerable<Account> AccountPrimaryContact
		{
			[DebuggerNonUserCode]
			get
			{
				return this.GetRelatedEntities<Account>("account_primary_contact", null);
			}
			[DebuggerNonUserCode]
			set
			{
				this.OnPropertyChanging("AccountPrimaryContact");
				this.SetRelatedEntities<Account>("account_primary_contact", null, value);
				this.OnPropertyChanged("AccountPrimaryContact");
			}
		}

		/// <summary>
		/// 1:N contact_customer_contacts
		/// </summary>	
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("contact_customer_contacts")]
		public System.Collections.Generic.IEnumerable<Contact> ContactCustomerContacts
		{
			[DebuggerNonUserCode]
			get
			{
				return this.GetRelatedEntities<Contact>("contact_customer_contacts", null);
			}
			[DebuggerNonUserCode]
			set
			{
				this.OnPropertyChanging("ContactCustomerContacts");
				this.SetRelatedEntities<Contact>("contact_customer_contacts", null, value);
				this.OnPropertyChanged("ContactCustomerContacts");
			}
		}

		/// <summary>
		/// 1:N contact_master_contact
		/// </summary>	
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("contact_master_contact")]
		public System.Collections.Generic.IEnumerable<Contact> ContactMasterContact
		{
			[DebuggerNonUserCode]
			get
			{
				return this.GetRelatedEntities<Contact>("contact_master_contact", null);
			}
			[DebuggerNonUserCode]
			set
			{
				this.OnPropertyChanging("ContactMasterContact");
				this.SetRelatedEntities<Contact>("contact_master_contact", null, value);
				this.OnPropertyChanged("ContactMasterContact");
			}
		}

		/// <summary>
		/// 1:N msgdpr_contact_msgdpr_gdprparent
		/// </summary>	
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("msgdpr_contact_msgdpr_gdprparent")]
		public System.Collections.Generic.IEnumerable<Contact> MsgdprContactMsgdprGdprparent
		{
			[DebuggerNonUserCode]
			get
			{
				return this.GetRelatedEntities<Contact>("msgdpr_contact_msgdpr_gdprparent", null);
			}
			[DebuggerNonUserCode]
			set
			{
				this.OnPropertyChanging("MsgdprContactMsgdprGdprparent");
				this.SetRelatedEntities<Contact>("msgdpr_contact_msgdpr_gdprparent", null, value);
				this.OnPropertyChanged("MsgdprContactMsgdprGdprparent");
			}
		}

		#endregion

		#region Options
		public static class Options
		{
			    public struct AccountRoleCode
                {
					public const int DecisionMaker = 1;
					public const int Employee = 2;
					public const int Influencer = 3;
                }
			    public struct Address1AddressTypeCode
                {
					public const int BillTo = 1;
					public const int ShipTo = 2;
					public const int Primary = 3;
					public const int Other = 4;
                }
			    public struct Address1FreightTermsCode
                {
					public const int FOB = 1;
					public const int NoCharge = 2;
                }
			    public struct Address1ShippingMethodCode
                {
					public const int Airborne = 1;
					public const int DHL = 2;
					public const int FedEx = 3;
					public const int UPS = 4;
					public const int PostalMail = 5;
					public const int FullLoad = 6;
					public const int WillCall = 7;
                }
			    public struct Address2AddressTypeCode
                {
					public const int DefaultValue = 1;
                }
			    public struct Address2FreightTermsCode
                {
					public const int DefaultValue = 1;
                }
			    public struct Address2ShippingMethodCode
                {
					public const int DefaultValue = 1;
                }
			    public struct Address3AddressTypeCode
                {
					public const int DefaultValue = 1;
                }
			    public struct Address3FreightTermsCode
                {
					public const int DefaultValue = 1;
                }
			    public struct Address3ShippingMethodCode
                {
					public const int DefaultValue = 1;
                }
                public struct AdxConfirmRemovePassword
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct AdxIdentityEmailaddress1confirmed
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct AdxIdentityLocallogindisabled
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct AdxIdentityLockoutenabled
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct AdxIdentityLogonenabled
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct AdxIdentityMobilephoneconfirmed
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct AdxIdentityTwofactorenabled
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct AdxProfilealert
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct AdxProfileIsAnonymous
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct CreditOnHold
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
			    public struct CustomerSizeCode
                {
					public const int DefaultValue = 1;
                }
			    public struct CustomerTypeCode
                {
					public const int DefaultValue = 1;
                }
                public struct DgtAdvertisingnotallowedBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct DgtConsentBusinessPhoneBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct DgtConsentEmailBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct DgtConsentFaxBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct DgtConsentMailBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct DgtConsentMobilePhoneBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct DgtConsentPrivatePhoneBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
			    public struct DgtPreferredCommunicationChannelSet
                {
					public const int Postal = 596030000;
					public const int PrivateEmail = 596030001;
					public const int BusinessEmail = 596030002;
					public const int ElectronicMailbox = 596030003;
                }
			    public struct DgtSalutationSet
                {
					public const int Other = 0;
					public const int Mr_ = 1;
					public const int Mrs_ = 2;
                }
			    public struct DgtTitleSet
                {
					public const int Dipl_Betriebswirt = 1;
					public const int Dres_ = 2;
					public const int Dr_ = 3;
					public const int Prof_ = 4;
					public const int Prof_Dr_ = 5;
					public const int Rechtsanwältin = 6;
					public const int Rechtsanwältinnen = 7;
					public const int Direktor = 8;
					public const int Ing_ = 9;
					public const int Rechtsanwalt = 10;
					public const int Rechtsanwälte = 11;
					public const int Dipl_Ing_ = 12;
					public const int Direktorin = 13;
					public const int Dr_Med_ = 14;
					public const int RechtsanwaltDr_ = 15;
					public const int RechtsanwälteDr_ = 16;
					public const int RechtsanwältinDr_ = 17;
					public const int RechtsanwältinnenDr_ = 18;
					public const int Autohaus = 19;
					public const int Dr_Med_Vet_ = 20;
					public const int Dr_Dr_ = 22;
					public const int Dr_Ing_ = 23;
					public const int RechtsanwaltProf_Dr_ = 26;
					public const int RechtsanwälteProf_Dr_ = 27;
					public const int RechtsanwältinProf_Dr_ = 28;
					public const int RechtsanwältinnenProf_Dr_ = 29;
					public const int Freiherr = 30;
					public const int Gräfin = 31;
					public const int RechtsanwaltProf_ = 32;
					public const int RechtsanwälteProf_ = 33;
					public const int RechtsanwältinProf_ = 34;
					public const int RechtsanwältinnenProf_ = 35;
					public const int Notarin = 37;
					public const int Notare = 38;
					public const int Ing_Büro = 39;
					public const int Steuerberater = 40;
					public const int Sachverständigenbüro = 44;
					public const int Bezirksdirektor = 50;
					public const int Bezirksdirektorin = 61;
					public const int Geschäftsstellenleiter = 68;
					public const int Geschäftsstellenleiterin = 69;
					public const int Agentursparkasse = 80;
					public const int DirektorImRuhestand = 84;
					public const int DirektorinImRuhestand = 115;
					public const int Dipl_Kaufmann = 161;
					public const int Dipl_Math_ = 162;
					public const int Dipl_Kauffrau = 167;
					public const int Dipl_Med_ = 170;
					public const int Graf = 171;
					public const int Oberbürgermeister = 172;
					public const int Studienrat = 173;
					public const int OMRDr_ = 174;
					public const int Oberstudienrat = 175;
					public const int MR = 176;
					public const int MRDr_ = 177;
					public const int Sanitätsrat = 178;
					public const int Baron = 179;
					public const int Pfarrer = 180;
					public const int Erbengemeinschaft = 181;
					public const int Prof_Dr_Dr_ = 182;
					public const int Dr_Dr_Med_ = 183;
					public const int Prof_Dr_Med_ = 184;
					public const int Prof_Dr_Med__ = 185;
					public const int Dres_Med_ = 186;
					public const int Prof_Dr_Ing_ = 187;
					public const int Dr_Jur_ = 188;
					public const int Dr_Phil_ = 189;
					public const int Dr_Rer_Nat_ = 190;
					public const int Dr_Rer_Pol_ = 191;
					public const int Dr_H_C_ = 192;
					public const int Prof_H_C_ = 193;
					public const int Dr_Oec_ = 194;
					public const int Dr_Theol_ = 195;
					public const int Dr_Paed_ = 196;
					public const int Dr_Mult_ = 197;
					public const int PD = 200;
					public const int PDDr_ = 201;
					public const int PDDr_Dr_ = 202;
					public const int PDDipl_Med_ = 203;
					public const int Notar = 596030032;
                }
			    public struct DgtWagegroupSet
                {
					public const int ÖD = 596030000;
					public const int GB0 = 596030001;
					public const int GB1 = 596030002;
					public const int GB2 = 596030003;
					public const int GB3 = 596030004;
					public const int G0 = 596030005;
					public const int G1 = 596030006;
					public const int G2 = 596030007;
					public const int G3 = 596030008;
					public const int Normal = 596030009;
					public const int WNurFürKfZ = 596030010;
					public const int ANurFürKfZ = 596030011;
                }
                public struct DgtiActivePolicyBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct DgtiActivePolicyExistsBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct DgtiAppointmentTookPlace
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
			    public struct DgtiConsentCallRecordingSet
                {
					public const int ConsentRefused = 941320000;
					public const int ConsentNotGiven = 941320001;
					public const int ConsentGiven = 941320002;
                }
			    public struct DgtiConsentMarketingandProductInformation
                {
					public const int ConsentRefused = 941320000;
					public const int ConsentNotGiven = 941320001;
					public const int ConsentGiven = 941320002;
                }
			    public struct DgtiCustomerRatingSet
                {
					public const int Gold = 941320000;
					public const int Silver = 941320001;
					public const int Bronze = 941320002;
					public const int SheetMetal = 941320003;
					public const int NotRated = 941320004;
                }
			    public struct DgtiCustomerSatisfactionSet
                {
					public const int HighlySatisfied = 941320000;
					public const int Satisfied = 941320001;
					public const int Neutral = 941320002;
					public const int Dissatisfied = 941320003;
					public const int HighlyDissatisfied = 941320004;
                }
			    public struct DgtiCustomerTypeSet
                {
					public const int Prospect = 941320000;
					public const int Policyholder = 941320001;
					public const int PreviousPolicyholder = 941320002;
					public const int ContactPerson = 941320003;
					public const int AggrievedParty = 941320004;
                }
			    public struct DgtiDataProtectionConsentSet
                {
					public const int ConsentRefused = 941320000;
					public const int ConsentNotGiven = 941320001;
					public const int ConsentGiven = 941320002;
                }
                public struct DgtiDonotallowSMS
                {
                    public const bool Allow = false;
                    public const bool DoNotAllow = true;
                }
                public struct DgtiDonotpushAppPortal
                {
                    public const bool Allow = false;
                    public const bool DoNotAllow = true;
                }
                public struct DgtiDonotwhatsapp
                {
                    public const bool Allow = false;
                    public const bool DoNotAllow = true;
                }
			    public struct DgtiEmployerRoleSet
                {
					public const int ManagingDirector = 941320000;
					public const int Board = 941320001;
					public const int Associates = 941320002;
					public const int Employee = 941320003;
					public const int SeniorCommercialEmployee = 941320004;
					public const int SeniorTechnicalEmployee = 941320005;
					public const int SupervisoryBoard_BoardMember = 941320006;
					public const int Shareholder = 941320007;
					public const int AccountManager = 941320008;
					public const int Other = 941320009;
                }
                public struct DgtiExternalCoverageBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct DgtiFourActiveContractsBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct DgtiIncomeCapturedBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct DgtiLifeRelationshipBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct DgtiManagedByPartnersystemBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct DgtiOpportunityWonBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
			    public struct DgtiProfessionalExperienceSet
                {
					public const int Apprenticeship = 941320000;
					public const int _05Years = 941320001;
					public const int _615Years = 941320002;
					public const int _1630Years = 941320003;
					public const int _3150Years = 941320004;
                }
                public struct DgtiPublicHealthInsuranceBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
			    public struct DgtiSalutationSet
                {
					public const int Association = 941320000;
					public const int Company = 941320001;
					public const int Mr_ = 941320002;
					public const int Mrs_ = 941320003;
					public const int Other = 941320004;
                }
                public struct DgtiTwoOrMoreActiveContractsBit
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
			    public struct DgtiTypeOfEmploymentSet
                {
					public const int Employed = 941320000;
					public const int PublicService = 941320001;
					public const int SelfEmployed = 941320002;
                }
                public struct DoNotBulkEMail
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct DoNotBulkPostalMail
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct DoNotEMail
                {
                    public const bool Allow = false;
                    public const bool DoNotAllow = true;
                }
                public struct DoNotFax
                {
                    public const bool Zulassen = false;
                    public const bool NichtZulassen = true;
                }
                public struct DoNotPhone
                {
                    public const bool Allow = false;
                    public const bool DoNotAllow = true;
                }
                public struct DoNotPostalMail
                {
                    public const bool Zulassen = false;
                    public const bool NichtZulassen = true;
                }
                public struct DoNotSendMM
                {
                    public const bool Send = false;
                    public const bool DoNotSend = true;
                }
			    public struct EducationCode
                {
					public const int DefaultValue = 1;
                }
			    public struct FamilyStatusCode
                {
					public const int Single = 1;
					public const int Married = 2;
					public const int Divorced = 3;
					public const int Widowed = 4;
					public const int Partnered = 596030001;
					public const int LivingSeparately = 596030002;
					public const int PartnerDeceased = 596030003;
					public const int InCohabitation = 596030004;
					public const int Departnered = 596030005;
                }
                public struct FollowEmail
                {
                    public const bool DoNotAllow = false;
                    public const bool Allow = true;
                }
			    public struct GenderCode
                {
					public const int Male = 1;
					public const int Female = 2;
					public const int Unknown = 596030000;
                }
			    public struct HasChildrenCode
                {
					public const int DefaultValue = 1;
                }
                public struct IsBackofficeCustomer
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
			    public struct LeadSourceCode
                {
					public const int DefaultValue = 1;
                }
                public struct MarketingOnly
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct Merged
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
			    public struct MsdynDecisioninfluencetag
                {
					public const int DecisionMaker = 0;
					public const int Influencer = 1;
					public const int Blocker = 2;
					public const int Unknown = 3;
                }
                public struct MsdynDisablewebtracking
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct MsdynGdproptout
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct MsdynIsassistantinorgchart
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct MsdynIsminor
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
                public struct MsdynIsminorwithparentalconsent
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
			    public struct MsdynOrgchangestatus
                {
					public const int NoFeedback = 0;
					public const int NotAtCompany = 1;
					public const int Ignore = 2;
                }
                public struct MsdyncrmRememberMe
                {
                    public const bool DoNotAllow = false;
                    public const bool Allow = true;
                }
                public struct MsgdprDonottrack
                {
                    public const bool Allow = false;
                    public const bool DoNotAllow = true;
                }
			    public struct MsgdprGdprconsent
                {
					public const int _1_Consent = 587030001;
					public const int _2_Transactional = 587030002;
					public const int _3_Subscriptions = 587030003;
					public const int _4_Marketing = 587030004;
					public const int _5_Profiling = 587030005;
                }
                public struct MsgdprGdprischild
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
			    public struct MsppUserpreferredlcid
                {
					public const int Arabic = 1025;
					public const int BulgarianBulgaria = 1026;
					public const int CatalanCatalan = 1027;
					public const int ChineseTraditional = 1028;
					public const int CzechCzechRepublic = 1029;
					public const int DanishDenmark = 1030;
					public const int GermanGermany = 1031;
					public const int GreekGreece = 1032;
					public const int English = 1033;
					public const int FinnishFinland = 1035;
					public const int FrenchFrance = 1036;
					public const int Hebrew = 1037;
					public const int HungarianHungary = 1038;
					public const int ItalianItaly = 1040;
					public const int JapaneseJapan = 1041;
					public const int KoreanKorea = 1042;
					public const int DutchNetherlands = 1043;
					public const int Norwegian_Bokm_l_Norway = 1044;
					public const int PolishPoland = 1045;
					public const int PortugueseBrazil = 1046;
					public const int RomanianRomania = 1048;
					public const int RussianRussia = 1049;
					public const int CroatianCroatia = 1050;
					public const int SlovakSlovakia = 1051;
					public const int SwedishSweden = 1053;
					public const int ThaiThailand = 1054;
					public const int TurkishTürkiye = 1055;
					public const int IndonesianIndonesia = 1057;
					public const int UkrainianUkraine = 1058;
					public const int SlovenianSlovenia = 1060;
					public const int EstonianEstonia = 1061;
					public const int LatvianLatvia = 1062;
					public const int LithuanianLithuania = 1063;
					public const int VietnameseVietnam = 1066;
					public const int BasqueBasque = 1069;
					public const int HindiIndia = 1081;
					public const int MalayMalaysia = 1086;
					public const int KazakhKazakhstan = 1087;
					public const int GalicianSpain = 1110;
					public const int ChineseChina = 2052;
					public const int PortuguesePortugal = 2070;
					public const int Serbian_Latin_Serbia = 2074;
					public const int ChineseHongKongSAR = 3076;
					public const int Spanish_TraditionalSort_Spain = 3082;
					public const int Serbian_Cyrillic_Serbia = 3098;
                }
                public struct ParticipatesInWorkflow
                {
                    public const bool No = false;
                    public const bool Yes = true;
                }
			    public struct PaymentTermsCode
                {
					public const int Net30 = 1;
					public const int _2_percent_10_Net30 = 2;
					public const int Net45 = 3;
					public const int Net60 = 4;
                }
			    public struct PreferredAppointmentDayCode
                {
					public const int Sunday = 0;
					public const int Monday = 1;
					public const int Tuesday = 2;
					public const int Wednesday = 3;
					public const int Thursday = 4;
					public const int Friday = 5;
					public const int Saturday = 6;
                }
			    public struct PreferredAppointmentTimeCode
                {
					public const int Morning = 1;
					public const int Afternoon = 2;
					public const int Evening = 3;
                }
			    public struct PreferredContactMethodCode
                {
					public const int Any = 1;
					public const int Email = 2;
					public const int Phone = 3;
					public const int Fax = 4;
					public const int Mail = 5;
					public const int SMS = 941320001;
					public const int WhatsApp = 941320002;
					public const int PushApp_Portal = 941320003;
                }
			    public struct ShippingMethodCode
                {
					public const int DefaultValue = 1;
                }
                public struct StateCode
                {
					public const int Active = 0;
					public const int Inactive = 1;
                }
                public struct StatusCode
                {
					public const int Active = 1;
					public const int Inactive = 2;
                }
			    public struct TerritoryCode
                {
					public const int DefaultValue = 1;
                }
		}
		#endregion

		#region LogicalNames
		public static class LogicalNames
		{
				public const string Address1AddressId = "address1_addressid";
				public const string Address2AddressId = "address2_addressid";
				public const string Address3AddressId = "address3_addressid";
				public const string ContactId = "contactid";
				public const string AccountId = "accountid";
				public const string AccountRoleCode = "accountrolecode";
				public const string Address1AddressTypeCode = "address1_addresstypecode";
				public const string Address1City = "address1_city";
				public const string Address1Composite = "address1_composite";
				public const string Address1Country = "address1_country";
				public const string Address1County = "address1_county";
				public const string Address1Fax = "address1_fax";
				public const string Address1FreightTermsCode = "address1_freighttermscode";
				public const string Address1Latitude = "address1_latitude";
				public const string Address1Line1 = "address1_line1";
				public const string Address1Line2 = "address1_line2";
				public const string Address1Line3 = "address1_line3";
				public const string Address1Longitude = "address1_longitude";
				public const string Address1Name = "address1_name";
				public const string Address1PostalCode = "address1_postalcode";
				public const string Address1PostOfficeBox = "address1_postofficebox";
				public const string Address1PrimaryContactName = "address1_primarycontactname";
				public const string Address1ShippingMethodCode = "address1_shippingmethodcode";
				public const string Address1StateOrProvince = "address1_stateorprovince";
				public const string Address1Telephone1 = "address1_telephone1";
				public const string Address1Telephone2 = "address1_telephone2";
				public const string Address1Telephone3 = "address1_telephone3";
				public const string Address1UPSZone = "address1_upszone";
				public const string Address1UTCOffset = "address1_utcoffset";
				public const string Address2AddressTypeCode = "address2_addresstypecode";
				public const string Address2City = "address2_city";
				public const string Address2Composite = "address2_composite";
				public const string Address2Country = "address2_country";
				public const string Address2County = "address2_county";
				public const string Address2Fax = "address2_fax";
				public const string Address2FreightTermsCode = "address2_freighttermscode";
				public const string Address2Latitude = "address2_latitude";
				public const string Address2Line1 = "address2_line1";
				public const string Address2Line2 = "address2_line2";
				public const string Address2Line3 = "address2_line3";
				public const string Address2Longitude = "address2_longitude";
				public const string Address2Name = "address2_name";
				public const string Address2PostalCode = "address2_postalcode";
				public const string Address2PostOfficeBox = "address2_postofficebox";
				public const string Address2PrimaryContactName = "address2_primarycontactname";
				public const string Address2ShippingMethodCode = "address2_shippingmethodcode";
				public const string Address2StateOrProvince = "address2_stateorprovince";
				public const string Address2Telephone1 = "address2_telephone1";
				public const string Address2Telephone2 = "address2_telephone2";
				public const string Address2Telephone3 = "address2_telephone3";
				public const string Address2UPSZone = "address2_upszone";
				public const string Address2UTCOffset = "address2_utcoffset";
				public const string Address3AddressTypeCode = "address3_addresstypecode";
				public const string Address3City = "address3_city";
				public const string Address3Composite = "address3_composite";
				public const string Address3Country = "address3_country";
				public const string Address3County = "address3_county";
				public const string Address3Fax = "address3_fax";
				public const string Address3FreightTermsCode = "address3_freighttermscode";
				public const string Address3Latitude = "address3_latitude";
				public const string Address3Line1 = "address3_line1";
				public const string Address3Line2 = "address3_line2";
				public const string Address3Line3 = "address3_line3";
				public const string Address3Longitude = "address3_longitude";
				public const string Address3Name = "address3_name";
				public const string Address3PostalCode = "address3_postalcode";
				public const string Address3PostOfficeBox = "address3_postofficebox";
				public const string Address3PrimaryContactName = "address3_primarycontactname";
				public const string Address3ShippingMethodCode = "address3_shippingmethodcode";
				public const string Address3StateOrProvince = "address3_stateorprovince";
				public const string Address3Telephone1 = "address3_telephone1";
				public const string Address3Telephone2 = "address3_telephone2";
				public const string Address3Telephone3 = "address3_telephone3";
				public const string Address3UPSZone = "address3_upszone";
				public const string Address3UTCOffset = "address3_utcoffset";
				public const string AdxConfirmRemovePassword = "adx_confirmremovepassword";
				public const string AdxCreatedByIPAddress = "adx_createdbyipaddress";
				public const string AdxCreatedByUsername = "adx_createdbyusername";
				public const string AdxIdentityAccessfailedcount = "adx_identity_accessfailedcount";
				public const string AdxIdentityEmailaddress1confirmed = "adx_identity_emailaddress1confirmed";
				public const string AdxIdentityLastsuccessfullogin = "adx_identity_lastsuccessfullogin";
				public const string AdxIdentityLocallogindisabled = "adx_identity_locallogindisabled";
				public const string AdxIdentityLockoutenabled = "adx_identity_lockoutenabled";
				public const string AdxIdentityLockoutenddate = "adx_identity_lockoutenddate";
				public const string AdxIdentityLogonenabled = "adx_identity_logonenabled";
				public const string AdxIdentityMobilephoneconfirmed = "adx_identity_mobilephoneconfirmed";
				public const string AdxIdentityNewpassword = "adx_identity_newpassword";
				public const string AdxIdentityPasswordhash = "adx_identity_passwordhash";
				public const string AdxIdentitySecuritystamp = "adx_identity_securitystamp";
				public const string AdxIdentityTwofactorenabled = "adx_identity_twofactorenabled";
				public const string AdxIdentityUsername = "adx_identity_username";
				public const string AdxModifiedByIPAddress = "adx_modifiedbyipaddress";
				public const string AdxModifiedByUsername = "adx_modifiedbyusername";
				public const string AdxOrganizationName = "adx_organizationname";
				public const string AdxPreferredlcid = "adx_preferredlcid";
				public const string AdxProfilealert = "adx_profilealert";
				public const string AdxProfilealertdate = "adx_profilealertdate";
				public const string AdxProfilealertinstructions = "adx_profilealertinstructions";
				public const string AdxProfileIsAnonymous = "adx_profileisanonymous";
				public const string AdxProfileLastActivity = "adx_profilelastactivity";
				public const string AdxProfilemodifiedon = "adx_profilemodifiedon";
				public const string AdxPublicProfileCopy = "adx_publicprofilecopy";
				public const string AdxTimeZone = "adx_timezone";
				public const string Aging30 = "aging30";
				public const string Aging30Base = "aging30_base";
				public const string Aging60 = "aging60";
				public const string Aging60Base = "aging60_base";
				public const string Aging90 = "aging90";
				public const string Aging90Base = "aging90_base";
				public const string Anniversary = "anniversary";
				public const string AnnualIncome = "annualincome";
				public const string AnnualIncomeBase = "annualincome_base";
				public const string AssistantName = "assistantname";
				public const string AssistantPhone = "assistantphone";
				public const string BirthDate = "birthdate";
				public const string Business2 = "business2";
				public const string BusinessCard = "businesscard";
				public const string BusinessCardAttributes = "businesscardattributes";
				public const string Callback = "callback";
				public const string ChildrensNames = "childrensnames";
				public const string Company = "company";
				public const string CreatedBy = "createdby";
				public const string CreatedByExternalParty = "createdbyexternalparty";
				public const string CreatedOn = "createdon";
				public const string CreatedOnBehalfBy = "createdonbehalfby";
				public const string CreditLimit = "creditlimit";
				public const string CreditLimitBase = "creditlimit_base";
				public const string CreditOnHold = "creditonhold";
				public const string CustomerSizeCode = "customersizecode";
				public const string CustomerTypeCode = "customertypecode";
				public const string DefaultPriceLevelId = "defaultpricelevelid";
				public const string Department = "department";
				public const string Description = "description";
				public const string DgtAddress1CountryId = "dgt_address1_country_id";
				public const string DgtAddress1Fx = "dgt_address1_fx";
				public const string DgtAdvertisingnotallowedBit = "dgt_advertisingnotallowed_bit";
				public const string DgtConsentBusinessPhoneBit = "dgt_consent_business_phone_bit";
				public const string DgtConsentBusinessPhoneDt = "dgt_consent_business_phone_dt";
				public const string DgtConsentEmailBit = "dgt_consent_email_bit";
				public const string DgtConsentEmailDt = "dgt_consent_email_dt";
				public const string DgtConsentFaxBit = "dgt_consent_fax_bit";
				public const string DgtConsentFaxDt = "dgt_consent_fax_dt";
				public const string DgtConsentMailBit = "dgt_consent_mail_bit";
				public const string DgtConsentMailDt = "dgt_consent_mail_dt";
				public const string DgtConsentMobilePhoneBit = "dgt_consent_mobile_phone_bit";
				public const string DgtConsentMobilePhoneDt = "dgt_consent_mobile_phone_dt";
				public const string DgtConsentPrivatePhoneBit = "dgt_consent_private_phone_bit";
				public const string DgtConsentPrivatePhoneDt = "dgt_consent_private_phone_dt";
				public const string DgtCustomerclassificationId = "dgt_customerclassification_id";
				public const string DgtImportNameTxt = "dgt_importname_txt";
				public const string DgtJobId = "dgt_job_id";
				public const string DgtPartneridTxt = "dgt_partnerid_txt";
				public const string DgtPreferredCommunicationChannelSet = "dgt_preferred_communication_channel_set";
				public const string DgtSalutationSet = "dgt_salutation_set";
				public const string DgtSupportingagencyId = "dgt_supportingagency_id";
				public const string DgtSvmidTxt = "dgt_svmid_txt";
				public const string DgtTitleSet = "dgt_title_set";
				public const string DgtWagegroupSet = "dgt_wagegroup_set";
				public const string DgtiActivePolicyBit = "dgti_active_policy_bit";
				public const string DgtiActivePolicyExistsBit = "dgti_active_policy_exists_bit";
				public const string DgtiAdvisoryTeamId = "dgti_advisory_team_id";
				public const string DgtiAppointmentTookPlace = "dgti_appointment_took_place";
				public const string DgtiChurnRiskInt = "dgti_churn_risk_int";
				public const string DgtiConsentCallRecordingSet = "dgti_consent_call_recording_set";
				public const string DgtiConsentMarketingandProductInformation = "dgti_consentmarketingandproductinformation";
				public const string DgtiCustomerRatingSet = "dgti_customer_rating_set";
				public const string DgtiCustomerSatisfactionSet = "dgti_customer_satisfaction_set";
				public const string DgtiCustomerTypeSet = "dgti_customer_type_set";
				public const string DgtiDashboard360ContactTxt = "dgti_dashboard_360_contact_txt";
				public const string DgtiDashboard360MissingInformationTxt = "dgti_dashboard_360_missing_information_txt";
				public const string DgtiDataProtectionConsentSet = "dgti_data_protection_consent_set";
				public const string DgtiDonotallowSMS = "dgti_donotallowsms";
				public const string DgtiDonotpushAppPortal = "dgti_donotpushappportal";
				public const string DgtiDonotwhatsapp = "dgti_donotwhatsapp";
				public const string DgtiEmployerRoleSet = "dgti_employer_role_set";
				public const string DgtiEmployerTxt = "dgti_employer_txt";
				public const string DgtiExternalCoverageBit = "dgti_external_coverage_bit";
				public const string DgtiFourActiveContractsBit = "dgti_four_active_contracts_bit";
				public const string DgtiIncomeCapturedBit = "dgti_income_captured_bit";
				public const string DgtiIncomeCur = "dgti_income_cur";
				public const string DgtiIncomeCurBase = "dgti_income_cur_base";
				public const string DgtiLifeRelationshipBit = "dgti_life_relationship_bit";
				public const string DgtiManagedByPartnersystemBit = "dgti_managed_by_partnersystem_bit";
				public const string DgtiOpportunityWonBit = "dgti_opportunity_won_bit";
				public const string DgtiPartOfHouseholdId = "dgti_part_of_household_id";
				public const string DgtiPartnerSystemIdTxt = "dgti_partner_system_id_txt";
				public const string DgtiPartneridTxt = "dgti_partnerid_txt";
				public const string DgtiPartnersystemLastChangeDat = "dgti_partnersystem_last_change_dat";
				public const string DgtiProfessionalExperienceSet = "dgti_professional_experience_set";
				public const string DgtiPublicHealthInsuranceBit = "dgti_public_health_insurance_bit";
				public const string DgtiRemarkHouseholdRelationTxt = "dgti_remark_household_relation_txt";
				public const string DgtiSalutationSet = "dgti_salutation_set";
				public const string DgtiTwoOrMoreActiveContractsBit = "dgti_two_or_more_active_contracts_bit";
				public const string DgtiTypeOfEmploymentSet = "dgti_type_of_employment_set";
				public const string DgtiTypeOfHouseholdRelationTxt = "dgti_type_of_household_relation_txt";
				public const string DoNotBulkEMail = "donotbulkemail";
				public const string DoNotBulkPostalMail = "donotbulkpostalmail";
				public const string DoNotEMail = "donotemail";
				public const string DoNotFax = "donotfax";
				public const string DoNotPhone = "donotphone";
				public const string DoNotPostalMail = "donotpostalmail";
				public const string DoNotSendMM = "donotsendmm";
				public const string EducationCode = "educationcode";
				public const string EMailAddress1 = "emailaddress1";
				public const string EMailAddress2 = "emailaddress2";
				public const string EMailAddress3 = "emailaddress3";
				public const string EmployeeId = "employeeid";
				public const string EntityImage = "entityimage";
				public const string EntityImageTimestamp = "entityimage_timestamp";
				public const string EntityImageURL = "entityimage_url";
				public const string EntityImageId = "entityimageid";
				public const string ExchangeRate = "exchangerate";
				public const string ExternalUserIdentifier = "externaluseridentifier";
				public const string FamilyStatusCode = "familystatuscode";
				public const string Fax = "fax";
				public const string FirstName = "firstname";
				public const string FollowEmail = "followemail";
				public const string FtpSiteUrl = "ftpsiteurl";
				public const string FullName = "fullname";
				public const string GenderCode = "gendercode";
				public const string GovernmentId = "governmentid";
				public const string HasChildrenCode = "haschildrencode";
				public const string Home2 = "home2";
				public const string ImportSequenceNumber = "importsequencenumber";
				public const string IsBackofficeCustomer = "isbackofficecustomer";
				public const string JobTitle = "jobtitle";
				public const string LastName = "lastname";
				public const string LastOnHoldTime = "lastonholdtime";
				public const string LastUsedInCampaign = "lastusedincampaign";
				public const string LeadSourceCode = "leadsourcecode";
				public const string ManagerName = "managername";
				public const string ManagerPhone = "managerphone";
				public const string MarketingOnly = "marketingonly";
				public const string MasterId = "masterid";
				public const string Merged = "merged";
				public const string MiddleName = "middlename";
				public const string MobilePhone = "mobilephone";
				public const string ModifiedBy = "modifiedby";
				public const string ModifiedByExternalParty = "modifiedbyexternalparty";
				public const string ModifiedOn = "modifiedon";
				public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
				public const string MsTarifrechnerAddin = "ms_tarifrechneraddin";
				public const string MsaManagingpartnerid = "msa_managingpartnerid";
				public const string MsdynContactkpiid = "msdyn_contactkpiid";
				public const string MsdynDecisioninfluencetag = "msdyn_decisioninfluencetag";
				public const string MsdynDisablewebtracking = "msdyn_disablewebtracking";
				public const string MsdynGdproptout = "msdyn_gdproptout";
				public const string MsdynIsassistantinorgchart = "msdyn_isassistantinorgchart";
				public const string MsdynIsminor = "msdyn_isminor";
				public const string MsdynIsminorwithparentalconsent = "msdyn_isminorwithparentalconsent";
				public const string MsdynOrgchangestatus = "msdyn_orgchangestatus";
				public const string MsdynPortaltermsagreementdate = "msdyn_portaltermsagreementdate";
				public const string MsdynSegmentid = "msdyn_segmentid";
				public const string MsdyncrmContactId = "msdyncrm_contactid";
				public const string MsdyncrmCustomerjourneyid = "msdyncrm_customerjourneyid";
				public const string MsdyncrmEmailid = "msdyncrm_emailid";
				public const string MsdyncrmInsightsPlaceholder = "msdyncrm_insights_placeholder";
				public const string MsdyncrmMarketingformid = "msdyncrm_marketingformid";
				public const string MsdyncrmMarketingformsubmissiondateprecise = "msdyncrm_marketingformsubmissiondateprecise";
				public const string MsdyncrmMarketingpageid = "msdyncrm_marketingpageid";
				public const string MsdyncrmRememberMe = "msdyncrm_rememberme";
				public const string MsdyncrmSegmentMemberId = "msdyncrm_segmentmemberid";
				public const string MsdynmktCustomerjourneyid = "msdynmkt_customerjourneyid";
				public const string MsdynmktEmailid = "msdynmkt_emailid";
				public const string MsdynmktMarketingformid = "msdynmkt_marketingformid";
				public const string MsevtmgtAadobjectid = "msevtmgt_aadobjectid";
				public const string MsevtmgtContactId = "msevtmgt_contactid";
				public const string MsevtmgtOriginatingeventid = "msevtmgt_originatingeventid";
				public const string MsgdprConsentchangesourceformId = "msgdpr_consentchangesourceformid";
				public const string MsgdprDonottrack = "msgdpr_donottrack";
				public const string MsgdprGdprconsent = "msgdpr_gdprconsent";
				public const string MsgdprGdprischild = "msgdpr_gdprischild";
				public const string MsgdprGDPRParentId = "msgdpr_gdprparentid";
				public const string MsppUserpreferredlcid = "mspp_userpreferredlcid";
				public const string NickName = "nickname";
				public const string NumberOfChildren = "numberofchildren";
				public const string OnHoldTime = "onholdtime";
				public const string OriginatingLeadId = "originatingleadid";
				public const string OverriddenCreatedOn = "overriddencreatedon";
				public const string OwnerId = "ownerid";
				public const string OwningBusinessUnit = "owningbusinessunit";
				public const string OwningTeam = "owningteam";
				public const string OwningUser = "owninguser";
				public const string Pager = "pager";
				public const string ParentContactId = "parentcontactid";
				public const string ParentCustomerId = "parentcustomerid";
				public const string ParticipatesInWorkflow = "participatesinworkflow";
				public const string PaymentTermsCode = "paymenttermscode";
				public const string PreferredAppointmentDayCode = "preferredappointmentdaycode";
				public const string PreferredAppointmentTimeCode = "preferredappointmenttimecode";
				public const string PreferredContactMethodCode = "preferredcontactmethodcode";
				public const string PreferredEquipmentId = "preferredequipmentid";
				public const string PreferredServiceId = "preferredserviceid";
				public const string PreferredSystemUserId = "preferredsystemuserid";
				public const string ProcessId = "processid";
				public const string Salutation = "salutation";
				public const string ShippingMethodCode = "shippingmethodcode";
				public const string SLAId = "slaid";
				public const string SLAInvokedId = "slainvokedid";
				public const string SpousesName = "spousesname";
				public const string StageId = "stageid";
				public const string StateCode = "statecode";
				public const string StatusCode = "statuscode";
				public const string SubscriptionId = "subscriptionid";
				public const string Suffix = "suffix";
				public const string TeamsFollowed = "teamsfollowed";
				public const string Telephone1 = "telephone1";
				public const string Telephone2 = "telephone2";
				public const string Telephone3 = "telephone3";
				public const string TerritoryCode = "territorycode";
				public const string TimeSpentByMeOnEmailAndMeetings = "timespentbymeonemailandmeetings";
				public const string TimeZoneRuleVersionNumber = "timezoneruleversionnumber";
				public const string TransactionCurrencyId = "transactioncurrencyid";
				public const string TraversedPath = "traversedpath";
				public const string UTCConversionTimeZoneCode = "utcconversiontimezonecode";
				public const string VersionNumber = "versionnumber";
				public const string WebSiteUrl = "websiteurl";
				public const string YomiFirstName = "yomifirstname";
				public const string YomiFullName = "yomifullname";
				public const string YomiLastName = "yomilastname";
				public const string YomiMiddleName = "yomimiddlename";
		}
		#endregion

		#region AlternateKeys
		public static class AlternateKeys
		{
				public const string PartnerKey = "dgt_partnerid_key";
		}
		#endregion

		#region Relations
        public static class Relations
        {
            public static class OneToMany
            {
				public const string AccountPrimaryContact = "account_primary_contact";
				public const string AdxContactExternalidentity = "adx_contact_externalidentity";
				public const string AdxInvitationInvitecontact = "adx_invitation_invitecontact";
				public const string AdxInvitationInvitercontact = "adx_invitation_invitercontact";
				public const string AdxInvitationRedeemedContact = "adx_invitation_redeemedContact";
				public const string AdxWebformsessionContact = "adx_webformsession_contact";
				public const string BpfContactDgtiDevelopmentPrivateInsuranceProcess = "bpf_contact_dgti_development_private_insurance_process";
				public const string ContactActioncard = "contact_actioncard";
				public const string ContactActivityParties = "contact_activity_parties";
				public const string ContactActivityPointers = "Contact_ActivityPointers";
				public const string ContactAdxInviteredemptions = "contact_adx_inviteredemptions";
				public const string ContactAdxPortalcomments = "contact_adx_portalcomments";
				public const string ContactAnnotation = "Contact_Annotation";
				public const string ContactAppointments = "Contact_Appointments";
				public const string ContactAsPrimaryContact = "contact_as_primary_contact";
				public const string ContactAsResponsibleContact = "contact_as_responsible_contact";
				public const string ContactAsyncOperations = "Contact_AsyncOperations";
				public const string ContactBookableresourceContactId = "contact_bookableresource_ContactId";
				public const string ContactBulkDeleteFailures = "Contact_BulkDeleteFailures";
				public const string ContactBulkOperations = "contact_BulkOperations";
				public const string ContactCampaignResponses = "contact_CampaignResponses";
				public const string ContactChats = "contact_chats";
				public const string ContactConnections1 = "contact_connections1";
				public const string ContactConnections2 = "contact_connections2";
				public const string ContactCustomerContacts = "contact_customer_contacts";
				public const string ContactCustomerOpportunityRoles = "contact_customer_opportunity_roles";
				public const string ContactCustomerRelationshipCustomer = "contact_customer_relationship_customer";
				public const string ContactCustomerRelationshipPartner = "contact_customer_relationship_partner";
				public const string ContactCustomerAddress = "Contact_CustomerAddress";
				public const string ContactDuplicateBaseRecord = "Contact_DuplicateBaseRecord";
				public const string ContactDuplicateMatchingRecord = "Contact_DuplicateMatchingRecord";
				public const string ContactEmailEmailSender = "Contact_Email_EmailSender";
				public const string ContactEmails = "Contact_Emails";
				public const string ContactEntitlementContactId = "contact_entitlement_ContactId";
				public const string ContactEntitlementCustomer = "contact_entitlement_Customer";
				public const string ContactExternalPartyItems = "Contact_ExternalPartyItems";
				public const string ContactFaxes = "Contact_Faxes";
				public const string ContactFeedback = "Contact_Feedback";
				public const string ContactLetters = "Contact_Letters";
				public const string ContactMailboxTrackingFolder = "Contact_MailboxTrackingFolder";
				public const string ContactMasterContact = "contact_master_contact";
				public const string ContactMsdynCopilottranscripts = "contact_msdyn_copilottranscripts";
				public const string ContactMsdynOcliveworkitems = "contact_msdyn_ocliveworkitems";
				public const string ContactMsdynOcsessions = "contact_msdyn_ocsessions";
				public const string ContactMsdynOrgchartnodeMsdynNoderecord = "contact_msdyn_orgchartnode_msdyn_noderecord";
				public const string ContactMsfpAlerts = "contact_msfp_alerts";
				public const string ContactMsfpSurveyinvites = "contact_msfp_surveyinvites";
				public const string ContactMsfpSurveyresponses = "contact_msfp_surveyresponses";
				public const string ContactPhonecalls = "Contact_Phonecalls";
				public const string ContactPostFollows = "contact_PostFollows";
				public const string ContactPostRegardings = "contact_PostRegardings";
				public const string ContactPostRoles = "contact_PostRoles";
				public const string ContactPosts = "contact_Posts";
				public const string ContactPrincipalobjectattributeaccess = "contact_principalobjectattributeaccess";
				public const string ContactProcessSessions = "Contact_ProcessSessions";
				public const string ContactRecurringAppointmentMasters = "Contact_RecurringAppointmentMasters";
				public const string ContactServiceAppointments = "Contact_ServiceAppointments";
				public const string ContactSharePointDocumentLocations = "contact_SharePointDocumentLocations";
				public const string ContactSharePointDocuments = "contact_SharePointDocuments";
				public const string ContactSocialActivities = "Contact_SocialActivities";
				public const string ContactSyncErrors = "Contact_SyncErrors";
				public const string ContactTasks = "Contact_Tasks";
				public const string ContactTeams = "contact_Teams";
				public const string ContractBillingcustomerContacts = "contract_billingcustomer_contacts";
				public const string ContractCustomerContacts = "contract_customer_contacts";
				public const string ContractlineitemCustomerContacts = "contractlineitem_customer_contacts";
				public const string CreatedContactBulkOperationLogs = "CreatedContact_BulkOperationLogs";
				public const string DgtContactToDgtBankaccountOnContactId = "dgt_contact_to_dgt_bankaccount_on_contact_id";
				public const string DgtContactToDgtBankaccountOnCustomerId = "dgt_contact_to_dgt_bankaccount_on_customer_id";
				public const string DgtContactToDgtPolicyDetailsOnDgtBeneficiaryVid = "dgt_contact_to_dgt_policy_details_on_dgt_beneficiary_vid";
				public const string DgtContactToDgtPolicyDetailsOnDgtPremiumPayerVid = "dgt_contact_to_dgt_policy_details_on_dgt_premium_payer_vid";
				public const string DgtiContactExternalCoverageVid = "dgti_contact__external_coverage_vid";
				public const string DgtiContactDgtiClaim312 = "dgti_contact_dgti_claim_312";
				public const string DgtiContactDgtiClaimbooking263 = "dgti_contact_dgti_claimbooking_263";
				public const string DgtiContactDgtiPolicyLifeBeneficiaryId = "dgti_contact_dgti_policy_life_beneficiary_id";
				public const string DgtiContactDgtiPolicyPolicyholder = "dgti_contact_dgti_policy_Policyholder";
				public const string DgtiContactPersonToHousehold = "dgti_contact_person_to_household";
				public const string DgtiContactToHouseholdMemberId = "dgti_contact_to_household_member_id";
				public const string DgtiDgtiClaimClaimantContactIdContact = "dgti_dgti_claim_claimant_contact_id_contact";
				public const string DgtiDgtiPartnerdataChangeContactIdContac = "dgti_dgti_partnerdata_change_contact_id_contac";
				public const string DgtiDgtiPartnerdataChangeMergedContactId = "dgti_dgti_partnerdata_change_merged_contact_id";
				public const string DgtiIncidentClaimantContactId = "dgti_incident_claimant_contact_id";
				public const string DgtiLifeEventContactId = "dgti_life_event_contact_id";
				public const string IncidentCustomerContacts = "incident_customer_contacts";
				public const string InvoiceCustomerContacts = "invoice_customer_contacts";
				public const string LeadCustomerContacts = "lead_customer_contacts";
				public const string LeadParentContact = "lead_parent_contact";
				public const string LkContactFeedbackCreatedby = "lk_contact_feedback_createdby";
				public const string LkContactFeedbackCreatedonbehalfby = "lk_contact_feedback_createdonbehalfby";
				public const string MsdynContactDailycontactkpiitemEntityid = "msdyn_contact_dailycontactkpiitem_entityid";
				public const string MsdynContactMsdynContactkpiitemContactid = "msdyn_contact_msdyn_contactkpiitem_contactid";
				public const string MsdynContactMsdynLiveconversationCustomer = "msdyn_contact_msdyn_liveconversation_Customer";
				public const string MsdynContactMsdynMostcontactedRegardingObjectId = "msdyn_contact_msdyn_mostcontacted_regardingObjectId";
				public const string MsdynContactMsdynMostcontactedbyRegardingObjectId = "msdyn_contact_msdyn_mostcontactedby_regardingObjectId";
				public const string MsdynContactMsdynOcliveworkitemCustomer = "msdyn_contact_msdyn_ocliveworkitem_Customer";
				public const string MsdynContactMsdynSalessuggestion = "msdyn_contact_msdyn_salessuggestion";
				public const string MsdynLinkeditemvalidityPolymorphicContactid = "msdyn_linkeditemvalidity_polymorphic_contactid";
				public const string MsdynMsdynConversationparticipantinsightsContactMsdynUser = "msdyn_msdyn_conversationparticipantinsights_contact_msdyn_User";
				public const string MsdynMsdynPreferredagentContactMsdynRecordId = "msdyn_msdyn_preferredagent_contact_msdyn_recordId";
				public const string MsdynMsdynSalescopilotinsightContactMsdynTargetentityid = "msdyn_msdyn_salescopilotinsight_contact_msdyn_targetentityid";
				public const string MsdynMsdynTaggedrecordContactMsdynDynamicsrecordid = "msdyn_msdyn_taggedrecord_contact_msdyn_dynamicsrecordid";
				public const string MsdynPlaybookinstanceContact = "msdyn_playbookinstance_contact";
				public const string MsdynSabackupdiagnosticContactMsdynTarget = "msdyn_sabackupdiagnostic_contact_msdyn_target";
				public const string MsdynSalesroutingdiagnosticContactMsdynTarget = "msdyn_salesroutingdiagnostic_contact_msdyn_target";
				public const string MsdynSequencetargetContactMsdynTarget = "msdyn_sequencetarget_contact_msdyn_target";
				public const string MsdyncrmContactMarketingformsubmissionMatched = "msdyncrm_contact_marketingformsubmission_matched";
				public const string MsdyncrmContactMarketingformsubmissionOriginal = "msdyncrm_contact_marketingformsubmission_original";
				public const string MsdyncrmContactMsdyncrmCustomerjourneycustomchannelactivityContact = "msdyncrm_contact_msdyncrm_customerjourneycustomchannelactivity_Contact";
				public const string MsdyncrmContactMsdyncrmDefaultmarketingsettingDefaultTestContact = "msdyncrm_contact_msdyncrm_defaultmarketingsetting_DefaultTestContact";
				public const string MsdyncrmContactMsdyncrmGeopin = "msdyncrm_contact_msdyncrm_geopin";
				public const string MsdyncrmContactMsdyncrmLinkedinformsubmissionContact = "msdyncrm_contact_msdyncrm_linkedinformsubmission_contact";
				public const string MsdyncrmContactMsdyncrmMarketingemailtestsendTestcontactid = "msdyncrm_contact_msdyncrm_marketingemailtestsend_testcontactid";
				public const string MsevtmgtContactEventregistrationRegisteredby = "msevtmgt_contact_eventregistration_registeredby";
				public const string MsevtmgtContactMsevtmgtAttendeepassContact = "msevtmgt_contact_msevtmgt_attendeepass_contact";
				public const string MsevtmgtContactMsevtmgtBuildingPrimaryContact = "msevtmgt_contact_msevtmgt_building_PrimaryContact";
				public const string MsevtmgtContactMsevtmgtCheckinContact = "msevtmgt_contact_msevtmgt_checkin_Contact";
				public const string MsevtmgtContactMsevtmgtEventpurchase = "msevtmgt_contact_msevtmgt_eventpurchase";
				public const string MsevtmgtContactMsevtmgtEventpurchaseattendee = "msevtmgt_contact_msevtmgt_eventpurchaseattendee";
				public const string MsevtmgtContactMsevtmgtEventregistrationContact = "msevtmgt_contact_msevtmgt_eventregistration_Contact";
				public const string MsevtmgtContactMsevtmgtEventteammemberContact = "msevtmgt_contact_msevtmgt_eventteammember_Contact";
				public const string MsevtmgtContactMsevtmgtHotelPrimaryContact = "msevtmgt_contact_msevtmgt_hotel_PrimaryContact";
				public const string MsevtmgtContactMsevtmgtHotelroomallocationPrimaryContact = "msevtmgt_contact_msevtmgt_hotelroomallocation_PrimaryContact";
				public const string MsevtmgtContactMsevtmgtRoomPrimaryContact = "msevtmgt_contact_msevtmgt_room_PrimaryContact";
				public const string MsevtmgtContactMsevtmgtSessionregistrationContactid = "msevtmgt_contact_msevtmgt_sessionregistration_contactid";
				public const string MsevtmgtContactMsevtmgtSpeakerContact = "msevtmgt_contact_msevtmgt_speaker_Contact";
				public const string MsevtmgtContactMsevtmgtVenuePrimaryContact = "msevtmgt_contact_msevtmgt_venue_PrimaryContact";
				public const string MsevtmgtContactWaitlistitem = "msevtmgt_contact_waitlistitem";
				public const string MsevtmgtContactWaitlistitemAddedby = "msevtmgt_contact_waitlistitem_addedby";
				public const string MsgdprContactMsgdprGdprconsentchangerecord = "msgdpr_contact_msgdpr_gdprconsentchangerecord";
				public const string MsgdprContactMsgdprGdprparent = "msgdpr_contact_msgdpr_gdprparent";
				public const string OpportunityCustomerContacts = "opportunity_customer_contacts";
				public const string OpportunityParentContact = "opportunity_parent_contact";
				public const string OrderCustomerContacts = "order_customer_contacts";
				public const string QuoteCustomerContacts = "quote_customer_contacts";
				public const string SlakpiinstanceContact = "slakpiinstance_contact";
				public const string SocialactivityPostauthorContacts = "socialactivity_postauthor_contacts";
				public const string SocialactivityPostauthoraccountContacts = "socialactivity_postauthoraccount_contacts";
				public const string SocialprofileCustomerContacts = "Socialprofile_customer_contacts";
				public const string SourceContactBulkOperationLogs = "SourceContact_BulkOperationLogs";
				public const string UserentityinstancedataContact = "userentityinstancedata_contact";
            }

            public static class ManyToOne
            {
				public const string BusinessUnitContacts = "business_unit_contacts";
				public const string ContactCustomerAccounts = "contact_customer_accounts";
				public const string ContactCustomerContacts = "contact_customer_contacts";
				public const string ContactMasterContact = "contact_master_contact";
				public const string ContactOriginatingLead = "contact_originating_lead";
				public const string ContactOwningUser = "contact_owning_user";
				public const string DgtBusinessunitToContactOnDgtSupportingagencyId = "dgt_businessunit_to_contact_on_dgt_supportingagency_id";
				public const string DgtCountryToContactOnDgtAddress1CountryId = "dgt_country_to_contact_on_dgt_address1_country_id";
				public const string DgtInsuranceSegmentsToContactOnDgtCustomerclassificationId = "dgt_insurance_segments_to_contact_on_dgt_customerclassification_id";
				public const string DgtJobToContactOnDgtJobId = "dgt_job_to_contact_on_dgt_job_id";
				public const string DgtiContactToHouseholdId = "dgti_contact_to_household_id";
				public const string DgtiDgtiAdvisoryTeamContactAdvisoryTeamId = "dgti_dgti_advisory_team_contact_advisory_team_id";
				public const string EquipmentContacts = "equipment_contacts";
				public const string LkContactCreatedonbehalfby = "lk_contact_createdonbehalfby";
				public const string LkContactEntityimage = "lk_contact_entityimage";
				public const string LkContactModifiedonbehalfby = "lk_contact_modifiedonbehalfby";
				public const string LkContactbaseCreatedby = "lk_contactbase_createdby";
				public const string LkContactbaseModifiedby = "lk_contactbase_modifiedby";
				public const string LkExternalpartyContactCreatedby = "lk_externalparty_contact_createdby";
				public const string LkExternalpartyContactModifiedby = "lk_externalparty_contact_modifiedby";
				public const string ManualslaContact = "manualsla_contact";
				public const string MsaContactManagingpartner = "msa_contact_managingpartner";
				public const string MsdynMsdynContactkpiitemContactContactkpiid = "msdyn_msdyn_contactkpiitem_contact_contactkpiid";
				public const string MsdynMsdynSegmentContact = "msdyn_msdyn_segment_contact";
				public const string MsdyncrmMsdyncrmCustomerjourneyContactCustomerjourneyid = "msdyncrm_msdyncrm_customerjourney_contact_customerjourneyid";
				public const string MsdyncrmMsdyncrmMarketingemailContactEmailid = "msdyncrm_msdyncrm_marketingemail_contact_emailid";
				public const string MsdyncrmMsdyncrmMarketingformContactMarketingformid = "msdyncrm_msdyncrm_marketingform_contact_marketingformid";
				public const string MsdyncrmMsdyncrmMarketingpageContactMarketingpageid = "msdyncrm_msdyncrm_marketingpage_contact_marketingpageid";
				public const string MsdyncrmMsdyncrmSegmentContact = "msdyncrm_msdyncrm_segment_contact";
				public const string MsdyncrmQuicksendemailContact = "msdyncrm_quicksendemail_contact";
				public const string MsdynmktMsdynmktEmailContactEmailid = "msdynmkt_msdynmkt_email_contact_emailid";
				public const string MsdynmktMsdynmktJourneyContactCustomerjourneyid = "msdynmkt_msdynmkt_journey_contact_customerjourneyid";
				public const string MsdynmktMsdynmktMarketingformContactMarketingformid = "msdynmkt_msdynmkt_marketingform_contact_marketingformid";
				public const string MsevtmgtCheckinContact = "msevtmgt_checkin_contact";
				public const string MsevtmgtMsevtmgtEventContactOriginatingeventid = "msevtmgt_msevtmgt_event_contact_originatingeventid";
				public const string MsgdprContactMsgdprGdprparent = "msgdpr_contact_msgdpr_gdprparent";
				public const string MsgdprMsdyncrmMarketingformContactConsentchangesourceformId = "msgdpr_msdyncrm_marketingform_contact_consentchangesourceformId";
				public const string OwnerContacts = "owner_contacts";
				public const string PriceLevelContacts = "price_level_contacts";
				public const string ProcessstageContact = "processstage_contact";
				public const string ServiceContacts = "service_contacts";
				public const string SlaContact = "sla_contact";
				public const string SystemUserContacts = "system_user_contacts";
				public const string TeamContacts = "team_contacts";
				public const string TransactioncurrencyContact = "transactioncurrency_contact";
            }

            public static class ManyToMany
            {
				public const string AdxInvitationInvitecontacts = "adx_invitation_invitecontacts";
				public const string AdxInvitationRedeemedcontacts = "adx_invitation_redeemedcontacts";
				public const string BulkOperationContacts = "BulkOperation_Contacts";
				public const string CampaignActivityContacts = "CampaignActivity_Contacts";
				public const string ContactSubscriptionAssociation = "contact_subscription_association";
				public const string ContactinvoicesAssociation = "contactinvoices_association";
				public const string ContactleadsAssociation = "contactleads_association";
				public const string ContactordersAssociation = "contactorders_association";
				public const string ContactquotesAssociation = "contactquotes_association";
				public const string DgtPolicyDetailsToContactByInsured = "dgt_policy_details_to_contact_by_insured";
				public const string DgtiInsuranceSegmentsContactContact = "dgti_insurance_segments_Contact_Contact";
				public const string EntitlementcontactsAssociation = "entitlementcontacts_association";
				public const string ListcontactAssociation = "listcontact_association";
				public const string PowerpagecomponentMsppWebroleContact = "powerpagecomponent_mspp_webrole_contact";
				public const string ServicecontractcontactsAssociation = "servicecontractcontacts_association";
            }
        }

        #endregion

		#region Methods
        public EntityReference ToNamedEntityReference()
        {
            var reference = ToEntityReference();
            reference.Name = GetAttributeValue<string>(PrimaryNameAttribute);

            return reference;
        }
        public static Contact Retrieve(IOrganizationService service, Guid id)
        {
            return Retrieve(service,id, new ColumnSet(true));
        }

        public static Contact Retrieve(IOrganizationService service, Guid id, ColumnSet columnSet)
        {
            return service.Retrieve("contact", id, columnSet).ToEntity<Contact>();
        }

        public Contact GetChangedEntity()
        {
            if (_trackChanges)
            {
                var attr = new AttributeCollection();
                foreach (var attrName in _changedProperties.Value.Select(changedProperty => ((AttributeLogicalNameAttribute) GetType().GetProperty(changedProperty).GetCustomAttribute(typeof (AttributeLogicalNameAttribute))).LogicalName).Where(attrName => Contains(attrName)))
                {
                    attr.Add(attrName,this[attrName]);
                }
                return new  Contact(Id) {Attributes = attr };
            }
            return this;
        }
        #endregion
	}

	#region Context
	public partial class DataContext
	{
		public IQueryable<Contact> ContactSet
		{
			get
			{
				return CreateQuery<Contact>();
			}
		}
	}
	#endregion
}
