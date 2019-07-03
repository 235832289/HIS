using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// MK3酶标仪消息参数类
    /// </summary>
    class clsDPEMessage
    {
        /// <summary>
        /// 启动计算机控制
        /// </summary>
        public const byte m_bytStart = (byte)'R';
        /// <summary>
        /// 申请应答
        /// </summary>
        public const string m_strTSDWN = "OK";
        /// <summary>
        /// 断开控制
        /// HEX 51
        /// </summary>
        public const byte m_bytDisconnect = (byte)'Q';
        /// <summary>
        /// 空气空白
        /// HEX 41
        /// </summary>
        public const byte m_bytAirBlank = (byte)'A';
        /// <summary>
        /// 振荡模式设置不对
        /// HEX 58
        /// </summary>
        public const byte m_bytShock = (byte)'X';
        /// <summary>
        /// 振荡速度
        /// HEX 32
        /// </summary>
        public const byte m_bytShockViews = (byte)'2';
        /// <summary>
        /// 振荡酶标板
        /// HEX 5A
        /// </summary>
        public const byte m_bytShockTime = (byte)'Z';
        /// <summary>
        /// 振荡酶标板
        /// HEX 30
        /// </summary>
        public const byte m_bytShockMin = (byte)'0';
        /// <summary>
        /// 振荡酶标板
        /// HEX 35
        /// </summary>
        public const byte m_bytShockSeconds = (byte)'5';
        /// <summary>
        /// 进板方式
        /// HEX 45
        /// </summary>
        public const byte m_bytContinueWay = (byte)'E';
        /// <summary>
        /// 进板方式
        /// HEX 30
        /// </summary>
        public const byte m_bytContinueModel = (byte)'0';
        /// <summary>
        /// 选择滤光片
        /// HEX 46
        /// </summary>
        public const byte m_bytSelectFilter = (byte)'F';
        /// <summary>
        /// 选择滤光片
        /// HEX 32
        /// </summary>
        public const byte m_bytSelectFilterModel = (byte)'2';
        /// <summary>
        /// 测量模式
        /// HEX 50
        /// </summary>
        public const byte m_bytMeasurement = (byte)'P';
        /// <summary>
        /// HEX 0A
        /// </summary>
        public const byte m_bytCR = (byte)'\r';
        /// <summary>
        /// HEX 0D
        /// </summary>
        public const byte m_bytLF = (byte)'\n';
    }
}
