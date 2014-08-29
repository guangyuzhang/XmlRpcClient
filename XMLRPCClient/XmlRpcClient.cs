using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Net;
using System.IO;


namespace XMLRPCClient
{
    public class XmlRpcClient
    {
        private string username;
        private string password;
        private string url;
        public XmlRpcClient(string username, string password, string url)
        {
            this.username = username;
            this.password = password;
            this.url = url;
        }

        #region Access Group Methods
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="sAccessGroupName">name for new Access Group</param>
        /// <param name="sAccessGroupGuid">GUID for new Access Group (autoassigned if "NULL")</param>
        /// <param name="sPartitionGuid">GUID for the partition which owns this access group (ignored on non-partitioned systems)</param>
        /// <param name="iPublic">0 = non-public, 1 = public (ignored on non-partitioned systems)</param>
        /// <param name="sTerminalGuids">array of Terminal GUIDs</param>
        /// <param name="sTerminalGroupGuids">array of Terminal Group GUIDs</param>
        /// <returns></returns>
        public string AccessGroupAdd(string sAccessGroupName, string sAccessGroupGuid, string sPartitionGuid, int iPublic, string[] sTerminalGuids, string[] sTerminalGroupGuids)
        {
            MethodCall methodCall = CreateMessage("AccessGroupAdd");
            methodCall.methodParameterList.Add(new MethodParameter(sAccessGroupName));
            methodCall.methodParameterList.Add(new MethodParameter(sAccessGroupGuid));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iPublic));
            methodCall.methodParameterList.Add(new MethodStringArrayParameter(sTerminalGuids));       
            methodCall.methodParameterList.Add(new MethodStringArrayParameter(sTerminalGroupGuids));  

            return WebPostSend(methodCall.Request);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sAccessGroupName">name for new Access Group</param>
        /// <param name="sAccessGroupGuid">GUID for new Access Group (autoassigned if "NULL")</param>
        /// <param name="sPartitionName">name of the partition which owns this access group (ignored on non-partitioned systems)</param>
        /// <param name="iPublic">0 = non-public, 1 = public (ignored on non-partitioned systems)</param>
        /// <param name="sTerminals">array of Terminal names</param>
        /// <param name="sTerminalGroups">array of Terminal Group names</param>
        /// <returns>Returns TRUE (1) if successful, Fault Structure if failure.</returns>
        /// <remarks>Available in P2000 V3.5 and later.</remarks>
        public string AccessGroupAddByName(string sAccessGroupName, string sAccessGroupGuid, string sPartitionName, string iPublic, string[] sTerminals, string[] sTerminalGroups)
        {
            MethodCall methodCall = CreateMessage("AccessGroupAddByName");
            methodCall.methodParameterList.Add(new MethodParameter(sAccessGroupName));
            methodCall.methodParameterList.Add(new MethodParameter(sAccessGroupGuid));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iPublic));
            methodCall.methodParameterList.Add(new MethodStringArrayParameter(sTerminals));
            methodCall.methodParameterList.Add(new MethodStringArrayParameter(sTerminalGroups));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of Partition to get AccessGroup list for (ignored on non-partitioned systems)</param>
        public string AccessGroupGetList(string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("AccessGroupGetList");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName">name of Partition to get AccessGroup list for (ignored on non-partitioned systems)</param>
        public string AccessGroupGetListByName( string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("AccessGroupGetListByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sAccessGroupGuid">GUID of Access Group</param>
        /// <param name="sTerminalGuids">array of Terminal GUIDs</param>
        /// <param name="sTerminalGroupGuids">array of Terminal Group GUIDs</param>
        public string AccessGroupModify(string sAccessGroupGuid, string [] sTerminalGuids, string [] sTerminalGroupGuids)
        {
            MethodCall methodCall = CreateMessage("AccessGroupModify");
            methodCall.methodParameterList.Add(new MethodParameter(sAccessGroupGuid));
            methodCall.methodParameterList.Add(new MethodStringArrayParameter(sTerminalGuids));
            methodCall.methodParameterList.Add(new MethodStringArrayParameter(sTerminalGroupGuids));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sAccessGroupName">name of Access Group</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="sTerminalNames">array of Terminal names</param>
        /// <param name="sTerminalGroupNames">array of Terminal Group names</param>
        /// <returns></returns>
        public string AccessGroupModifyByName(string sAccessGroupName, string sPartitionName, string[] sTerminalNames, string[] sTerminalGroupNames)
        {

            MethodCall methodCall = CreateMessage("AccessGroupModifyByName");
            methodCall.methodParameterList.Add(new MethodParameter(sAccessGroupName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodStringArrayParameter(sTerminalNames));
            methodCall.methodParameterList.Add(new MethodStringArrayParameter(sTerminalGroupNames));

            return WebPostSend(methodCall.Request);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sAccessGroupGuid">GUID of Access Group</param>
        public string AccessGroupDelete(string sAccessGroupGuid)
        {
            MethodCall methodCall = CreateMessage("AccessGroupDelete");
            methodCall.methodParameterList.Add(new MethodParameter(sAccessGroupGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sAccessGroupName">name of Access Group</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <returns></returns>
        public string AccessGroupDeleteByName(string sAccessGroupName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("AccessGroupDeleteByName");
            methodCall.methodParameterList.Add(new MethodParameter(sAccessGroupName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }
#endregion
        #region Alarm Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sAlarmTypeGuid">Unique type GUID of alarm to be created (alarms with the same type GUID are considered to be alarms for the same item)</param>
        /// <param name="sPartitionGuid">Guid of partition that alarm belongs to (ignored on non-partitioned systems)</param>
        /// <param name="iPublic">Public flag of alarm (ignored on non-partitioned systems)</param>
        /// <param name="sItemName">Name of item generating alarm</param>
        /// <param name="sDescription">Alarm description</param>
        /// <param name="sInstructions">Alarm Instructions (may be left blank)</param>
        /// <param name="iPriority">Alarm priority (0 to 255)</param>
        /// <param name="sCategory">Alarm category (default category if blank)</param>
        /// <param name="sQueryString">Alarm query string (may be left blank)</param>
        /// <param name="iAckRequired">Ack required flag</param>
        /// <param name="iResponseRequired">Response required flag</param>
        /// <param name="iPopup">Alarm Monitor popup flag</param>
        /// <returns></returns>
        public string AlarmCreate(string sAlarmTypeGuid, string sPartitionGuid, int iPublic, string sItemName,
            string sDescription, string sInstructions, int iPriority, string sCategory, string sQueryString,
            int iAckRequired, int iResponseRequired, int iPopup)
        {
            MethodCall methodCall = CreateMessage("AlarmCreate");
            //Unique type GUID of alarm to be created (alarms with the same type GUID are considered to be alarms for the same item)
            methodCall.methodParameterList.Add(new MethodParameter(sAlarmTypeGuid));
            //Guid of partition that alarm belongs to (ignored on non-partitioned systems)
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));
            //Public flag of alarm (ignored on non-partitioned systems)
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iPublic));
            //Name of item generating alarm
            methodCall.methodParameterList.Add(new MethodParameter(sItemName));
            //Alarm description
            methodCall.methodParameterList.Add(new MethodParameter(sDescription));
            //Alarm Instructions (may be left blank)
            methodCall.methodParameterList.Add(new MethodParameter(sInstructions));
            //Alarm priority (0 to 255)
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iPriority));
            //Alarm category (default category if blank)
            methodCall.methodParameterList.Add(new MethodParameter(sCategory));
            //Alarm query string (may be left blank)
            methodCall.methodParameterList.Add(new MethodParameter(sQueryString));
            //Ack required flag
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iAckRequired));
            //Response required flag
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iResponseRequired));
            //Alarm Monitor popup flag
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iPopup));
            return WebPostSend(methodCall.Request);
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sAlarmTypeGuid">Unique type GUID of alarm to be created (alarms with the same type GUID are considered to be alarms for the same item)</param>
        /// <param name="sPartitionGuid">Guid of partition that alarm belongs to (ignored on non-partitioned systems)</param>
        /// <param name="iPublic">Public flag of alarm (ignored on non-partitioned systems)</param>
        /// <param name="sItemName">Name of item generating alarm</param>
        /// <param name="sDescription">Alarm description</param>
        /// <param name="sInstructions">Alarm Instructions (may be left blank)</param>
        /// <param name="iAlarmType">P2000 Alarm Type</param>
        /// <param name="iPriority">Alarm priority (0 to 255)</param>
        /// <param name="sCategory">Alarm category (default category if blank)</param>
        /// <param name="sQueryString">Alarm query string (may be left blank)</param>
        /// <param name="iAckRequired">Ack required flag</param>
        /// <param name="iResponseRequired">Response required flag</param>
        /// <param name="iPopup">Alarm Monitor popup flag</param>
        /// <param name="dtAlarmTime">Time of the alarm in UTC</param>
        public string AlarmCreateDetailed(string sAlarmTypeGuid, string sPartitionGuid, int iPublic, 
            string sItemName, string sDescription, string sInstructions, int iAlarmType, int iPriority, 
            string sCategory, string sQueryString, int iAckRequired, int iResponseRequired, int iPopup, DateTime dtAlarmTime)
        {
            MethodCall methodCall = CreateMessage("AlarmCreateDetailed");
            methodCall.methodParameterList.Add(new MethodParameter(sAlarmTypeGuid));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iPublic));
            methodCall.methodParameterList.Add(new MethodParameter(sItemName));
            methodCall.methodParameterList.Add(new MethodParameter(sDescription));
            methodCall.methodParameterList.Add(new MethodParameter(sInstructions));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iAlarmType));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iPriority));
            methodCall.methodParameterList.Add(new MethodParameter(sCategory));
            methodCall.methodParameterList.Add(new MethodParameter(sQueryString));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iAckRequired));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iResponseRequired));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iPopup));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(dtAlarmTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of partition to search (ignored on non-partitioned systems)</param>
        public string AlarmGetList(string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("AlarmGetList");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName">Name of partition to search (ignored on non-partitioned systems)</param>
        public string AlarmGetListByName(string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("AlarmGetListByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sAlarmGuid">database GUID of alarm to be updated</param>
        public string AlarmGetState(string sAlarmGuid)
        {
            MethodCall methodCall = CreateMessage("AlarmGetState");
            methodCall.methodParameterList.Add(new MethodParameter(sAlarmGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sAlarmGuid">P2000 V3.x: database GUID of alarm to be updated</param>
        /// <param name="iAlarmState">1 = alarm completed, 2 = alarm responding, 3 = alarm acknowledged</param>
        /// <param name="sResponse">response to be recorded with alarm (only valid for iAlarmState = 2)</param>
        public string AlarmUpdate(string sAlarmGuid, int iAlarmState, string sResponse)
        {
            MethodCall methodCall = CreateMessage("AlarmUpdate");
            methodCall.methodParameterList.Add(new MethodParameter(sAlarmGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iAlarmState));
            methodCall.methodParameterList.Add(new MethodParameter(sResponse));

            return WebPostSend(methodCall.Request);
        }
#endregion
        #region Badge Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sBadgeNumber">Badge number</param>
        /// <param name="sAccessGroupGuid">GUID of Access Group</param>
        /// <param name="sTimezoneGuid">GUID of Timezone</param>
        /// Optional arguments in P2000 V3.9 and later:
        /// <param name="dtStartDate">date Access Group starts (NULL if 0:0:00 AM Jan 1, 1900)</param>
        /// <param name="dtVoidDate">date Access Group ends (NULL if 0:0:00 AM Jan 1, 1900)</param>
        /// <param name="sSiteName">name of Enterprise site to modify (ignored for non-Enterprise systems)</param>
        public string BadgeAddAccessGroup(string sBadgeNumber, string sAccessGroupGuid, string sTimezoneGuid, DateTime? dtStartDate = null, DateTime? dtVoidDate = null, string sSiteName = null)
        {
            MethodCall methodCall = CreateMessage("BadgeAddAccessGroup");
            methodCall.methodParameterList.Add(new MethodParameter(sBadgeNumber));
            methodCall.methodParameterList.Add(new MethodParameter(sAccessGroupGuid));
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneGuid));
            if(dtStartDate != null)
            {
                methodCall.methodParameterList.Add(new MethodDateTimeParameter((DateTime)dtStartDate));
            }
            if (dtVoidDate != null)
            {
                methodCall.methodParameterList.Add(new MethodDateTimeParameter((DateTime)dtVoidDate));
            }
            if (sSiteName != null)
            {
                methodCall.methodParameterList.Add(new MethodParameter(sSiteName));
            }
            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sBadgeNumber">Badge number</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="sAccessGroupName">name of Access Group</param>
        /// <param name="sTimezoneName">name of Timezone</param>
        /// Optional arguments in P2000 V3.9 and later:
        /// <param name="dtStartDate">date Access Group starts (NULL if 0:0:00 AM Jan 1, 1900)</param>
        /// <param name="dtVoidDate">date Access Group ends (NULL if 0:0:00 AM Jan 1, 1900)</param>
        /// <param name="sSiteName">name of Enterprise site to modify (ignored for non-Enterprise systems)</param>
        public string BadgeAddAccessGroupByName(string sBadgeNumber, string sPartitionName, string sAccessGroupName, 
            string sTimezoneName, DateTime? dtStartDate=null, DateTime? dtVoidDate=null, string sSiteName=null)
        {
            MethodCall methodCall = CreateMessage("BadgeAddAccessGroupByName");
            methodCall.methodParameterList.Add(new MethodParameter(sBadgeNumber));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodParameter(sAccessGroupName));
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneName));
            if(dtStartDate != null)
            {
                methodCall.methodParameterList.Add(new MethodDateTimeParameter((DateTime)dtStartDate));
            }
            if (dtVoidDate != null)
            {
                methodCall.methodParameterList.Add(new MethodDateTimeParameter((DateTime)dtVoidDate));
            }
            if (sSiteName != null)
            {
                methodCall.methodParameterList.Add(new MethodParameter(sSiteName));
            }

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sBadgeNumber">Badge number</param>
        /// Optional arguments in P2000 V3.9 and later:
        /// <param name="sSiteName">name of Enterprise site to get data for (ignored for non-Enterprise systems)</param>
        public string BadgeGetInfo(string sBadgeNumber, string sSiteName)
        {
            MethodCall methodCall = CreateMessage("BadgeGetInfo");
            methodCall.methodParameterList.Add(new MethodParameter(sBadgeNumber));
            methodCall.methodParameterList.Add(new MethodParameter(sSiteName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sBadgeNumber">Badge number</param>
        /// Optional arguments in P2000 V3.9 and later:
        /// <param name="sSiteName">name of Enterprise site to get data for (ignored for non-Enterprise systems)</param>
        public string BadgeGetInfoDetailed(string sBadgeNumber, string sSiteName)
        {
            MethodCall methodCall = CreateMessage("BadgeGetInfoDetailed");
            methodCall.methodParameterList.Add(new MethodParameter(sBadgeNumber));
            methodCall.methodParameterList.Add(new MethodParameter(sSiteName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sBadgeNumber">Badge number</param>
        public string BadgeGetLastBadgeInfo(string sBadgeNumber)
        {
            MethodCall methodCall = CreateMessage("BadgeGetLastBadgeInfo");
            methodCall.methodParameterList.Add(new MethodParameter(sBadgeNumber));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sBadgeNumber">Badge number</param>
        public string BadgeGetPurpose(string sBadgeNumber)
        {
            MethodCall methodCall = CreateMessage("BadgeGetPurpose");
            methodCall.methodParameterList.Add(new MethodParameter(sBadgeNumber));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sBadgeNumber">Badge number</param>
        /// <param name="sAccessGroupGuid">GUID of Access Group</param>
        /// Optional arguments in P2000 V3.9 and later:
        /// <param name="sSiteName">name of Enterprise site to get data for (ignored for non-Enterprise systems)</param>
        public string BadgeRemoveAccessGroup(string sBadgeNumber, string sAccessGroupGuid, string sSiteName = null)
        {
            MethodCall methodCall = CreateMessage("BadgeRemoveAccessGroup");
            methodCall.methodParameterList.Add(new MethodParameter(sBadgeNumber));
            if (sSiteName != null)
            {
                methodCall.methodParameterList.Add(new MethodParameter(sSiteName));
            }

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sBadgeNumber">Badge number</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="sAccessGroupName">name of Access Group</param>
        /// Optional arguments in P2000 V3.9 and later:
        /// <param name="sSiteName">name of Enterprise site to get data for (ignored for non-Enterprise systems)</param>
        public string BadgeRemoveAccessGroupByName(string sBadgeNumber, string sPartitionName, string sAccessGroupName, 
            string sSiteName = null)
        {
            MethodCall methodCall = CreateMessage("BadgeRemoveAccessGroupByName");
            methodCall.methodParameterList.Add(new MethodParameter(sBadgeNumber));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodParameter(sAccessGroupName));
            if (sSiteName !=null)
            {
                methodCall.methodParameterList.Add(new MethodParameter(sSiteName));
            }
            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sBadgeNumber">Badge number</param>
        /// <param name="iStatus">0 = undefined, 1 = in, 2 = out</param>
        public string BadgeSetEntryExitStatus(string sBadgeNumber, int iStatus)
        {
            MethodCall methodCall = CreateMessage("BadgeSetEntryExitStatus");
            methodCall.methodParameterList.Add(new MethodParameter(sBadgeNumber));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iStatus));
             
            return WebPostSend(methodCall.Request);
        }
#endregion
        #region Cardholder Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCardholderGuid">Guid of cardholder</param>
        public string CardholderGetAllUdf(string sCardholderGuid)
        {
            MethodCall methodCall = CreateMessage("CardholderGetAllUdf");
            methodCall.methodParameterList.Add(new MethodParameter(sCardholderGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCardholderGuid">Guid of cardholder</param>
        /// <param name="sPartitionGuid">Guid of partition to search (ignored on non-partitioned systems)</param>
        public string CardholderGetBadgeList(string sCardholderGuid, string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("CardholderGetBadgeList");
            methodCall.methodParameterList.Add(new MethodParameter(sCardholderGuid));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCardholderGuid">Guid of cardholder</param>
        public string CardholderGetImage(string sCardholderGuid)
        {
            MethodCall methodCall = CreateMessage("CardholderGetImage");
            methodCall.methodParameterList.Add(new MethodParameter(sCardholderGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sEmployeeID">employee ID of cardholder</param>
        public string CardholderGetImageByID(string sEmployeeID)
        {
            MethodCall methodCall = CreateMessage("CardholderGetImageByID");
            methodCall.methodParameterList.Add(new MethodParameter(sEmployeeID));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCardholderGuid">Guid of cardholder</param>
        public string CardholderGetInfo(string sCardholderGuid)
        {
            MethodCall methodCall = CreateMessage("CardholderGetInfo");
            methodCall.methodParameterList.Add(new MethodParameter(sCardholderGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sEmployeeID"></param>
        public string CardholderGetInfoByID(string sEmployeeID)
        {
            MethodCall methodCall = CreateMessage("CardholderGetInfoByID");
            methodCall.methodParameterList.Add(new MethodParameter(sEmployeeID));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sEmployeeID">employee ID of cardholder</param>
        public string CardholderGetLastBadgeInfo(string sEmployeeID)
        {
            MethodCall methodCall = CreateMessage("CardholderGetLastBadgeInfo");
            methodCall.methodParameterList.Add(new MethodParameter(sEmployeeID));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCardholderGuid">Guid of cardholder</param>
        public string CardholderGetLastBadgeInfoByID(string sCardholderGuid)
        {
            MethodCall methodCall = CreateMessage("CardholderGetLastBadgeInfoByID");
            methodCall.methodParameterList.Add(new MethodParameter(sCardholderGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of partition to search (ignored on non-partitioned systems)</param>
        /// <param name="sFirstNameFilter">first name search filter string*</param>
        /// <param name="sLastNameFilter">last name search filter string*</param>
        /// <param name="iMaxCount">the maximum number of results to return;</param>
        public string CardholderGetList(string sPartitionGuid, string sFirstNameFilter, string sLastNameFilter, 
            int iMaxCount)
        {
            MethodCall methodCall = CreateMessage("CardholderGetList");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));
            methodCall.methodParameterList.Add(new MethodParameter(sFirstNameFilter));
            methodCall.methodParameterList.Add(new MethodParameter(sLastNameFilter));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iMaxCount));

            return WebPostSend(methodCall.Request);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName"></param>
        /// <param name="sFirstNameFilter"></param>
        /// <param name="sLastNameFilter"></param>
        /// <param name="iMaxCount"></param>
        /// <returns></returns>
        public string CardholderGetListByName(string sPartitionName, string sFirstNameFilter, 
            string sLastNameFilter, int iMaxCount)
        {
            MethodCall methodCall = CreateMessage("CardholderGetListByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodParameter(sFirstNameFilter));
            methodCall.methodParameterList.Add(new MethodParameter(sLastNameFilter));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iMaxCount));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of partition to search (ignored on non-partitioned systems)</param>
        /// <param name="sFirstNameFilter">first name search filter string*</param>
        /// <param name="sLastNameFilter">last name search filter string*</param>
        public string CardholderGetListCount(string sPartitionGuid, string sFirstNameFilter, string sLastNameFilter)
        {
            MethodCall methodCall = CreateMessage("CardholderGetListCount");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));
            methodCall.methodParameterList.Add(new MethodParameter(sFirstNameFilter));
            methodCall.methodParameterList.Add(new MethodParameter(sLastNameFilter));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName">name of partition to search (ignored on non-partitioned systems)</param>
        /// <param name="sFirstNameFilter">first name search filter string*</param>
        /// <param name="sLastNameFilter">last name search filter string*</param>
        public string CardholderGetListCountByName(string sPartitionName, string sFirstNameFilter, string sLastNameFilter)
        {
            MethodCall methodCall = CreateMessage("CardholderGetListCountByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodParameter(sFirstNameFilter));
            methodCall.methodParameterList.Add(new MethodParameter(sLastNameFilter));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCardholderGuid">Guid of cardholder</param>
        /// <param name="sUdfGuid">Guid of Udf</param>
        public string CardholderGetUdf(string sCardholderGuid, string sUdfGuid)
        {
            MethodCall methodCall = CreateMessage("CardholderGetUdf");
            methodCall.methodParameterList.Add(new MethodParameter(sCardholderGuid));
            methodCall.methodParameterList.Add(new MethodParameter(sUdfGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCardholderGuid">Guid of cardholder</param>
        /// <param name="iStatus">0 = undefined, 1 = in, 2 = out</param>
        public string CardholderSetEntryExitStatus( string sCardholderGuid, int iStatus)
        {
            MethodCall methodCall = CreateMessage("CardholderSetEntryExitStatus");
            methodCall.methodParameterList.Add(new MethodParameter(sCardholderGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iStatus));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sEmployeeID">employee ID of cardholder</param>
        /// <param name="iStatus">0 = undefined, 1 = in, 2 = out</param>
        public string CardholderSetEntryExitStatusByID(string sEmployeeID, int iStatus)
        {
            MethodCall methodCall = CreateMessage("CardholderSetEntryExitStatusByID");
            methodCall.methodParameterList.Add(new MethodParameter(sEmployeeID));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iStatus));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCardholderGuid">Guid of cardholder</param>
        /// <param name="sUdfGuid">Guid of Udf</param>
        /// <param name="?">UDF value of proper type for UDF (boolean, integer, string, or date)</param>
        //public string CardholderSetUdf( string sCardholderGuid, string sUdfGuid, Value)
        //{
        //    MethodCall methodCall = CreateMessage("");
        //    methodCall.methodParameterList.Add(new MethodParameter());
        //    methodCall.methodParameterList.Add(new MethodStringArrayParameter());

        //    return WebPostSend(methodCall.Request);
        //}
#endregion
        #region Company Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of Partition to get Company list for (ignored on non-partitioned systems)</param>
        public string CompanyGetList(string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("CompanyGetList");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName">name of Partition to get Company list for (ignored on non-partitioned systems)</param>
        public string CompanyGetListByName( string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("CompanyGetListByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        #endregion

        #region Counter Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of Partition to get counter list for (ignored on non-partitioned systems)</param>
        public string CounterGetList( string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("CounterGetList");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName">name of Partition to get counter list for (ignored on non-partitioned systems)</param>
        public string CounterGetListByName(string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("CounterGetListByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCounterGuid">database GUID of counter</param>
        public string CounterGetValue(string sCounterGuid)
        {
            MethodCall methodCall = CreateMessage("CounterGetValue");
            methodCall.methodParameterList.Add(new MethodParameter(sCounterGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCounterName">name of counter</param>
        /// <param name="sPartitionName">name of the partition (ignored on non-partitioned systems)</param>
        public string CounterGetValueByName(string sCounterName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("CounterGetValueByName");
            methodCall.methodParameterList.Add(new MethodParameter(sCounterName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCounterGuid">database GUID of counter</param>
        /// <param name="iValue">value to set counter to</param>
        public string CounterSetValue(string sCounterGuid, int iValue)
        {
            MethodCall methodCall = CreateMessage("CounterSetValue");
            methodCall.methodParameterList.Add(new MethodParameter(sCounterGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iValue));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCounterName">name of counter</param>
        /// <param name="sPartitionName">name of Partition (ignored on non-partitioned systems)</param>
        /// <param name="iValue">value to set counter to</param>
        public string CounterSetValueByName(string sCounterName, string sPartitionName, int iValue)
        {
            MethodCall methodCall = CreateMessage("CounterSetValueByName");
            methodCall.methodParameterList.Add(new MethodParameter(sCounterName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iValue));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCounterGuid">database GUID of counter</param>
        /// <param name="iValueBy">value to increment counter by</param>
        public string CounterChangeValue(string sCounterGuid, int iValueBy)
        {
            MethodCall methodCall = CreateMessage("CounterChangeValue");
            methodCall.methodParameterList.Add(new MethodParameter(sCounterGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iValueBy));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCounterName">Counter Name</param>
        /// <param name="sPartitionName">Partition Name (ignored if system is not partitioned)</param>
        /// <param name="iValueBy">value to increment counter by</param>
        public string CounterChangeValueByName(string sCounterName, string sPartitionName, int iValueBy)
        {
            MethodCall methodCall = CreateMessage("CounterChangeValueByName");
            methodCall.methodParameterList.Add(new MethodParameter(sCounterName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iValueBy));

            return WebPostSend(methodCall.Request);
        }

        #endregion

        #region Department Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of Partition to get Department list for (ignored on non-partitioned systems)</param>
        public string DepartmentGetList(string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("DepartmentGetList");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName">Name of Partition to get Department list for (ignored on non-partitioned systems)</param>
        public string DepartmentGetListByName(string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("DepartmentGetListByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        #endregion

        #region Door Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iScheduledID">ID of scheduled action to be deleted</param>
        public string DoorDeleteScheduled( int iScheduledID)
        {
            MethodCall methodCall = CreateMessage("DoorDeleteScheduled");
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iScheduledID));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        /// <param name="iEnable">1 = enabled, 0 = disabled</param>
        public string DoorEnable(string sTerminalGuid, int iEnable)
        {
            MethodCall methodCall = CreateMessage("DoorEnable");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iEnable));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        public string DoorGetAlarmInputs(string sTerminalGuid)
        {
            MethodCall methodCall = CreateMessage("DoorGetAlarmInputs");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalName">name of terminal</param>
        /// <param name="sPartitionName">name of partition (ignored for non-partitioned system)</param>
        public string DoorGetAlarmInputsByName(string sTerminalName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("DoorGetAlarmInputsByName");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of Partition to get door list for (ignored on non-partitioned systems)</param>
        public string DoorGetList(string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("DoorGetList");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName">name of Partition to get door list for (ignored on non-partitioned systems)</param>
        /// <returns></returns>
        public string DoorGetListByName(string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("DoorGetListByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        public string DoorGetScheduled(string sTerminalGuid)
        {
            MethodCall methodCall = CreateMessage("DoorGetScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalName">name of terminal</param>
        /// <param name="sPartitionName">name of partition (ignored for non-partitioned systems)</param>
        public string DoorGetScheduledByName(string sTerminalName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("DoorGetScheduledByName");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of Partition to get list for (ignored on non-partitioned systems)</param>
        public string DoorGetAllScheduled(string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("DoorGetAllScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName">name of Partition to get list for (ignored on non-partitioned systems)</param>
        public string DoorGetAllScheduledByName(string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("DoorGetAllScheduledByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sDoorGuid">Guid of door as retrieve from door point list</param>
        public string DoorGetSecurityLevel(string sDoorGuid)
        {
            MethodCall methodCall = CreateMessage("DoorGetSecurityLevel");
            methodCall.methodParameterList.Add(new MethodParameter(sDoorGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sDoorName">name of door</param>
        /// <param name="sPartitionName">partition name (ignored on non-partitioned systems)</param>
        public string DoorGetSecurityLevelByName (string sDoorName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("DoorGetSecurityLevelByName");
            methodCall.methodParameterList.Add(new MethodParameter(sDoorName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        public string DoorGetStatus(string sTerminalGuid)
        {
            MethodCall methodCall = CreateMessage("DoorGetStatus");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalName">name of terminal</param>
        /// <param name="sPartitionName">partition name (ignored on non-partitioned systems)</param>
		public string DoorGetStatusByName(string sTerminalName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("DoorGetStatusByName");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        public string DoorLock(string sTerminalGuid)
        {
            MethodCall methodCall = CreateMessage("DoorLock");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string DoorLockScheduled(string sTerminalGuid, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("DoorLockScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(tScheduledTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalName">name of terminal</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        public string DoorLockByName(string sTerminalName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("DoorLockByName");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalName">name of terminal</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string DoorLockByNameScheduled(string sTerminalName, string sPartitionName, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("DoorLockByNameScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(tScheduledTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        /// <param name="sTimezoneGuid">database GUID of the Timezone</param>
        public string DoorSetOverrideTimezone(string sTerminalGuid, string sTimezoneGuid)
        {
            MethodCall methodCall = CreateMessage("DoorSetOverrideTimezone");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalName">name of terminal</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="sTimezoneName">name of the Timezone</param>
        public string DoorSetOverrideTimezoneByName(string sTerminalName, string sPartitionName, string sTimezoneName)
        {
            MethodCall methodCall = CreateMessage("DoorSetOverrideTimezoneByName");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        /// <param name="iEnable">1 = override timezone enabled, 0 = override timezone disabled</param>
        public string DoorSetOverrideTimezoneEnable(string sTerminalGuid, int iEnable)
        {
            MethodCall methodCall = CreateMessage("DoorSetOverrideTimezoneEnable");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iEnable));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalName">name of terminal</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="iEnable">1 = override timezone enabled, 0 = override timezone disabled</param>
        public string DoorSetOverrideTimezoneEnableByName(string sTerminalName, string sPartitionName, int iEnable)
        {
            MethodCall methodCall = CreateMessage("DoorSetOverrideTimezoneEnableByName");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iEnable));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        /// <param name="sTimezoneGuid">database GUID of time zone to be overridden</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string DoorSetOverrideTimezoneScheduled(string sTerminalGuid, string sTimezoneGuid, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("DoorSetOverrideTimezoneScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneGuid));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(tScheduledTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalName">name of terminal</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="sTimezoneGuid">database GUID of time zone to be overridden</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string DoorSetOverrideTimezoneByNameScheduled( string sTerminalName, string sPartitionName, 
            string sTimezoneGuid, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("DoorSetOverrideTimezoneByNameScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneGuid));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(tScheduledTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        /// <param name="iEnable">Enable flag</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string DoorSetOverrideTimezoneEnableScheduled(string sTerminalGuid, int iEnable, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("DoorSetOverrideTimezoneEnableScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iEnable));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(tScheduledTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalName">name of terminal</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="iEnable">Enable flag</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string DoorSetOverrideTimezoneEnableByNameScheduled (string sTerminalName, string sPartitionName,
            int iEnable, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("DoorSetOverrideTimezoneEnableByNameScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iEnable));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(tScheduledTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        /// <param name="iSecurityLevel">the new security level for this door (0 .. 99)</param>
        public string DoorSetSecurityLevel(string sTerminalGuid, int iSecurityLevel)
        {
            MethodCall methodCall = CreateMessage("DoorSetSecurityLevel");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iSecurityLevel));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalName">name of terminal</param>
        /// <param name="sPartitionName">partition name (ignored on non-partitioned systems)</param>
        /// <param name="iSecurityLevel">the new security level for this door (0 .. 99)</param>
        public string DoorSetSecurityLevelByName (string sTerminalName, string sPartitionName, int iSecurityLevel)
        {
            MethodCall methodCall = CreateMessage("DoorSetSecurityLevelByName");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iSecurityLevel));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        /// <param name="iSecurityLevelColor">new security level for this door (0 = clear, 1 = green, 2 = blue, 3 = yellow, 4 = orange, 5 = red)</param>
        public string DoorSetSecurityLevelColor(string sTerminalGuid, int iSecurityLevelColor)
        {
            MethodCall methodCall = CreateMessage("DoorSetSecurityLevelColor");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iSecurityLevelColor));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalName">name of terminal</param>
        /// <param name="sPartitionName">partition name (ignored on non-partitioned systems)</param>
        /// <param name="sSecurityLevelColor">the new security level for this door ("clear", "green", "blue", "yellow", "orange", or "red")</param>
        public string DoorSetSecurityLevelColorByName (string sTerminalName, string sPartitionName, 
            string sSecurityLevelColor)
        {
            MethodCall methodCall = CreateMessage("DoorSetSecurityLevelColorByName");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        /// <param name="iTime">amount of time to unlock door in minutes (maximum of 1440 minutes)</param>
        public string DoorTimedUnlock(string sTerminalGuid, int iTime)
        {
            MethodCall methodCall = CreateMessage("DoorTimedUnlock");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        /// <param name="iTime">amount of time to unlock door in minutes (maximum of 1440 minutes)</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string DoorTimedUnlockScheduled(string sTerminalGuid, int iTime, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("DoorTimedUnlockScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iTime));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(tScheduledTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalName">name of terminal</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="iTime">amount of time to unlock door in minutes (maximum of 1440 minutes)</param>
        public string DoorTimedUnlockByName(string sTerminalName, string sPartitionName, int iTime)
        {
            MethodCall methodCall = CreateMessage("DoorTimedUnlockByName");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalName">name of terminal</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="iTime">amount of time to unlock door in minutes (maximum of 1440 minutes)</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string DoorTimedUnlockByNameScheduled(string sTerminalName, string sPartitionName,
            int iTime, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("DoorTimedUnlockByNameScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iTime));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(tScheduledTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        public string DoorUnlock(string sTerminalGuid)
        {
            MethodCall methodCall = CreateMessage("DoorUnlock");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalGuid">database GUID of terminal</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string DoorUnlockScheduled(string sTerminalGuid, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("DoorUnlockScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalGuid));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(tScheduledTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalName">name of terminal</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        public string DoorUnlockByName(string sTerminalName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("DoorUnlockByName");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTerminalName">name of terminal</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string DoorUnlockByNameScheduled(string sTerminalName, string sPartitionName, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("DoorUnlockByNameScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(tScheduledTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iUnlock">0 = return to normal, 1 = unlock</param>
        /// <param name="sPartitionGuid">Guid of Partition of doors to unlock (ignored on non-partitioned systems)</param>
        public string DoorUnlockAll(int iUnlock, string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("DoorUnlockAll");
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iUnlock));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iUnlock">0 = return to normal, 1 = unlock</param>
        /// <param name="sPartitionName">name of Partition of doors to unlock (ignored on non-partitioned systems)</param>
        public string DoorUnlockAllByName(int iUnlock, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("DoorUnlockAllByName");
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iUnlock));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        #endregion
       
        #region Event Methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iScheduledID">ID of scheduled action to be deleted</param>
        public string EventDeleteScheduled(int iScheduledID)
        {
            MethodCall methodCall = CreateMessage("EventDeleteScheduled");
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iScheduledID));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of partition to get scheduled events for (ignored for non-partitioned systems)</param>
        public string EventGetAllScheduled(string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("EventGetAllScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName">name of partition to get scheduled events for (ignored for non-partitioned systems)</param>
        public string EventGetAllScheduledByName(string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("EventGetAllScheduledByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sEventGuid">database GUID of event to be triggered</param>
        public string EventTrigger(string sEventGuid)
        {
            MethodCall methodCall = CreateMessage("EventTrigger");
            methodCall.methodParameterList.Add(new MethodParameter(sEventGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sEventName">name of event to be triggered</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        public string EventTriggerByName(string sEventName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("EventTriggerByName");
            methodCall.methodParameterList.Add(new MethodParameter(sEventName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sEventName">name of event to be triggered</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string EventTriggerByNameScheduled(string sEventName, string sPartitionName, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("EventTriggerByNameScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sEventName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(tScheduledTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sEventGuid">database GUID of event to be triggered</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string EventTriggerScheduled(string sEventGuid, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("EventTriggerScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sEventGuid));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(tScheduledTime));

            return WebPostSend(methodCall.Request);
        }

        #endregion

        #region Input Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sInputGuid">database GUID of input point</param>
        /// <param name="iDisable">1 = disable input, 0 = enable input</param>
        public string InputDisable(string sInputGuid, int iDisable)
        {
            MethodCall methodCall = CreateMessage("InputDisable");
            methodCall.methodParameterList.Add(new MethodParameter(sInputGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iDisable));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sInputName">name of input</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="iDisable">1 = disable input, 0 = enable input</param>
        public string InputDisableByName(string sInputName, string sPartitionName, int iDisable)
        {
            MethodCall methodCall = CreateMessage("InputDisableByName");
            methodCall.methodParameterList.Add(new MethodParameter(sInputName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iDisable));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of partition to get input list for (ignored on non-partitioned systems)</param>
        public string InputGetList(string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("InputGetList");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName">name of partition to get Input list for (ignored on non-partitioned systems)</param>
        public string InputGetListByName(string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("InputGetListByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sInputGuid">database GUID of input point</param>
        public string InputGetStatus(string sInputGuid)
        {
            MethodCall methodCall = CreateMessage("InputGetStatus");
            methodCall.methodParameterList.Add(new MethodParameter(sInputGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sInputName">name of input</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        public string InputGetStatusByName(string sInputName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("InputGetStatusByName");
            methodCall.methodParameterList.Add(new MethodParameter(sInputName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sInputGuid">database GUID of input point</param>
        /// <param name="iDuration">duration in seconds (0 to cancel suppression)</param>
        public string InputSuppress(string sInputGuid, int iDuration)
        {
            MethodCall methodCall = CreateMessage("InputSuppress");
            methodCall.methodParameterList.Add(new MethodParameter(sInputGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iDuration));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sInputName">name of input</param>
        /// <param name="sPartition">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="iDuration">duration in seconds (0 to cancel suppression)</param>
        public string InputSuppressByName(string sInputName, string sPartition, int iDuration)
        {
            MethodCall methodCall = CreateMessage("InputSuppressByName");
            methodCall.methodParameterList.Add(new MethodParameter(sInputName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartition));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iDuration));

            return WebPostSend(methodCall.Request);
        }

        #endregion

        #region Output Methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iScheduledID">ID of scheduled action to be deleted</param>
        public string OutputDeleteScheduled(int iScheduledID)
        {
            MethodCall methodCall = CreateMessage("OutputDeleteScheduled");
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iScheduledID));

            return WebPostSend(methodCall.Request);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of Partition to get Output list for (ignored on non-partitioned systems)</param>
        public string OutputGetList(string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("OutputGetList");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName">name of partition to get Output list for (ignored on non-partitioned systems)</param>
        public string OutputGetListByName(string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("OutputGetListByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sOutputGuid">database GUID of output point</param>
        public string OutputGetScheduled(string sOutputGuid)
        {
            MethodCall methodCall = CreateMessage("OutputGetScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sOutputGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sOutputName">name of output point</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        public string OutputGetScheduledByName(string sOutputName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("OutputGetScheduledByName");
            methodCall.methodParameterList.Add(new MethodParameter(sOutputName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sOutputGuid">database GUID of output point</param>
        public string OutputGetStatus(string sOutputGuid)
        {
            MethodCall methodCall = CreateMessage("OutputGetStatus");
            methodCall.methodParameterList.Add(new MethodParameter(sOutputGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sOutputName">name of output</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        public string OutputGetStatusByName(string sOutputName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("OutputGetStatusByName");
            methodCall.methodParameterList.Add(new MethodParameter(sOutputName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sOutputGuid">database GUID of output point</param>
        /// <param name="iAction">0 = reset output, 1 = set output, 2 = slow flash, 3 = fast flash, 4 = preset</param>
        public string OutputSet(string sOutputGuid, int iAction)
        {
            MethodCall methodCall = CreateMessage("OutputSet");
            methodCall.methodParameterList.Add(new MethodParameter(sOutputGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iAction));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sOutputName">name of output point</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="iAction">0 = reset output, 1 = set output, 2 = slow flash, 3 = fast flash, 4 = preset</param>
        public string OutputSetByName(string sOutputName, string sPartitionName, int iAction)
        {
            MethodCall methodCall = CreateMessage("OutputSetByName");
            methodCall.methodParameterList.Add(new MethodParameter(sOutputName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iAction));

            return WebPostSend(methodCall.Request);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sOutputName">name of output point</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="iAction">0 = reset output, 1 = set output</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string OutputSetByNameScheduled(string sOutputName, string sPartitionName, int iAction, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("OutputSetByNameScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sOutputName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iAction));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(tScheduledTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sOutputGuid">database GUID of output point</param>
        /// <param name="iAction">0 = reset output, 1 = set output</param>
        /// <param name="iDuration">duration in seconds (ignored if action is reset)</param>
        public string OutputSetForDuration(string sOutputGuid, int iAction, int iDuration)
        {
            MethodCall methodCall = CreateMessage("OutputSetForDuration");
            methodCall.methodParameterList.Add(new MethodParameter(sOutputGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iAction));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iDuration));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sOutputName">name of output point</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="iAction">0 = reset output, 1 = set output</param>
        /// <param name="iDuration">duration in seconds (ignored if action is reset)</param>
        public string OutputSetForDurationByName(string sOutputName, string sPartitionName, int iAction, int iDuration)
        {
            MethodCall methodCall = CreateMessage("OutputSetForDurationByName");
            methodCall.methodParameterList.Add(new MethodParameter(sOutputName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iAction));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iDuration));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sOutputGuid">database GUID of output point</param>
        /// <param name="iAction">0 = reset output, 1 = set output</param>
        /// <param name="iDuration">duration in seconds (ignored if action is reset)</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string OutputSetForDurationScheduled(string sOutputGuid, int iAction, int iDuration, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("OutputSetForDurationScheduled");
            methodCall.methodParameterList.Add(new MethodParameter(sOutputGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iAction));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iDuration));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(tScheduledTime));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sOutputName">name of output point</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="iAction">0 = reset output, 1 = set output</param>
        /// <param name="iDuration">duration in seconds (ignored if action is reset)</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string OutputSetForDurationByNameScheduled(string sOutputName, string sPartitionName, 
            int iAction, int iDuration, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("");
            methodCall.methodParameterList.Add(new MethodParameter());
            methodCall.methodParameterList.Add(new MethodStringArrayParameter());

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sOutputGuid">database GUID of output point</param>
        /// <param name="iAction">0 = reset output, 1 = set output</param>
        /// <param name="tScheduledTime">time for action to occur</param>
        public string OutputSetScheduled(string sOutputGuid, int iAction, DateTime tScheduledTime)
        {
            MethodCall methodCall = CreateMessage("");
            methodCall.methodParameterList.Add(new MethodParameter());
            methodCall.methodParameterList.Add(new MethodStringArrayParameter());

            return WebPostSend(methodCall.Request);
        }

        #endregion

        #region P2000 Methods

        /// <summary>
        /// 
        /// </summary>
        public string P2000GetVersion()
        {
            MethodCall methodCall = CreateMessage("P2000GetVersion");
            methodCall.methodParameterList.Add(new MethodParameter());
            methodCall.methodParameterList.Add(new MethodStringArrayParameter());

            return WebPostSend(methodCall.Request);
        }

        #endregion
        
        #region Panel Methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPanelGuid">Guid of panel</param>
        /// <param name="sPartitionGuid">Guid of Partition to get component list for (ignored on non-partitioned systems)</param>
        public string PanelGetComponents(string sPanelGuid, string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("PanelGetComponents");
            methodCall.methodParameterList.Add(new MethodParameter(sPanelGuid));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPanelName">name of panel</param>
        /// <param name="sPartitionName">name of Partition to get component list for (ignored on non-partitioned systems)</param>
        public string PanelGetComponentsByName(string sPanelName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("PanelGetComponentsByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPanelName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of Partition to get Panel list for (ignored on non-partitioned systems)</param>
        public string PanelGetList(string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("PanelGetList");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName">name of Partition to get Panel list for (ignored on non-partitioned systems)</param>
        public string PanelGetListByName(string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("PanelGetListByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPanelGuid">Guid of panel</param>
        public string PanelGetTimezones(string sPanelGuid)
        {
            MethodCall methodCall = CreateMessage("PanelGetTimezones");
            methodCall.methodParameterList.Add(new MethodParameter(sPanelGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPanelName">name of panel</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        public string PanelGetTimezonesByName(string sPanelName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("PanelGetTimezonesByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPanelName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPanelGuid">Guid of panel</param>
        /// <param name="iTimezonePos">position of Timezone (1 to 64)</param>
        /// <param name="sTimezoneGuid">Guid of Timezone ("<NULL>" if none)</param>
        /// <param name="sOutputGrpGuid">Guid of output group ("<NULL>" if none)</param>
        public string PanelModifyTimezone(string sPanelGuid, int iTimezonePos, string sTimezoneGuid, string sOutputGrpGuid)
        {
            MethodCall methodCall = CreateMessage("PanelModifyTimezone");
            methodCall.methodParameterList.Add(new MethodParameter(sPanelGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iTimezonePos));
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneGuid));
            methodCall.methodParameterList.Add(new MethodParameter(sOutputGrpGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPanelName">name of panel</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        /// <param name="iTimezonePos">position of Timezone (1 to 64)</param>
        /// <param name="sTimezoneName">name of Timezone ("<NULL>" if none)</param>
        /// <param name="sOutputGrpName">name of output group ("<NULL>" if none)</param>
        public string PanelModifyTimezoneByName(string sPanelName, string sPartitionName, int iTimezonePos, 
            string sTimezoneName, string sOutputGrpName)
        {
            MethodCall methodCall = CreateMessage("PanelModifyTimezoneByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPanelName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iTimezonePos));
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneName));
            methodCall.methodParameterList.Add(new MethodParameter(sOutputGrpName));

            return WebPostSend(methodCall.Request);
        }

        #endregion

        #region Partition Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string PartitionGetList()
        {
            MethodCall methodCall = CreateMessage("PartitionGetList");
            return WebPostSend(methodCall.Request);
        }

        #endregion

        #region Terminal Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of Partition to get terminal list for (ignored on non-partitioned systems)</param>
        public string TerminalGetList(string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("TerminalGetList");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName">name of Partition to get terminal list for (ignored on non-partitioned systems)</param>
        public string TerminalGetListByName(string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("TerminalGetListByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        #endregion
       
        #region TimeZone Methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTimezoneName">name for new Timezone</param>
        /// <param name="sTimezoneGuid">GUID for new Timezone (autoassigned if "NULL")</param>
        /// <param name="sPartitionGuid">GUID for the partition which owns this timezone (ignored on non-partitioned systems)</param>
        /// <param name="iPublic">0 = non-public, 1 = public (ignored on non-partitioned systems)</param>
        /// <param name="iAddToAllPanels">0 = do not add to panels, 1 = add to all panels</param>
        /// <param name="iInitialStates">array of 10 initial states (0 = starts disabled at midnight, 1 = starts enabled at midnight)</param>
        /// <param name="tTimes">array of 70 timezone toggles (ignored if 00:00:00)</param>
        public string TimezoneAdd(string sTimezoneName, string sTimezoneGuid, string sPartitionGuid, 
            int iPublic, int iAddToAllPanels, int [] iInitialStates, DateTime[] tTimes)
        {
            MethodCall methodCall = CreateMessage("TimezoneAdd");
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneName));
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneGuid));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iPublic));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iAddToAllPanels));
            methodCall.methodParameterList.Add(new MethodIntArrayParameter(iInitialStates));
            methodCall.methodParameterList.Add(new MethodDateTimeArrayParameter(tTimes));

            return WebPostSend(methodCall.Request);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTimezoneName">name for new Timezone</param>
        /// <param name="sTimezoneGuid">GUID for new Timezone (autoassigned if "NULL")</param>
        /// <param name="sPartitionName">name of the partition which owns this timezone (ignored on non-partitioned systems)</param>
        /// <param name="iPublic">0 = non-public, 1 = public (ignored on non-partitioned systems)</param>
        /// <param name="iAddToAllPanels">0 = do not add to panels, 1 = add to all panels</param>
        /// <param name="iInitialStates">array of 10 initial states (0 = starts disabled at midnight, 1 = starts enabled at midnight)</param>
        /// <param name="tTimes">array of 70 timezone toggles (ignored if 00:00:00)</param>
        public string TimezoneAddByName(string sTimezoneName, string sTimezoneGuid, string sPartitionName, 
            int iPublic, int iAddToAllPanels, int [] iInitialStates, DateTime[] tTimes)
        {
            MethodCall methodCall = CreateMessage("TimezoneAddByName");
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneName));
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneGuid));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iPublic));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iAddToAllPanels));
            methodCall.methodParameterList.Add(new MethodIntArrayParameter(iInitialStates));
            methodCall.methodParameterList.Add(new MethodDateTimeArrayParameter(tTimes));
            return WebPostSend(methodCall.Request);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTimezoneGuid">database GUID of the Timezone</param>
        public string TimezoneIsActive(string sTimezoneGuid)
        {
            MethodCall methodCall = CreateMessage("TimezoneIsActive");
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTimezoneName">name of the Timezone</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        public string TimezoneIsActiveByName(string sTimezoneName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("TimezoneIsActiveByName");
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTimezoneGuid">database GUID of the Timezone</param>
        public string TimezoneGetInfo(string sTimezoneGuid)
        {
            MethodCall methodCall = CreateMessage("TimezoneGetInfo");
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTimezoneName">name of the Timezone</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        public string TimezoneGetInfoByName(string sTimezoneName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("TimezoneGetInfoByName");
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of Partition to get Timezone list for (ignored on non-partitioned systems)</param>
        public string TimezoneGetList(string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("TimezoneGetList");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName">name of Partition to get Timezone list for (ignored on non-partitioned systems)</param>
        public string TimezoneGetListByName(string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("TimezoneGetListByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTimezoneGuid">database GUID of the Timezone</param>
        /// <param name="iInitialState">array of 10 initial states (0 = starts disabled at midnight, 1 = starts enabled at midnight)</param>
        /// <param name="tTimes">array of 70 timezone toggles (ignored if 00:00:00)</param>
        public string TimezoneModify(string sTimezoneGuid, int iInitialState, DateTime [] tTimes)
        {
            MethodCall methodCall = CreateMessage("TimezoneModify");
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneGuid));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iInitialState));
            methodCall.methodParameterList.Add(new MethodDateTimeArrayParameter(tTimes));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTimezoneName">name of the Timezone</param>
        /// <param name="sPartitionName">name of Partition (ignored on non-partitioned systems)</param>
        /// <param name="iInitialState">array of 10 initial states (0 = starts disabled at midnight, 1 = starts enabled at midnight)</param>
        /// <param name="tTimes">array of 70 timezone toggles (ignored if 00:00:00)</param>
        public string TimezoneModifyByName(string sTimezoneName, string sPartitionName, 
            int iInitialState, DateTime[] tTimes)
        {
            MethodCall methodCall = CreateMessage("TimezoneModifyByName");
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iInitialState));
            methodCall.methodParameterList.Add(new MethodDateTimeArrayParameter(tTimes));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTimezoneGuid">database GUID of the Timezone</param>
        public string TimezoneDelete(string sTimezoneGuid)
        {
            MethodCall methodCall = CreateMessage("TimezoneDelete");
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sTimezoneName">name of the Timezone</param>
        /// <param name="sPartitionName">name of partition (ignored if system is not partitioned)</param>
        public string TimezoneDeleteByName(string sTimezoneName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("TimezoneDeleteByName");
            methodCall.methodParameterList.Add(new MethodParameter(sTimezoneName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        #endregion

        #region UDF Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionGuid">Guid of Partition to get UDF list for (ignored on non-partitioned systems)</param>
        public string UdfGetList(string sPartitionGuid)
        {
            MethodCall methodCall = CreateMessage("UdfGetList");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sPartitionName">name of Partition to get UDF list for (ignored on non-partitioned systems)</param>
        public string UdfGetListByName(string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("UdfGetListByName");
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sUdfGuid">Guid of UDF to get selection choices for</param>
        public string UdfGetSelectionChoices(string sUdfGuid)
        {
            MethodCall methodCall = CreateMessage("UdfGetSelectionChoices");
            methodCall.methodParameterList.Add(new MethodParameter(sUdfGuid));

            return WebPostSend(methodCall.Request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sUdfName">name of UDF to get selection choices for</param>
        /// <param name="sPartitionName">name of partition (ignored on non-partitioned systems)</param>
        public string UdfGetSelectionChoicesByName(string sUdfName, string sPartitionName)
        {
            MethodCall methodCall = CreateMessage("UdfGetSelectionChoicesByName");
            methodCall.methodParameterList.Add(new MethodParameter(sUdfName));
            methodCall.methodParameterList.Add(new MethodParameter(sPartitionName));

            return WebPostSend(methodCall.Request);
        }

        #endregion

        #region XAction Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iHistType">History Type</param>
        /// <param name="sPanelName">name of panel</param>
        /// <param name="sTerminalName">Terminal name</param>
        /// <param name="sPointName">Point name</param>
        /// <param name="sBadgeNumber">Badge number</param>
        /// <param name="sFirstName">First name</param>
        /// <param name="sLastName">Last name</param>
        /// <param name="iTimedOverride">Override time</param>
        /// <param name="iIssueLevel">Issue Level of badge</param>
        /// <param name="iFacilityCode">Facility code of badge</param>
        /// <param name="sEventName">name of event</param>
        /// <param name="tTime">timestamp of transaction</param>
        /// <param name="sPartition">name of partition which owns this action</param>
        /// <param name="iPublic">0 = non-public, 1 = public</param>
        public string XActionSave(int iHistType, string sPanelName, string sTerminalName, 
            string sPointName, string sBadgeNumber, string sFirstName, string sLastName, 
            int iTimedOverride, int iIssueLevel, int iFacilityCode, string sEventName, 
            DateTime tTime, string sPartition, int iPublic)
        {
            MethodCall methodCall = CreateMessage("XActionSave");
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iHistType));
            methodCall.methodParameterList.Add(new MethodParameter(sPanelName));
            methodCall.methodParameterList.Add(new MethodParameter(sTerminalName));
            methodCall.methodParameterList.Add(new MethodParameter(sPointName));
            methodCall.methodParameterList.Add(new MethodParameter(sBadgeNumber));
            methodCall.methodParameterList.Add(new MethodParameter(sFirstName));
            methodCall.methodParameterList.Add(new MethodParameter(sLastName));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iTimedOverride));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iIssueLevel));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iFacilityCode));
            methodCall.methodParameterList.Add(new MethodParameter(sEventName));
            methodCall.methodParameterList.Add(new MethodDateTimeParameter(tTime));
            methodCall.methodParameterList.Add(new MethodParameter(sPartition));
            methodCall.methodParameterList.Add(new MethodIntegerParameter(iPublic));

            return WebPostSend(methodCall.Request);
        }
        #endregion

        private MethodCall CreateMessage(string methodName)
        {
            MethodCall methodCall = new MethodCall(this.username, this.password, methodName);
            return methodCall;
        }

        private string WebPostSend(string postData)
        {
            string responseData = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.url);
                request.AllowAutoRedirect = true;
                request.Timeout = 6000;
                request.Method = "POST";
                request.ContentType = "text/xml";

                request.ContentType = "application/x-www-form-urlencoded";
                ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] postByteArray = encoding.GetBytes(postData);
                request.ContentLength = postByteArray.Length;

                Stream postStream = request.GetRequestStream();
                postStream.Write(postByteArray, 0, postByteArray.Length);
                postStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(responseStream);
                    responseData = myStreamReader.ReadToEnd();
                }
                response.Close();
            }
            catch (System.Net.WebException webEx)
            {
                throw webEx;
            }
            catch (Exception e)
            {
                throw e;
            }
            return responseData;
        }
    }

}
