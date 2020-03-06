/* ========================================================================
 * Copyright (c) 2005-2019 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;
using Opc.Ua.Di;

namespace fortiss_Device
{
    #region DataType Identifiers
    /// <summary>
    /// A class that declares constants for all DataTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypes
    {
        /// <summary>
        /// The identifier for the GripTypeEnumeration DataType.
        /// </summary>
        public const uint GripTypeEnumeration = 15252;
    }
    #endregion

    #region Method Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Open Method.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_Open = 15015;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Close Method.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_Close = 15018;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Read Method.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_Read = 15020;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Write Method.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_Write = 15023;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_GetPosition Method.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_GetPosition = 15025;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_SetPosition Method.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_SetPosition = 15028;

        /// <summary>
        /// The identifier for the SkillType_Start Method.
        /// </summary>
        public const uint SkillType_Start = 15095;

        /// <summary>
        /// The identifier for the SkillType_Suspend Method.
        /// </summary>
        public const uint SkillType_Suspend = 15096;

        /// <summary>
        /// The identifier for the SkillType_Resume Method.
        /// </summary>
        public const uint SkillType_Resume = 15097;

        /// <summary>
        /// The identifier for the SkillType_Halt Method.
        /// </summary>
        public const uint SkillType_Halt = 15098;

        /// <summary>
        /// The identifier for the SkillType_Reset Method.
        /// </summary>
        public const uint SkillType_Reset = 15099;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__Halt Method.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__Halt = 15242;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__Reset Method.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__Reset = 15243;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__Resume Method.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__Resume = 15244;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__Suspend Method.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__Suspend = 15245;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__Start Method.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__Start = 15246;

        /// <summary>
        /// The identifier for the IPowerOffDeviceType_PowerOffDevice Method.
        /// </summary>
        public const uint IPowerOffDeviceType_PowerOffDevice = 15248;

        /// <summary>
        /// The identifier for the SensorType_Lock_InitLock Method.
        /// </summary>
        public const uint SensorType_Lock_InitLock = 15706;

        /// <summary>
        /// The identifier for the SensorType_Lock_RenewLock Method.
        /// </summary>
        public const uint SensorType_Lock_RenewLock = 15709;

        /// <summary>
        /// The identifier for the SensorType_Lock_ExitLock Method.
        /// </summary>
        public const uint SensorType_Lock_ExitLock = 15711;

        /// <summary>
        /// The identifier for the SensorType_Lock_BreakLock Method.
        /// </summary>
        public const uint SensorType_Lock_BreakLock = 15713;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_InitLock Method.
        /// </summary>
        public const uint ForceTorqueSensorType_Lock_InitLock = 15742;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_RenewLock Method.
        /// </summary>
        public const uint ForceTorqueSensorType_Lock_RenewLock = 15745;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_ExitLock Method.
        /// </summary>
        public const uint ForceTorqueSensorType_Lock_ExitLock = 15747;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_BreakLock Method.
        /// </summary>
        public const uint ForceTorqueSensorType_Lock_BreakLock = 15749;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_InitLock Method.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor_Lock_InitLock = 15776;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_RenewLock Method.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor_Lock_RenewLock = 15779;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_ExitLock Method.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor_Lock_ExitLock = 15781;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_BreakLock Method.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor_Lock_BreakLock = 15783;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_InitLock Method.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor_Lock_InitLock = 15816;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_RenewLock Method.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor_Lock_RenewLock = 15819;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_ExitLock Method.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor_Lock_ExitLock = 15821;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_BreakLock Method.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor_Lock_BreakLock = 15823;
    }
    #endregion

    #region Object Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata Object.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata = 15001;

        /// <summary>
        /// The identifier for the SkillType_FinalResultData Object.
        /// </summary>
        public const uint SkillType_FinalResultData = 15068;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ParameterSet Object.
        /// </summary>
        public const uint GraspGripperSkillType_ParameterSet = 15235;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ParameterSet Object.
        /// </summary>
        public const uint ReleaseGripperSkillType_ParameterSet = 15943;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ParameterSet Object.
        /// </summary>
        public const uint MoveGripperSkillType_ParameterSet = 16017;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills Object.
        /// </summary>
        public const uint ISkillControllerType_Skills = 15398;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No_ Object.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No_ = 15399;

        /// <summary>
        /// The identifier for the IGripperType_GripPoints Object.
        /// </summary>
        public const uint IGripperType_GripPoints = 15304;

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No_ Object.
        /// </summary>
        public const uint IGripperType_GripPoints_GripPoint__No_ = 15305;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor Object.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor = 15764;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor Object.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor = 15804;
    }
    #endregion

    #region ObjectType Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <summary>
        /// The identifier for the SkillType ObjectType.
        /// </summary>
        public const uint SkillType = 15034;

        /// <summary>
        /// The identifier for the GripperSkillType ObjectType.
        /// </summary>
        public const uint GripperSkillType = 15101;

        /// <summary>
        /// The identifier for the GraspGripperSkillType ObjectType.
        /// </summary>
        public const uint GraspGripperSkillType = 15168;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType ObjectType.
        /// </summary>
        public const uint ReleaseGripperSkillType = 15473;

        /// <summary>
        /// The identifier for the MoveGripperSkillType ObjectType.
        /// </summary>
        public const uint MoveGripperSkillType = 15950;

        /// <summary>
        /// The identifier for the ISkillControllerType ObjectType.
        /// </summary>
        public const uint ISkillControllerType = 15396;

        /// <summary>
        /// The identifier for the IPowerOffDeviceType ObjectType.
        /// </summary>
        public const uint IPowerOffDeviceType = 15247;

        /// <summary>
        /// The identifier for the GripPoint ObjectType.
        /// </summary>
        public const uint GripPoint = 15254;

        /// <summary>
        /// The identifier for the VacuumGripPoint ObjectType.
        /// </summary>
        public const uint VacuumGripPoint = 15270;

        /// <summary>
        /// The identifier for the ParallelGripPoint ObjectType.
        /// </summary>
        public const uint ParallelGripPoint = 15286;

        /// <summary>
        /// The identifier for the IGripperType ObjectType.
        /// </summary>
        public const uint IGripperType = 15303;

        /// <summary>
        /// The identifier for the SensorType ObjectType.
        /// </summary>
        public const uint SensorType = 15692;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType ObjectType.
        /// </summary>
        public const uint ForceTorqueSensorType = 15728;

        /// <summary>
        /// The identifier for the SkillTransitionEventType ObjectType.
        /// </summary>
        public const uint SkillTransitionEventType = 15844;
    }
    #endregion

    #region Variable Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceUri Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceUri = 15002;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceVersion Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceVersion = 15003;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespacePublicationDate Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespacePublicationDate = 15004;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_IsNamespaceSubset Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_IsNamespaceSubset = 15005;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_StaticNodeIdTypes Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_StaticNodeIdTypes = 15006;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_StaticNumericNodeIdRange Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_StaticNumericNodeIdRange = 15007;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_StaticStringNodeIdPattern Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_StaticStringNodeIdPattern = 15008;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Size Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_Size = 15010;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Writable Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_Writable = 15011;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_UserWritable Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_UserWritable = 15012;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_OpenCount Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_OpenCount = 15013;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Open_InputArguments Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_Open_InputArguments = 15016;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Open_OutputArguments Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_Open_OutputArguments = 15017;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Close_InputArguments Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_Close_InputArguments = 15019;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Read_InputArguments Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_Read_InputArguments = 15021;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Read_OutputArguments Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_Read_OutputArguments = 15022;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Write_InputArguments Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_Write_InputArguments = 15024;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_GetPosition_InputArguments Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = 15026;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = 15027;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_SetPosition_InputArguments Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = 15029;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_DefaultRolePermissions Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_DefaultRolePermissions = 15031;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_DefaultUserRolePermissions Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_DefaultUserRolePermissions = 15032;

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_DefaultAccessRestrictions Variable.
        /// </summary>
        public const uint FortissDeviceNamespaceMetadata_DefaultAccessRestrictions = 15033;

        /// <summary>
        /// The identifier for the SkillType_CurrentState_Id Variable.
        /// </summary>
        public const uint SkillType_CurrentState_Id = 15036;

        /// <summary>
        /// The identifier for the SkillType_CurrentState_Number Variable.
        /// </summary>
        public const uint SkillType_CurrentState_Number = 15038;

        /// <summary>
        /// The identifier for the SkillType_LastTransition_Id Variable.
        /// </summary>
        public const uint SkillType_LastTransition_Id = 15041;

        /// <summary>
        /// The identifier for the SkillType_LastTransition_Number Variable.
        /// </summary>
        public const uint SkillType_LastTransition_Number = 15043;

        /// <summary>
        /// The identifier for the SkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint SkillType_LastTransition_TransitionTime = 15044;

        /// <summary>
        /// The identifier for the SkillType_MaxInstanceCount Variable.
        /// </summary>
        public const uint SkillType_MaxInstanceCount = 15053;

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint SkillType_ProgramDiagnostic_CreateSessionId = 15056;

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint SkillType_ProgramDiagnostic_CreateClientName = 15057;

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint SkillType_ProgramDiagnostic_InvocationCreationTime = 15058;

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint SkillType_ProgramDiagnostic_LastTransitionTime = 15059;

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint SkillType_ProgramDiagnostic_LastMethodCall = 15060;

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint SkillType_ProgramDiagnostic_LastMethodSessionId = 15061;

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint SkillType_ProgramDiagnostic_LastMethodInputArguments = 15062;

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint SkillType_ProgramDiagnostic_LastMethodOutputArguments = 15063;

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint SkillType_ProgramDiagnostic_LastMethodInputValues = 15064;

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint SkillType_ProgramDiagnostic_LastMethodOutputValues = 15065;

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint SkillType_ProgramDiagnostic_LastMethodCallTime = 15066;

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint SkillType_ProgramDiagnostic_LastMethodReturnStatus = 15067;

        /// <summary>
        /// The identifier for the SkillType_Halted_StateNumber Variable.
        /// </summary>
        public const uint SkillType_Halted_StateNumber = 15070;

        /// <summary>
        /// The identifier for the SkillType_Ready_StateNumber Variable.
        /// </summary>
        public const uint SkillType_Ready_StateNumber = 15072;

        /// <summary>
        /// The identifier for the SkillType_Running_StateNumber Variable.
        /// </summary>
        public const uint SkillType_Running_StateNumber = 15074;

        /// <summary>
        /// The identifier for the SkillType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint SkillType_Suspended_StateNumber = 15076;

        /// <summary>
        /// The identifier for the SkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint SkillType_HaltedToReady_TransitionNumber = 15078;

        /// <summary>
        /// The identifier for the SkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint SkillType_ReadyToRunning_TransitionNumber = 15080;

        /// <summary>
        /// The identifier for the SkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint SkillType_RunningToHalted_TransitionNumber = 15082;

        /// <summary>
        /// The identifier for the SkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint SkillType_RunningToReady_TransitionNumber = 15084;

        /// <summary>
        /// The identifier for the SkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint SkillType_RunningToSuspended_TransitionNumber = 15086;

        /// <summary>
        /// The identifier for the SkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint SkillType_SuspendedToRunning_TransitionNumber = 15088;

        /// <summary>
        /// The identifier for the SkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint SkillType_SuspendedToHalted_TransitionNumber = 15090;

        /// <summary>
        /// The identifier for the SkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint SkillType_SuspendedToReady_TransitionNumber = 15092;

        /// <summary>
        /// The identifier for the SkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint SkillType_ReadyToHalted_TransitionNumber = 15094;

        /// <summary>
        /// The identifier for the SkillType_Name Variable.
        /// </summary>
        public const uint SkillType_Name = 15100;

        /// <summary>
        /// The identifier for the GripperSkillType_CurrentState_Id Variable.
        /// </summary>
        public const uint GripperSkillType_CurrentState_Id = 15103;

        /// <summary>
        /// The identifier for the GripperSkillType_CurrentState_Number Variable.
        /// </summary>
        public const uint GripperSkillType_CurrentState_Number = 15105;

        /// <summary>
        /// The identifier for the GripperSkillType_LastTransition_Id Variable.
        /// </summary>
        public const uint GripperSkillType_LastTransition_Id = 15108;

        /// <summary>
        /// The identifier for the GripperSkillType_LastTransition_Number Variable.
        /// </summary>
        public const uint GripperSkillType_LastTransition_Number = 15110;

        /// <summary>
        /// The identifier for the GripperSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint GripperSkillType_LastTransition_TransitionTime = 15111;

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint GripperSkillType_ProgramDiagnostic_CreateSessionId = 15123;

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint GripperSkillType_ProgramDiagnostic_CreateClientName = 15124;

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint GripperSkillType_ProgramDiagnostic_InvocationCreationTime = 15125;

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint GripperSkillType_ProgramDiagnostic_LastTransitionTime = 15126;

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint GripperSkillType_ProgramDiagnostic_LastMethodCall = 15127;

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint GripperSkillType_ProgramDiagnostic_LastMethodSessionId = 15128;

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint GripperSkillType_ProgramDiagnostic_LastMethodInputArguments = 15129;

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint GripperSkillType_ProgramDiagnostic_LastMethodOutputArguments = 15130;

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint GripperSkillType_ProgramDiagnostic_LastMethodInputValues = 15131;

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint GripperSkillType_ProgramDiagnostic_LastMethodOutputValues = 15132;

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint GripperSkillType_ProgramDiagnostic_LastMethodCallTime = 15133;

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint GripperSkillType_ProgramDiagnostic_LastMethodReturnStatus = 15134;

        /// <summary>
        /// The identifier for the GripperSkillType_Halted_StateNumber Variable.
        /// </summary>
        public const uint GripperSkillType_Halted_StateNumber = 15137;

        /// <summary>
        /// The identifier for the GripperSkillType_Ready_StateNumber Variable.
        /// </summary>
        public const uint GripperSkillType_Ready_StateNumber = 15139;

        /// <summary>
        /// The identifier for the GripperSkillType_Running_StateNumber Variable.
        /// </summary>
        public const uint GripperSkillType_Running_StateNumber = 15141;

        /// <summary>
        /// The identifier for the GripperSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint GripperSkillType_Suspended_StateNumber = 15143;

        /// <summary>
        /// The identifier for the GripperSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint GripperSkillType_HaltedToReady_TransitionNumber = 15145;

        /// <summary>
        /// The identifier for the GripperSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint GripperSkillType_ReadyToRunning_TransitionNumber = 15147;

        /// <summary>
        /// The identifier for the GripperSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint GripperSkillType_RunningToHalted_TransitionNumber = 15149;

        /// <summary>
        /// The identifier for the GripperSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint GripperSkillType_RunningToReady_TransitionNumber = 15151;

        /// <summary>
        /// The identifier for the GripperSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint GripperSkillType_RunningToSuspended_TransitionNumber = 15153;

        /// <summary>
        /// The identifier for the GripperSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint GripperSkillType_SuspendedToRunning_TransitionNumber = 15155;

        /// <summary>
        /// The identifier for the GripperSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint GripperSkillType_SuspendedToHalted_TransitionNumber = 15157;

        /// <summary>
        /// The identifier for the GripperSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint GripperSkillType_SuspendedToReady_TransitionNumber = 15159;

        /// <summary>
        /// The identifier for the GripperSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint GripperSkillType_ReadyToHalted_TransitionNumber = 15161;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_CurrentState_Id Variable.
        /// </summary>
        public const uint GraspGripperSkillType_CurrentState_Id = 15170;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_CurrentState_Number Variable.
        /// </summary>
        public const uint GraspGripperSkillType_CurrentState_Number = 15172;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_LastTransition_Id Variable.
        /// </summary>
        public const uint GraspGripperSkillType_LastTransition_Id = 15175;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_LastTransition_Number Variable.
        /// </summary>
        public const uint GraspGripperSkillType_LastTransition_Number = 15177;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint GraspGripperSkillType_LastTransition_TransitionTime = 15178;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ProgramDiagnostic_CreateSessionId = 15190;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ProgramDiagnostic_CreateClientName = 15191;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ProgramDiagnostic_InvocationCreationTime = 15192;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ProgramDiagnostic_LastTransitionTime = 15193;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ProgramDiagnostic_LastMethodCall = 15194;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ProgramDiagnostic_LastMethodSessionId = 15195;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ProgramDiagnostic_LastMethodInputArguments = 15196;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ProgramDiagnostic_LastMethodOutputArguments = 15197;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ProgramDiagnostic_LastMethodInputValues = 15198;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ProgramDiagnostic_LastMethodOutputValues = 15199;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ProgramDiagnostic_LastMethodCallTime = 15200;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ProgramDiagnostic_LastMethodReturnStatus = 15201;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_Halted_StateNumber Variable.
        /// </summary>
        public const uint GraspGripperSkillType_Halted_StateNumber = 15204;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_Ready_StateNumber Variable.
        /// </summary>
        public const uint GraspGripperSkillType_Ready_StateNumber = 15206;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_Running_StateNumber Variable.
        /// </summary>
        public const uint GraspGripperSkillType_Running_StateNumber = 15208;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint GraspGripperSkillType_Suspended_StateNumber = 15210;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint GraspGripperSkillType_HaltedToReady_TransitionNumber = 15212;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ReadyToRunning_TransitionNumber = 15214;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint GraspGripperSkillType_RunningToHalted_TransitionNumber = 15216;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint GraspGripperSkillType_RunningToReady_TransitionNumber = 15218;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint GraspGripperSkillType_RunningToSuspended_TransitionNumber = 15220;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint GraspGripperSkillType_SuspendedToRunning_TransitionNumber = 15222;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint GraspGripperSkillType_SuspendedToHalted_TransitionNumber = 15224;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint GraspGripperSkillType_SuspendedToReady_TransitionNumber = 15226;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ReadyToHalted_TransitionNumber = 15228;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ParameterSet_Force Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ParameterSet_Force = 15236;

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ParameterSet_Force_EURange Variable.
        /// </summary>
        public const uint GraspGripperSkillType_ParameterSet_Force_EURange = 15240;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_CurrentState_Id Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_CurrentState_Id = 15738;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_CurrentState_Number Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_CurrentState_Number = 15812;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_LastTransition_Id Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_LastTransition_Id = 15883;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_LastTransition_Number Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_LastTransition_Number = 15885;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_LastTransition_TransitionTime = 15886;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ProgramDiagnostic_CreateSessionId = 15898;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ProgramDiagnostic_CreateClientName = 15899;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ProgramDiagnostic_InvocationCreationTime = 15900;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ProgramDiagnostic_LastTransitionTime = 15901;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ProgramDiagnostic_LastMethodCall = 15902;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ProgramDiagnostic_LastMethodSessionId = 15903;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ProgramDiagnostic_LastMethodInputArguments = 15904;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ProgramDiagnostic_LastMethodOutputArguments = 15905;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ProgramDiagnostic_LastMethodInputValues = 15906;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ProgramDiagnostic_LastMethodOutputValues = 15907;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ProgramDiagnostic_LastMethodCallTime = 15908;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ProgramDiagnostic_LastMethodReturnStatus = 15909;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_Halted_StateNumber Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_Halted_StateNumber = 15912;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_Ready_StateNumber Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_Ready_StateNumber = 15914;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_Running_StateNumber Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_Running_StateNumber = 15916;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_Suspended_StateNumber = 15918;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_HaltedToReady_TransitionNumber = 15920;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ReadyToRunning_TransitionNumber = 15922;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_RunningToHalted_TransitionNumber = 15924;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_RunningToReady_TransitionNumber = 15926;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_RunningToSuspended_TransitionNumber = 15928;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_SuspendedToRunning_TransitionNumber = 15930;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_SuspendedToHalted_TransitionNumber = 15932;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_SuspendedToReady_TransitionNumber = 15934;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ReadyToHalted_TransitionNumber = 15936;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ParameterSet_Force Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ParameterSet_Force = 15944;

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ParameterSet_Force_EURange Variable.
        /// </summary>
        public const uint ReleaseGripperSkillType_ParameterSet_Force_EURange = 15948;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_CurrentState_Id Variable.
        /// </summary>
        public const uint MoveGripperSkillType_CurrentState_Id = 15952;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_CurrentState_Number Variable.
        /// </summary>
        public const uint MoveGripperSkillType_CurrentState_Number = 15954;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_LastTransition_Id Variable.
        /// </summary>
        public const uint MoveGripperSkillType_LastTransition_Id = 15957;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_LastTransition_Number Variable.
        /// </summary>
        public const uint MoveGripperSkillType_LastTransition_Number = 15959;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint MoveGripperSkillType_LastTransition_TransitionTime = 15960;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ProgramDiagnostic_CreateSessionId = 15972;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ProgramDiagnostic_CreateClientName = 15973;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ProgramDiagnostic_InvocationCreationTime = 15974;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ProgramDiagnostic_LastTransitionTime = 15975;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ProgramDiagnostic_LastMethodCall = 15976;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ProgramDiagnostic_LastMethodSessionId = 15977;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ProgramDiagnostic_LastMethodInputArguments = 15978;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ProgramDiagnostic_LastMethodOutputArguments = 15979;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ProgramDiagnostic_LastMethodInputValues = 15980;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ProgramDiagnostic_LastMethodOutputValues = 15981;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ProgramDiagnostic_LastMethodCallTime = 15982;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ProgramDiagnostic_LastMethodReturnStatus = 15983;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_Halted_StateNumber Variable.
        /// </summary>
        public const uint MoveGripperSkillType_Halted_StateNumber = 15986;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_Ready_StateNumber Variable.
        /// </summary>
        public const uint MoveGripperSkillType_Ready_StateNumber = 15988;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_Running_StateNumber Variable.
        /// </summary>
        public const uint MoveGripperSkillType_Running_StateNumber = 15990;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint MoveGripperSkillType_Suspended_StateNumber = 15992;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint MoveGripperSkillType_HaltedToReady_TransitionNumber = 15994;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ReadyToRunning_TransitionNumber = 15996;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint MoveGripperSkillType_RunningToHalted_TransitionNumber = 15998;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint MoveGripperSkillType_RunningToReady_TransitionNumber = 16000;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint MoveGripperSkillType_RunningToSuspended_TransitionNumber = 16002;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint MoveGripperSkillType_SuspendedToRunning_TransitionNumber = 16004;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint MoveGripperSkillType_SuspendedToHalted_TransitionNumber = 16006;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint MoveGripperSkillType_SuspendedToReady_TransitionNumber = 16008;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ReadyToHalted_TransitionNumber = 16010;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ParameterSet_Width Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ParameterSet_Width = 16018;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ParameterSet_Width_EURange Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ParameterSet_Width_EURange = 16022;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ParameterSet_Force Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ParameterSet_Force = 16024;

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ParameterSet_Force_EURange Variable.
        /// </summary>
        public const uint MoveGripperSkillType_ParameterSet_Force_EURange = 16028;

        /// <summary>
        /// The identifier for the ISkillControllerType_Name Variable.
        /// </summary>
        public const uint ISkillControllerType_Name = 15397;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__CurrentState Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__CurrentState = 15400;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__CurrentState_Id Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__CurrentState_Id = 15401;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__CurrentState_Number Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__CurrentState_Number = 15403;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__LastTransition Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__LastTransition = 15405;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__LastTransition_Id Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__LastTransition_Id = 15406;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__LastTransition_Number Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__LastTransition_Number = 15408;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__LastTransition_TransitionTime = 15409;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__Deletable Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__Deletable = 15413;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__AutoDelete Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__AutoDelete = 15414;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__RecycleCount Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__RecycleCount = 15415;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_CreateSessionId = 15417;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_CreateClientName = 15418;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_InvocationCreationTime = 15419;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastTransitionTime = 15420;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodCall = 15421;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodSessionId = 15422;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodInputArguments = 15423;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodOutputArguments = 15424;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodInputValues = 15425;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodOutputValues = 15426;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodCallTime = 15427;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodReturnStatus = 15428;

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__MaxInstanceCount Variable.
        /// </summary>
        public const uint ISkillControllerType_Skills_Skill__No__MaxInstanceCount = 15431;

        /// <summary>
        /// The identifier for the IPowerOffDeviceType_PowerOffDevice_InputArguments Variable.
        /// </summary>
        public const uint IPowerOffDeviceType_PowerOffDevice_InputArguments = 15249;

        /// <summary>
        /// The identifier for the GripTypeEnumeration_EnumStrings Variable.
        /// </summary>
        public const uint GripTypeEnumeration_EnumStrings = 15253;

        /// <summary>
        /// The identifier for the GripPoint_Type Variable.
        /// </summary>
        public const uint GripPoint_Type = 15255;

        /// <summary>
        /// The identifier for the GripPoint_Offset Variable.
        /// </summary>
        public const uint GripPoint_Offset = 15256;

        /// <summary>
        /// The identifier for the GripPoint_Offset_CartesianCoordinates Variable.
        /// </summary>
        public const uint GripPoint_Offset_CartesianCoordinates = 15257;

        /// <summary>
        /// The identifier for the GripPoint_Offset_Orientation Variable.
        /// </summary>
        public const uint GripPoint_Offset_Orientation = 15259;

        /// <summary>
        /// The identifier for the GripPoint_Offset_CartesianCoordinates_X Variable.
        /// </summary>
        public const uint GripPoint_Offset_CartesianCoordinates_X = 15264;

        /// <summary>
        /// The identifier for the GripPoint_Offset_CartesianCoordinates_Y Variable.
        /// </summary>
        public const uint GripPoint_Offset_CartesianCoordinates_Y = 15265;

        /// <summary>
        /// The identifier for the GripPoint_Offset_CartesianCoordinates_Z Variable.
        /// </summary>
        public const uint GripPoint_Offset_CartesianCoordinates_Z = 15266;

        /// <summary>
        /// The identifier for the GripPoint_Offset_Orientation_A Variable.
        /// </summary>
        public const uint GripPoint_Offset_Orientation_A = 15267;

        /// <summary>
        /// The identifier for the GripPoint_Offset_Orientation_B Variable.
        /// </summary>
        public const uint GripPoint_Offset_Orientation_B = 15268;

        /// <summary>
        /// The identifier for the GripPoint_Offset_Orientation_C Variable.
        /// </summary>
        public const uint GripPoint_Offset_Orientation_C = 15269;

        /// <summary>
        /// The identifier for the VacuumGripPoint_Type Variable.
        /// </summary>
        public const uint VacuumGripPoint_Type = 15271;

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_CartesianCoordinates Variable.
        /// </summary>
        public const uint VacuumGripPoint_Offset_CartesianCoordinates = 15273;

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_Orientation Variable.
        /// </summary>
        public const uint VacuumGripPoint_Offset_Orientation = 15275;

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_CartesianCoordinates_X Variable.
        /// </summary>
        public const uint VacuumGripPoint_Offset_CartesianCoordinates_X = 15280;

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_CartesianCoordinates_Y Variable.
        /// </summary>
        public const uint VacuumGripPoint_Offset_CartesianCoordinates_Y = 15281;

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_CartesianCoordinates_Z Variable.
        /// </summary>
        public const uint VacuumGripPoint_Offset_CartesianCoordinates_Z = 15282;

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_Orientation_A Variable.
        /// </summary>
        public const uint VacuumGripPoint_Offset_Orientation_A = 15283;

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_Orientation_B Variable.
        /// </summary>
        public const uint VacuumGripPoint_Offset_Orientation_B = 15284;

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_Orientation_C Variable.
        /// </summary>
        public const uint VacuumGripPoint_Offset_Orientation_C = 15285;

        /// <summary>
        /// The identifier for the ParallelGripPoint_Type Variable.
        /// </summary>
        public const uint ParallelGripPoint_Type = 15287;

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_CartesianCoordinates Variable.
        /// </summary>
        public const uint ParallelGripPoint_Offset_CartesianCoordinates = 15289;

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_Orientation Variable.
        /// </summary>
        public const uint ParallelGripPoint_Offset_Orientation = 15291;

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_CartesianCoordinates_X Variable.
        /// </summary>
        public const uint ParallelGripPoint_Offset_CartesianCoordinates_X = 15296;

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_CartesianCoordinates_Y Variable.
        /// </summary>
        public const uint ParallelGripPoint_Offset_CartesianCoordinates_Y = 15297;

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_CartesianCoordinates_Z Variable.
        /// </summary>
        public const uint ParallelGripPoint_Offset_CartesianCoordinates_Z = 15298;

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_Orientation_A Variable.
        /// </summary>
        public const uint ParallelGripPoint_Offset_Orientation_A = 15299;

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_Orientation_B Variable.
        /// </summary>
        public const uint ParallelGripPoint_Offset_Orientation_B = 15300;

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_Orientation_C Variable.
        /// </summary>
        public const uint ParallelGripPoint_Offset_Orientation_C = 15301;

        /// <summary>
        /// The identifier for the ParallelGripPoint_Range Variable.
        /// </summary>
        public const uint ParallelGripPoint_Range = 15302;

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Type Variable.
        /// </summary>
        public const uint IGripperType_GripPoints_GripPoint__No__Type = 15306;

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset Variable.
        /// </summary>
        public const uint IGripperType_GripPoints_GripPoint__No__Offset = 15307;

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates Variable.
        /// </summary>
        public const uint IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates = 15308;

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_Orientation Variable.
        /// </summary>
        public const uint IGripperType_GripPoints_GripPoint__No__Offset_Orientation = 15310;

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates_X Variable.
        /// </summary>
        public const uint IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates_X = 15315;

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates_Y Variable.
        /// </summary>
        public const uint IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates_Y = 15316;

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates_Z Variable.
        /// </summary>
        public const uint IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates_Z = 15317;

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_Orientation_A Variable.
        /// </summary>
        public const uint IGripperType_GripPoints_GripPoint__No__Offset_Orientation_A = 15318;

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_Orientation_B Variable.
        /// </summary>
        public const uint IGripperType_GripPoints_GripPoint__No__Offset_Orientation_B = 15319;

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_Orientation_C Variable.
        /// </summary>
        public const uint IGripperType_GripPoints_GripPoint__No__Offset_Orientation_C = 15320;

        /// <summary>
        /// The identifier for the SensorType_Lock_Locked Variable.
        /// </summary>
        public const uint SensorType_Lock_Locked = 15873;

        /// <summary>
        /// The identifier for the SensorType_Lock_LockingClient Variable.
        /// </summary>
        public const uint SensorType_Lock_LockingClient = 15703;

        /// <summary>
        /// The identifier for the SensorType_Lock_LockingUser Variable.
        /// </summary>
        public const uint SensorType_Lock_LockingUser = 15704;

        /// <summary>
        /// The identifier for the SensorType_Lock_RemainingLockTime Variable.
        /// </summary>
        public const uint SensorType_Lock_RemainingLockTime = 15705;

        /// <summary>
        /// The identifier for the SensorType_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public const uint SensorType_Lock_InitLock_InputArguments = 15707;

        /// <summary>
        /// The identifier for the SensorType_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public const uint SensorType_Lock_InitLock_OutputArguments = 15708;

        /// <summary>
        /// The identifier for the SensorType_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public const uint SensorType_Lock_RenewLock_OutputArguments = 15710;

        /// <summary>
        /// The identifier for the SensorType_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public const uint SensorType_Lock_ExitLock_OutputArguments = 15712;

        /// <summary>
        /// The identifier for the SensorType_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public const uint SensorType_Lock_BreakLock_OutputArguments = 15714;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_Locked Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_Lock_Locked = 15875;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_LockingClient Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_Lock_LockingClient = 15739;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_LockingUser Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_Lock_LockingUser = 15740;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_RemainingLockTime Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_Lock_RemainingLockTime = 15741;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_Lock_InitLock_InputArguments = 15743;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_Lock_InitLock_OutputArguments = 15744;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_Lock_RenewLock_OutputArguments = 15746;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_Lock_ExitLock_OutputArguments = 15748;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_Lock_BreakLock_OutputArguments = 15750;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_Locked Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor_Lock_Locked = 15877;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_LockingClient Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor_Lock_LockingClient = 15773;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_LockingUser Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor_Lock_LockingUser = 15774;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_RemainingLockTime Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor_Lock_RemainingLockTime = 15775;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor_Lock_InitLock_InputArguments = 15777;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor_Lock_InitLock_OutputArguments = 15778;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor_Lock_RenewLock_OutputArguments = 15780;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor_Lock_ExitLock_OutputArguments = 15782;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor_Lock_BreakLock_OutputArguments = 15784;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Force Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor_Force = 15798;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Force_EURange Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_ForceSensor_Force_EURange = 15802;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_Locked Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor_Lock_Locked = 15879;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_LockingClient Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor_Lock_LockingClient = 15813;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_LockingUser Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor_Lock_LockingUser = 15814;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_RemainingLockTime Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor_Lock_RemainingLockTime = 15815;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor_Lock_InitLock_InputArguments = 15817;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor_Lock_InitLock_OutputArguments = 15818;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor_Lock_RenewLock_OutputArguments = 15820;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor_Lock_ExitLock_OutputArguments = 15822;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor_Lock_BreakLock_OutputArguments = 15824;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Torque Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor_Torque = 15838;

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Torque_EURange Variable.
        /// </summary>
        public const uint ForceTorqueSensorType_TorqueSensor_Torque_EURange = 15842;

        /// <summary>
        /// The identifier for the SkillTransitionEventType_Transition_Id Variable.
        /// </summary>
        public const uint SkillTransitionEventType_Transition_Id = 15855;

        /// <summary>
        /// The identifier for the SkillTransitionEventType_FromState_Id Variable.
        /// </summary>
        public const uint SkillTransitionEventType_FromState_Id = 15861;

        /// <summary>
        /// The identifier for the SkillTransitionEventType_ToState_Id Variable.
        /// </summary>
        public const uint SkillTransitionEventType_ToState_Id = 15866;

        /// <summary>
        /// The identifier for the fortissDevice_BinarySchema Variable.
        /// </summary>
        public const uint fortissDevice_BinarySchema = 15321;

        /// <summary>
        /// The identifier for the fortissDevice_BinarySchema_NamespaceUri Variable.
        /// </summary>
        public const uint fortissDevice_BinarySchema_NamespaceUri = 15323;

        /// <summary>
        /// The identifier for the fortissDevice_BinarySchema_Deprecated Variable.
        /// </summary>
        public const uint fortissDevice_BinarySchema_Deprecated = 15324;

        /// <summary>
        /// The identifier for the fortissDevice_XmlSchema Variable.
        /// </summary>
        public const uint fortissDevice_XmlSchema = 15325;

        /// <summary>
        /// The identifier for the fortissDevice_XmlSchema_NamespaceUri Variable.
        /// </summary>
        public const uint fortissDevice_XmlSchema_NamespaceUri = 15327;

        /// <summary>
        /// The identifier for the fortissDevice_XmlSchema_Deprecated Variable.
        /// </summary>
        public const uint fortissDevice_XmlSchema_Deprecated = 15328;
    }
    #endregion

    #region DataType Node Identifiers
    /// <summary>
    /// A class that declares constants for all DataTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypeIds
    {
        /// <summary>
        /// The identifier for the GripTypeEnumeration DataType.
        /// </summary>
        public static readonly ExpandedNodeId GripTypeEnumeration = new ExpandedNodeId(fortiss_Device.DataTypes.GripTypeEnumeration, fortiss_Device.Namespaces.fortissDevice);
    }
    #endregion

    #region Method Node Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class MethodIds
    {
        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Open Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_Open = new ExpandedNodeId(fortiss_Device.Methods.FortissDeviceNamespaceMetadata_NamespaceFile_Open, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Close Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_Close = new ExpandedNodeId(fortiss_Device.Methods.FortissDeviceNamespaceMetadata_NamespaceFile_Close, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Read Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_Read = new ExpandedNodeId(fortiss_Device.Methods.FortissDeviceNamespaceMetadata_NamespaceFile_Read, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Write Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_Write = new ExpandedNodeId(fortiss_Device.Methods.FortissDeviceNamespaceMetadata_NamespaceFile_Write, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_GetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_GetPosition = new ExpandedNodeId(fortiss_Device.Methods.FortissDeviceNamespaceMetadata_NamespaceFile_GetPosition, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_SetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_SetPosition = new ExpandedNodeId(fortiss_Device.Methods.FortissDeviceNamespaceMetadata_NamespaceFile_SetPosition, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_Start Method.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_Start = new ExpandedNodeId(fortiss_Device.Methods.SkillType_Start, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_Suspend Method.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_Suspend = new ExpandedNodeId(fortiss_Device.Methods.SkillType_Suspend, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_Resume Method.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_Resume = new ExpandedNodeId(fortiss_Device.Methods.SkillType_Resume, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_Halt Method.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_Halt = new ExpandedNodeId(fortiss_Device.Methods.SkillType_Halt, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_Reset Method.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_Reset = new ExpandedNodeId(fortiss_Device.Methods.SkillType_Reset, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__Halt Method.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__Halt = new ExpandedNodeId(fortiss_Device.Methods.ISkillControllerType_Skills_Skill__No__Halt, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__Reset Method.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__Reset = new ExpandedNodeId(fortiss_Device.Methods.ISkillControllerType_Skills_Skill__No__Reset, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__Resume Method.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__Resume = new ExpandedNodeId(fortiss_Device.Methods.ISkillControllerType_Skills_Skill__No__Resume, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__Suspend Method.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__Suspend = new ExpandedNodeId(fortiss_Device.Methods.ISkillControllerType_Skills_Skill__No__Suspend, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__Start Method.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__Start = new ExpandedNodeId(fortiss_Device.Methods.ISkillControllerType_Skills_Skill__No__Start, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IPowerOffDeviceType_PowerOffDevice Method.
        /// </summary>
        public static readonly ExpandedNodeId IPowerOffDeviceType_PowerOffDevice = new ExpandedNodeId(fortiss_Device.Methods.IPowerOffDeviceType_PowerOffDevice, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SensorType_Lock_InitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId SensorType_Lock_InitLock = new ExpandedNodeId(fortiss_Device.Methods.SensorType_Lock_InitLock, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SensorType_Lock_RenewLock Method.
        /// </summary>
        public static readonly ExpandedNodeId SensorType_Lock_RenewLock = new ExpandedNodeId(fortiss_Device.Methods.SensorType_Lock_RenewLock, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SensorType_Lock_ExitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId SensorType_Lock_ExitLock = new ExpandedNodeId(fortiss_Device.Methods.SensorType_Lock_ExitLock, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SensorType_Lock_BreakLock Method.
        /// </summary>
        public static readonly ExpandedNodeId SensorType_Lock_BreakLock = new ExpandedNodeId(fortiss_Device.Methods.SensorType_Lock_BreakLock, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_InitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_Lock_InitLock = new ExpandedNodeId(fortiss_Device.Methods.ForceTorqueSensorType_Lock_InitLock, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_RenewLock Method.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_Lock_RenewLock = new ExpandedNodeId(fortiss_Device.Methods.ForceTorqueSensorType_Lock_RenewLock, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_ExitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_Lock_ExitLock = new ExpandedNodeId(fortiss_Device.Methods.ForceTorqueSensorType_Lock_ExitLock, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_BreakLock Method.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_Lock_BreakLock = new ExpandedNodeId(fortiss_Device.Methods.ForceTorqueSensorType_Lock_BreakLock, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_InitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor_Lock_InitLock = new ExpandedNodeId(fortiss_Device.Methods.ForceTorqueSensorType_ForceSensor_Lock_InitLock, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_RenewLock Method.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor_Lock_RenewLock = new ExpandedNodeId(fortiss_Device.Methods.ForceTorqueSensorType_ForceSensor_Lock_RenewLock, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_ExitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor_Lock_ExitLock = new ExpandedNodeId(fortiss_Device.Methods.ForceTorqueSensorType_ForceSensor_Lock_ExitLock, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_BreakLock Method.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor_Lock_BreakLock = new ExpandedNodeId(fortiss_Device.Methods.ForceTorqueSensorType_ForceSensor_Lock_BreakLock, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_InitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor_Lock_InitLock = new ExpandedNodeId(fortiss_Device.Methods.ForceTorqueSensorType_TorqueSensor_Lock_InitLock, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_RenewLock Method.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor_Lock_RenewLock = new ExpandedNodeId(fortiss_Device.Methods.ForceTorqueSensorType_TorqueSensor_Lock_RenewLock, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_ExitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor_Lock_ExitLock = new ExpandedNodeId(fortiss_Device.Methods.ForceTorqueSensorType_TorqueSensor_Lock_ExitLock, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_BreakLock Method.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor_Lock_BreakLock = new ExpandedNodeId(fortiss_Device.Methods.ForceTorqueSensorType_TorqueSensor_Lock_BreakLock, fortiss_Device.Namespaces.fortissDevice);
    }
    #endregion

    #region Object Node Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata Object.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata = new ExpandedNodeId(fortiss_Device.Objects.FortissDeviceNamespaceMetadata, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_FinalResultData Object.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_FinalResultData = new ExpandedNodeId(fortiss_Device.Objects.SkillType_FinalResultData, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ParameterSet Object.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ParameterSet = new ExpandedNodeId(fortiss_Device.Objects.GraspGripperSkillType_ParameterSet, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ParameterSet Object.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ParameterSet = new ExpandedNodeId(fortiss_Device.Objects.ReleaseGripperSkillType_ParameterSet, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ParameterSet Object.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ParameterSet = new ExpandedNodeId(fortiss_Device.Objects.MoveGripperSkillType_ParameterSet, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills Object.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills = new ExpandedNodeId(fortiss_Device.Objects.ISkillControllerType_Skills, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No_ Object.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No_ = new ExpandedNodeId(fortiss_Device.Objects.ISkillControllerType_Skills_Skill__No_, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IGripperType_GripPoints Object.
        /// </summary>
        public static readonly ExpandedNodeId IGripperType_GripPoints = new ExpandedNodeId(fortiss_Device.Objects.IGripperType_GripPoints, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No_ Object.
        /// </summary>
        public static readonly ExpandedNodeId IGripperType_GripPoints_GripPoint__No_ = new ExpandedNodeId(fortiss_Device.Objects.IGripperType_GripPoints_GripPoint__No_, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor Object.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor = new ExpandedNodeId(fortiss_Device.Objects.ForceTorqueSensorType_ForceSensor, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor Object.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor = new ExpandedNodeId(fortiss_Device.Objects.ForceTorqueSensorType_TorqueSensor, fortiss_Device.Namespaces.fortissDevice);
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <summary>
        /// The identifier for the SkillType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId SkillType = new ExpandedNodeId(fortiss_Device.ObjectTypes.SkillType, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType = new ExpandedNodeId(fortiss_Device.ObjectTypes.GripperSkillType, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType = new ExpandedNodeId(fortiss_Device.ObjectTypes.GraspGripperSkillType, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType = new ExpandedNodeId(fortiss_Device.ObjectTypes.ReleaseGripperSkillType, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType = new ExpandedNodeId(fortiss_Device.ObjectTypes.MoveGripperSkillType, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType = new ExpandedNodeId(fortiss_Device.ObjectTypes.ISkillControllerType, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IPowerOffDeviceType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId IPowerOffDeviceType = new ExpandedNodeId(fortiss_Device.ObjectTypes.IPowerOffDeviceType, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripPoint ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId GripPoint = new ExpandedNodeId(fortiss_Device.ObjectTypes.GripPoint, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the VacuumGripPoint ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId VacuumGripPoint = new ExpandedNodeId(fortiss_Device.ObjectTypes.VacuumGripPoint, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ParallelGripPoint ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId ParallelGripPoint = new ExpandedNodeId(fortiss_Device.ObjectTypes.ParallelGripPoint, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IGripperType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId IGripperType = new ExpandedNodeId(fortiss_Device.ObjectTypes.IGripperType, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SensorType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId SensorType = new ExpandedNodeId(fortiss_Device.ObjectTypes.SensorType, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType = new ExpandedNodeId(fortiss_Device.ObjectTypes.ForceTorqueSensorType, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillTransitionEventType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId SkillTransitionEventType = new ExpandedNodeId(fortiss_Device.ObjectTypes.SkillTransitionEventType, fortiss_Device.Namespaces.fortissDevice);
    }
    #endregion

    #region Variable Node Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceUri = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespaceUri, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceVersion Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceVersion = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespaceVersion, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespacePublicationDate Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespacePublicationDate = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespacePublicationDate, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_IsNamespaceSubset Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_IsNamespaceSubset = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_IsNamespaceSubset, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_StaticNodeIdTypes Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_StaticNodeIdTypes = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_StaticNodeIdTypes, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_StaticNumericNodeIdRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_StaticNumericNodeIdRange = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_StaticNumericNodeIdRange, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_StaticStringNodeIdPattern Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_StaticStringNodeIdPattern = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_StaticStringNodeIdPattern, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Size Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_Size = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespaceFile_Size, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Writable Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_Writable = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespaceFile_Writable, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_UserWritable Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_UserWritable = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespaceFile_UserWritable, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_OpenCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_OpenCount = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespaceFile_OpenCount, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Open_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_Open_InputArguments = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespaceFile_Open_InputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Open_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_Open_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespaceFile_Open_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Close_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_Close_InputArguments = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespaceFile_Close_InputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Read_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_Read_InputArguments = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespaceFile_Read_InputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Read_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_Read_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespaceFile_Read_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_Write_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_Write_InputArguments = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespaceFile_Write_InputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_GetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespaceFile_GetPosition_InputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_NamespaceFile_SetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_NamespaceFile_SetPosition_InputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_DefaultRolePermissions Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_DefaultRolePermissions = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_DefaultRolePermissions, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_DefaultUserRolePermissions Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_DefaultUserRolePermissions = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_DefaultUserRolePermissions, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the FortissDeviceNamespaceMetadata_DefaultAccessRestrictions Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissDeviceNamespaceMetadata_DefaultAccessRestrictions = new ExpandedNodeId(fortiss_Device.Variables.FortissDeviceNamespaceMetadata_DefaultAccessRestrictions, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_CurrentState_Id = new ExpandedNodeId(fortiss_Device.Variables.SkillType_CurrentState_Id, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_CurrentState_Number = new ExpandedNodeId(fortiss_Device.Variables.SkillType_CurrentState_Number, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_LastTransition_Id = new ExpandedNodeId(fortiss_Device.Variables.SkillType_LastTransition_Id, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_LastTransition_Number = new ExpandedNodeId(fortiss_Device.Variables.SkillType_LastTransition_Number, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Device.Variables.SkillType_LastTransition_TransitionTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_MaxInstanceCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_MaxInstanceCount = new ExpandedNodeId(fortiss_Device.Variables.SkillType_MaxInstanceCount, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Device.Variables.SkillType_ProgramDiagnostic_CreateSessionId, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Device.Variables.SkillType_ProgramDiagnostic_CreateClientName, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Device.Variables.SkillType_ProgramDiagnostic_InvocationCreationTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Device.Variables.SkillType_ProgramDiagnostic_LastTransitionTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Device.Variables.SkillType_ProgramDiagnostic_LastMethodCall, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Device.Variables.SkillType_ProgramDiagnostic_LastMethodSessionId, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Device.Variables.SkillType_ProgramDiagnostic_LastMethodInputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Device.Variables.SkillType_ProgramDiagnostic_LastMethodOutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Device.Variables.SkillType_ProgramDiagnostic_LastMethodInputValues, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Device.Variables.SkillType_ProgramDiagnostic_LastMethodOutputValues, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Device.Variables.SkillType_ProgramDiagnostic_LastMethodCallTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Device.Variables.SkillType_ProgramDiagnostic_LastMethodReturnStatus, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_Halted_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.SkillType_Halted_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_Ready_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.SkillType_Ready_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_Running_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.SkillType_Running_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_Suspended_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.SkillType_Suspended_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_HaltedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.SkillType_HaltedToReady_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.SkillType_ReadyToRunning_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_RunningToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.SkillType_RunningToHalted_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_RunningToReady_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.SkillType_RunningToReady_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.SkillType_RunningToSuspended_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.SkillType_SuspendedToRunning_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.SkillType_SuspendedToHalted_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.SkillType_SuspendedToReady_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.SkillType_ReadyToHalted_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillType_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillType_Name = new ExpandedNodeId(fortiss_Device.Variables.SkillType_Name, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_CurrentState_Id = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_CurrentState_Id, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_CurrentState_Number = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_CurrentState_Number, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_LastTransition_Id = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_LastTransition_Id, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_LastTransition_Number = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_LastTransition_Number, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_LastTransition_TransitionTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_ProgramDiagnostic_CreateSessionId, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_ProgramDiagnostic_CreateClientName, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_ProgramDiagnostic_InvocationCreationTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_ProgramDiagnostic_LastTransitionTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_ProgramDiagnostic_LastMethodCall, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_ProgramDiagnostic_LastMethodSessionId, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_ProgramDiagnostic_LastMethodInputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_ProgramDiagnostic_LastMethodOutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_ProgramDiagnostic_LastMethodInputValues, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_ProgramDiagnostic_LastMethodOutputValues, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_ProgramDiagnostic_LastMethodCallTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_ProgramDiagnostic_LastMethodReturnStatus, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_Halted_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_Halted_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_Ready_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_Ready_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_Running_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_Running_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_Suspended_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_Suspended_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_HaltedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_HaltedToReady_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_ReadyToRunning_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_RunningToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_RunningToHalted_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_RunningToReady_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_RunningToReady_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_RunningToSuspended_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_SuspendedToRunning_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_SuspendedToHalted_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_SuspendedToReady_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripperSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripperSkillType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GripperSkillType_ReadyToHalted_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_CurrentState_Id = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_CurrentState_Id, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_CurrentState_Number = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_CurrentState_Number, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_LastTransition_Id = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_LastTransition_Id, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_LastTransition_Number = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_LastTransition_Number, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_LastTransition_TransitionTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ProgramDiagnostic_CreateSessionId, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ProgramDiagnostic_CreateClientName, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ProgramDiagnostic_InvocationCreationTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ProgramDiagnostic_LastTransitionTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ProgramDiagnostic_LastMethodCall, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ProgramDiagnostic_LastMethodSessionId, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ProgramDiagnostic_LastMethodInputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ProgramDiagnostic_LastMethodOutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ProgramDiagnostic_LastMethodInputValues, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ProgramDiagnostic_LastMethodOutputValues, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ProgramDiagnostic_LastMethodCallTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ProgramDiagnostic_LastMethodReturnStatus, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_Halted_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_Halted_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_Ready_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_Ready_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_Running_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_Running_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_Suspended_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_Suspended_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_HaltedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_HaltedToReady_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ReadyToRunning_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_RunningToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_RunningToHalted_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_RunningToReady_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_RunningToReady_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_RunningToSuspended_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_SuspendedToRunning_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_SuspendedToHalted_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_SuspendedToReady_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ReadyToHalted_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ParameterSet_Force Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ParameterSet_Force = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ParameterSet_Force, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GraspGripperSkillType_ParameterSet_Force_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId GraspGripperSkillType_ParameterSet_Force_EURange = new ExpandedNodeId(fortiss_Device.Variables.GraspGripperSkillType_ParameterSet_Force_EURange, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_CurrentState_Id = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_CurrentState_Id, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_CurrentState_Number = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_CurrentState_Number, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_LastTransition_Id = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_LastTransition_Id, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_LastTransition_Number = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_LastTransition_Number, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_LastTransition_TransitionTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ProgramDiagnostic_CreateSessionId, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ProgramDiagnostic_CreateClientName, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ProgramDiagnostic_InvocationCreationTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ProgramDiagnostic_LastTransitionTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ProgramDiagnostic_LastMethodCall, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ProgramDiagnostic_LastMethodSessionId, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ProgramDiagnostic_LastMethodInputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ProgramDiagnostic_LastMethodOutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ProgramDiagnostic_LastMethodInputValues, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ProgramDiagnostic_LastMethodOutputValues, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ProgramDiagnostic_LastMethodCallTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ProgramDiagnostic_LastMethodReturnStatus, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_Halted_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_Halted_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_Ready_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_Ready_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_Running_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_Running_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_Suspended_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_Suspended_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_HaltedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_HaltedToReady_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ReadyToRunning_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_RunningToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_RunningToHalted_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_RunningToReady_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_RunningToReady_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_RunningToSuspended_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_SuspendedToRunning_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_SuspendedToHalted_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_SuspendedToReady_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ReadyToHalted_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ParameterSet_Force Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ParameterSet_Force = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ParameterSet_Force, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ReleaseGripperSkillType_ParameterSet_Force_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId ReleaseGripperSkillType_ParameterSet_Force_EURange = new ExpandedNodeId(fortiss_Device.Variables.ReleaseGripperSkillType_ParameterSet_Force_EURange, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_CurrentState_Id = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_CurrentState_Id, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_CurrentState_Number = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_CurrentState_Number, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_LastTransition_Id = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_LastTransition_Id, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_LastTransition_Number = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_LastTransition_Number, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_LastTransition_TransitionTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ProgramDiagnostic_CreateSessionId, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ProgramDiagnostic_CreateClientName, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ProgramDiagnostic_InvocationCreationTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ProgramDiagnostic_LastTransitionTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ProgramDiagnostic_LastMethodCall, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ProgramDiagnostic_LastMethodSessionId, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ProgramDiagnostic_LastMethodInputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ProgramDiagnostic_LastMethodOutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ProgramDiagnostic_LastMethodInputValues, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ProgramDiagnostic_LastMethodOutputValues, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ProgramDiagnostic_LastMethodCallTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ProgramDiagnostic_LastMethodReturnStatus, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_Halted_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_Halted_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_Ready_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_Ready_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_Running_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_Running_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_Suspended_StateNumber = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_Suspended_StateNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_HaltedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_HaltedToReady_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ReadyToRunning_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_RunningToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_RunningToHalted_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_RunningToReady_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_RunningToReady_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_RunningToSuspended_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_SuspendedToRunning_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_SuspendedToHalted_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_SuspendedToReady_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ReadyToHalted_TransitionNumber, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ParameterSet_Width Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ParameterSet_Width = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ParameterSet_Width, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ParameterSet_Width_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ParameterSet_Width_EURange = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ParameterSet_Width_EURange, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ParameterSet_Force Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ParameterSet_Force = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ParameterSet_Force, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the MoveGripperSkillType_ParameterSet_Force_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveGripperSkillType_ParameterSet_Force_EURange = new ExpandedNodeId(fortiss_Device.Variables.MoveGripperSkillType_ParameterSet_Force_EURange, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Name = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Name, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__CurrentState Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__CurrentState = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__CurrentState, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__CurrentState_Id = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__CurrentState_Id, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__CurrentState_Number = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__CurrentState_Number, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__LastTransition Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__LastTransition = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__LastTransition, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__LastTransition_Id = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__LastTransition_Id, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__LastTransition_Number = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__LastTransition_Number, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__LastTransition_TransitionTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__Deletable Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__Deletable = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__Deletable, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__AutoDelete Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__AutoDelete = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__AutoDelete, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__RecycleCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__RecycleCount = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__RecycleCount, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_CreateSessionId, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_CreateClientName, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_InvocationCreationTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastTransitionTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodCall, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodSessionId, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodInputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodOutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodInputValues, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodOutputValues, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodCallTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__ProgramDiagnostic_LastMethodReturnStatus, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ISkillControllerType_Skills_Skill__No__MaxInstanceCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId ISkillControllerType_Skills_Skill__No__MaxInstanceCount = new ExpandedNodeId(fortiss_Device.Variables.ISkillControllerType_Skills_Skill__No__MaxInstanceCount, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IPowerOffDeviceType_PowerOffDevice_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId IPowerOffDeviceType_PowerOffDevice_InputArguments = new ExpandedNodeId(fortiss_Device.Variables.IPowerOffDeviceType_PowerOffDevice_InputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripTypeEnumeration_EnumStrings Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripTypeEnumeration_EnumStrings = new ExpandedNodeId(fortiss_Device.Variables.GripTypeEnumeration_EnumStrings, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripPoint_Type Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripPoint_Type = new ExpandedNodeId(fortiss_Device.Variables.GripPoint_Type, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripPoint_Offset Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripPoint_Offset = new ExpandedNodeId(fortiss_Device.Variables.GripPoint_Offset, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripPoint_Offset_CartesianCoordinates Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripPoint_Offset_CartesianCoordinates = new ExpandedNodeId(fortiss_Device.Variables.GripPoint_Offset_CartesianCoordinates, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripPoint_Offset_Orientation Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripPoint_Offset_Orientation = new ExpandedNodeId(fortiss_Device.Variables.GripPoint_Offset_Orientation, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripPoint_Offset_CartesianCoordinates_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripPoint_Offset_CartesianCoordinates_X = new ExpandedNodeId(fortiss_Device.Variables.GripPoint_Offset_CartesianCoordinates_X, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripPoint_Offset_CartesianCoordinates_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripPoint_Offset_CartesianCoordinates_Y = new ExpandedNodeId(fortiss_Device.Variables.GripPoint_Offset_CartesianCoordinates_Y, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripPoint_Offset_CartesianCoordinates_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripPoint_Offset_CartesianCoordinates_Z = new ExpandedNodeId(fortiss_Device.Variables.GripPoint_Offset_CartesianCoordinates_Z, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripPoint_Offset_Orientation_A Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripPoint_Offset_Orientation_A = new ExpandedNodeId(fortiss_Device.Variables.GripPoint_Offset_Orientation_A, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripPoint_Offset_Orientation_B Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripPoint_Offset_Orientation_B = new ExpandedNodeId(fortiss_Device.Variables.GripPoint_Offset_Orientation_B, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the GripPoint_Offset_Orientation_C Variable.
        /// </summary>
        public static readonly ExpandedNodeId GripPoint_Offset_Orientation_C = new ExpandedNodeId(fortiss_Device.Variables.GripPoint_Offset_Orientation_C, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the VacuumGripPoint_Type Variable.
        /// </summary>
        public static readonly ExpandedNodeId VacuumGripPoint_Type = new ExpandedNodeId(fortiss_Device.Variables.VacuumGripPoint_Type, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_CartesianCoordinates Variable.
        /// </summary>
        public static readonly ExpandedNodeId VacuumGripPoint_Offset_CartesianCoordinates = new ExpandedNodeId(fortiss_Device.Variables.VacuumGripPoint_Offset_CartesianCoordinates, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_Orientation Variable.
        /// </summary>
        public static readonly ExpandedNodeId VacuumGripPoint_Offset_Orientation = new ExpandedNodeId(fortiss_Device.Variables.VacuumGripPoint_Offset_Orientation, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_CartesianCoordinates_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId VacuumGripPoint_Offset_CartesianCoordinates_X = new ExpandedNodeId(fortiss_Device.Variables.VacuumGripPoint_Offset_CartesianCoordinates_X, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_CartesianCoordinates_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId VacuumGripPoint_Offset_CartesianCoordinates_Y = new ExpandedNodeId(fortiss_Device.Variables.VacuumGripPoint_Offset_CartesianCoordinates_Y, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_CartesianCoordinates_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId VacuumGripPoint_Offset_CartesianCoordinates_Z = new ExpandedNodeId(fortiss_Device.Variables.VacuumGripPoint_Offset_CartesianCoordinates_Z, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_Orientation_A Variable.
        /// </summary>
        public static readonly ExpandedNodeId VacuumGripPoint_Offset_Orientation_A = new ExpandedNodeId(fortiss_Device.Variables.VacuumGripPoint_Offset_Orientation_A, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_Orientation_B Variable.
        /// </summary>
        public static readonly ExpandedNodeId VacuumGripPoint_Offset_Orientation_B = new ExpandedNodeId(fortiss_Device.Variables.VacuumGripPoint_Offset_Orientation_B, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the VacuumGripPoint_Offset_Orientation_C Variable.
        /// </summary>
        public static readonly ExpandedNodeId VacuumGripPoint_Offset_Orientation_C = new ExpandedNodeId(fortiss_Device.Variables.VacuumGripPoint_Offset_Orientation_C, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ParallelGripPoint_Type Variable.
        /// </summary>
        public static readonly ExpandedNodeId ParallelGripPoint_Type = new ExpandedNodeId(fortiss_Device.Variables.ParallelGripPoint_Type, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_CartesianCoordinates Variable.
        /// </summary>
        public static readonly ExpandedNodeId ParallelGripPoint_Offset_CartesianCoordinates = new ExpandedNodeId(fortiss_Device.Variables.ParallelGripPoint_Offset_CartesianCoordinates, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_Orientation Variable.
        /// </summary>
        public static readonly ExpandedNodeId ParallelGripPoint_Offset_Orientation = new ExpandedNodeId(fortiss_Device.Variables.ParallelGripPoint_Offset_Orientation, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_CartesianCoordinates_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId ParallelGripPoint_Offset_CartesianCoordinates_X = new ExpandedNodeId(fortiss_Device.Variables.ParallelGripPoint_Offset_CartesianCoordinates_X, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_CartesianCoordinates_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId ParallelGripPoint_Offset_CartesianCoordinates_Y = new ExpandedNodeId(fortiss_Device.Variables.ParallelGripPoint_Offset_CartesianCoordinates_Y, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_CartesianCoordinates_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId ParallelGripPoint_Offset_CartesianCoordinates_Z = new ExpandedNodeId(fortiss_Device.Variables.ParallelGripPoint_Offset_CartesianCoordinates_Z, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_Orientation_A Variable.
        /// </summary>
        public static readonly ExpandedNodeId ParallelGripPoint_Offset_Orientation_A = new ExpandedNodeId(fortiss_Device.Variables.ParallelGripPoint_Offset_Orientation_A, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_Orientation_B Variable.
        /// </summary>
        public static readonly ExpandedNodeId ParallelGripPoint_Offset_Orientation_B = new ExpandedNodeId(fortiss_Device.Variables.ParallelGripPoint_Offset_Orientation_B, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ParallelGripPoint_Offset_Orientation_C Variable.
        /// </summary>
        public static readonly ExpandedNodeId ParallelGripPoint_Offset_Orientation_C = new ExpandedNodeId(fortiss_Device.Variables.ParallelGripPoint_Offset_Orientation_C, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ParallelGripPoint_Range Variable.
        /// </summary>
        public static readonly ExpandedNodeId ParallelGripPoint_Range = new ExpandedNodeId(fortiss_Device.Variables.ParallelGripPoint_Range, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Type Variable.
        /// </summary>
        public static readonly ExpandedNodeId IGripperType_GripPoints_GripPoint__No__Type = new ExpandedNodeId(fortiss_Device.Variables.IGripperType_GripPoints_GripPoint__No__Type, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset Variable.
        /// </summary>
        public static readonly ExpandedNodeId IGripperType_GripPoints_GripPoint__No__Offset = new ExpandedNodeId(fortiss_Device.Variables.IGripperType_GripPoints_GripPoint__No__Offset, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates Variable.
        /// </summary>
        public static readonly ExpandedNodeId IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates = new ExpandedNodeId(fortiss_Device.Variables.IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_Orientation Variable.
        /// </summary>
        public static readonly ExpandedNodeId IGripperType_GripPoints_GripPoint__No__Offset_Orientation = new ExpandedNodeId(fortiss_Device.Variables.IGripperType_GripPoints_GripPoint__No__Offset_Orientation, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates_X = new ExpandedNodeId(fortiss_Device.Variables.IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates_X, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates_Y = new ExpandedNodeId(fortiss_Device.Variables.IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates_Y, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates_Z = new ExpandedNodeId(fortiss_Device.Variables.IGripperType_GripPoints_GripPoint__No__Offset_CartesianCoordinates_Z, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_Orientation_A Variable.
        /// </summary>
        public static readonly ExpandedNodeId IGripperType_GripPoints_GripPoint__No__Offset_Orientation_A = new ExpandedNodeId(fortiss_Device.Variables.IGripperType_GripPoints_GripPoint__No__Offset_Orientation_A, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_Orientation_B Variable.
        /// </summary>
        public static readonly ExpandedNodeId IGripperType_GripPoints_GripPoint__No__Offset_Orientation_B = new ExpandedNodeId(fortiss_Device.Variables.IGripperType_GripPoints_GripPoint__No__Offset_Orientation_B, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the IGripperType_GripPoints_GripPoint__No__Offset_Orientation_C Variable.
        /// </summary>
        public static readonly ExpandedNodeId IGripperType_GripPoints_GripPoint__No__Offset_Orientation_C = new ExpandedNodeId(fortiss_Device.Variables.IGripperType_GripPoints_GripPoint__No__Offset_Orientation_C, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SensorType_Lock_Locked Variable.
        /// </summary>
        public static readonly ExpandedNodeId SensorType_Lock_Locked = new ExpandedNodeId(fortiss_Device.Variables.SensorType_Lock_Locked, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SensorType_Lock_LockingClient Variable.
        /// </summary>
        public static readonly ExpandedNodeId SensorType_Lock_LockingClient = new ExpandedNodeId(fortiss_Device.Variables.SensorType_Lock_LockingClient, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SensorType_Lock_LockingUser Variable.
        /// </summary>
        public static readonly ExpandedNodeId SensorType_Lock_LockingUser = new ExpandedNodeId(fortiss_Device.Variables.SensorType_Lock_LockingUser, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SensorType_Lock_RemainingLockTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId SensorType_Lock_RemainingLockTime = new ExpandedNodeId(fortiss_Device.Variables.SensorType_Lock_RemainingLockTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SensorType_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId SensorType_Lock_InitLock_InputArguments = new ExpandedNodeId(fortiss_Device.Variables.SensorType_Lock_InitLock_InputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SensorType_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId SensorType_Lock_InitLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.SensorType_Lock_InitLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SensorType_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId SensorType_Lock_RenewLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.SensorType_Lock_RenewLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SensorType_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId SensorType_Lock_ExitLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.SensorType_Lock_ExitLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SensorType_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId SensorType_Lock_BreakLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.SensorType_Lock_BreakLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_Locked Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_Lock_Locked = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_Lock_Locked, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_LockingClient Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_Lock_LockingClient = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_Lock_LockingClient, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_LockingUser Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_Lock_LockingUser = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_Lock_LockingUser, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_RemainingLockTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_Lock_RemainingLockTime = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_Lock_RemainingLockTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_Lock_InitLock_InputArguments = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_Lock_InitLock_InputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_Lock_InitLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_Lock_InitLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_Lock_RenewLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_Lock_RenewLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_Lock_ExitLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_Lock_ExitLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_Lock_BreakLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_Lock_BreakLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_Locked Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor_Lock_Locked = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_ForceSensor_Lock_Locked, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_LockingClient Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor_Lock_LockingClient = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_ForceSensor_Lock_LockingClient, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_LockingUser Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor_Lock_LockingUser = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_ForceSensor_Lock_LockingUser, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_RemainingLockTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor_Lock_RemainingLockTime = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_ForceSensor_Lock_RemainingLockTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor_Lock_InitLock_InputArguments = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_ForceSensor_Lock_InitLock_InputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor_Lock_InitLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_ForceSensor_Lock_InitLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor_Lock_RenewLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_ForceSensor_Lock_RenewLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor_Lock_ExitLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_ForceSensor_Lock_ExitLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor_Lock_BreakLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_ForceSensor_Lock_BreakLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Force Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor_Force = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_ForceSensor_Force, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_ForceSensor_Force_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_ForceSensor_Force_EURange = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_ForceSensor_Force_EURange, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_Locked Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor_Lock_Locked = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_TorqueSensor_Lock_Locked, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_LockingClient Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor_Lock_LockingClient = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_TorqueSensor_Lock_LockingClient, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_LockingUser Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor_Lock_LockingUser = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_TorqueSensor_Lock_LockingUser, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_RemainingLockTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor_Lock_RemainingLockTime = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_TorqueSensor_Lock_RemainingLockTime, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor_Lock_InitLock_InputArguments = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_TorqueSensor_Lock_InitLock_InputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor_Lock_InitLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_TorqueSensor_Lock_InitLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor_Lock_RenewLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_TorqueSensor_Lock_RenewLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor_Lock_ExitLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_TorqueSensor_Lock_ExitLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor_Lock_BreakLock_OutputArguments = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_TorqueSensor_Lock_BreakLock_OutputArguments, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Torque Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor_Torque = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_TorqueSensor_Torque, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the ForceTorqueSensorType_TorqueSensor_Torque_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId ForceTorqueSensorType_TorqueSensor_Torque_EURange = new ExpandedNodeId(fortiss_Device.Variables.ForceTorqueSensorType_TorqueSensor_Torque_EURange, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillTransitionEventType_Transition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillTransitionEventType_Transition_Id = new ExpandedNodeId(fortiss_Device.Variables.SkillTransitionEventType_Transition_Id, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillTransitionEventType_FromState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillTransitionEventType_FromState_Id = new ExpandedNodeId(fortiss_Device.Variables.SkillTransitionEventType_FromState_Id, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the SkillTransitionEventType_ToState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId SkillTransitionEventType_ToState_Id = new ExpandedNodeId(fortiss_Device.Variables.SkillTransitionEventType_ToState_Id, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the fortissDevice_BinarySchema Variable.
        /// </summary>
        public static readonly ExpandedNodeId fortissDevice_BinarySchema = new ExpandedNodeId(fortiss_Device.Variables.fortissDevice_BinarySchema, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the fortissDevice_BinarySchema_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId fortissDevice_BinarySchema_NamespaceUri = new ExpandedNodeId(fortiss_Device.Variables.fortissDevice_BinarySchema_NamespaceUri, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the fortissDevice_BinarySchema_Deprecated Variable.
        /// </summary>
        public static readonly ExpandedNodeId fortissDevice_BinarySchema_Deprecated = new ExpandedNodeId(fortiss_Device.Variables.fortissDevice_BinarySchema_Deprecated, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the fortissDevice_XmlSchema Variable.
        /// </summary>
        public static readonly ExpandedNodeId fortissDevice_XmlSchema = new ExpandedNodeId(fortiss_Device.Variables.fortissDevice_XmlSchema, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the fortissDevice_XmlSchema_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId fortissDevice_XmlSchema_NamespaceUri = new ExpandedNodeId(fortiss_Device.Variables.fortissDevice_XmlSchema_NamespaceUri, fortiss_Device.Namespaces.fortissDevice);

        /// <summary>
        /// The identifier for the fortissDevice_XmlSchema_Deprecated Variable.
        /// </summary>
        public static readonly ExpandedNodeId fortissDevice_XmlSchema_Deprecated = new ExpandedNodeId(fortiss_Device.Variables.fortissDevice_XmlSchema_Deprecated, fortiss_Device.Namespaces.fortissDevice);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the ForceSensor component.
        /// </summary>
        public const string ForceSensor = "ForceSensor";

        /// <summary>
        /// The BrowseName for the ForceTorqueSensorType component.
        /// </summary>
        public const string ForceTorqueSensorType = "ForceTorqueSensorType";

        /// <summary>
        /// The BrowseName for the fortissDevice_BinarySchema component.
        /// </summary>
        public const string fortissDevice_BinarySchema = "fortiss_Device";

        /// <summary>
        /// The BrowseName for the fortissDevice_XmlSchema component.
        /// </summary>
        public const string fortissDevice_XmlSchema = "fortiss_Device";

        /// <summary>
        /// The BrowseName for the FortissDeviceNamespaceMetadata component.
        /// </summary>
        public const string FortissDeviceNamespaceMetadata = "https://fortiss.org/UA/Device/";

        /// <summary>
        /// The BrowseName for the GraspGripperSkillType component.
        /// </summary>
        public const string GraspGripperSkillType = "GraspGripperSkill";

        /// <summary>
        /// The BrowseName for the GripperSkillType component.
        /// </summary>
        public const string GripperSkillType = "GripperSkillType";

        /// <summary>
        /// The BrowseName for the GripPoint component.
        /// </summary>
        public const string GripPoint = "GripPoint";

        /// <summary>
        /// The BrowseName for the GripPoints component.
        /// </summary>
        public const string GripPoints = "GripPoints";

        /// <summary>
        /// The BrowseName for the GripTypeEnumeration component.
        /// </summary>
        public const string GripTypeEnumeration = "GripTypeEnumeration";

        /// <summary>
        /// The BrowseName for the IGripperType component.
        /// </summary>
        public const string IGripperType = "IGripperType";

        /// <summary>
        /// The BrowseName for the IPowerOffDeviceType component.
        /// </summary>
        public const string IPowerOffDeviceType = "IPowerOffDeviceType";

        /// <summary>
        /// The BrowseName for the ISkillControllerType component.
        /// </summary>
        public const string ISkillControllerType = "ISkillControllerType";

        /// <summary>
        /// The BrowseName for the MoveGripperSkillType component.
        /// </summary>
        public const string MoveGripperSkillType = "MoveGripperSkill";

        /// <summary>
        /// The BrowseName for the Name component.
        /// </summary>
        public const string Name = "Name";

        /// <summary>
        /// The BrowseName for the Offset component.
        /// </summary>
        public const string Offset = "Offset";

        /// <summary>
        /// The BrowseName for the ParallelGripPoint component.
        /// </summary>
        public const string ParallelGripPoint = "ParallelGripPoint";

        /// <summary>
        /// The BrowseName for the PowerOffDevice component.
        /// </summary>
        public const string PowerOffDevice = "PowerOffDevice";

        /// <summary>
        /// The BrowseName for the Range component.
        /// </summary>
        public const string Range = "Range";

        /// <summary>
        /// The BrowseName for the ReleaseGripperSkillType component.
        /// </summary>
        public const string ReleaseGripperSkillType = "ReleaseGripperSkill";

        /// <summary>
        /// The BrowseName for the SensorType component.
        /// </summary>
        public const string SensorType = "SensorType";

        /// <summary>
        /// The BrowseName for the Skills component.
        /// </summary>
        public const string Skills = "Skills";

        /// <summary>
        /// The BrowseName for the SkillTransitionEventType component.
        /// </summary>
        public const string SkillTransitionEventType = "SkillTransitionEventType";

        /// <summary>
        /// The BrowseName for the SkillType component.
        /// </summary>
        public const string SkillType = "SkillType";

        /// <summary>
        /// The BrowseName for the TorqueSensor component.
        /// </summary>
        public const string TorqueSensor = "TorqueSensor";

        /// <summary>
        /// The BrowseName for the Type component.
        /// </summary>
        public const string Type = "Type";

        /// <summary>
        /// The BrowseName for the VacuumGripPoint component.
        /// </summary>
        public const string VacuumGripPoint = "VacuumGripPoint";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the model design.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";

        /// <summary>
        /// The URI for the OpcUaDi namespace (.NET code namespace is 'Opc.Ua.Di').
        /// </summary>
        public const string OpcUaDi = "http://opcfoundation.org/UA/DI/";

        /// <summary>
        /// The URI for the OpcUaDiXsd namespace (.NET code namespace is 'Opc.Ua.Di').
        /// </summary>
        public const string OpcUaDiXsd = "http://opcfoundation.org/UA/DI/Types.xsd";

        /// <summary>
        /// The URI for the fortissDevice namespace (.NET code namespace is 'fortiss_Device').
        /// </summary>
        public const string fortissDevice = "https://fortiss.org/UA/Device/";

        /// <summary>
        /// The URI for the fortissDeviceXsd namespace (.NET code namespace is 'fortiss_Device').
        /// </summary>
        public const string fortissDeviceXsd = "https://fortiss.org/UA/Device/Types.xsd";
    }
    #endregion
}