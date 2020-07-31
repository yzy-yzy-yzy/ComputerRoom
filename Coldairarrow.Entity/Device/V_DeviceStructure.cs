﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Device
{
    /// <summary>
    /// V_DeviceStructure
    /// </summary>
    [Table("V_DeviceStructure")]
    public class V_DeviceStructure
    {
        /// <summary>
        /// Id
        /// </summary>
        public Int64? Id { get; set; }

        /// <summary>
        /// DeviceTypeId
        /// </summary>
        public Int32 DeviceTypeId { get; set; }

        /// <summary>
        /// DeviceTypeName
        /// </summary>
        public String DeviceTypeName { get; set; }

        /// <summary>
        /// 设备状态
        /// </summary>
        public bool DeviceStatus { get; set; }

        /// <summary>
        /// DeviceId
        /// </summary>
        public Int32 DeviceId { get; set; }

        /// <summary>
        /// 设备Mac地址
        /// </summary>
        public string DeviceMacCode { get; set; }

        /// <summary>
        /// DeviceName
        /// </summary>
        public String DeviceName { get; set; }

        /// <summary>
        /// Number
        /// </summary>
        public Int32 Number { get; set; }

        /// <summary>
        /// DevicePropId
        /// </summary>
        public Int32 DevicePropId { get; set; }

        /// <summary>
        /// DevicePropName
        /// </summary>
        public String DevicePropName { get; set; }

        /// <summary>
        /// 设备显示名称
        /// </summary>
        public string DevicePropDisplayName { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string DevicePropUnit { get; set; }

        /// <summary>
        /// PropType
        /// </summary>
        public String PropType { get; set; }



        /// <summary>
        /// Max
        /// </summary>
        public String Max { get; set; }

        /// <summary>
        /// Min
        /// </summary>
        public String Min { get; set; }
    }
}