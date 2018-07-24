﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace WpfApplication1
{
    #region 上下文
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    public partial class ZYdatabaseEntities : ObjectContext
    {
        #region 构造函数
    
        /// <summary>
        /// 请使用应用程序配置文件的“ZYdatabaseEntities”部分中的连接字符串初始化新 ZYdatabaseEntities 对象。
        /// </summary>
        public ZYdatabaseEntities() : base("name=ZYdatabaseEntities", "ZYdatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// 初始化新的 ZYdatabaseEntities 对象。
        /// </summary>
        public ZYdatabaseEntities(string connectionString) : base(connectionString, "ZYdatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// 初始化新的 ZYdatabaseEntities 对象。
        /// </summary>
        public ZYdatabaseEntities(EntityConnection connection) : base(connection, "ZYdatabaseEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region 分部方法
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet 属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        public ObjectSet<UserInformation> UserInformations
        {
            get
            {
                if ((_UserInformations == null))
                {
                    _UserInformations = base.CreateObjectSet<UserInformation>("UserInformations");
                }
                return _UserInformations;
            }
        }
        private ObjectSet<UserInformation> _UserInformations;

        #endregion

        #region AddTo 方法
    
        /// <summary>
        /// 用于向 UserInformations EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        public void AddToUserInformations(UserInformation userInformation)
        {
            base.AddObject("UserInformations", userInformation);
        }

        #endregion

    }

    #endregion

    #region 实体
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ZYdatabaseModel", Name="UserInformation")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class UserInformation : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 UserInformation 对象。
        /// </summary>
        /// <param name="medicalNo">MedicalNo 属性的初始值。</param>
        public static UserInformation CreateUserInformation(global::System.String medicalNo)
        {
            UserInformation userInformation = new UserInformation();
            userInformation.MedicalNo = medicalNo;
            return userInformation;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String MedicalNo
        {
            get
            {
                return _MedicalNo;
            }
            set
            {
                if (_MedicalNo != value)
                {
                    OnMedicalNoChanging(value);
                    ReportPropertyChanging("MedicalNo");
                    _MedicalNo = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("MedicalNo");
                    OnMedicalNoChanged();
                }
            }
        }
        private global::System.String _MedicalNo;
        partial void OnMedicalNoChanging(global::System.String value);
        partial void OnMedicalNoChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Sex
        {
            get
            {
                return _Sex;
            }
            set
            {
                OnSexChanging(value);
                ReportPropertyChanging("Sex");
                _Sex = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Sex");
                OnSexChanged();
            }
        }
        private global::System.String _Sex;
        partial void OnSexChanging(global::System.String value);
        partial void OnSexChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int64> Age
        {
            get
            {
                return _Age;
            }
            set
            {
                OnAgeChanging(value);
                ReportPropertyChanging("Age");
                _Age = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Age");
                OnAgeChanged();
            }
        }
        private Nullable<global::System.Int64> _Age;
        partial void OnAgeChanging(Nullable<global::System.Int64> value);
        partial void OnAgeChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Married
        {
            get
            {
                return _Married;
            }
            set
            {
                OnMarriedChanging(value);
                ReportPropertyChanging("Married");
                _Married = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Married");
                OnMarriedChanged();
            }
        }
        private global::System.String _Married;
        partial void OnMarriedChanging(global::System.String value);
        partial void OnMarriedChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Nation
        {
            get
            {
                return _Nation;
            }
            set
            {
                OnNationChanging(value);
                ReportPropertyChanging("Nation");
                _Nation = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Nation");
                OnNationChanged();
            }
        }
        private global::System.String _Nation;
        partial void OnNationChanging(global::System.String value);
        partial void OnNationChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String NativePlace
        {
            get
            {
                return _NativePlace;
            }
            set
            {
                OnNativePlaceChanging(value);
                ReportPropertyChanging("NativePlace");
                _NativePlace = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NativePlace");
                OnNativePlaceChanged();
            }
        }
        private global::System.String _NativePlace;
        partial void OnNativePlaceChanging(global::System.String value);
        partial void OnNativePlaceChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Occupation
        {
            get
            {
                return _Occupation;
            }
            set
            {
                OnOccupationChanging(value);
                ReportPropertyChanging("Occupation");
                _Occupation = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Occupation");
                OnOccupationChanged();
            }
        }
        private global::System.String _Occupation;
        partial void OnOccupationChanging(global::System.String value);
        partial void OnOccupationChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String WorkUnit
        {
            get
            {
                return _WorkUnit;
            }
            set
            {
                OnWorkUnitChanging(value);
                ReportPropertyChanging("WorkUnit");
                _WorkUnit = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("WorkUnit");
                OnWorkUnitChanged();
            }
        }
        private global::System.String _WorkUnit;
        partial void OnWorkUnitChanging(global::System.String value);
        partial void OnWorkUnitChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Telephone
        {
            get
            {
                return _Telephone;
            }
            set
            {
                OnTelephoneChanging(value);
                ReportPropertyChanging("Telephone");
                _Telephone = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Telephone");
                OnTelephoneChanged();
            }
        }
        private global::System.String _Telephone;
        partial void OnTelephoneChanging(global::System.String value);
        partial void OnTelephoneChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                OnAddressChanging(value);
                ReportPropertyChanging("Address");
                _Address = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Address");
                OnAddressChanged();
            }
        }
        private global::System.String _Address;
        partial void OnAddressChanging(global::System.String value);
        partial void OnAddressChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> PhysicalDate
        {
            get
            {
                return _PhysicalDate;
            }
            set
            {
                OnPhysicalDateChanging(value);
                ReportPropertyChanging("PhysicalDate");
                _PhysicalDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("PhysicalDate");
                OnPhysicalDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _PhysicalDate;
        partial void OnPhysicalDateChanging(Nullable<global::System.DateTime> value);
        partial void OnPhysicalDateChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String YangXu
        {
            get
            {
                return _YangXu;
            }
            set
            {
                OnYangXuChanging(value);
                ReportPropertyChanging("YangXu");
                _YangXu = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("YangXu");
                OnYangXuChanged();
            }
        }
        private global::System.String _YangXu;
        partial void OnYangXuChanging(global::System.String value);
        partial void OnYangXuChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String YinXu
        {
            get
            {
                return _YinXu;
            }
            set
            {
                OnYinXuChanging(value);
                ReportPropertyChanging("YinXu");
                _YinXu = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("YinXu");
                OnYinXuChanged();
            }
        }
        private global::System.String _YinXu;
        partial void OnYinXuChanging(global::System.String value);
        partial void OnYinXuChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String QiXu
        {
            get
            {
                return _QiXu;
            }
            set
            {
                OnQiXuChanging(value);
                ReportPropertyChanging("QiXu");
                _QiXu = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("QiXu");
                OnQiXuChanged();
            }
        }
        private global::System.String _QiXu;
        partial void OnQiXuChanging(global::System.String value);
        partial void OnQiXuChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TanShi
        {
            get
            {
                return _TanShi;
            }
            set
            {
                OnTanShiChanging(value);
                ReportPropertyChanging("TanShi");
                _TanShi = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TanShi");
                OnTanShiChanged();
            }
        }
        private global::System.String _TanShi;
        partial void OnTanShiChanging(global::System.String value);
        partial void OnTanShiChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ShiRe
        {
            get
            {
                return _ShiRe;
            }
            set
            {
                OnShiReChanging(value);
                ReportPropertyChanging("ShiRe");
                _ShiRe = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ShiRe");
                OnShiReChanged();
            }
        }
        private global::System.String _ShiRe;
        partial void OnShiReChanging(global::System.String value);
        partial void OnShiReChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String XueYu
        {
            get
            {
                return _XueYu;
            }
            set
            {
                OnXueYuChanging(value);
                ReportPropertyChanging("XueYu");
                _XueYu = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("XueYu");
                OnXueYuChanged();
            }
        }
        private global::System.String _XueYu;
        partial void OnXueYuChanging(global::System.String value);
        partial void OnXueYuChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TeBing
        {
            get
            {
                return _TeBing;
            }
            set
            {
                OnTeBingChanging(value);
                ReportPropertyChanging("TeBing");
                _TeBing = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TeBing");
                OnTeBingChanged();
            }
        }
        private global::System.String _TeBing;
        partial void OnTeBingChanging(global::System.String value);
        partial void OnTeBingChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String QiYu
        {
            get
            {
                return _QiYu;
            }
            set
            {
                OnQiYuChanging(value);
                ReportPropertyChanging("QiYu");
                _QiYu = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("QiYu");
                OnQiYuChanged();
            }
        }
        private global::System.String _QiYu;
        partial void OnQiYuChanging(global::System.String value);
        partial void OnQiYuChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PingHe
        {
            get
            {
                return _PingHe;
            }
            set
            {
                OnPingHeChanging(value);
                ReportPropertyChanging("PingHe");
                _PingHe = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PingHe");
                OnPingHeChanged();
            }
        }
        private global::System.String _PingHe;
        partial void OnPingHeChanging(global::System.String value);
        partial void OnPingHeChanged();

        #endregion

    
    }

    #endregion

    
}