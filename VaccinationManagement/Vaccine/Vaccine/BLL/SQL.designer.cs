﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vaccine.BLL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="VaccinationManager_p5")]
	public partial class SQLDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDanhMucVaccine(DanhMucVaccine instance);
    partial void UpdateDanhMucVaccine(DanhMucVaccine instance);
    partial void DeleteDanhMucVaccine(DanhMucVaccine instance);
    partial void InsertHoaDon(HoaDon instance);
    partial void UpdateHoaDon(HoaDon instance);
    partial void DeleteHoaDon(HoaDon instance);
    partial void InserttbChiTietHoaDon(tbChiTietHoaDon instance);
    partial void UpdatetbChiTietHoaDon(tbChiTietHoaDon instance);
    partial void DeletetbChiTietHoaDon(tbChiTietHoaDon instance);
    partial void InserttbNhanVien(tbNhanVien instance);
    partial void UpdatetbNhanVien(tbNhanVien instance);
    partial void DeletetbNhanVien(tbNhanVien instance);
    partial void InsertVaccine(Vaccine instance);
    partial void UpdateVaccine(Vaccine instance);
    partial void DeleteVaccine(Vaccine instance);
    #endregion
		
		public SQLDataContext() : 
				base(global::Vaccine.Properties.Settings.Default.VaccinationManager_p5ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SQLDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQLDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQLDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQLDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<DanhMucVaccine> DanhMucVaccines
		{
			get
			{
				return this.GetTable<DanhMucVaccine>();
			}
		}
		
		public System.Data.Linq.Table<HoaDon> HoaDons
		{
			get
			{
				return this.GetTable<HoaDon>();
			}
		}
		
		public System.Data.Linq.Table<tbChiTietHoaDon> tbChiTietHoaDons
		{
			get
			{
				return this.GetTable<tbChiTietHoaDon>();
			}
		}
		
		public System.Data.Linq.Table<tbNhanVien> tbNhanViens
		{
			get
			{
				return this.GetTable<tbNhanVien>();
			}
		}
		
		public System.Data.Linq.Table<Vaccine> Vaccines
		{
			get
			{
				return this.GetTable<Vaccine>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DanhMucVaccine")]
	public partial class DanhMucVaccine : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaDM;
		
		private string _TenDM;
		
		private EntitySet<Vaccine> _Vaccines;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaDMChanging(string value);
    partial void OnMaDMChanged();
    partial void OnTenDMChanging(string value);
    partial void OnTenDMChanged();
    #endregion
		
		public DanhMucVaccine()
		{
			this._Vaccines = new EntitySet<Vaccine>(new Action<Vaccine>(this.attach_Vaccines), new Action<Vaccine>(this.detach_Vaccines));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaDM", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaDM
		{
			get
			{
				return this._MaDM;
			}
			set
			{
				if ((this._MaDM != value))
				{
					this.OnMaDMChanging(value);
					this.SendPropertyChanging();
					this._MaDM = value;
					this.SendPropertyChanged("MaDM");
					this.OnMaDMChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenDM", DbType="NVarChar(50)")]
		public string TenDM
		{
			get
			{
				return this._TenDM;
			}
			set
			{
				if ((this._TenDM != value))
				{
					this.OnTenDMChanging(value);
					this.SendPropertyChanging();
					this._TenDM = value;
					this.SendPropertyChanged("TenDM");
					this.OnTenDMChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DanhMucVaccine_Vaccine", Storage="_Vaccines", ThisKey="MaDM", OtherKey="MaDM")]
		public EntitySet<Vaccine> Vaccines
		{
			get
			{
				return this._Vaccines;
			}
			set
			{
				this._Vaccines.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Vaccines(Vaccine entity)
		{
			this.SendPropertyChanging();
			entity.DanhMucVaccine = this;
		}
		
		private void detach_Vaccines(Vaccine entity)
		{
			this.SendPropertyChanging();
			entity.DanhMucVaccine = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.HoaDon")]
	public partial class HoaDon : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaHD;
		
		private string _MaNV;
		
		private string _MaVC;
		
		private EntitySet<tbChiTietHoaDon> _tbChiTietHoaDons;
		
		private EntityRef<tbNhanVien> _tbNhanVien;
		
		private EntityRef<Vaccine> _Vaccine;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaHDChanging(string value);
    partial void OnMaHDChanged();
    partial void OnMaNVChanging(string value);
    partial void OnMaNVChanged();
    partial void OnMaVCChanging(string value);
    partial void OnMaVCChanged();
    #endregion
		
		public HoaDon()
		{
			this._tbChiTietHoaDons = new EntitySet<tbChiTietHoaDon>(new Action<tbChiTietHoaDon>(this.attach_tbChiTietHoaDons), new Action<tbChiTietHoaDon>(this.detach_tbChiTietHoaDons));
			this._tbNhanVien = default(EntityRef<tbNhanVien>);
			this._Vaccine = default(EntityRef<Vaccine>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaHD", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaHD
		{
			get
			{
				return this._MaHD;
			}
			set
			{
				if ((this._MaHD != value))
				{
					this.OnMaHDChanging(value);
					this.SendPropertyChanging();
					this._MaHD = value;
					this.SendPropertyChanged("MaHD");
					this.OnMaHDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaNV", DbType="Char(10) NOT NULL", CanBeNull=false)]
		public string MaNV
		{
			get
			{
				return this._MaNV;
			}
			set
			{
				if ((this._MaNV != value))
				{
					if (this._tbNhanVien.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaNVChanging(value);
					this.SendPropertyChanging();
					this._MaNV = value;
					this.SendPropertyChanged("MaNV");
					this.OnMaNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaVC", DbType="Char(10) NOT NULL", CanBeNull=false)]
		public string MaVC
		{
			get
			{
				return this._MaVC;
			}
			set
			{
				if ((this._MaVC != value))
				{
					if (this._Vaccine.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaVCChanging(value);
					this.SendPropertyChanging();
					this._MaVC = value;
					this.SendPropertyChanged("MaVC");
					this.OnMaVCChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="HoaDon_tbChiTietHoaDon", Storage="_tbChiTietHoaDons", ThisKey="MaHD", OtherKey="MaHD")]
		public EntitySet<tbChiTietHoaDon> tbChiTietHoaDons
		{
			get
			{
				return this._tbChiTietHoaDons;
			}
			set
			{
				this._tbChiTietHoaDons.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbNhanVien_HoaDon", Storage="_tbNhanVien", ThisKey="MaNV", OtherKey="MaNV", IsForeignKey=true)]
		public tbNhanVien tbNhanVien
		{
			get
			{
				return this._tbNhanVien.Entity;
			}
			set
			{
				tbNhanVien previousValue = this._tbNhanVien.Entity;
				if (((previousValue != value) 
							|| (this._tbNhanVien.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tbNhanVien.Entity = null;
						previousValue.HoaDons.Remove(this);
					}
					this._tbNhanVien.Entity = value;
					if ((value != null))
					{
						value.HoaDons.Add(this);
						this._MaNV = value.MaNV;
					}
					else
					{
						this._MaNV = default(string);
					}
					this.SendPropertyChanged("tbNhanVien");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Vaccine_HoaDon", Storage="_Vaccine", ThisKey="MaVC", OtherKey="MaVC", IsForeignKey=true)]
		public Vaccine Vaccine
		{
			get
			{
				return this._Vaccine.Entity;
			}
			set
			{
				Vaccine previousValue = this._Vaccine.Entity;
				if (((previousValue != value) 
							|| (this._Vaccine.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Vaccine.Entity = null;
						previousValue.HoaDons.Remove(this);
					}
					this._Vaccine.Entity = value;
					if ((value != null))
					{
						value.HoaDons.Add(this);
						this._MaVC = value.MaVC;
					}
					else
					{
						this._MaVC = default(string);
					}
					this.SendPropertyChanged("Vaccine");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tbChiTietHoaDons(tbChiTietHoaDon entity)
		{
			this.SendPropertyChanging();
			entity.HoaDon = this;
		}
		
		private void detach_tbChiTietHoaDons(tbChiTietHoaDon entity)
		{
			this.SendPropertyChanging();
			entity.HoaDon = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbChiTietHoaDon")]
	public partial class tbChiTietHoaDon : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaCTHD;
		
		private string _MaHD;
		
		private string _MaVC;
		
		private System.Nullable<int> _SoLuong;
		
		private System.Nullable<int> _Gia;
		
		private EntityRef<HoaDon> _HoaDon;
		
		private EntityRef<Vaccine> _Vaccine;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaCTHDChanging(string value);
    partial void OnMaCTHDChanged();
    partial void OnMaHDChanging(string value);
    partial void OnMaHDChanged();
    partial void OnMaVCChanging(string value);
    partial void OnMaVCChanged();
    partial void OnSoLuongChanging(System.Nullable<int> value);
    partial void OnSoLuongChanged();
    partial void OnGiaChanging(System.Nullable<int> value);
    partial void OnGiaChanged();
    #endregion
		
		public tbChiTietHoaDon()
		{
			this._HoaDon = default(EntityRef<HoaDon>);
			this._Vaccine = default(EntityRef<Vaccine>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaCTHD", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaCTHD
		{
			get
			{
				return this._MaCTHD;
			}
			set
			{
				if ((this._MaCTHD != value))
				{
					this.OnMaCTHDChanging(value);
					this.SendPropertyChanging();
					this._MaCTHD = value;
					this.SendPropertyChanged("MaCTHD");
					this.OnMaCTHDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaHD", DbType="Char(10) NOT NULL", CanBeNull=false)]
		public string MaHD
		{
			get
			{
				return this._MaHD;
			}
			set
			{
				if ((this._MaHD != value))
				{
					if (this._HoaDon.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaHDChanging(value);
					this.SendPropertyChanging();
					this._MaHD = value;
					this.SendPropertyChanged("MaHD");
					this.OnMaHDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaVC", DbType="Char(10) NOT NULL", CanBeNull=false)]
		public string MaVC
		{
			get
			{
				return this._MaVC;
			}
			set
			{
				if ((this._MaVC != value))
				{
					if (this._Vaccine.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaVCChanging(value);
					this.SendPropertyChanging();
					this._MaVC = value;
					this.SendPropertyChanged("MaVC");
					this.OnMaVCChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoLuong", DbType="Int")]
		public System.Nullable<int> SoLuong
		{
			get
			{
				return this._SoLuong;
			}
			set
			{
				if ((this._SoLuong != value))
				{
					this.OnSoLuongChanging(value);
					this.SendPropertyChanging();
					this._SoLuong = value;
					this.SendPropertyChanged("SoLuong");
					this.OnSoLuongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gia", DbType="Int")]
		public System.Nullable<int> Gia
		{
			get
			{
				return this._Gia;
			}
			set
			{
				if ((this._Gia != value))
				{
					this.OnGiaChanging(value);
					this.SendPropertyChanging();
					this._Gia = value;
					this.SendPropertyChanged("Gia");
					this.OnGiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="HoaDon_tbChiTietHoaDon", Storage="_HoaDon", ThisKey="MaHD", OtherKey="MaHD", IsForeignKey=true)]
		public HoaDon HoaDon
		{
			get
			{
				return this._HoaDon.Entity;
			}
			set
			{
				HoaDon previousValue = this._HoaDon.Entity;
				if (((previousValue != value) 
							|| (this._HoaDon.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._HoaDon.Entity = null;
						previousValue.tbChiTietHoaDons.Remove(this);
					}
					this._HoaDon.Entity = value;
					if ((value != null))
					{
						value.tbChiTietHoaDons.Add(this);
						this._MaHD = value.MaHD;
					}
					else
					{
						this._MaHD = default(string);
					}
					this.SendPropertyChanged("HoaDon");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Vaccine_tbChiTietHoaDon", Storage="_Vaccine", ThisKey="MaVC", OtherKey="MaVC", IsForeignKey=true)]
		public Vaccine Vaccine
		{
			get
			{
				return this._Vaccine.Entity;
			}
			set
			{
				Vaccine previousValue = this._Vaccine.Entity;
				if (((previousValue != value) 
							|| (this._Vaccine.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Vaccine.Entity = null;
						previousValue.tbChiTietHoaDons.Remove(this);
					}
					this._Vaccine.Entity = value;
					if ((value != null))
					{
						value.tbChiTietHoaDons.Add(this);
						this._MaVC = value.MaVC;
					}
					else
					{
						this._MaVC = default(string);
					}
					this.SendPropertyChanged("Vaccine");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbNhanVien")]
	public partial class tbNhanVien : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaNV;
		
		private string _TenNV;
		
		private string _TenDN;
		
		private string _MatKhau;
		
		private string _DiaChi;
		
		private string _SDT;
		
		private EntitySet<HoaDon> _HoaDons;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaNVChanging(string value);
    partial void OnMaNVChanged();
    partial void OnTenNVChanging(string value);
    partial void OnTenNVChanged();
    partial void OnTenDNChanging(string value);
    partial void OnTenDNChanged();
    partial void OnMatKhauChanging(string value);
    partial void OnMatKhauChanged();
    partial void OnDiaChiChanging(string value);
    partial void OnDiaChiChanged();
    partial void OnSDTChanging(string value);
    partial void OnSDTChanged();
    #endregion
		
		public tbNhanVien()
		{
			this._HoaDons = new EntitySet<HoaDon>(new Action<HoaDon>(this.attach_HoaDons), new Action<HoaDon>(this.detach_HoaDons));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaNV", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaNV
		{
			get
			{
				return this._MaNV;
			}
			set
			{
				if ((this._MaNV != value))
				{
					this.OnMaNVChanging(value);
					this.SendPropertyChanging();
					this._MaNV = value;
					this.SendPropertyChanged("MaNV");
					this.OnMaNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenNV", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string TenNV
		{
			get
			{
				return this._TenNV;
			}
			set
			{
				if ((this._TenNV != value))
				{
					this.OnTenNVChanging(value);
					this.SendPropertyChanging();
					this._TenNV = value;
					this.SendPropertyChanged("TenNV");
					this.OnTenNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenDN", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string TenDN
		{
			get
			{
				return this._TenDN;
			}
			set
			{
				if ((this._TenDN != value))
				{
					this.OnTenDNChanging(value);
					this.SendPropertyChanging();
					this._TenDN = value;
					this.SendPropertyChanged("TenDN");
					this.OnTenDNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatKhau", DbType="Char(10) NOT NULL", CanBeNull=false)]
		public string MatKhau
		{
			get
			{
				return this._MatKhau;
			}
			set
			{
				if ((this._MatKhau != value))
				{
					this.OnMatKhauChanging(value);
					this.SendPropertyChanging();
					this._MatKhau = value;
					this.SendPropertyChanged("MatKhau");
					this.OnMatKhauChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiaChi", DbType="NVarChar(50)")]
		public string DiaChi
		{
			get
			{
				return this._DiaChi;
			}
			set
			{
				if ((this._DiaChi != value))
				{
					this.OnDiaChiChanging(value);
					this.SendPropertyChanging();
					this._DiaChi = value;
					this.SendPropertyChanged("DiaChi");
					this.OnDiaChiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SDT", DbType="Char(10)")]
		public string SDT
		{
			get
			{
				return this._SDT;
			}
			set
			{
				if ((this._SDT != value))
				{
					this.OnSDTChanging(value);
					this.SendPropertyChanging();
					this._SDT = value;
					this.SendPropertyChanged("SDT");
					this.OnSDTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbNhanVien_HoaDon", Storage="_HoaDons", ThisKey="MaNV", OtherKey="MaNV")]
		public EntitySet<HoaDon> HoaDons
		{
			get
			{
				return this._HoaDons;
			}
			set
			{
				this._HoaDons.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_HoaDons(HoaDon entity)
		{
			this.SendPropertyChanging();
			entity.tbNhanVien = this;
		}
		
		private void detach_HoaDons(HoaDon entity)
		{
			this.SendPropertyChanging();
			entity.tbNhanVien = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Vaccine")]
	public partial class Vaccine : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaVC;
		
		private string _TenVC;
		
		private System.Nullable<System.DateTime> _HSD;
		
		private string _MaDM;
		
		private EntitySet<HoaDon> _HoaDons;
		
		private EntitySet<tbChiTietHoaDon> _tbChiTietHoaDons;
		
		private EntityRef<DanhMucVaccine> _DanhMucVaccine;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaVCChanging(string value);
    partial void OnMaVCChanged();
    partial void OnTenVCChanging(string value);
    partial void OnTenVCChanged();
    partial void OnHSDChanging(System.Nullable<System.DateTime> value);
    partial void OnHSDChanged();
    partial void OnMaDMChanging(string value);
    partial void OnMaDMChanged();
    #endregion
		
		public Vaccine()
		{
			this._HoaDons = new EntitySet<HoaDon>(new Action<HoaDon>(this.attach_HoaDons), new Action<HoaDon>(this.detach_HoaDons));
			this._tbChiTietHoaDons = new EntitySet<tbChiTietHoaDon>(new Action<tbChiTietHoaDon>(this.attach_tbChiTietHoaDons), new Action<tbChiTietHoaDon>(this.detach_tbChiTietHoaDons));
			this._DanhMucVaccine = default(EntityRef<DanhMucVaccine>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaVC", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaVC
		{
			get
			{
				return this._MaVC;
			}
			set
			{
				if ((this._MaVC != value))
				{
					this.OnMaVCChanging(value);
					this.SendPropertyChanging();
					this._MaVC = value;
					this.SendPropertyChanged("MaVC");
					this.OnMaVCChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenVC", DbType="NVarChar(50)")]
		public string TenVC
		{
			get
			{
				return this._TenVC;
			}
			set
			{
				if ((this._TenVC != value))
				{
					this.OnTenVCChanging(value);
					this.SendPropertyChanging();
					this._TenVC = value;
					this.SendPropertyChanged("TenVC");
					this.OnTenVCChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HSD", DbType="Date")]
		public System.Nullable<System.DateTime> HSD
		{
			get
			{
				return this._HSD;
			}
			set
			{
				if ((this._HSD != value))
				{
					this.OnHSDChanging(value);
					this.SendPropertyChanging();
					this._HSD = value;
					this.SendPropertyChanged("HSD");
					this.OnHSDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaDM", DbType="Char(10)")]
		public string MaDM
		{
			get
			{
				return this._MaDM;
			}
			set
			{
				if ((this._MaDM != value))
				{
					if (this._DanhMucVaccine.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaDMChanging(value);
					this.SendPropertyChanging();
					this._MaDM = value;
					this.SendPropertyChanged("MaDM");
					this.OnMaDMChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Vaccine_HoaDon", Storage="_HoaDons", ThisKey="MaVC", OtherKey="MaVC")]
		public EntitySet<HoaDon> HoaDons
		{
			get
			{
				return this._HoaDons;
			}
			set
			{
				this._HoaDons.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Vaccine_tbChiTietHoaDon", Storage="_tbChiTietHoaDons", ThisKey="MaVC", OtherKey="MaVC")]
		public EntitySet<tbChiTietHoaDon> tbChiTietHoaDons
		{
			get
			{
				return this._tbChiTietHoaDons;
			}
			set
			{
				this._tbChiTietHoaDons.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DanhMucVaccine_Vaccine", Storage="_DanhMucVaccine", ThisKey="MaDM", OtherKey="MaDM", IsForeignKey=true)]
		public DanhMucVaccine DanhMucVaccine
		{
			get
			{
				return this._DanhMucVaccine.Entity;
			}
			set
			{
				DanhMucVaccine previousValue = this._DanhMucVaccine.Entity;
				if (((previousValue != value) 
							|| (this._DanhMucVaccine.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DanhMucVaccine.Entity = null;
						previousValue.Vaccines.Remove(this);
					}
					this._DanhMucVaccine.Entity = value;
					if ((value != null))
					{
						value.Vaccines.Add(this);
						this._MaDM = value.MaDM;
					}
					else
					{
						this._MaDM = default(string);
					}
					this.SendPropertyChanged("DanhMucVaccine");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_HoaDons(HoaDon entity)
		{
			this.SendPropertyChanging();
			entity.Vaccine = this;
		}
		
		private void detach_HoaDons(HoaDon entity)
		{
			this.SendPropertyChanging();
			entity.Vaccine = null;
		}
		
		private void attach_tbChiTietHoaDons(tbChiTietHoaDon entity)
		{
			this.SendPropertyChanging();
			entity.Vaccine = this;
		}
		
		private void detach_tbChiTietHoaDons(tbChiTietHoaDon entity)
		{
			this.SendPropertyChanging();
			entity.Vaccine = null;
		}
	}
}
#pragma warning restore 1591