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

namespace MyTaskTracker.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TaskTracker")]
	public partial class TaskTrackerDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTaskOwner(TaskOwner instance);
    partial void UpdateTaskOwner(TaskOwner instance);
    partial void DeleteTaskOwner(TaskOwner instance);
    partial void InsertTaskList(TaskList instance);
    partial void UpdateTaskList(TaskList instance);
    partial void DeleteTaskList(TaskList instance);
    #endregion
		
		public TaskTrackerDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["TaskTrackerConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TaskTrackerDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TaskTrackerDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TaskTrackerDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TaskTrackerDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<TaskOwner> TaskOwners
		{
			get
			{
				return this.GetTable<TaskOwner>();
			}
		}
		
		public System.Data.Linq.Table<TaskList> TaskLists
		{
			get
			{
				return this.GetTable<TaskList>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TaskOwner")]
	public partial class TaskOwner : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _TaskId;
		
		private string _UserName;
		
		private EntityRef<TaskList> _TaskList;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTaskIdChanging(int value);
    partial void OnTaskIdChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    #endregion
		
		public TaskOwner()
		{
			this._TaskList = default(EntityRef<TaskList>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int TaskId
		{
			get
			{
				return this._TaskId;
			}
			set
			{
				if ((this._TaskId != value))
				{
					if (this._TaskList.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTaskIdChanging(value);
					this.SendPropertyChanging();
					this._TaskId = value;
					this.SendPropertyChanged("TaskId");
					this.OnTaskIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TaskList_TaskOwner", Storage="_TaskList", ThisKey="TaskId", OtherKey="TaskID", IsForeignKey=true)]
		public TaskList TaskList
		{
			get
			{
				return this._TaskList.Entity;
			}
			set
			{
				TaskList previousValue = this._TaskList.Entity;
				if (((previousValue != value) 
							|| (this._TaskList.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TaskList.Entity = null;
						previousValue.TaskOwners.Remove(this);
					}
					this._TaskList.Entity = value;
					if ((value != null))
					{
						value.TaskOwners.Add(this);
						this._TaskId = value.TaskID;
					}
					else
					{
						this._TaskId = default(int);
					}
					this.SendPropertyChanged("TaskList");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TaskList")]
	public partial class TaskList : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _TaskID;
		
		private string _TaskName;
		
		private System.DateTime _DueDate;
		
		private string _TaskText;
		
		private bool _TaskComplete;
		
		private EntitySet<TaskOwner> _TaskOwners;
		
		private EntityRef<TaskList> _TaskList2;
		
		private EntityRef<TaskList> _TaskList1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTaskIDChanging(int value);
    partial void OnTaskIDChanged();
    partial void OnTaskNameChanging(string value);
    partial void OnTaskNameChanged();
    partial void OnDueDateChanging(System.DateTime value);
    partial void OnDueDateChanged();
    partial void OnTaskTextChanging(string value);
    partial void OnTaskTextChanged();
    partial void OnTaskCompleteChanging(bool value);
    partial void OnTaskCompleteChanged();
    #endregion
		
		public TaskList()
		{
			this._TaskOwners = new EntitySet<TaskOwner>(new Action<TaskOwner>(this.attach_TaskOwners), new Action<TaskOwner>(this.detach_TaskOwners));
			this._TaskList2 = default(EntityRef<TaskList>);
			this._TaskList1 = default(EntityRef<TaskList>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int TaskID
		{
			get
			{
				return this._TaskID;
			}
			set
			{
				if ((this._TaskID != value))
				{
					if (this._TaskList1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTaskIDChanging(value);
					this.SendPropertyChanging();
					this._TaskID = value;
					this.SendPropertyChanged("TaskID");
					this.OnTaskIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskName", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string TaskName
		{
			get
			{
				return this._TaskName;
			}
			set
			{
				if ((this._TaskName != value))
				{
					this.OnTaskNameChanging(value);
					this.SendPropertyChanging();
					this._TaskName = value;
					this.SendPropertyChanged("TaskName");
					this.OnTaskNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DueDate", DbType="Date NOT NULL")]
		public System.DateTime DueDate
		{
			get
			{
				return this._DueDate;
			}
			set
			{
				if ((this._DueDate != value))
				{
					this.OnDueDateChanging(value);
					this.SendPropertyChanging();
					this._DueDate = value;
					this.SendPropertyChanged("DueDate");
					this.OnDueDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskText", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string TaskText
		{
			get
			{
				return this._TaskText;
			}
			set
			{
				if ((this._TaskText != value))
				{
					this.OnTaskTextChanging(value);
					this.SendPropertyChanging();
					this._TaskText = value;
					this.SendPropertyChanged("TaskText");
					this.OnTaskTextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TaskComplete", DbType="Bit NOT NULL")]
		public bool TaskComplete
		{
			get
			{
				return this._TaskComplete;
			}
			set
			{
				if ((this._TaskComplete != value))
				{
					this.OnTaskCompleteChanging(value);
					this.SendPropertyChanging();
					this._TaskComplete = value;
					this.SendPropertyChanged("TaskComplete");
					this.OnTaskCompleteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TaskList_TaskOwner", Storage="_TaskOwners", ThisKey="TaskID", OtherKey="TaskId")]
		public EntitySet<TaskOwner> TaskOwners
		{
			get
			{
				return this._TaskOwners;
			}
			set
			{
				this._TaskOwners.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TaskList_TaskList", Storage="_TaskList2", ThisKey="TaskID", OtherKey="TaskID", IsUnique=true, IsForeignKey=false)]
		public TaskList TaskList2
		{
			get
			{
				return this._TaskList2.Entity;
			}
			set
			{
				TaskList previousValue = this._TaskList2.Entity;
				if (((previousValue != value) 
							|| (this._TaskList2.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TaskList2.Entity = null;
						previousValue.TaskList1 = null;
					}
					this._TaskList2.Entity = value;
					if ((value != null))
					{
						value.TaskList1 = this;
					}
					this.SendPropertyChanged("TaskList2");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TaskList_TaskList", Storage="_TaskList1", ThisKey="TaskID", OtherKey="TaskID", IsForeignKey=true)]
		public TaskList TaskList1
		{
			get
			{
				return this._TaskList1.Entity;
			}
			set
			{
				TaskList previousValue = this._TaskList1.Entity;
				if (((previousValue != value) 
							|| (this._TaskList1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TaskList1.Entity = null;
						previousValue.TaskList2 = null;
					}
					this._TaskList1.Entity = value;
					if ((value != null))
					{
						value.TaskList2 = this;
						this._TaskID = value.TaskID;
					}
					else
					{
						this._TaskID = default(int);
					}
					this.SendPropertyChanged("TaskList1");
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
		
		private void attach_TaskOwners(TaskOwner entity)
		{
			this.SendPropertyChanging();
			entity.TaskList = this;
		}
		
		private void detach_TaskOwners(TaskOwner entity)
		{
			this.SendPropertyChanging();
			entity.TaskList = null;
		}
	}
}
#pragma warning restore 1591
