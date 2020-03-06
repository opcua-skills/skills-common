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
using fortiss_Device;
using Opc.Ua;
using Opc.Ua.Di;
using Opc.Ua.Robotics;

namespace fortiss_Robotics
{
    #region Method Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Open Method.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_Open = 15015;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Close Method.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_Close = 15018;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Read Method.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_Read = 15020;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Write Method.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_Write = 15023;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_GetPosition Method.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_GetPosition = 15025;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_SetPosition Method.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_SetPosition = 15028;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_InitLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_Lock_InitLock = 15871;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_RenewLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_Lock_RenewLock = 15874;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_ExitLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_Lock_ExitLock = 15876;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_BreakLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_Lock_BreakLock = 15878;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_InitLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_Lock_InitLock = 15911;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_RenewLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_Lock_RenewLock = 15914;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_ExitLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_Lock_ExitLock = 15916;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_BreakLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_Lock_BreakLock = 15918;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_InitLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_InitLock = 15992;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_RenewLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_RenewLock = 15995;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_ExitLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_ExitLock = 15997;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_BreakLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_BreakLock = 15999;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_InitLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_InitLock = 16054;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_RenewLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_RenewLock = 16057;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_ExitLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_ExitLock = 16059;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_BreakLock Method.
        /// </summary>
        public const uint FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_BreakLock = 16061;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeToolSet Method.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeToolSet = 16077;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeToolClear Method.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeToolClear = 16079;
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
        /// The identifier for the FortissRoboticsNamespaceMetadata Object.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata = 15001;

        /// <summary>
        /// The identifier for the MoveSkillType_ParameterSet Object.
        /// </summary>
        public const uint MoveSkillType_ParameterSet = 15101;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ParameterSet Object.
        /// </summary>
        public const uint LinearMoveSkillType_ParameterSet = 15170;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ParameterSet Object.
        /// </summary>
        public const uint PtpMoveSkillType_ParameterSet = 15251;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData Object.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_FinalResultData = 15266;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet Object.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_ParameterSet = 15272;

        /// <summary>
        /// The identifier for the IJointMoveSkillParameterType_ParameterSet Object.
        /// </summary>
        public const uint IJointMoveSkillParameterType_ParameterSet = 15289;

        /// <summary>
        /// The identifier for the IForceMoveParameterType_ParameterSet Object.
        /// </summary>
        public const uint IForceMoveParameterType_ParameterSet = 15297;

        /// <summary>
        /// The identifier for the FinishStateMachineType_ForceExceeded Object.
        /// </summary>
        public const uint FinishStateMachineType_ForceExceeded = 16105;

        /// <summary>
        /// The identifier for the FinishStateMachineType_Success Object.
        /// </summary>
        public const uint FinishStateMachineType_Success = 16106;

        /// <summary>
        /// The identifier for the FinishStateMachineType_ForceExceededToRunning Object.
        /// </summary>
        public const uint FinishStateMachineType_ForceExceededToRunning = 16125;

        /// <summary>
        /// The identifier for the FinishStateMachineType_SuccessToRunning Object.
        /// </summary>
        public const uint FinishStateMachineType_SuccessToRunning = 16128;

        /// <summary>
        /// The identifier for the FinishStateMachineType_SuccessToHalted Object.
        /// </summary>
        public const uint FinishStateMachineType_SuccessToHalted = 16130;

        /// <summary>
        /// The identifier for the FinishStateMachineType_ForceExceededToHalted Object.
        /// </summary>
        public const uint FinishStateMachineType_ForceExceededToHalted = 16132;

        /// <summary>
        /// The identifier for the FinishStateMachineType_RunningToForceExceeded Object.
        /// </summary>
        public const uint FinishStateMachineType_RunningToForceExceeded = 16143;

        /// <summary>
        /// The identifier for the FinishStateMachineType_RunningToSuccess Object.
        /// </summary>
        public const uint FinishStateMachineType_RunningToSuccess = 16145;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_FinalResultData Object.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_FinalResultData = 15661;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_FinishStateMachine Object.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_FinishStateMachine = 16126;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet Object.
        /// </summary>
        public const uint PositionStreamSkillType_ParameterSet = 15842;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet Object.
        /// </summary>
        public const uint FortissMotionDeviceType_ParameterSet = 15858;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet Object.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet = 15900;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad Object.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad = 16015;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool Object.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeTool = 16081;
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
        /// The identifier for the MoveSkillType ObjectType.
        /// </summary>
        public const uint MoveSkillType = 15034;

        /// <summary>
        /// The identifier for the LinearMoveSkillType ObjectType.
        /// </summary>
        public const uint LinearMoveSkillType = 15103;

        /// <summary>
        /// The identifier for the PtpMoveSkillType ObjectType.
        /// </summary>
        public const uint PtpMoveSkillType = 15184;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType ObjectType.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType = 15265;

        /// <summary>
        /// The identifier for the IJointMoveSkillParameterType ObjectType.
        /// </summary>
        public const uint IJointMoveSkillParameterType = 15288;

        /// <summary>
        /// The identifier for the IForceMoveParameterType ObjectType.
        /// </summary>
        public const uint IForceMoveParameterType = 15296;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType ObjectType.
        /// </summary>
        public const uint CartesianLinearMoveSkillType = 15303;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType ObjectType.
        /// </summary>
        public const uint JointLinearMoveSkillType = 15384;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType ObjectType.
        /// </summary>
        public const uint CartesianPtpMoveSkillType = 15465;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType ObjectType.
        /// </summary>
        public const uint JointPtpMoveSkillType = 15546;

        /// <summary>
        /// The identifier for the FinishStateMachineType ObjectType.
        /// </summary>
        public const uint FinishStateMachineType = 16103;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType ObjectType.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType = 15627;

        /// <summary>
        /// The identifier for the StreamSkillType ObjectType.
        /// </summary>
        public const uint StreamSkillType = 15708;

        /// <summary>
        /// The identifier for the PositionStreamSkillType ObjectType.
        /// </summary>
        public const uint PositionStreamSkillType = 15775;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType ObjectType.
        /// </summary>
        public const uint FortissMotionDeviceType = 15857;
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
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceUri Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceUri = 15002;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceVersion Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceVersion = 15003;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespacePublicationDate Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespacePublicationDate = 15004;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_IsNamespaceSubset Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_IsNamespaceSubset = 15005;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_StaticNodeIdTypes Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_StaticNodeIdTypes = 15006;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_StaticNumericNodeIdRange Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_StaticNumericNodeIdRange = 15007;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_StaticStringNodeIdPattern Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_StaticStringNodeIdPattern = 15008;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Size Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_Size = 15010;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Writable Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_Writable = 15011;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_UserWritable Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_UserWritable = 15012;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_OpenCount Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_OpenCount = 15013;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Open_InputArguments Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_Open_InputArguments = 15016;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Open_OutputArguments Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_Open_OutputArguments = 15017;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Close_InputArguments Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_Close_InputArguments = 15019;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Read_InputArguments Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_Read_InputArguments = 15021;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Read_OutputArguments Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_Read_OutputArguments = 15022;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Write_InputArguments Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_Write_InputArguments = 15024;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_GetPosition_InputArguments Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = 15026;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = 15027;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_SetPosition_InputArguments Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = 15029;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_DefaultRolePermissions Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_DefaultRolePermissions = 15031;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_DefaultUserRolePermissions Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_DefaultUserRolePermissions = 15032;

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_DefaultAccessRestrictions Variable.
        /// </summary>
        public const uint FortissRoboticsNamespaceMetadata_DefaultAccessRestrictions = 15033;

        /// <summary>
        /// The identifier for the MoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public const uint MoveSkillType_CurrentState_Id = 15036;

        /// <summary>
        /// The identifier for the MoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public const uint MoveSkillType_CurrentState_Number = 15038;

        /// <summary>
        /// The identifier for the MoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public const uint MoveSkillType_LastTransition_Id = 15041;

        /// <summary>
        /// The identifier for the MoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public const uint MoveSkillType_LastTransition_Number = 15043;

        /// <summary>
        /// The identifier for the MoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint MoveSkillType_LastTransition_TransitionTime = 15044;

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint MoveSkillType_ProgramDiagnostic_CreateSessionId = 15056;

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint MoveSkillType_ProgramDiagnostic_CreateClientName = 15057;

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint MoveSkillType_ProgramDiagnostic_InvocationCreationTime = 15058;

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint MoveSkillType_ProgramDiagnostic_LastTransitionTime = 15059;

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint MoveSkillType_ProgramDiagnostic_LastMethodCall = 15060;

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint MoveSkillType_ProgramDiagnostic_LastMethodSessionId = 15061;

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint MoveSkillType_ProgramDiagnostic_LastMethodInputArguments = 15062;

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint MoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = 15063;

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint MoveSkillType_ProgramDiagnostic_LastMethodInputValues = 15064;

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint MoveSkillType_ProgramDiagnostic_LastMethodOutputValues = 15065;

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint MoveSkillType_ProgramDiagnostic_LastMethodCallTime = 15066;

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint MoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = 15067;

        /// <summary>
        /// The identifier for the MoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public const uint MoveSkillType_Halted_StateNumber = 15070;

        /// <summary>
        /// The identifier for the MoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public const uint MoveSkillType_Ready_StateNumber = 15072;

        /// <summary>
        /// The identifier for the MoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public const uint MoveSkillType_Running_StateNumber = 15074;

        /// <summary>
        /// The identifier for the MoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint MoveSkillType_Suspended_StateNumber = 15076;

        /// <summary>
        /// The identifier for the MoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint MoveSkillType_HaltedToReady_TransitionNumber = 15078;

        /// <summary>
        /// The identifier for the MoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint MoveSkillType_ReadyToRunning_TransitionNumber = 15080;

        /// <summary>
        /// The identifier for the MoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint MoveSkillType_RunningToHalted_TransitionNumber = 15082;

        /// <summary>
        /// The identifier for the MoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint MoveSkillType_RunningToReady_TransitionNumber = 15084;

        /// <summary>
        /// The identifier for the MoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint MoveSkillType_RunningToSuspended_TransitionNumber = 15086;

        /// <summary>
        /// The identifier for the MoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint MoveSkillType_SuspendedToRunning_TransitionNumber = 15088;

        /// <summary>
        /// The identifier for the MoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint MoveSkillType_SuspendedToHalted_TransitionNumber = 15090;

        /// <summary>
        /// The identifier for the MoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint MoveSkillType_SuspendedToReady_TransitionNumber = 15092;

        /// <summary>
        /// The identifier for the MoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint MoveSkillType_ReadyToHalted_TransitionNumber = 15094;

        /// <summary>
        /// The identifier for the MoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public const uint MoveSkillType_ParameterSet_ToolFrame = 15102;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public const uint LinearMoveSkillType_CurrentState_Id = 15105;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public const uint LinearMoveSkillType_CurrentState_Number = 15107;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public const uint LinearMoveSkillType_LastTransition_Id = 15110;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public const uint LinearMoveSkillType_LastTransition_Number = 15112;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint LinearMoveSkillType_LastTransition_TransitionTime = 15113;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ProgramDiagnostic_CreateSessionId = 15125;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ProgramDiagnostic_CreateClientName = 15126;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ProgramDiagnostic_InvocationCreationTime = 15127;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ProgramDiagnostic_LastTransitionTime = 15128;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ProgramDiagnostic_LastMethodCall = 15129;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ProgramDiagnostic_LastMethodSessionId = 15130;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ProgramDiagnostic_LastMethodInputArguments = 15131;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = 15132;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ProgramDiagnostic_LastMethodInputValues = 15133;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ProgramDiagnostic_LastMethodOutputValues = 15134;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ProgramDiagnostic_LastMethodCallTime = 15135;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = 15136;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public const uint LinearMoveSkillType_Halted_StateNumber = 15139;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public const uint LinearMoveSkillType_Ready_StateNumber = 15141;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public const uint LinearMoveSkillType_Running_StateNumber = 15143;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint LinearMoveSkillType_Suspended_StateNumber = 15145;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint LinearMoveSkillType_HaltedToReady_TransitionNumber = 15147;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ReadyToRunning_TransitionNumber = 15149;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint LinearMoveSkillType_RunningToHalted_TransitionNumber = 15151;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint LinearMoveSkillType_RunningToReady_TransitionNumber = 15153;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint LinearMoveSkillType_RunningToSuspended_TransitionNumber = 15155;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint LinearMoveSkillType_SuspendedToRunning_TransitionNumber = 15157;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint LinearMoveSkillType_SuspendedToHalted_TransitionNumber = 15159;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint LinearMoveSkillType_SuspendedToReady_TransitionNumber = 15161;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ReadyToHalted_TransitionNumber = 15163;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ParameterSet_ToolFrame = 15171;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ParameterSet_MaxAcceleration Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ParameterSet_MaxAcceleration = 15172;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits = 15177;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ParameterSet_MaxVelocity Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ParameterSet_MaxVelocity = 15178;

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits Variable.
        /// </summary>
        public const uint LinearMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits = 15183;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public const uint PtpMoveSkillType_CurrentState_Id = 15186;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public const uint PtpMoveSkillType_CurrentState_Number = 15188;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public const uint PtpMoveSkillType_LastTransition_Id = 15191;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public const uint PtpMoveSkillType_LastTransition_Number = 15193;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint PtpMoveSkillType_LastTransition_TransitionTime = 15194;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ProgramDiagnostic_CreateSessionId = 15206;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ProgramDiagnostic_CreateClientName = 15207;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ProgramDiagnostic_InvocationCreationTime = 15208;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ProgramDiagnostic_LastTransitionTime = 15209;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ProgramDiagnostic_LastMethodCall = 15210;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ProgramDiagnostic_LastMethodSessionId = 15211;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ProgramDiagnostic_LastMethodInputArguments = 15212;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = 15213;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ProgramDiagnostic_LastMethodInputValues = 15214;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ProgramDiagnostic_LastMethodOutputValues = 15215;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ProgramDiagnostic_LastMethodCallTime = 15216;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = 15217;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public const uint PtpMoveSkillType_Halted_StateNumber = 15220;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public const uint PtpMoveSkillType_Ready_StateNumber = 15222;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public const uint PtpMoveSkillType_Running_StateNumber = 15224;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint PtpMoveSkillType_Suspended_StateNumber = 15226;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint PtpMoveSkillType_HaltedToReady_TransitionNumber = 15228;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ReadyToRunning_TransitionNumber = 15230;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint PtpMoveSkillType_RunningToHalted_TransitionNumber = 15232;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint PtpMoveSkillType_RunningToReady_TransitionNumber = 15234;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint PtpMoveSkillType_RunningToSuspended_TransitionNumber = 15236;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint PtpMoveSkillType_SuspendedToRunning_TransitionNumber = 15238;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint PtpMoveSkillType_SuspendedToHalted_TransitionNumber = 15240;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint PtpMoveSkillType_SuspendedToReady_TransitionNumber = 15242;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ReadyToHalted_TransitionNumber = 15244;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ParameterSet_ToolFrame = 15252;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ParameterSet_MaxAcceleration Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ParameterSet_MaxAcceleration = 15253;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits = 15258;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ParameterSet_MaxVelocity Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ParameterSet_MaxVelocity = 15259;

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits Variable.
        /// </summary>
        public const uint PtpMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits = 15264;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded = 15267;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded_X Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded_X = 15269;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded_Y Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded_Y = 15270;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded_Z Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded_Z = 15271;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesMax Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_FinalResultData_ForcesMax = 16161;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesMax_X Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_FinalResultData_ForcesMax_X = 16163;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesMax_Y Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_FinalResultData_ForcesMax_Y = 16164;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesMax_Z Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_FinalResultData_ForcesMax_Z = 16165;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_ParameterSet_TargetPosition = 15273;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates = 15274;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation = 15276;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates_X Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates_X = 15281;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates_Y Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates_Y = 15282;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates_Z Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates_Z = 15283;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation_A Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation_A = 15284;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation_B Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation_B = 15285;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation_C Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation_C = 15286;

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_AxisBounds Variable.
        /// </summary>
        public const uint ICartesianMoveSkillParameterType_ParameterSet_AxisBounds = 15287;

        /// <summary>
        /// The identifier for the IJointMoveSkillParameterType_ParameterSet_TargetJointPosition Variable.
        /// </summary>
        public const uint IJointMoveSkillParameterType_ParameterSet_TargetJointPosition = 15290;

        /// <summary>
        /// The identifier for the IJointMoveSkillParameterType_ParameterSet_TargetJointPosition_EURange Variable.
        /// </summary>
        public const uint IJointMoveSkillParameterType_ParameterSet_TargetJointPosition_EURange = 15294;

        /// <summary>
        /// The identifier for the IForceMoveParameterType_ParameterSet_MaxForce Variable.
        /// </summary>
        public const uint IForceMoveParameterType_ParameterSet_MaxForce = 15298;

        /// <summary>
        /// The identifier for the IForceMoveParameterType_ParameterSet_MaxForce_X Variable.
        /// </summary>
        public const uint IForceMoveParameterType_ParameterSet_MaxForce_X = 15300;

        /// <summary>
        /// The identifier for the IForceMoveParameterType_ParameterSet_MaxForce_Y Variable.
        /// </summary>
        public const uint IForceMoveParameterType_ParameterSet_MaxForce_Y = 15301;

        /// <summary>
        /// The identifier for the IForceMoveParameterType_ParameterSet_MaxForce_Z Variable.
        /// </summary>
        public const uint IForceMoveParameterType_ParameterSet_MaxForce_Z = 15302;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_CurrentState_Id = 15305;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_CurrentState_Number = 15307;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_LastTransition_Id = 15310;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_LastTransition_Number = 15312;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_LastTransition_TransitionTime = 15313;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ProgramDiagnostic_CreateSessionId = 15325;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ProgramDiagnostic_CreateClientName = 15326;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ProgramDiagnostic_InvocationCreationTime = 15327;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ProgramDiagnostic_LastTransitionTime = 15328;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodCall = 15329;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodSessionId = 15330;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodInputArguments = 15331;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = 15332;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodInputValues = 15333;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputValues = 15334;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodCallTime = 15335;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = 15336;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_Halted_StateNumber = 15339;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_Ready_StateNumber = 15341;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_Running_StateNumber = 15343;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_Suspended_StateNumber = 15345;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_HaltedToReady_TransitionNumber = 15347;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ReadyToRunning_TransitionNumber = 15349;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_RunningToHalted_TransitionNumber = 15351;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_RunningToReady_TransitionNumber = 15353;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_RunningToSuspended_TransitionNumber = 15355;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_SuspendedToRunning_TransitionNumber = 15357;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_SuspendedToHalted_TransitionNumber = 15359;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_SuspendedToReady_TransitionNumber = 15361;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ReadyToHalted_TransitionNumber = 15363;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ParameterSet_ToolFrame = 15371;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ParameterSet_MaxAcceleration Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ParameterSet_MaxAcceleration = 15372;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits = 15377;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ParameterSet_MaxVelocity Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ParameterSet_MaxVelocity = 15378;

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits Variable.
        /// </summary>
        public const uint CartesianLinearMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits = 15383;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_CurrentState_Id = 15386;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_CurrentState_Number = 15388;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_LastTransition_Id = 15391;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_LastTransition_Number = 15393;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_LastTransition_TransitionTime = 15394;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ProgramDiagnostic_CreateSessionId = 15406;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ProgramDiagnostic_CreateClientName = 15407;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ProgramDiagnostic_InvocationCreationTime = 15408;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ProgramDiagnostic_LastTransitionTime = 15409;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ProgramDiagnostic_LastMethodCall = 15410;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ProgramDiagnostic_LastMethodSessionId = 15411;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ProgramDiagnostic_LastMethodInputArguments = 15412;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = 15413;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ProgramDiagnostic_LastMethodInputValues = 15414;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputValues = 15415;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ProgramDiagnostic_LastMethodCallTime = 15416;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = 15417;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_Halted_StateNumber = 15420;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_Ready_StateNumber = 15422;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_Running_StateNumber = 15424;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_Suspended_StateNumber = 15426;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_HaltedToReady_TransitionNumber = 15428;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ReadyToRunning_TransitionNumber = 15430;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_RunningToHalted_TransitionNumber = 15432;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_RunningToReady_TransitionNumber = 15434;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_RunningToSuspended_TransitionNumber = 15436;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_SuspendedToRunning_TransitionNumber = 15438;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_SuspendedToHalted_TransitionNumber = 15440;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_SuspendedToReady_TransitionNumber = 15442;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ReadyToHalted_TransitionNumber = 15444;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ParameterSet_ToolFrame = 15452;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ParameterSet_MaxAcceleration Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ParameterSet_MaxAcceleration = 15453;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits = 15458;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ParameterSet_MaxVelocity Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ParameterSet_MaxVelocity = 15459;

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits Variable.
        /// </summary>
        public const uint JointLinearMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits = 15464;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_CurrentState_Id = 15467;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_CurrentState_Number = 15469;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_LastTransition_Id = 15472;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_LastTransition_Number = 15474;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_LastTransition_TransitionTime = 15475;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ProgramDiagnostic_CreateSessionId = 15487;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ProgramDiagnostic_CreateClientName = 15488;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ProgramDiagnostic_InvocationCreationTime = 15489;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ProgramDiagnostic_LastTransitionTime = 15490;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodCall = 15491;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodSessionId = 15492;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodInputArguments = 15493;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = 15494;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodInputValues = 15495;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputValues = 15496;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodCallTime = 15497;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = 15498;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_Halted_StateNumber = 15501;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_Ready_StateNumber = 15503;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_Running_StateNumber = 15505;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_Suspended_StateNumber = 15507;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_HaltedToReady_TransitionNumber = 15509;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ReadyToRunning_TransitionNumber = 15511;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_RunningToHalted_TransitionNumber = 15513;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_RunningToReady_TransitionNumber = 15515;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_RunningToSuspended_TransitionNumber = 15517;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_SuspendedToRunning_TransitionNumber = 15519;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_SuspendedToHalted_TransitionNumber = 15521;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_SuspendedToReady_TransitionNumber = 15523;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ReadyToHalted_TransitionNumber = 15525;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ParameterSet_ToolFrame = 15533;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ParameterSet_MaxAcceleration Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ParameterSet_MaxAcceleration = 15534;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits = 15539;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ParameterSet_MaxVelocity Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ParameterSet_MaxVelocity = 15540;

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits Variable.
        /// </summary>
        public const uint CartesianPtpMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits = 15545;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_CurrentState_Id = 15548;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_CurrentState_Number = 15550;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_LastTransition_Id = 15553;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_LastTransition_Number = 15555;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_LastTransition_TransitionTime = 15556;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ProgramDiagnostic_CreateSessionId = 15568;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ProgramDiagnostic_CreateClientName = 15569;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ProgramDiagnostic_InvocationCreationTime = 15570;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ProgramDiagnostic_LastTransitionTime = 15571;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ProgramDiagnostic_LastMethodCall = 15572;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ProgramDiagnostic_LastMethodSessionId = 15573;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ProgramDiagnostic_LastMethodInputArguments = 15574;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = 15575;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ProgramDiagnostic_LastMethodInputValues = 15576;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputValues = 15577;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ProgramDiagnostic_LastMethodCallTime = 15578;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = 15579;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_Halted_StateNumber = 15582;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_Ready_StateNumber = 15584;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_Running_StateNumber = 15586;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_Suspended_StateNumber = 15588;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_HaltedToReady_TransitionNumber = 15590;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ReadyToRunning_TransitionNumber = 15592;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_RunningToHalted_TransitionNumber = 15594;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_RunningToReady_TransitionNumber = 15596;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_RunningToSuspended_TransitionNumber = 15598;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_SuspendedToRunning_TransitionNumber = 15600;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_SuspendedToHalted_TransitionNumber = 15602;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_SuspendedToReady_TransitionNumber = 15604;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ReadyToHalted_TransitionNumber = 15606;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ParameterSet_ToolFrame = 15614;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ParameterSet_MaxAcceleration Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ParameterSet_MaxAcceleration = 15615;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits = 15620;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ParameterSet_MaxVelocity Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ParameterSet_MaxVelocity = 15621;

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits Variable.
        /// </summary>
        public const uint JointPtpMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits = 15626;

        /// <summary>
        /// The identifier for the FinishStateMachineType_CurrentState_Id Variable.
        /// </summary>
        public const uint FinishStateMachineType_CurrentState_Id = 16110;

        /// <summary>
        /// The identifier for the FinishStateMachineType_LastTransition_Id Variable.
        /// </summary>
        public const uint FinishStateMachineType_LastTransition_Id = 16115;

        /// <summary>
        /// The identifier for the FinishStateMachineType_ForceExceeded_StateNumber Variable.
        /// </summary>
        public const uint FinishStateMachineType_ForceExceeded_StateNumber = 16107;

        /// <summary>
        /// The identifier for the FinishStateMachineType_Success_StateNumber Variable.
        /// </summary>
        public const uint FinishStateMachineType_Success_StateNumber = 16108;

        /// <summary>
        /// The identifier for the FinishStateMachineType_ForceExceededToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint FinishStateMachineType_ForceExceededToRunning_TransitionNumber = 16127;

        /// <summary>
        /// The identifier for the FinishStateMachineType_SuccessToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint FinishStateMachineType_SuccessToRunning_TransitionNumber = 16129;

        /// <summary>
        /// The identifier for the FinishStateMachineType_SuccessToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint FinishStateMachineType_SuccessToHalted_TransitionNumber = 16131;

        /// <summary>
        /// The identifier for the FinishStateMachineType_ForceExceededToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint FinishStateMachineType_ForceExceededToHalted_TransitionNumber = 16133;

        /// <summary>
        /// The identifier for the FinishStateMachineType_RunningToForceExceeded_TransitionNumber Variable.
        /// </summary>
        public const uint FinishStateMachineType_RunningToForceExceeded_TransitionNumber = 16144;

        /// <summary>
        /// The identifier for the FinishStateMachineType_RunningToSuccess_TransitionNumber Variable.
        /// </summary>
        public const uint FinishStateMachineType_RunningToSuccess_TransitionNumber = 16146;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_CurrentState_Id = 15629;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_CurrentState_Number = 15631;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_LastTransition_Id = 15634;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_LastTransition_Number = 15636;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_LastTransition_TransitionTime = 15637;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ProgramDiagnostic_CreateSessionId = 15649;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ProgramDiagnostic_CreateClientName = 15650;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ProgramDiagnostic_InvocationCreationTime = 15651;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastTransitionTime = 15652;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodCall = 15653;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodSessionId = 15654;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodInputArguments = 15655;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = 15656;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodInputValues = 15657;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodOutputValues = 15658;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodCallTime = 15659;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = 15660;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_Halted_StateNumber = 15663;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_Ready_StateNumber = 15665;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_Running_StateNumber = 15667;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_Suspended_StateNumber = 15669;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_HaltedToReady_TransitionNumber = 15671;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ReadyToRunning_TransitionNumber = 15673;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_RunningToHalted_TransitionNumber = 15675;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_RunningToReady_TransitionNumber = 15677;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_RunningToSuspended_TransitionNumber = 15679;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_SuspendedToRunning_TransitionNumber = 15681;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_SuspendedToHalted_TransitionNumber = 15683;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_SuspendedToReady_TransitionNumber = 15685;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ReadyToHalted_TransitionNumber = 15687;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ParameterSet_ToolFrame = 15695;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ParameterSet_MaxAcceleration Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ParameterSet_MaxAcceleration = 15696;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits = 15701;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ParameterSet_MaxVelocity Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ParameterSet_MaxVelocity = 15702;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits = 15707;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_FinishStateMachine_CurrentState Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_FinishStateMachine_CurrentState = 16104;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_FinishStateMachine_CurrentState_Id Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_FinishStateMachine_CurrentState_Id = 16122;

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_FinishStateMachine_LastTransition_Id Variable.
        /// </summary>
        public const uint CartesianLinearForceMoveSkillType_FinishStateMachine_LastTransition_Id = 16136;

        /// <summary>
        /// The identifier for the StreamSkillType_CurrentState_Id Variable.
        /// </summary>
        public const uint StreamSkillType_CurrentState_Id = 15710;

        /// <summary>
        /// The identifier for the StreamSkillType_CurrentState_Number Variable.
        /// </summary>
        public const uint StreamSkillType_CurrentState_Number = 15712;

        /// <summary>
        /// The identifier for the StreamSkillType_LastTransition_Id Variable.
        /// </summary>
        public const uint StreamSkillType_LastTransition_Id = 15715;

        /// <summary>
        /// The identifier for the StreamSkillType_LastTransition_Number Variable.
        /// </summary>
        public const uint StreamSkillType_LastTransition_Number = 15717;

        /// <summary>
        /// The identifier for the StreamSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint StreamSkillType_LastTransition_TransitionTime = 15718;

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint StreamSkillType_ProgramDiagnostic_CreateSessionId = 15730;

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint StreamSkillType_ProgramDiagnostic_CreateClientName = 15731;

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint StreamSkillType_ProgramDiagnostic_InvocationCreationTime = 15732;

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint StreamSkillType_ProgramDiagnostic_LastTransitionTime = 15733;

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint StreamSkillType_ProgramDiagnostic_LastMethodCall = 15734;

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint StreamSkillType_ProgramDiagnostic_LastMethodSessionId = 15735;

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint StreamSkillType_ProgramDiagnostic_LastMethodInputArguments = 15736;

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint StreamSkillType_ProgramDiagnostic_LastMethodOutputArguments = 15737;

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint StreamSkillType_ProgramDiagnostic_LastMethodInputValues = 15738;

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint StreamSkillType_ProgramDiagnostic_LastMethodOutputValues = 15739;

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint StreamSkillType_ProgramDiagnostic_LastMethodCallTime = 15740;

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint StreamSkillType_ProgramDiagnostic_LastMethodReturnStatus = 15741;

        /// <summary>
        /// The identifier for the StreamSkillType_Halted_StateNumber Variable.
        /// </summary>
        public const uint StreamSkillType_Halted_StateNumber = 15744;

        /// <summary>
        /// The identifier for the StreamSkillType_Ready_StateNumber Variable.
        /// </summary>
        public const uint StreamSkillType_Ready_StateNumber = 15746;

        /// <summary>
        /// The identifier for the StreamSkillType_Running_StateNumber Variable.
        /// </summary>
        public const uint StreamSkillType_Running_StateNumber = 15748;

        /// <summary>
        /// The identifier for the StreamSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint StreamSkillType_Suspended_StateNumber = 15750;

        /// <summary>
        /// The identifier for the StreamSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint StreamSkillType_HaltedToReady_TransitionNumber = 15752;

        /// <summary>
        /// The identifier for the StreamSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint StreamSkillType_ReadyToRunning_TransitionNumber = 15754;

        /// <summary>
        /// The identifier for the StreamSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint StreamSkillType_RunningToHalted_TransitionNumber = 15756;

        /// <summary>
        /// The identifier for the StreamSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint StreamSkillType_RunningToReady_TransitionNumber = 15758;

        /// <summary>
        /// The identifier for the StreamSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint StreamSkillType_RunningToSuspended_TransitionNumber = 15760;

        /// <summary>
        /// The identifier for the StreamSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint StreamSkillType_SuspendedToRunning_TransitionNumber = 15762;

        /// <summary>
        /// The identifier for the StreamSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint StreamSkillType_SuspendedToHalted_TransitionNumber = 15764;

        /// <summary>
        /// The identifier for the StreamSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint StreamSkillType_SuspendedToReady_TransitionNumber = 15766;

        /// <summary>
        /// The identifier for the StreamSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint StreamSkillType_ReadyToHalted_TransitionNumber = 15768;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_CurrentState_Id Variable.
        /// </summary>
        public const uint PositionStreamSkillType_CurrentState_Id = 15777;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_CurrentState_Number Variable.
        /// </summary>
        public const uint PositionStreamSkillType_CurrentState_Number = 15779;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_LastTransition_Id Variable.
        /// </summary>
        public const uint PositionStreamSkillType_LastTransition_Id = 15782;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_LastTransition_Number Variable.
        /// </summary>
        public const uint PositionStreamSkillType_LastTransition_Number = 15784;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint PositionStreamSkillType_LastTransition_TransitionTime = 15785;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ProgramDiagnostic_CreateSessionId = 15797;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ProgramDiagnostic_CreateClientName = 15798;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ProgramDiagnostic_InvocationCreationTime = 15799;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ProgramDiagnostic_LastTransitionTime = 15800;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ProgramDiagnostic_LastMethodCall = 15801;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ProgramDiagnostic_LastMethodSessionId = 15802;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ProgramDiagnostic_LastMethodInputArguments = 15803;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ProgramDiagnostic_LastMethodOutputArguments = 15804;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ProgramDiagnostic_LastMethodInputValues = 15805;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ProgramDiagnostic_LastMethodOutputValues = 15806;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ProgramDiagnostic_LastMethodCallTime = 15807;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ProgramDiagnostic_LastMethodReturnStatus = 15808;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_Halted_StateNumber Variable.
        /// </summary>
        public const uint PositionStreamSkillType_Halted_StateNumber = 15811;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_Ready_StateNumber Variable.
        /// </summary>
        public const uint PositionStreamSkillType_Ready_StateNumber = 15813;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_Running_StateNumber Variable.
        /// </summary>
        public const uint PositionStreamSkillType_Running_StateNumber = 15815;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public const uint PositionStreamSkillType_Suspended_StateNumber = 15817;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint PositionStreamSkillType_HaltedToReady_TransitionNumber = 15819;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ReadyToRunning_TransitionNumber = 15821;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint PositionStreamSkillType_RunningToHalted_TransitionNumber = 15823;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public const uint PositionStreamSkillType_RunningToReady_TransitionNumber = 15825;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public const uint PositionStreamSkillType_RunningToSuspended_TransitionNumber = 15827;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public const uint PositionStreamSkillType_SuspendedToRunning_TransitionNumber = 15829;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint PositionStreamSkillType_SuspendedToHalted_TransitionNumber = 15831;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public const uint PositionStreamSkillType_SuspendedToReady_TransitionNumber = 15833;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ReadyToHalted_TransitionNumber = 15835;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ParameterSet_TargetPosition = 15843;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates = 15844;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_Orientation Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ParameterSet_TargetPosition_Orientation = 15846;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates_X Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates_X = 15851;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates_Y Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates_Y = 15852;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates_Z Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates_Z = 15853;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_Orientation_A Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ParameterSet_TargetPosition_Orientation_A = 15854;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_Orientation_B Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ParameterSet_TargetPosition_Orientation_B = 15855;

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_Orientation_C Variable.
        /// </summary>
        public const uint PositionStreamSkillType_ParameterSet_TargetPosition_Orientation_C = 15856;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_Locked Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Lock_Locked = 15867;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_LockingClient Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Lock_LockingClient = 15868;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_LockingUser Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Lock_LockingUser = 15869;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_RemainingLockTime Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Lock_RemainingLockTime = 15870;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Lock_InitLock_InputArguments = 15872;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Lock_InitLock_OutputArguments = 15873;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Lock_RenewLock_OutputArguments = 15875;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Lock_ExitLock_OutputArguments = 15877;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Lock_BreakLock_OutputArguments = 15879;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_SpeedOverride Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_ParameterSet_SpeedOverride = 15897;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_Locked Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_Lock_Locked = 15907;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_LockingClient Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_Lock_LockingClient = 15908;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_LockingUser Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_Lock_LockingUser = 15909;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_RemainingLockTime Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_Lock_RemainingLockTime = 15910;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_Lock_InitLock_InputArguments = 15912;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_Lock_InitLock_OutputArguments = 15913;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_Lock_RenewLock_OutputArguments = 15915;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_Lock_ExitLock_OutputArguments = 15917;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_Lock_BreakLock_OutputArguments = 15919;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_MotionProfile Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_MotionProfile = 15934;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Mass Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Mass = 15936;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Mass_EngineeringUnits Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Mass_EngineeringUnits = 15941;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates = 15943;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation = 15945;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates_X Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates_X = 15950;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates_Y Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates_Y = 15951;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates_Z Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates_Z = 15952;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation_A Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation_A = 15953;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation_B Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation_B = 15954;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation_C Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation_C = 15955;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Inertia_X Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Inertia_X = 15958;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Inertia_Y Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Inertia_Y = 15959;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Inertia_Z Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Inertia_Z = 15960;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualPosition Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualPosition = 15961;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualPosition_EngineeringUnits Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualPosition_EngineeringUnits = 15966;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualSpeed_EngineeringUnits Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualSpeed_EngineeringUnits = 15972;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualAcceleration_EngineeringUnits Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualAcceleration_EngineeringUnits = 15978;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_Locked Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_Locked = 15988;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_LockingClient Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_LockingClient = 15989;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_LockingUser Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_LockingUser = 15990;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_RemainingLockTime Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_RemainingLockTime = 15991;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_InitLock_InputArguments = 15993;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_InitLock_OutputArguments = 15994;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_RenewLock_OutputArguments = 15996;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_ExitLock_OutputArguments = 15998;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_BreakLock_OutputArguments = 16000;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_Mass Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad_Mass = 16016;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_Mass_EngineeringUnits Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad_Mass_EngineeringUnits = 16021;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad_CenterOfMass = 16022;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates = 16023;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation = 16025;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates_X Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates_X = 16030;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates_Y Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates_Y = 16031;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates_Z Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates_Z = 16032;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation_A Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation_A = 16033;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation_B Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation_B = 16034;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation_C Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation_C = 16035;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_Inertia Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad_Inertia = 16036;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_Inertia_X Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad_Inertia_X = 16038;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_Inertia_Y Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad_Inertia_Y = 16039;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_Inertia_Z Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeLoad_Inertia_Z = 16040;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_Locked Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_Locked = 16050;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_LockingClient Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_LockingClient = 16051;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_LockingUser Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_LockingUser = 16052;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_RemainingLockTime Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_RemainingLockTime = 16053;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_InitLock_InputArguments = 16055;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_InitLock_OutputArguments = 16056;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_RenewLock_OutputArguments = 16058;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_ExitLock_OutputArguments = 16060;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_BreakLock_OutputArguments = 16062;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeToolSet_InputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeToolSet_InputArguments = 16078;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeToolClear_InputArguments Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeToolClear_InputArguments = 16080;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_Name Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeTool_Name = 16082;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeTool_ThreeDFrame = 16083;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates = 16084;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation = 16086;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates_X Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates_X = 16091;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates_Y Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates_Y = 16092;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates_Z Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates_Z = 16093;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation_A Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation_A = 16094;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation_B Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation_B = 16095;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation_C Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation_C = 16096;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_ParameterSet_WorldToRobotBase = 16147;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates = 16148;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation = 16150;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates_X Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates_X = 16155;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates_Y Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates_Y = 16156;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates_Z Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates_Z = 16157;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation_A Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation_A = 16158;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation_B Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation_B = 16159;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation_C Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation_C = 16160;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_DeviceOnPath Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_ParameterSet_DeviceOnPath = 16097;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_ProgrammedDeviceSpeed Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_ParameterSet_ProgrammedDeviceSpeed = 16098;

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_UnderControl Variable.
        /// </summary>
        public const uint FortissMotionDeviceType_ParameterSet_UnderControl = 16099;
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
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Open Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_Open = new ExpandedNodeId(fortiss_Robotics.Methods.FortissRoboticsNamespaceMetadata_NamespaceFile_Open, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Close Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_Close = new ExpandedNodeId(fortiss_Robotics.Methods.FortissRoboticsNamespaceMetadata_NamespaceFile_Close, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Read Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_Read = new ExpandedNodeId(fortiss_Robotics.Methods.FortissRoboticsNamespaceMetadata_NamespaceFile_Read, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Write Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_Write = new ExpandedNodeId(fortiss_Robotics.Methods.FortissRoboticsNamespaceMetadata_NamespaceFile_Write, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_GetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_GetPosition = new ExpandedNodeId(fortiss_Robotics.Methods.FortissRoboticsNamespaceMetadata_NamespaceFile_GetPosition, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_SetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_SetPosition = new ExpandedNodeId(fortiss_Robotics.Methods.FortissRoboticsNamespaceMetadata_NamespaceFile_SetPosition, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_InitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Lock_InitLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_Lock_InitLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_RenewLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Lock_RenewLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_Lock_RenewLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_ExitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Lock_ExitLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_Lock_ExitLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_BreakLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Lock_BreakLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_Lock_BreakLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_InitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_Lock_InitLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_Axes_AxisIdentifier_Lock_InitLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_RenewLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_Lock_RenewLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_Axes_AxisIdentifier_Lock_RenewLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_ExitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_Lock_ExitLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_Axes_AxisIdentifier_Lock_ExitLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_BreakLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_Lock_BreakLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_Axes_AxisIdentifier_Lock_BreakLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_InitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_InitLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_InitLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_RenewLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_RenewLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_RenewLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_ExitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_ExitLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_ExitLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_BreakLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_BreakLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_BreakLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_InitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_InitLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_InitLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_RenewLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_RenewLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_RenewLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_ExitLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_ExitLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_ExitLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_BreakLock Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_BreakLock = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_BreakLock, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeToolSet Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeToolSet = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_FlangeToolSet, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeToolClear Method.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeToolClear = new ExpandedNodeId(fortiss_Robotics.Methods.FortissMotionDeviceType_FlangeToolClear, fortiss_Robotics.Namespaces.fortissRobotics);
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
        /// The identifier for the FortissRoboticsNamespaceMetadata Object.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata = new ExpandedNodeId(fortiss_Robotics.Objects.FortissRoboticsNamespaceMetadata, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ParameterSet Object.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ParameterSet = new ExpandedNodeId(fortiss_Robotics.Objects.MoveSkillType_ParameterSet, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ParameterSet Object.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ParameterSet = new ExpandedNodeId(fortiss_Robotics.Objects.LinearMoveSkillType_ParameterSet, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ParameterSet Object.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ParameterSet = new ExpandedNodeId(fortiss_Robotics.Objects.PtpMoveSkillType_ParameterSet, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData Object.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_FinalResultData = new ExpandedNodeId(fortiss_Robotics.Objects.ICartesianMoveSkillParameterType_FinalResultData, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet Object.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_ParameterSet = new ExpandedNodeId(fortiss_Robotics.Objects.ICartesianMoveSkillParameterType_ParameterSet, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the IJointMoveSkillParameterType_ParameterSet Object.
        /// </summary>
        public static readonly ExpandedNodeId IJointMoveSkillParameterType_ParameterSet = new ExpandedNodeId(fortiss_Robotics.Objects.IJointMoveSkillParameterType_ParameterSet, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the IForceMoveParameterType_ParameterSet Object.
        /// </summary>
        public static readonly ExpandedNodeId IForceMoveParameterType_ParameterSet = new ExpandedNodeId(fortiss_Robotics.Objects.IForceMoveParameterType_ParameterSet, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_ForceExceeded Object.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_ForceExceeded = new ExpandedNodeId(fortiss_Robotics.Objects.FinishStateMachineType_ForceExceeded, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_Success Object.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_Success = new ExpandedNodeId(fortiss_Robotics.Objects.FinishStateMachineType_Success, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_ForceExceededToRunning Object.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_ForceExceededToRunning = new ExpandedNodeId(fortiss_Robotics.Objects.FinishStateMachineType_ForceExceededToRunning, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_SuccessToRunning Object.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_SuccessToRunning = new ExpandedNodeId(fortiss_Robotics.Objects.FinishStateMachineType_SuccessToRunning, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_SuccessToHalted Object.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_SuccessToHalted = new ExpandedNodeId(fortiss_Robotics.Objects.FinishStateMachineType_SuccessToHalted, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_ForceExceededToHalted Object.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_ForceExceededToHalted = new ExpandedNodeId(fortiss_Robotics.Objects.FinishStateMachineType_ForceExceededToHalted, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_RunningToForceExceeded Object.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_RunningToForceExceeded = new ExpandedNodeId(fortiss_Robotics.Objects.FinishStateMachineType_RunningToForceExceeded, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_RunningToSuccess Object.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_RunningToSuccess = new ExpandedNodeId(fortiss_Robotics.Objects.FinishStateMachineType_RunningToSuccess, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_FinalResultData Object.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_FinalResultData = new ExpandedNodeId(fortiss_Robotics.Objects.CartesianLinearForceMoveSkillType_FinalResultData, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_FinishStateMachine Object.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_FinishStateMachine = new ExpandedNodeId(fortiss_Robotics.Objects.CartesianLinearForceMoveSkillType_FinishStateMachine, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet Object.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ParameterSet = new ExpandedNodeId(fortiss_Robotics.Objects.PositionStreamSkillType_ParameterSet, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet Object.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_ParameterSet = new ExpandedNodeId(fortiss_Robotics.Objects.FortissMotionDeviceType_ParameterSet, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet Object.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet = new ExpandedNodeId(fortiss_Robotics.Objects.FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad Object.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad = new ExpandedNodeId(fortiss_Robotics.Objects.FortissMotionDeviceType_FlangeLoad, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool Object.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeTool = new ExpandedNodeId(fortiss_Robotics.Objects.FortissMotionDeviceType_FlangeTool, fortiss_Robotics.Namespaces.fortissRobotics);
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
        /// The identifier for the MoveSkillType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType = new ExpandedNodeId(fortiss_Robotics.ObjectTypes.MoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType = new ExpandedNodeId(fortiss_Robotics.ObjectTypes.LinearMoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType = new ExpandedNodeId(fortiss_Robotics.ObjectTypes.PtpMoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType = new ExpandedNodeId(fortiss_Robotics.ObjectTypes.ICartesianMoveSkillParameterType, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the IJointMoveSkillParameterType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId IJointMoveSkillParameterType = new ExpandedNodeId(fortiss_Robotics.ObjectTypes.IJointMoveSkillParameterType, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the IForceMoveParameterType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId IForceMoveParameterType = new ExpandedNodeId(fortiss_Robotics.ObjectTypes.IForceMoveParameterType, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType = new ExpandedNodeId(fortiss_Robotics.ObjectTypes.CartesianLinearMoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType = new ExpandedNodeId(fortiss_Robotics.ObjectTypes.JointLinearMoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType = new ExpandedNodeId(fortiss_Robotics.ObjectTypes.CartesianPtpMoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType = new ExpandedNodeId(fortiss_Robotics.ObjectTypes.JointPtpMoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType = new ExpandedNodeId(fortiss_Robotics.ObjectTypes.FinishStateMachineType, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType = new ExpandedNodeId(fortiss_Robotics.ObjectTypes.CartesianLinearForceMoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType = new ExpandedNodeId(fortiss_Robotics.ObjectTypes.StreamSkillType, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType = new ExpandedNodeId(fortiss_Robotics.ObjectTypes.PositionStreamSkillType, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType = new ExpandedNodeId(fortiss_Robotics.ObjectTypes.FortissMotionDeviceType, fortiss_Robotics.Namespaces.fortissRobotics);
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
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceUri = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespaceUri, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceVersion Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceVersion = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespaceVersion, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespacePublicationDate Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespacePublicationDate = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespacePublicationDate, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_IsNamespaceSubset Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_IsNamespaceSubset = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_IsNamespaceSubset, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_StaticNodeIdTypes Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_StaticNodeIdTypes = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_StaticNodeIdTypes, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_StaticNumericNodeIdRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_StaticNumericNodeIdRange = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_StaticNumericNodeIdRange, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_StaticStringNodeIdPattern Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_StaticStringNodeIdPattern = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_StaticStringNodeIdPattern, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Size Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_Size = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespaceFile_Size, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Writable Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_Writable = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespaceFile_Writable, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_UserWritable Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_UserWritable = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespaceFile_UserWritable, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_OpenCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_OpenCount = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespaceFile_OpenCount, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Open_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_Open_InputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespaceFile_Open_InputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Open_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_Open_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespaceFile_Open_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Close_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_Close_InputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespaceFile_Close_InputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Read_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_Read_InputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespaceFile_Read_InputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Read_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_Read_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespaceFile_Read_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_Write_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_Write_InputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespaceFile_Write_InputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_GetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespaceFile_GetPosition_InputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_NamespaceFile_SetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_NamespaceFile_SetPosition_InputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_DefaultRolePermissions Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_DefaultRolePermissions = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_DefaultRolePermissions, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_DefaultUserRolePermissions Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_DefaultUserRolePermissions = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_DefaultUserRolePermissions, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissRoboticsNamespaceMetadata_DefaultAccessRestrictions Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissRoboticsNamespaceMetadata_DefaultAccessRestrictions = new ExpandedNodeId(fortiss_Robotics.Variables.FortissRoboticsNamespaceMetadata_DefaultAccessRestrictions, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_CurrentState_Id = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_CurrentState_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_CurrentState_Number = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_CurrentState_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_LastTransition_Id = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_LastTransition_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_LastTransition_Number = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_LastTransition_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_LastTransition_TransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_ProgramDiagnostic_CreateSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_ProgramDiagnostic_CreateClientName, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_ProgramDiagnostic_InvocationCreationTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_ProgramDiagnostic_LastTransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_ProgramDiagnostic_LastMethodCall, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_ProgramDiagnostic_LastMethodSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_ProgramDiagnostic_LastMethodInputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_ProgramDiagnostic_LastMethodOutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_ProgramDiagnostic_LastMethodInputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_ProgramDiagnostic_LastMethodOutputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_ProgramDiagnostic_LastMethodCallTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_ProgramDiagnostic_LastMethodReturnStatus, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_Halted_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_Halted_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_Ready_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_Ready_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_Running_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_Running_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_Suspended_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_Suspended_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_HaltedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_HaltedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_ReadyToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_RunningToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_RunningToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_RunningToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_RunningToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_RunningToSuspended_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_SuspendedToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_SuspendedToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_SuspendedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_ReadyToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the MoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public static readonly ExpandedNodeId MoveSkillType_ParameterSet_ToolFrame = new ExpandedNodeId(fortiss_Robotics.Variables.MoveSkillType_ParameterSet_ToolFrame, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_CurrentState_Id = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_CurrentState_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_CurrentState_Number = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_CurrentState_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_LastTransition_Id = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_LastTransition_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_LastTransition_Number = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_LastTransition_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_LastTransition_TransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ProgramDiagnostic_CreateSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ProgramDiagnostic_CreateClientName, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ProgramDiagnostic_InvocationCreationTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ProgramDiagnostic_LastTransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ProgramDiagnostic_LastMethodCall, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ProgramDiagnostic_LastMethodSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ProgramDiagnostic_LastMethodInputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ProgramDiagnostic_LastMethodInputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ProgramDiagnostic_LastMethodOutputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ProgramDiagnostic_LastMethodCallTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_Halted_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_Halted_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_Ready_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_Ready_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_Running_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_Running_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_Suspended_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_Suspended_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_HaltedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_HaltedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ReadyToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_RunningToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_RunningToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_RunningToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_RunningToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_RunningToSuspended_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_SuspendedToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_SuspendedToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_SuspendedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ReadyToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ParameterSet_ToolFrame = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ParameterSet_ToolFrame, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ParameterSet_MaxAcceleration Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ParameterSet_MaxAcceleration = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ParameterSet_MaxAcceleration, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ParameterSet_MaxVelocity Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ParameterSet_MaxVelocity = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ParameterSet_MaxVelocity, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the LinearMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId LinearMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.LinearMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_CurrentState_Id = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_CurrentState_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_CurrentState_Number = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_CurrentState_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_LastTransition_Id = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_LastTransition_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_LastTransition_Number = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_LastTransition_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_LastTransition_TransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ProgramDiagnostic_CreateSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ProgramDiagnostic_CreateClientName, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ProgramDiagnostic_InvocationCreationTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ProgramDiagnostic_LastTransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ProgramDiagnostic_LastMethodCall, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ProgramDiagnostic_LastMethodSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ProgramDiagnostic_LastMethodInputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ProgramDiagnostic_LastMethodInputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ProgramDiagnostic_LastMethodOutputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ProgramDiagnostic_LastMethodCallTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_Halted_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_Halted_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_Ready_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_Ready_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_Running_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_Running_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_Suspended_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_Suspended_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_HaltedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_HaltedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ReadyToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_RunningToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_RunningToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_RunningToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_RunningToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_RunningToSuspended_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_SuspendedToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_SuspendedToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_SuspendedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ReadyToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ParameterSet_ToolFrame = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ParameterSet_ToolFrame, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ParameterSet_MaxAcceleration Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ParameterSet_MaxAcceleration = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ParameterSet_MaxAcceleration, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ParameterSet_MaxVelocity Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ParameterSet_MaxVelocity = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ParameterSet_MaxVelocity, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PtpMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId PtpMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.PtpMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded_X = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded_X, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded_Y = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded_Y, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded_Z = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_FinalResultData_ForcesExceeded_Z, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesMax Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_FinalResultData_ForcesMax = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_FinalResultData_ForcesMax, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesMax_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_FinalResultData_ForcesMax_X = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_FinalResultData_ForcesMax_X, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesMax_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_FinalResultData_ForcesMax_Y = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_FinalResultData_ForcesMax_Y, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_FinalResultData_ForcesMax_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_FinalResultData_ForcesMax_Z = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_FinalResultData_ForcesMax_Z, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_ParameterSet_TargetPosition = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_ParameterSet_TargetPosition, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates_X = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates_X, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates_Y = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates_Y, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates_Z = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_CartesianCoordinates_Z, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation_A Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation_A = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation_A, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation_B Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation_B = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation_B, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation_C Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation_C = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_ParameterSet_TargetPosition_Orientation_C, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the ICartesianMoveSkillParameterType_ParameterSet_AxisBounds Variable.
        /// </summary>
        public static readonly ExpandedNodeId ICartesianMoveSkillParameterType_ParameterSet_AxisBounds = new ExpandedNodeId(fortiss_Robotics.Variables.ICartesianMoveSkillParameterType_ParameterSet_AxisBounds, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the IJointMoveSkillParameterType_ParameterSet_TargetJointPosition Variable.
        /// </summary>
        public static readonly ExpandedNodeId IJointMoveSkillParameterType_ParameterSet_TargetJointPosition = new ExpandedNodeId(fortiss_Robotics.Variables.IJointMoveSkillParameterType_ParameterSet_TargetJointPosition, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the IJointMoveSkillParameterType_ParameterSet_TargetJointPosition_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId IJointMoveSkillParameterType_ParameterSet_TargetJointPosition_EURange = new ExpandedNodeId(fortiss_Robotics.Variables.IJointMoveSkillParameterType_ParameterSet_TargetJointPosition_EURange, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the IForceMoveParameterType_ParameterSet_MaxForce Variable.
        /// </summary>
        public static readonly ExpandedNodeId IForceMoveParameterType_ParameterSet_MaxForce = new ExpandedNodeId(fortiss_Robotics.Variables.IForceMoveParameterType_ParameterSet_MaxForce, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the IForceMoveParameterType_ParameterSet_MaxForce_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId IForceMoveParameterType_ParameterSet_MaxForce_X = new ExpandedNodeId(fortiss_Robotics.Variables.IForceMoveParameterType_ParameterSet_MaxForce_X, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the IForceMoveParameterType_ParameterSet_MaxForce_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId IForceMoveParameterType_ParameterSet_MaxForce_Y = new ExpandedNodeId(fortiss_Robotics.Variables.IForceMoveParameterType_ParameterSet_MaxForce_Y, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the IForceMoveParameterType_ParameterSet_MaxForce_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId IForceMoveParameterType_ParameterSet_MaxForce_Z = new ExpandedNodeId(fortiss_Robotics.Variables.IForceMoveParameterType_ParameterSet_MaxForce_Z, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_CurrentState_Id = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_CurrentState_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_CurrentState_Number = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_CurrentState_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_LastTransition_Id = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_LastTransition_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_LastTransition_Number = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_LastTransition_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_LastTransition_TransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ProgramDiagnostic_CreateSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ProgramDiagnostic_CreateClientName, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ProgramDiagnostic_InvocationCreationTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ProgramDiagnostic_LastTransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodCall, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodInputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodInputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodCallTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_Halted_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_Halted_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_Ready_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_Ready_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_Running_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_Running_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_Suspended_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_Suspended_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_HaltedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_HaltedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ReadyToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_RunningToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_RunningToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_RunningToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_RunningToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_RunningToSuspended_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_SuspendedToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_SuspendedToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_SuspendedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ReadyToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ParameterSet_ToolFrame = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ParameterSet_ToolFrame, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ParameterSet_MaxAcceleration Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ParameterSet_MaxAcceleration = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ParameterSet_MaxAcceleration, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ParameterSet_MaxVelocity Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ParameterSet_MaxVelocity = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ParameterSet_MaxVelocity, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_CurrentState_Id = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_CurrentState_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_CurrentState_Number = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_CurrentState_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_LastTransition_Id = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_LastTransition_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_LastTransition_Number = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_LastTransition_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_LastTransition_TransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ProgramDiagnostic_CreateSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ProgramDiagnostic_CreateClientName, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ProgramDiagnostic_InvocationCreationTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ProgramDiagnostic_LastTransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ProgramDiagnostic_LastMethodCall, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ProgramDiagnostic_LastMethodSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ProgramDiagnostic_LastMethodInputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ProgramDiagnostic_LastMethodInputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ProgramDiagnostic_LastMethodOutputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ProgramDiagnostic_LastMethodCallTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_Halted_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_Halted_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_Ready_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_Ready_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_Running_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_Running_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_Suspended_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_Suspended_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_HaltedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_HaltedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ReadyToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_RunningToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_RunningToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_RunningToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_RunningToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_RunningToSuspended_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_SuspendedToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_SuspendedToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_SuspendedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ReadyToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ParameterSet_ToolFrame = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ParameterSet_ToolFrame, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ParameterSet_MaxAcceleration Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ParameterSet_MaxAcceleration = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ParameterSet_MaxAcceleration, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ParameterSet_MaxVelocity Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ParameterSet_MaxVelocity = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ParameterSet_MaxVelocity, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointLinearMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointLinearMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.JointLinearMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_CurrentState_Id = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_CurrentState_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_CurrentState_Number = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_CurrentState_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_LastTransition_Id = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_LastTransition_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_LastTransition_Number = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_LastTransition_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_LastTransition_TransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ProgramDiagnostic_CreateSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ProgramDiagnostic_CreateClientName, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ProgramDiagnostic_InvocationCreationTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ProgramDiagnostic_LastTransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodCall, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodInputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodInputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodCallTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_Halted_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_Halted_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_Ready_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_Ready_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_Running_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_Running_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_Suspended_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_Suspended_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_HaltedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_HaltedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ReadyToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_RunningToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_RunningToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_RunningToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_RunningToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_RunningToSuspended_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_SuspendedToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_SuspendedToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_SuspendedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ReadyToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ParameterSet_ToolFrame = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ParameterSet_ToolFrame, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ParameterSet_MaxAcceleration Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ParameterSet_MaxAcceleration = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ParameterSet_MaxAcceleration, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ParameterSet_MaxVelocity Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ParameterSet_MaxVelocity = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ParameterSet_MaxVelocity, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianPtpMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianPtpMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianPtpMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_CurrentState_Id = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_CurrentState_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_CurrentState_Number = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_CurrentState_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_LastTransition_Id = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_LastTransition_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_LastTransition_Number = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_LastTransition_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_LastTransition_TransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ProgramDiagnostic_CreateSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ProgramDiagnostic_CreateClientName, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ProgramDiagnostic_InvocationCreationTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ProgramDiagnostic_LastTransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ProgramDiagnostic_LastMethodCall, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ProgramDiagnostic_LastMethodSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ProgramDiagnostic_LastMethodInputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ProgramDiagnostic_LastMethodInputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ProgramDiagnostic_LastMethodOutputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ProgramDiagnostic_LastMethodCallTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_Halted_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_Halted_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_Ready_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_Ready_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_Running_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_Running_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_Suspended_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_Suspended_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_HaltedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_HaltedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ReadyToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_RunningToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_RunningToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_RunningToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_RunningToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_RunningToSuspended_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_SuspendedToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_SuspendedToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_SuspendedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ReadyToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ParameterSet_ToolFrame = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ParameterSet_ToolFrame, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ParameterSet_MaxAcceleration Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ParameterSet_MaxAcceleration = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ParameterSet_MaxAcceleration, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ParameterSet_MaxVelocity Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ParameterSet_MaxVelocity = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ParameterSet_MaxVelocity, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the JointPtpMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId JointPtpMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.JointPtpMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_CurrentState_Id = new ExpandedNodeId(fortiss_Robotics.Variables.FinishStateMachineType_CurrentState_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_LastTransition_Id = new ExpandedNodeId(fortiss_Robotics.Variables.FinishStateMachineType_LastTransition_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_ForceExceeded_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_ForceExceeded_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.FinishStateMachineType_ForceExceeded_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_Success_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_Success_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.FinishStateMachineType_Success_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_ForceExceededToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_ForceExceededToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.FinishStateMachineType_ForceExceededToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_SuccessToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_SuccessToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.FinishStateMachineType_SuccessToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_SuccessToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_SuccessToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.FinishStateMachineType_SuccessToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_ForceExceededToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_ForceExceededToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.FinishStateMachineType_ForceExceededToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_RunningToForceExceeded_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_RunningToForceExceeded_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.FinishStateMachineType_RunningToForceExceeded_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FinishStateMachineType_RunningToSuccess_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId FinishStateMachineType_RunningToSuccess_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.FinishStateMachineType_RunningToSuccess_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_CurrentState_Id = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_CurrentState_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_CurrentState_Number = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_CurrentState_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_LastTransition_Id = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_LastTransition_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_LastTransition_Number = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_LastTransition_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_LastTransition_TransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ProgramDiagnostic_CreateSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ProgramDiagnostic_CreateClientName, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ProgramDiagnostic_InvocationCreationTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastTransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodCall, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodInputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodOutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodInputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodOutputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodCallTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ProgramDiagnostic_LastMethodReturnStatus, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_Halted_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_Halted_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_Ready_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_Ready_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_Running_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_Running_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_Suspended_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_Suspended_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_HaltedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_HaltedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ReadyToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_RunningToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_RunningToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_RunningToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_RunningToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_RunningToSuspended_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_SuspendedToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_SuspendedToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_SuspendedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ReadyToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ParameterSet_ToolFrame Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ParameterSet_ToolFrame = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ParameterSet_ToolFrame, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ParameterSet_MaxAcceleration Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ParameterSet_MaxAcceleration = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ParameterSet_MaxAcceleration, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ParameterSet_MaxAcceleration_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ParameterSet_MaxVelocity Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ParameterSet_MaxVelocity = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ParameterSet_MaxVelocity, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_ParameterSet_MaxVelocity_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_FinishStateMachine_CurrentState Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_FinishStateMachine_CurrentState = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_FinishStateMachine_CurrentState, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_FinishStateMachine_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_FinishStateMachine_CurrentState_Id = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_FinishStateMachine_CurrentState_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the CartesianLinearForceMoveSkillType_FinishStateMachine_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId CartesianLinearForceMoveSkillType_FinishStateMachine_LastTransition_Id = new ExpandedNodeId(fortiss_Robotics.Variables.CartesianLinearForceMoveSkillType_FinishStateMachine_LastTransition_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_CurrentState_Id = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_CurrentState_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_CurrentState_Number = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_CurrentState_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_LastTransition_Id = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_LastTransition_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_LastTransition_Number = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_LastTransition_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_LastTransition_TransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_ProgramDiagnostic_CreateSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_ProgramDiagnostic_CreateClientName, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_ProgramDiagnostic_InvocationCreationTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_ProgramDiagnostic_LastTransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_ProgramDiagnostic_LastMethodCall, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_ProgramDiagnostic_LastMethodSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_ProgramDiagnostic_LastMethodInputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_ProgramDiagnostic_LastMethodOutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_ProgramDiagnostic_LastMethodInputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_ProgramDiagnostic_LastMethodOutputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_ProgramDiagnostic_LastMethodCallTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_ProgramDiagnostic_LastMethodReturnStatus, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_Halted_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_Halted_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_Ready_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_Ready_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_Running_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_Running_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_Suspended_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_Suspended_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_HaltedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_HaltedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_ReadyToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_RunningToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_RunningToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_RunningToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_RunningToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_RunningToSuspended_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_SuspendedToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_SuspendedToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_SuspendedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the StreamSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId StreamSkillType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.StreamSkillType_ReadyToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_CurrentState_Id = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_CurrentState_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_CurrentState_Number = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_CurrentState_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_LastTransition_Id = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_LastTransition_Id, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_LastTransition_Number = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_LastTransition_Number, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_LastTransition_TransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_LastTransition_TransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ProgramDiagnostic_CreateSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ProgramDiagnostic_CreateSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ProgramDiagnostic_CreateClientName = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ProgramDiagnostic_CreateClientName, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ProgramDiagnostic_InvocationCreationTime = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ProgramDiagnostic_InvocationCreationTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ProgramDiagnostic_LastTransitionTime = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ProgramDiagnostic_LastTransitionTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ProgramDiagnostic_LastMethodCall = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ProgramDiagnostic_LastMethodCall, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ProgramDiagnostic_LastMethodSessionId = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ProgramDiagnostic_LastMethodSessionId, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ProgramDiagnostic_LastMethodInputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ProgramDiagnostic_LastMethodInputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ProgramDiagnostic_LastMethodOutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ProgramDiagnostic_LastMethodOutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodInputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ProgramDiagnostic_LastMethodInputValues = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ProgramDiagnostic_LastMethodInputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodOutputValues Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ProgramDiagnostic_LastMethodOutputValues = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ProgramDiagnostic_LastMethodOutputValues, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ProgramDiagnostic_LastMethodCallTime = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ProgramDiagnostic_LastMethodCallTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ProgramDiagnostic_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ProgramDiagnostic_LastMethodReturnStatus = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ProgramDiagnostic_LastMethodReturnStatus, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_Halted_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_Halted_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_Halted_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_Ready_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_Ready_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_Ready_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_Running_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_Running_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_Running_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_Suspended_StateNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_Suspended_StateNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_Suspended_StateNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_HaltedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_HaltedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_HaltedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ReadyToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ReadyToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ReadyToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_RunningToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_RunningToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_RunningToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_RunningToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_RunningToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_RunningToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_RunningToSuspended_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_RunningToSuspended_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_RunningToSuspended_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_SuspendedToRunning_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_SuspendedToRunning_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_SuspendedToRunning_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_SuspendedToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_SuspendedToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_SuspendedToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_SuspendedToReady_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_SuspendedToReady_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_SuspendedToReady_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ReadyToHalted_TransitionNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ReadyToHalted_TransitionNumber = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ReadyToHalted_TransitionNumber, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ParameterSet_TargetPosition = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ParameterSet_TargetPosition, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_Orientation Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ParameterSet_TargetPosition_Orientation = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ParameterSet_TargetPosition_Orientation, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates_X = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates_X, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates_Y = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates_Y, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates_Z = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ParameterSet_TargetPosition_CartesianCoordinates_Z, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_Orientation_A Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ParameterSet_TargetPosition_Orientation_A = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ParameterSet_TargetPosition_Orientation_A, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_Orientation_B Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ParameterSet_TargetPosition_Orientation_B = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ParameterSet_TargetPosition_Orientation_B, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the PositionStreamSkillType_ParameterSet_TargetPosition_Orientation_C Variable.
        /// </summary>
        public static readonly ExpandedNodeId PositionStreamSkillType_ParameterSet_TargetPosition_Orientation_C = new ExpandedNodeId(fortiss_Robotics.Variables.PositionStreamSkillType_ParameterSet_TargetPosition_Orientation_C, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_Locked Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Lock_Locked = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Lock_Locked, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_LockingClient Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Lock_LockingClient = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Lock_LockingClient, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_LockingUser Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Lock_LockingUser = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Lock_LockingUser, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_RemainingLockTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Lock_RemainingLockTime = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Lock_RemainingLockTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Lock_InitLock_InputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Lock_InitLock_InputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Lock_InitLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Lock_InitLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Lock_RenewLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Lock_RenewLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Lock_ExitLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Lock_ExitLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Lock_BreakLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Lock_BreakLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_SpeedOverride Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_ParameterSet_SpeedOverride = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_ParameterSet_SpeedOverride, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_Locked Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_Lock_Locked = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_Lock_Locked, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_LockingClient Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_Lock_LockingClient = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_Lock_LockingClient, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_LockingUser Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_Lock_LockingUser = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_Lock_LockingUser, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_RemainingLockTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_Lock_RemainingLockTime = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_Lock_RemainingLockTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_Lock_InitLock_InputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_Lock_InitLock_InputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_Lock_InitLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_Lock_InitLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_Lock_RenewLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_Lock_RenewLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_Lock_ExitLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_Lock_ExitLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_Lock_BreakLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_Lock_BreakLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_MotionProfile Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_MotionProfile = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_MotionProfile, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Mass Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Mass = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Mass, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Mass_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Mass_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Mass_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates_X = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates_X, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates_Y = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates_Y, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates_Z = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_CartesianCoordinates_Z, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation_A Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation_A = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation_A, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation_B Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation_B = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation_B, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation_C Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation_C = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_CenterOfMass_Orientation_C, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Inertia_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Inertia_X = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Inertia_X, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Inertia_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Inertia_Y = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Inertia_Y, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Inertia_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Inertia_Z = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_AdditionalLoad_Inertia_Z, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualPosition Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualPosition = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualPosition, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualPosition_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualPosition_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualPosition_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualSpeed_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualSpeed_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualSpeed_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualAcceleration_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualAcceleration_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_Axes_AxisIdentifier_ParameterSet_ActualAcceleration_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_Locked Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_Locked = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_Locked, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_LockingClient Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_LockingClient = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_LockingClient, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_LockingUser Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_LockingUser = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_LockingUser, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_RemainingLockTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_RemainingLockTime = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_RemainingLockTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_InitLock_InputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_InitLock_InputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_InitLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_InitLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_RenewLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_RenewLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_ExitLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_ExitLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_BreakLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_PowerTrains_PowerTrainIdentifier_Lock_BreakLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_Mass Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad_Mass = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeLoad_Mass, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_Mass_EngineeringUnits Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad_Mass_EngineeringUnits = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeLoad_Mass_EngineeringUnits, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad_CenterOfMass = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeLoad_CenterOfMass, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates_X = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates_X, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates_Y = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates_Y, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates_Z = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeLoad_CenterOfMass_CartesianCoordinates_Z, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation_A Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation_A = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation_A, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation_B Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation_B = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation_B, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation_C Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation_C = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeLoad_CenterOfMass_Orientation_C, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_Inertia Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad_Inertia = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeLoad_Inertia, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_Inertia_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad_Inertia_X = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeLoad_Inertia_X, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_Inertia_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad_Inertia_Y = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeLoad_Inertia_Y, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeLoad_Inertia_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeLoad_Inertia_Z = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeLoad_Inertia_Z, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_Locked Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_Locked = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_Locked, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_LockingClient Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_LockingClient = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_LockingClient, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_LockingUser Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_LockingUser = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_LockingUser, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_RemainingLockTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_RemainingLockTime = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_RemainingLockTime, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_InitLock_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_InitLock_InputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_InitLock_InputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_InitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_InitLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_InitLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_RenewLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_RenewLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_RenewLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_ExitLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_ExitLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_ExitLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_BreakLock_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_BreakLock_OutputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_AdditionalComponents_AdditionalComponentIdentifier_Lock_BreakLock_OutputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeToolSet_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeToolSet_InputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeToolSet_InputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeToolClear_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeToolClear_InputArguments = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeToolClear_InputArguments, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeTool_Name = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeTool_Name, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeTool_ThreeDFrame = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeTool_ThreeDFrame, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates_X = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates_X, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates_Y = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates_Y, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates_Z = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeTool_ThreeDFrame_CartesianCoordinates_Z, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation_A Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation_A = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation_A, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation_B Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation_B = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation_B, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation_C Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation_C = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_FlangeTool_ThreeDFrame_Orientation_C, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_ParameterSet_WorldToRobotBase = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_ParameterSet_WorldToRobotBase, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates_X Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates_X = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates_X, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates_Y Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates_Y = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates_Y, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates_Z Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates_Z = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_ParameterSet_WorldToRobotBase_CartesianCoordinates_Z, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation_A Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation_A = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation_A, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation_B Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation_B = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation_B, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation_C Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation_C = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_ParameterSet_WorldToRobotBase_Orientation_C, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_DeviceOnPath Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_ParameterSet_DeviceOnPath = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_ParameterSet_DeviceOnPath, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_ProgrammedDeviceSpeed Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_ParameterSet_ProgrammedDeviceSpeed = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_ParameterSet_ProgrammedDeviceSpeed, fortiss_Robotics.Namespaces.fortissRobotics);

        /// <summary>
        /// The identifier for the FortissMotionDeviceType_ParameterSet_UnderControl Variable.
        /// </summary>
        public static readonly ExpandedNodeId FortissMotionDeviceType_ParameterSet_UnderControl = new ExpandedNodeId(fortiss_Robotics.Variables.FortissMotionDeviceType_ParameterSet_UnderControl, fortiss_Robotics.Namespaces.fortissRobotics);
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
        /// The BrowseName for the CartesianLinearForceMoveSkillType component.
        /// </summary>
        public const string CartesianLinearForceMoveSkillType = "CartesianLinearForceMoveSkillType";

        /// <summary>
        /// The BrowseName for the CartesianLinearMoveSkillType component.
        /// </summary>
        public const string CartesianLinearMoveSkillType = "CartesianLinearMoveSkillType";

        /// <summary>
        /// The BrowseName for the CartesianPtpMoveSkillType component.
        /// </summary>
        public const string CartesianPtpMoveSkillType = "CartesianPtpMoveSkillType";

        /// <summary>
        /// The BrowseName for the FinishStateMachine component.
        /// </summary>
        public const string FinishStateMachine = "FinishStateMachine";

        /// <summary>
        /// The BrowseName for the FinishStateMachineType component.
        /// </summary>
        public const string FinishStateMachineType = "FinishStateMachineType";

        /// <summary>
        /// The BrowseName for the FlangeLoad component.
        /// </summary>
        public const string FlangeLoad = "FlangeLoad";

        /// <summary>
        /// The BrowseName for the FlangeTool component.
        /// </summary>
        public const string FlangeTool = "FlangeTool";

        /// <summary>
        /// The BrowseName for the FlangeToolClear component.
        /// </summary>
        public const string FlangeToolClear = "FlangeToolClear";

        /// <summary>
        /// The BrowseName for the FlangeToolSet component.
        /// </summary>
        public const string FlangeToolSet = "FlangeToolSet";

        /// <summary>
        /// The BrowseName for the ForceExceeded component.
        /// </summary>
        public const string ForceExceeded = "ForceExceeded";

        /// <summary>
        /// The BrowseName for the ForceExceededToHalted component.
        /// </summary>
        public const string ForceExceededToHalted = "ForceExceededToHalted";

        /// <summary>
        /// The BrowseName for the ForceExceededToRunning component.
        /// </summary>
        public const string ForceExceededToRunning = "ForceExceededToRunning";

        /// <summary>
        /// The BrowseName for the FortissMotionDeviceType component.
        /// </summary>
        public const string FortissMotionDeviceType = "FortissMotionDeviceType";

        /// <summary>
        /// The BrowseName for the FortissRoboticsNamespaceMetadata component.
        /// </summary>
        public const string FortissRoboticsNamespaceMetadata = "https://fortiss.org/UA/Robotics/";

        /// <summary>
        /// The BrowseName for the ICartesianMoveSkillParameterType component.
        /// </summary>
        public const string ICartesianMoveSkillParameterType = "ICartesianMoveSkillParameterType";

        /// <summary>
        /// The BrowseName for the IForceMoveParameterType component.
        /// </summary>
        public const string IForceMoveParameterType = "IForceMoveParameterType";

        /// <summary>
        /// The BrowseName for the IJointMoveSkillParameterType component.
        /// </summary>
        public const string IJointMoveSkillParameterType = "IJointMoveSkillParameterType";

        /// <summary>
        /// The BrowseName for the JointLinearMoveSkillType component.
        /// </summary>
        public const string JointLinearMoveSkillType = "JointLinearMoveSkillType";

        /// <summary>
        /// The BrowseName for the JointPtpMoveSkillType component.
        /// </summary>
        public const string JointPtpMoveSkillType = "JointPtpMoveSkillType";

        /// <summary>
        /// The BrowseName for the LinearMoveSkillType component.
        /// </summary>
        public const string LinearMoveSkillType = "LinearMoveSkillType";

        /// <summary>
        /// The BrowseName for the MoveSkillType component.
        /// </summary>
        public const string MoveSkillType = "MoveSkillType";

        /// <summary>
        /// The BrowseName for the PositionStreamSkillType component.
        /// </summary>
        public const string PositionStreamSkillType = "PositionStreamSkillType";

        /// <summary>
        /// The BrowseName for the PtpMoveSkillType component.
        /// </summary>
        public const string PtpMoveSkillType = "PtpMoveSkillType";

        /// <summary>
        /// The BrowseName for the RunningToForceExceeded component.
        /// </summary>
        public const string RunningToForceExceeded = "RunningToForceExceeded";

        /// <summary>
        /// The BrowseName for the RunningToSuccess component.
        /// </summary>
        public const string RunningToSuccess = "RunningToSuccess";

        /// <summary>
        /// The BrowseName for the StreamSkillType component.
        /// </summary>
        public const string StreamSkillType = "StreamSkillType";

        /// <summary>
        /// The BrowseName for the Success component.
        /// </summary>
        public const string Success = "Success";

        /// <summary>
        /// The BrowseName for the SuccessToHalted component.
        /// </summary>
        public const string SuccessToHalted = "SuccessToHalted";

        /// <summary>
        /// The BrowseName for the SuccessToRunning component.
        /// </summary>
        public const string SuccessToRunning = "SuccessToRunning";
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
        /// The URI for the fortissRobotics namespace (.NET code namespace is 'fortiss_Robotics').
        /// </summary>
        public const string fortissRobotics = "https://fortiss.org/UA/Robotics/";

        /// <summary>
        /// The URI for the fortissRoboticsXsd namespace (.NET code namespace is 'fortiss_Robotics').
        /// </summary>
        public const string fortissRoboticsXsd = "https://fortiss.org/UA/Robotics/Types.xsd";

        /// <summary>
        /// The URI for the fortissDevice namespace (.NET code namespace is 'fortiss_Device').
        /// </summary>
        public const string fortissDevice = "https://fortiss.org/UA/Device/";

        /// <summary>
        /// The URI for the fortissDeviceXsd namespace (.NET code namespace is 'fortiss_Device').
        /// </summary>
        public const string fortissDeviceXsd = "https://fortiss.org/UA/Device/Types.xsd";

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
        /// The URI for the OpcUaRobotics namespace (.NET code namespace is 'Opc.Ua.Robotics').
        /// </summary>
        public const string OpcUaRobotics = "http://opcfoundation.org/UA/Robotics/";

        /// <summary>
        /// The URI for the OpcUaRoboticsXsd namespace (.NET code namespace is 'Opc.Ua.Robotics').
        /// </summary>
        public const string OpcUaRoboticsXsd = "http://opcfoundation.org/UA/Robotics/Types.xsd";
    }
    #endregion
}