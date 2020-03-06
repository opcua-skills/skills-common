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
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;
using Opc.Ua.Di;

namespace fortiss_Device
{
    #region SkillState Class
    #if (!OPCUA_EXCLUDE_SkillState)
    /// <summary>
    /// Stores an instance of the SkillType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class SkillState : ProgramStateMachineState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public SkillState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Device.ObjectTypes.SkillType, fortiss_Device.Namespaces.fortissDevice, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);

            if (FinalResultData != null)
            {
                FinalResultData.Initialize(context, FinalResultData_InitializationString);
            }
        }

        #region Initialization String
        private const string FinalResultData_InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////8EYIAKAQAAAAAADwAAAEZpbmFsUmVzdWx0RGF0YQEC3DoALwA63DoAAP//" +
           "//8AAAAA";

        private const string InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////8EYIACAQAAAAIAEQAAAFNraWxsVHlwZUluc3RhbmNlAQK6OgECujq6OgAA" +
           "/////wwAAAAVYIkKAgAAAAAADAAAAEN1cnJlbnRTdGF0ZQECuzoALwEAyAq7OgAAABX/////AQH/////" +
           "AgAAABVgiQoCAAAAAAACAAAASWQBArw6AC4ARLw6AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYA" +
           "AABOdW1iZXIBAr46AC4ARL46AAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABMYXN0VHJhbnNp" +
           "dGlvbgECwDoALwEAzwrAOgAAABX/////AQH/////AwAAABVgiQoCAAAAAAACAAAASWQBAsE6AC4ARME6" +
           "AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABOdW1iZXIBAsM6AC4ARMM6AAAAB/////8BAf//" +
           "//8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQECxDoALgBExDoAAAEAJgH/////AQH/////" +
           "AAAAABVgiQoCAAAAAAAJAAAARGVsZXRhYmxlAQLJOgAuAETJOgAAAAH/////AQH/////AAAAABVgiQoC" +
           "AAAAAAAKAAAAQXV0b0RlbGV0ZQECyjoALgBEyjoAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAA" +
           "AFJlY3ljbGVDb3VudAECyzoALgBEyzoAAAAG/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAE1heElu" +
           "c3RhbmNlQ291bnQBAs06AC4ARM06AAAAB/////8BAf////8AAAAABGCACgEAAAAAAA8AAABGaW5hbFJl" +
           "c3VsdERhdGEBAtw6AC8AOtw6AAD/////AAAAAARhggoEAAAAAAAFAAAAU3RhcnQBAvc6AC8BAHoJ9zoA" +
           "AAEBAQAAAAA1AQEC5zoAAAAABGGCCgQAAAAAAAcAAABTdXNwZW5kAQL4OgAvAQB7Cfg6AAABAQEAAAAA" +
           "NQEBAu06AAAAAARhggoEAAAAAAAGAAAAUmVzdW1lAQL5OgAvAQB8Cfk6AAABAQEAAAAANQEBAu86AAAA" +
           "AARhggoEAAAAAAAEAAAASGFsdAEC+joALwEAfQn6OgAAAQEDAAAAADUBAQLpOgA1AQEC8ToANQEBAvU6" +
           "AAAAAARhggoEAAAAAAAFAAAAUmVzZXQBAvs6AC8BAH4J+zoAAAEBAQAAAAA1AQEC5ToAAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public MethodState Halt
        {
            get
            {
                return m_haltMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_haltMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_haltMethod = value;
            }
        }

        /// <remarks />
        public MethodState Reset
        {
            get
            {
                return m_resetMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_resetMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_resetMethod = value;
            }
        }

        /// <remarks />
        public MethodState Resume
        {
            get
            {
                return m_resumeMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_resumeMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_resumeMethod = value;
            }
        }

        /// <remarks />
        public MethodState Suspend
        {
            get
            {
                return m_suspendMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_suspendMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_suspendMethod = value;
            }
        }

        /// <remarks />
        public MethodState Start
        {
            get
            {
                return m_startMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_startMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_startMethod = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_haltMethod != null)
            {
                children.Add(m_haltMethod);
            }

            if (m_resetMethod != null)
            {
                children.Add(m_resetMethod);
            }

            if (m_resumeMethod != null)
            {
                children.Add(m_resumeMethod);
            }

            if (m_suspendMethod != null)
            {
                children.Add(m_suspendMethod);
            }

            if (m_startMethod != null)
            {
                children.Add(m_startMethod);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.BrowseNames.Halt:
                {
                    if (createOrReplace)
                    {
                        if (Halt == null)
                        {
                            if (replacement == null)
                            {
                                Halt = new MethodState(this);
                            }
                            else
                            {
                                Halt = (MethodState)replacement;
                            }
                        }
                    }

                    instance = Halt;
                    break;
                }

                case Opc.Ua.BrowseNames.Reset:
                {
                    if (createOrReplace)
                    {
                        if (Reset == null)
                        {
                            if (replacement == null)
                            {
                                Reset = new MethodState(this);
                            }
                            else
                            {
                                Reset = (MethodState)replacement;
                            }
                        }
                    }

                    instance = Reset;
                    break;
                }

                case Opc.Ua.BrowseNames.Resume:
                {
                    if (createOrReplace)
                    {
                        if (Resume == null)
                        {
                            if (replacement == null)
                            {
                                Resume = new MethodState(this);
                            }
                            else
                            {
                                Resume = (MethodState)replacement;
                            }
                        }
                    }

                    instance = Resume;
                    break;
                }

                case Opc.Ua.BrowseNames.Suspend:
                {
                    if (createOrReplace)
                    {
                        if (Suspend == null)
                        {
                            if (replacement == null)
                            {
                                Suspend = new MethodState(this);
                            }
                            else
                            {
                                Suspend = (MethodState)replacement;
                            }
                        }
                    }

                    instance = Suspend;
                    break;
                }

                case Opc.Ua.BrowseNames.Start:
                {
                    if (createOrReplace)
                    {
                        if (Start == null)
                        {
                            if (replacement == null)
                            {
                                Start = new MethodState(this);
                            }
                            else
                            {
                                Start = (MethodState)replacement;
                            }
                        }
                    }

                    instance = Start;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private MethodState m_haltMethod;
        private MethodState m_resetMethod;
        private MethodState m_resumeMethod;
        private MethodState m_suspendMethod;
        private MethodState m_startMethod;
        #endregion
    }
    #endif
    #endregion

    #region GripperSkillState Class
    #if (!OPCUA_EXCLUDE_GripperSkillState)
    /// <summary>
    /// Stores an instance of the GripperSkillType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GripperSkillState : SkillState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GripperSkillState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Device.ObjectTypes.GripperSkillType, fortiss_Device.Namespaces.fortissDevice, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////8EYIACAQAAAAIAGAAAAEdyaXBwZXJTa2lsbFR5cGVJbnN0YW5jZQEC/ToB" +
           "Av06/ToAAP////8LAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBAv46AC8BAMgK/joAAAAV////" +
           "/wEB/////wIAAAAVYIkKAgAAAAAAAgAAAElkAQL/OgAuAET/OgAAABH/////AQH/////AAAAABVgiQoC" +
           "AAAAAAAGAAAATnVtYmVyAQIBOwAuAEQBOwAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAOAAAATGFz" +
           "dFRyYW5zaXRpb24BAgM7AC8BAM8KAzsAAAAV/////wEB/////wMAAAAVYIkKAgAAAAAAAgAAAElkAQIE" +
           "OwAuAEQEOwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAATnVtYmVyAQIGOwAuAEQGOwAAAAf/" +
           "////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBAgc7AC4ARAc7AAABACYB////" +
           "/wEB/////wAAAAAVYIkKAgAAAAAACQAAAERlbGV0YWJsZQECDDsALgBEDDsAAAAB/////wEB/////wAA" +
           "AAAVYIkKAgAAAAAACgAAAEF1dG9EZWxldGUBAg07AC4ARA07AAAAAf////8BAf////8AAAAAFWCJCgIA" +
           "AAAAAAwAAABSZWN5Y2xlQ291bnQBAg47AC4ARA47AAAABv////8BAf////8AAAAAFWCJCgIAAAAAABAA" +
           "AABNYXhJbnN0YW5jZUNvdW50AQIQOwAuAEQQOwAAAAf/////AQH/////AAAAAARhggoEAAAAAAAFAAAA" +
           "U3RhcnQBAjo7AC8BAHoJOjsAAAEBAQAAAAA1AQECKjsAAAAABGGCCgQAAAAAAAcAAABTdXNwZW5kAQI7" +
           "OwAvAQB7CTs7AAABAQEAAAAANQEBAjA7AAAAAARhggoEAAAAAAAGAAAAUmVzdW1lAQI8OwAvAQB8CTw7" +
           "AAABAQEAAAAANQEBAjI7AAAAAARhggoEAAAAAAAEAAAASGFsdAECPTsALwEAfQk9OwAAAQEDAAAAADUB" +
           "AQIsOwA1AQECNDsANQEBAjg7AAAAAARhggoEAAAAAAAFAAAAUmVzZXQBAj47AC8BAH4JPjsAAAEBAQAA" +
           "AAA1AQECKDsAAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region GraspGripperSkillState Class
    #if (!OPCUA_EXCLUDE_GraspGripperSkillState)
    /// <summary>
    /// Stores an instance of the GraspGripperSkillType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GraspGripperSkillState : GripperSkillState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GraspGripperSkillState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Device.ObjectTypes.GraspGripperSkillType, fortiss_Device.Namespaces.fortissDevice, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);

            if (ParameterSet != null)
            {
                ParameterSet.Initialize(context, ParameterSet_InitializationString);
            }
        }

        #region Initialization String
        private const string ParameterSet_InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////8EYIAKAQAAAAEADAAAAFBhcmFtZXRlclNldAECgzsALwA6gzsAAP////8B" +
           "AAAANWCJCgIAAAACAAUAAABGb3JjZQEChDsDAAAAABEAAABUaGUgZ3JpcHBlciBmb3JjZQAvAQBACYQ7" +
           "AAAAC/////8DA/////8BAAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQKIOwAuAESIOwAAAQB0A/////8B" +
           "Af////8AAAAA";

        private const string InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////8EYIACAQAAAAIAHQAAAEdyYXNwR3JpcHBlclNraWxsVHlwZUluc3RhbmNl" +
           "AQJAOwECQDtAOwAA/////wwAAAAVYIkKAgAAAAAADAAAAEN1cnJlbnRTdGF0ZQECQTsALwEAyApBOwAA" +
           "ABX/////AQH/////AgAAABVgiQoCAAAAAAACAAAASWQBAkI7AC4AREI7AAAAEf////8BAf////8AAAAA" +
           "FWCJCgIAAAAAAAYAAABOdW1iZXIBAkQ7AC4AREQ7AAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA4A" +
           "AABMYXN0VHJhbnNpdGlvbgECRjsALwEAzwpGOwAAABX/////AQH/////AwAAABVgiQoCAAAAAAACAAAA" +
           "SWQBAkc7AC4AREc7AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABOdW1iZXIBAkk7AC4AREk7" +
           "AAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQECSjsALgBESjsAAAEA" +
           "JgH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAARGVsZXRhYmxlAQJPOwAuAERPOwAAAAH/////AQH/" +
           "////AAAAABVgiQoCAAAAAAAKAAAAQXV0b0RlbGV0ZQECUDsALgBEUDsAAAAB/////wEB/////wAAAAAV" +
           "YIkKAgAAAAAADAAAAFJlY3ljbGVDb3VudAECUTsALgBEUTsAAAAG/////wEB/////wAAAAAVYIkKAgAA" +
           "AAAAEAAAAE1heEluc3RhbmNlQ291bnQBAlM7AC4ARFM7AAAAB/////8BAf////8AAAAABGGCCgQAAAAA" +
           "AAUAAABTdGFydAECfTsALwEAegl9OwAAAQEBAAAAADUBAQJtOwAAAAAEYYIKBAAAAAAABwAAAFN1c3Bl" +
           "bmQBAn47AC8BAHsJfjsAAAEBAQAAAAA1AQECczsAAAAABGGCCgQAAAAAAAYAAABSZXN1bWUBAn87AC8B" +
           "AHwJfzsAAAEBAQAAAAA1AQECdTsAAAAABGGCCgQAAAAAAAQAAABIYWx0AQKAOwAvAQB9CYA7AAABAQMA" +
           "AAAANQEBAm87ADUBAQJ3OwA1AQECezsAAAAABGGCCgQAAAAAAAUAAABSZXNldAECgTsALwEAfgmBOwAA" +
           "AQEBAAAAADUBAQJrOwAAAAAEYIAKAQAAAAEADAAAAFBhcmFtZXRlclNldAECgzsALwA6gzsAAP////8B" +
           "AAAANWCJCgIAAAACAAUAAABGb3JjZQEChDsDAAAAABEAAABUaGUgZ3JpcHBlciBmb3JjZQAvAQBACYQ7" +
           "AAAAC/////8DA/////8BAAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQKIOwAuAESIOwAAAQB0A/////8B" +
           "Af////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseObjectState ParameterSet
        {
            get
            {
                return m_parameterSet;
            }

            set
            {
                if (!Object.ReferenceEquals(m_parameterSet, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_parameterSet = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_parameterSet != null)
            {
                children.Add(m_parameterSet);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Di.BrowseNames.ParameterSet:
                {
                    if (createOrReplace)
                    {
                        if (ParameterSet == null)
                        {
                            if (replacement == null)
                            {
                                ParameterSet = new BaseObjectState(this);
                            }
                            else
                            {
                                ParameterSet = (BaseObjectState)replacement;
                            }
                        }
                    }

                    instance = ParameterSet;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseObjectState m_parameterSet;
        #endregion
    }
    #endif
    #endregion

    #region ReleaseGripperSkillState Class
    #if (!OPCUA_EXCLUDE_ReleaseGripperSkillState)
    /// <summary>
    /// Stores an instance of the ReleaseGripperSkillType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ReleaseGripperSkillState : GripperSkillState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ReleaseGripperSkillState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Device.ObjectTypes.ReleaseGripperSkillType, fortiss_Device.Namespaces.fortissDevice, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);

            if (ParameterSet != null)
            {
                ParameterSet.Initialize(context, ParameterSet_InitializationString);
            }
        }

        #region Initialization String
        private const string ParameterSet_InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////8EYIAKAQAAAAEADAAAAFBhcmFtZXRlclNldAECRz4ALwA6Rz4AAP////8B" +
           "AAAANWCJCgIAAAACAAUAAABGb3JjZQECSD4DAAAAABEAAABUaGUgZ3JpcHBlciBmb3JjZQAvAQBACUg+" +
           "AAAAC/////8DA/////8BAAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQJMPgAuAERMPgAAAQB0A/////8B" +
           "Af////8AAAAA";

        private const string InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////8EYIACAQAAAAIAHwAAAFJlbGVhc2VHcmlwcGVyU2tpbGxUeXBlSW5zdGFu" +
           "Y2UBAnE8AQJxPHE8AAD/////DAAAABVgiQoCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQJWPQAvAQDIClY9" +
           "AAAAFf////8BAf////8CAAAAFWCJCgIAAAAAAAIAAABJZAECej0ALgBEej0AAAAR/////wEB/////wAA" +
           "AAAVYIkKAgAAAAAABgAAAE51bWJlcgECxD0ALgBExD0AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAA" +
           "DgAAAExhc3RUcmFuc2l0aW9uAQIKPgAvAQDPCgo+AAAAFf////8BAf////8DAAAAFWCJCgIAAAAAAAIA" +
           "AABJZAECCz4ALgBECz4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgECDT4ALgBE" +
           "DT4AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQIOPgAuAEQOPgAA" +
           "AQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABEZWxldGFibGUBAhM+AC4ARBM+AAAAAf////8B" +
           "Af////8AAAAAFWCJCgIAAAAAAAoAAABBdXRvRGVsZXRlAQIUPgAuAEQUPgAAAAH/////AQH/////AAAA" +
           "ABVgiQoCAAAAAAAMAAAAUmVjeWNsZUNvdW50AQIVPgAuAEQVPgAAAAb/////AQH/////AAAAABVgiQoC" +
           "AAAAAAAQAAAATWF4SW5zdGFuY2VDb3VudAECFz4ALgBEFz4AAAAH/////wEB/////wAAAAAEYYIKBAAA" +
           "AAAABQAAAFN0YXJ0AQJBPgAvAQB6CUE+AAABAQEAAAAANQEBAjE+AAAAAARhggoEAAAAAAAHAAAAU3Vz" +
           "cGVuZAECQj4ALwEAewlCPgAAAQEBAAAAADUBAQI3PgAAAAAEYYIKBAAAAAAABgAAAFJlc3VtZQECQz4A" +
           "LwEAfAlDPgAAAQEBAAAAADUBAQI5PgAAAAAEYYIKBAAAAAAABAAAAEhhbHQBAkQ+AC8BAH0JRD4AAAEB" +
           "AwAAAAA1AQECMz4ANQEBAjs+ADUBAQI/PgAAAAAEYYIKBAAAAAAABQAAAFJlc2V0AQJFPgAvAQB+CUU+" +
           "AAABAQEAAAAANQEBAi8+AAAAAARggAoBAAAAAQAMAAAAUGFyYW1ldGVyU2V0AQJHPgAvADpHPgAA////" +
           "/wEAAAA1YIkKAgAAAAIABQAAAEZvcmNlAQJIPgMAAAAAEQAAAFRoZSBncmlwcGVyIGZvcmNlAC8BAEAJ" +
           "SD4AAAAL/////wMD/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBAkw+AC4AREw+AAABAHQD////" +
           "/wEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseObjectState ParameterSet
        {
            get
            {
                return m_parameterSet;
            }

            set
            {
                if (!Object.ReferenceEquals(m_parameterSet, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_parameterSet = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_parameterSet != null)
            {
                children.Add(m_parameterSet);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Di.BrowseNames.ParameterSet:
                {
                    if (createOrReplace)
                    {
                        if (ParameterSet == null)
                        {
                            if (replacement == null)
                            {
                                ParameterSet = new BaseObjectState(this);
                            }
                            else
                            {
                                ParameterSet = (BaseObjectState)replacement;
                            }
                        }
                    }

                    instance = ParameterSet;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseObjectState m_parameterSet;
        #endregion
    }
    #endif
    #endregion

    #region MoveGripperSkillState Class
    #if (!OPCUA_EXCLUDE_MoveGripperSkillState)
    /// <summary>
    /// Stores an instance of the MoveGripperSkillType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class MoveGripperSkillState : GripperSkillState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public MoveGripperSkillState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Device.ObjectTypes.MoveGripperSkillType, fortiss_Device.Namespaces.fortissDevice, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////8EYIACAQAAAAIAHAAAAE1vdmVHcmlwcGVyU2tpbGxUeXBlSW5zdGFuY2UB" +
           "Ak4+AQJOPk4+AAD/////DAAAABVgiQoCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQJPPgAvAQDICk8+AAAA" +
           "Ff////8BAf////8CAAAAFWCJCgIAAAAAAAIAAABJZAECUD4ALgBEUD4AAAAR/////wEB/////wAAAAAV" +
           "YIkKAgAAAAAABgAAAE51bWJlcgECUj4ALgBEUj4AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAA" +
           "AExhc3RUcmFuc2l0aW9uAQJUPgAvAQDPClQ+AAAAFf////8BAf////8DAAAAFWCJCgIAAAAAAAIAAABJ" +
           "ZAECVT4ALgBEVT4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgECVz4ALgBEVz4A" +
           "AAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQJYPgAuAERYPgAAAQAm" +
           "Af////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABEZWxldGFibGUBAl0+AC4ARF0+AAAAAf////8BAf//" +
           "//8AAAAAFWCJCgIAAAAAAAoAAABBdXRvRGVsZXRlAQJePgAuAERePgAAAAH/////AQH/////AAAAABVg" +
           "iQoCAAAAAAAMAAAAUmVjeWNsZUNvdW50AQJfPgAuAERfPgAAAAb/////AQH/////AAAAABVgiQoCAAAA" +
           "AAAQAAAATWF4SW5zdGFuY2VDb3VudAECYT4ALgBEYT4AAAAH/////wEB/////wAAAAAEYYIKBAAAAAAA" +
           "BQAAAFN0YXJ0AQKLPgAvAQB6CYs+AAABAQEAAAAANQEBAns+AAAAAARhggoEAAAAAAAHAAAAU3VzcGVu" +
           "ZAECjD4ALwEAewmMPgAAAQEBAAAAADUBAQKBPgAAAAAEYYIKBAAAAAAABgAAAFJlc3VtZQECjT4ALwEA" +
           "fAmNPgAAAQEBAAAAADUBAQKDPgAAAAAEYYIKBAAAAAAABAAAAEhhbHQBAo4+AC8BAH0Jjj4AAAEBAwAA" +
           "AAA1AQECfT4ANQEBAoU+ADUBAQKJPgAAAAAEYYIKBAAAAAAABQAAAFJlc2V0AQKPPgAvAQB+CY8+AAAB" +
           "AQEAAAAANQEBAnk+AAAAAARggAoBAAAAAQAMAAAAUGFyYW1ldGVyU2V0AQKRPgAvADqRPgAA/////wIA" +
           "AAA1YIkKAgAAAAIABQAAAFdpZHRoAQKSPgMAAAAAEQAAAFRoZSBncmlwcGVyIHdpZHRoAC8BAEAJkj4A" +
           "AAAL/////wMD/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBApY+AC4ARJY+AAABAHQD/////wEB" +
           "/////wAAAAA1YIkKAgAAAAIABQAAAEZvcmNlAQKYPgMAAAAAEQAAAFRoZSBncmlwcGVyIGZvcmNlAC8B" +
           "AEAJmD4AAAAL/////wMD/////wEAAAAVYIkKAgAAAAAABwAAAEVVUmFuZ2UBApw+AC4ARJw+AAABAHQD" +
           "/////wEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseObjectState ParameterSet
        {
            get
            {
                return m_parameterSet;
            }

            set
            {
                if (!Object.ReferenceEquals(m_parameterSet, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_parameterSet = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_parameterSet != null)
            {
                children.Add(m_parameterSet);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Di.BrowseNames.ParameterSet:
                {
                    if (createOrReplace)
                    {
                        if (ParameterSet == null)
                        {
                            if (replacement == null)
                            {
                                ParameterSet = new BaseObjectState(this);
                            }
                            else
                            {
                                ParameterSet = (BaseObjectState)replacement;
                            }
                        }
                    }

                    instance = ParameterSet;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseObjectState m_parameterSet;
        #endregion
    }
    #endif
    #endregion

    #region ISkillControllerState Class
    #if (!OPCUA_EXCLUDE_ISkillControllerState)
    /// <summary>
    /// Stores an instance of the ISkillControllerType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ISkillControllerState : BaseInterfaceState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ISkillControllerState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Device.ObjectTypes.ISkillControllerType, fortiss_Device.Namespaces.fortissDevice, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);

            if (Name != null)
            {
                Name.Initialize(context, Name_InitializationString);
            }
        }

        #region Initialization String
        private const string Name_InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////8VYIkKAgAAAAIABAAAAE5hbWUBAiU8AC4ARCU8AAAAFf////8BAf////8A" +
           "AAAA";

        private const string InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////+EYIACAQAAAAIAHAAAAElTa2lsbENvbnRyb2xsZXJUeXBlSW5zdGFuY2UB" +
           "AiQ8AQIkPCQ8AAAB/////wIAAAAVYIkKAgAAAAIABAAAAE5hbWUBAiU8AC4ARCU8AAAAFf////8BAf//" +
           "//8AAAAAJGCACgEAAAACAAYAAABTa2lsbHMBAiY8AwAAAAAkAAAAQ29udGFpbnMgdGhlIHNraWxscyBv" +
           "ZiB0aGUgQ29tcG9uZW50AC8AOiY8AAD/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public PropertyState<LocalizedText> Name
        {
            get
            {
                return m_name;
            }

            set
            {
                if (!Object.ReferenceEquals(m_name, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_name = value;
            }
        }

        /// <remarks />
        public BaseObjectState Skills
        {
            get
            {
                return m_skills;
            }

            set
            {
                if (!Object.ReferenceEquals(m_skills, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_skills = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_name != null)
            {
                children.Add(m_name);
            }

            if (m_skills != null)
            {
                children.Add(m_skills);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case fortiss_Device.BrowseNames.Name:
                {
                    if (createOrReplace)
                    {
                        if (Name == null)
                        {
                            if (replacement == null)
                            {
                                Name = new PropertyState<LocalizedText>(this);
                            }
                            else
                            {
                                Name = (PropertyState<LocalizedText>)replacement;
                            }
                        }
                    }

                    instance = Name;
                    break;
                }

                case fortiss_Device.BrowseNames.Skills:
                {
                    if (createOrReplace)
                    {
                        if (Skills == null)
                        {
                            if (replacement == null)
                            {
                                Skills = new BaseObjectState(this);
                            }
                            else
                            {
                                Skills = (BaseObjectState)replacement;
                            }
                        }
                    }

                    instance = Skills;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<LocalizedText> m_name;
        private BaseObjectState m_skills;
        #endregion
    }
    #endif
    #endregion

    #region IPowerOffDeviceState Class
    #if (!OPCUA_EXCLUDE_IPowerOffDeviceState)
    /// <summary>
    /// Stores an instance of the IPowerOffDeviceType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class IPowerOffDeviceState : BaseInterfaceState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public IPowerOffDeviceState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Device.ObjectTypes.IPowerOffDeviceType, fortiss_Device.Namespaces.fortissDevice, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////+EYIACAQAAAAIAGwAAAElQb3dlck9mZkRldmljZVR5cGVJbnN0YW5jZQEC" +
           "jzsBAo87jzsAAAH/////AQAAAARhggoEAAAAAgAOAAAAUG93ZXJPZmZEZXZpY2UBApA7AC8BApA7kDsA" +
           "AAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQKROwAuAESROwAAlgEAAAABACoB" +
           "ARYAAAAHAAAARGVsYXlNcwAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public PowerOffDeviceMethodState PowerOffDevice
        {
            get
            {
                return m_powerOffDeviceMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_powerOffDeviceMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_powerOffDeviceMethod = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_powerOffDeviceMethod != null)
            {
                children.Add(m_powerOffDeviceMethod);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case fortiss_Device.BrowseNames.PowerOffDevice:
                {
                    if (createOrReplace)
                    {
                        if (PowerOffDevice == null)
                        {
                            if (replacement == null)
                            {
                                PowerOffDevice = new PowerOffDeviceMethodState(this);
                            }
                            else
                            {
                                PowerOffDevice = (PowerOffDeviceMethodState)replacement;
                            }
                        }
                    }

                    instance = PowerOffDevice;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PowerOffDeviceMethodState m_powerOffDeviceMethod;
        #endregion
    }
    #endif
    #endregion

    #region PowerOffDeviceMethodState Class
    #if (!OPCUA_EXCLUDE_PowerOffDeviceMethodState)
    /// <summary>
    /// Stores an instance of the PowerOffDeviceMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class PowerOffDeviceMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public PowerOffDeviceMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new PowerOffDeviceMethodState(parent);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////8EYYIKBAAAAAIAGAAAAFBvd2VyT2ZmRGV2aWNlTWV0aG9kVHlwZQECkjsA" +
           "LwECkjuSOwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBApM7AC4ARJM7AACW" +
           "AQAAAAEAKgEBFgAAAAcAAABEZWxheU1zAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAA" +
           "AA==";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public PowerOffDeviceMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        protected override ServiceResult Call(
            ISystemContext _context,
            NodeId _objectId,
            IList<object> _inputArguments,
            IList<object> _outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(_context, _objectId, _inputArguments, _outputArguments);
            }

            ServiceResult result = null;

            uint delayMs = (uint)_inputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    _context,
                    this,
                    _objectId,
                    delayMs);
            }

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult PowerOffDeviceMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        uint delayMs);
    #endif
    #endregion

    #region GripPointState Class
    #if (!OPCUA_EXCLUDE_GripPointState)
    /// <summary>
    /// Stores an instance of the GripPoint ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GripPointState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GripPointState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Device.ObjectTypes.GripPoint, fortiss_Device.Namespaces.fortissDevice, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////8EYIACAQAAAAIAEQAAAEdyaXBQb2ludEluc3RhbmNlAQKWOwECljuWOwAA" +
           "/////wIAAAA1YIkKAgAAAAIABAAAAFR5cGUBApc7AwAAAAANAAAAR3JpcHBpbmcgdHlwZQAvAD+XOwAA" +
           "AQKUO/////8BAf////8AAAAANWCJCgIAAAACAAYAAABPZmZzZXQBApg7AwAAAAA1AAAAT2Zmc2V0IHRv" +
           "IHRoZSBncmlwcGluZyBwb2ludCBmcm9tIHRoZSB0b29sIGJhc2UgZnJhbWUALwEAZ0mYOwAAAQB+Sf//" +
           "//8BAf////8CAAAAFWCJCgIAAAAAABQAAABDYXJ0ZXNpYW5Db29yZGluYXRlcwECmTsALwEAVkmZOwAA" +
           "AQB6Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABYAQKgOwAvAD+gOwAAAAv/////AQH/////AAAA" +
           "ABVgiQoCAAAAAAABAAAAWQECoTsALwA/oTsAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAFoB" +
           "AqI7AC8AP6I7AAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABPcmllbnRhdGlvbgECmzsALwEA" +
           "XUmbOwAAAQB8Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABBAQKjOwAvAD+jOwAAAAv/////AQH/" +
           "////AAAAABVgiQoCAAAAAAABAAAAQgECpDsALwA/pDsAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAA" +
           "AQAAAEMBAqU7AC8AP6U7AAAAC/////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseDataVariableState<GripTypeEnumeration> Type
        {
            get
            {
                return m_type;
            }

            set
            {
                if (!Object.ReferenceEquals(m_type, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_type = value;
            }
        }

        /// <remarks />
        public ThreeDFrameState Offset
        {
            get
            {
                return m_offset;
            }

            set
            {
                if (!Object.ReferenceEquals(m_offset, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_offset = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_type != null)
            {
                children.Add(m_type);
            }

            if (m_offset != null)
            {
                children.Add(m_offset);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case fortiss_Device.BrowseNames.Type:
                {
                    if (createOrReplace)
                    {
                        if (Type == null)
                        {
                            if (replacement == null)
                            {
                                Type = new BaseDataVariableState<GripTypeEnumeration>(this);
                            }
                            else
                            {
                                Type = (BaseDataVariableState<GripTypeEnumeration>)replacement;
                            }
                        }
                    }

                    instance = Type;
                    break;
                }

                case fortiss_Device.BrowseNames.Offset:
                {
                    if (createOrReplace)
                    {
                        if (Offset == null)
                        {
                            if (replacement == null)
                            {
                                Offset = new ThreeDFrameState(this);
                            }
                            else
                            {
                                Offset = (ThreeDFrameState)replacement;
                            }
                        }
                    }

                    instance = Offset;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseDataVariableState<GripTypeEnumeration> m_type;
        private ThreeDFrameState m_offset;
        #endregion
    }
    #endif
    #endregion

    #region VacuumGripPointState Class
    #if (!OPCUA_EXCLUDE_VacuumGripPointState)
    /// <summary>
    /// Stores an instance of the VacuumGripPoint ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class VacuumGripPointState : GripPointState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public VacuumGripPointState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Device.ObjectTypes.VacuumGripPoint, fortiss_Device.Namespaces.fortissDevice, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////8EYIACAQAAAAIAFwAAAFZhY3V1bUdyaXBQb2ludEluc3RhbmNlAQKmOwEC" +
           "pjumOwAA/////wIAAAA1YKkKAgAAAAIABAAAAFR5cGUBAqc7AwAAAAANAAAAR3JpcHBpbmcgdHlwZQAv" +
           "AD+nOwAABQEAAQKUO/////8BAf////8AAAAANWCJCgIAAAACAAYAAABPZmZzZXQBAqg7AwAAAAA1AAAA" +
           "T2Zmc2V0IHRvIHRoZSBncmlwcGluZyBwb2ludCBmcm9tIHRoZSB0b29sIGJhc2UgZnJhbWUALwEAZ0mo" +
           "OwAAAQB+Sf////8BAf////8CAAAAFWCJCgIAAAAAABQAAABDYXJ0ZXNpYW5Db29yZGluYXRlcwECqTsA" +
           "LwEAVkmpOwAAAQB6Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABYAQKwOwAvAD+wOwAAAAv/////" +
           "AQH/////AAAAABVgiQoCAAAAAAABAAAAWQECsTsALwA/sTsAAAAL/////wEB/////wAAAAAVYIkKAgAA" +
           "AAAAAQAAAFoBArI7AC8AP7I7AAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABPcmllbnRhdGlv" +
           "bgECqzsALwEAXUmrOwAAAQB8Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABBAQKzOwAvAD+zOwAA" +
           "AAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAQgECtDsALwA/tDsAAAAL/////wEB/////wAAAAAV" +
           "YIkKAgAAAAAAAQAAAEMBArU7AC8AP7U7AAAAC/////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region ParallelGripPointState Class
    #if (!OPCUA_EXCLUDE_ParallelGripPointState)
    /// <summary>
    /// Stores an instance of the ParallelGripPoint ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ParallelGripPointState : GripPointState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ParallelGripPointState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Device.ObjectTypes.ParallelGripPoint, fortiss_Device.Namespaces.fortissDevice, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////8EYIACAQAAAAIAGQAAAFBhcmFsbGVsR3JpcFBvaW50SW5zdGFuY2UBArY7" +
           "AQK2O7Y7AAD/////AwAAADVgqQoCAAAAAgAEAAAAVHlwZQECtzsDAAAAAA0AAABHcmlwcGluZyB0eXBl" +
           "AC8AP7c7AAAFAAABApQ7/////wEB/////wAAAAA1YIkKAgAAAAIABgAAAE9mZnNldAECuDsDAAAAADUA" +
           "AABPZmZzZXQgdG8gdGhlIGdyaXBwaW5nIHBvaW50IGZyb20gdGhlIHRvb2wgYmFzZSBmcmFtZQAvAQBn" +
           "Sbg7AAABAH5J/////wEB/////wIAAAAVYIkKAgAAAAAAFAAAAENhcnRlc2lhbkNvb3JkaW5hdGVzAQK5" +
           "OwAvAQBWSbk7AAABAHpJ/////wEB/////wMAAAAVYIkKAgAAAAAAAQAAAFgBAsA7AC8AP8A7AAAAC///" +
           "//8BAf////8AAAAAFWCJCgIAAAAAAAEAAABZAQLBOwAvAD/BOwAAAAv/////AQH/////AAAAABVgiQoC" +
           "AAAAAAABAAAAWgECwjsALwA/wjsAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAE9yaWVudGF0" +
           "aW9uAQK7OwAvAQBdSbs7AAABAHxJ/////wEB/////wMAAAAVYIkKAgAAAAAAAQAAAEEBAsM7AC8AP8M7" +
           "AAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAEAAABCAQLEOwAvAD/EOwAAAAv/////AQH/////AAAA" +
           "ABVgiQoCAAAAAAABAAAAQwECxTsALwA/xTsAAAAL/////wEB/////wAAAAAVYIkKAgAAAAIABQAAAFJh" +
           "bmdlAQLGOwAvAD/GOwAAAQB0A/////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseDataVariableState<Range> Range
        {
            get
            {
                return m_range;
            }

            set
            {
                if (!Object.ReferenceEquals(m_range, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_range = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_range != null)
            {
                children.Add(m_range);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case fortiss_Device.BrowseNames.Range:
                {
                    if (createOrReplace)
                    {
                        if (Range == null)
                        {
                            if (replacement == null)
                            {
                                Range = new BaseDataVariableState<Range>(this);
                            }
                            else
                            {
                                Range = (BaseDataVariableState<Range>)replacement;
                            }
                        }
                    }

                    instance = Range;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseDataVariableState<Range> m_range;
        #endregion
    }
    #endif
    #endregion

    #region IGripperState Class
    #if (!OPCUA_EXCLUDE_IGripperState)
    /// <summary>
    /// Stores an instance of the IGripperType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class IGripperState : BaseInterfaceState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public IGripperState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Device.ObjectTypes.IGripperType, fortiss_Device.Namespaces.fortissDevice, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////+EYIACAQAAAAIAFAAAAElHcmlwcGVyVHlwZUluc3RhbmNlAQLHOwECxzvH" +
           "OwAAAf////8BAAAAJGCACgEAAAACAAoAAABHcmlwUG9pbnRzAQLIOwMAAAAAJQAAAENvbnRhaW5zIHRo" +
           "ZSBwb3NzaWJsZSBncmlwcGluZyBwb2ludHMALwA6yDsAAP////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseObjectState GripPoints
        {
            get
            {
                return m_gripPoints;
            }

            set
            {
                if (!Object.ReferenceEquals(m_gripPoints, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_gripPoints = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_gripPoints != null)
            {
                children.Add(m_gripPoints);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case fortiss_Device.BrowseNames.GripPoints:
                {
                    if (createOrReplace)
                    {
                        if (GripPoints == null)
                        {
                            if (replacement == null)
                            {
                                GripPoints = new BaseObjectState(this);
                            }
                            else
                            {
                                GripPoints = (BaseObjectState)replacement;
                            }
                        }
                    }

                    instance = GripPoints;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseObjectState m_gripPoints;
        #endregion
    }
    #endif
    #endregion

    #region SensorState Class
    #if (!OPCUA_EXCLUDE_SensorState)
    /// <summary>
    /// Stores an instance of the SensorType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class SensorState : ComponentState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public SensorState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Device.ObjectTypes.SensorType, fortiss_Device.Namespaces.fortissDevice, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////8EYIACAQAAAAIAEgAAAFNlbnNvclR5cGVJbnN0YW5jZQECTD0BAkw9TD0A" +
           "AP////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region ForceTorqueSensorState Class
    #if (!OPCUA_EXCLUDE_ForceTorqueSensorState)
    /// <summary>
    /// Stores an instance of the ForceTorqueSensorType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ForceTorqueSensorState : SensorState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ForceTorqueSensorState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Device.ObjectTypes.ForceTorqueSensorType, fortiss_Device.Namespaces.fortissDevice, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////+EYIACAQAAAAIAHQAAAEZvcmNlVG9ycXVlU2Vuc29yVHlwZUluc3RhbmNl" +
           "AQJwPQECcD1wPQAAAf////8CAAAAJGCACgEAAAACAAsAAABGb3JjZVNlbnNvcgEClD0DAAAAADcAAABP" +
           "ZmZlcnMgaW5mb3JtYXRpb24gYWJvdXQgZm9yY2UgZXhwZXJpZW5jZWQgYnkgdGhlIHJvYm90AC8BAkw9" +
           "lD0AAP////8BAAAAN2CJCgIAAAACAAUAAABGb3JjZQECtj0DAAAAACQAAABUaGUgY3VycmVudCBmb3Jj" +
           "ZXMgaW4gWCBZIGFuZCBaIGluIE4ALwEAQAm2PQAAAAsBAAAAAQAAAAAAAAADA/////8BAAAAFWCJCgIA" +
           "AAAAAAcAAABFVVJhbmdlAQK6PQAuAES6PQAAAQB0A/////8BAf////8AAAAAJGCACgEAAAACAAwAAABU" +
           "b3JxdWVTZW5zb3IBArw9AwAAAAA5AAAAT2ZmZXJzIGluZm9ybWF0aW9uIGFib3V0IHRvcnF1ZSBleHBl" +
           "cmllbmNlZCBieSB0aGUgc2Vuc29yAC8BAkw9vD0AAP////8BAAAAN2CJCgIAAAACAAYAAABUb3JxdWUB" +
           "At49AwAAAAAdAAAAVGhlIHRvcnF1ZSBpbiBYIFkgYW5kIFogaW4gTm0ALwEAQAnePQAAAAsBAAAAAQAA" +
           "AAAAAAADA/////8BAAAAFWCJCgIAAAAAAAcAAABFVVJhbmdlAQLiPQAuAETiPQAAAQB0A/////8BAf//" +
           "//8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public SensorState ForceSensor
        {
            get
            {
                return m_forceSensor;
            }

            set
            {
                if (!Object.ReferenceEquals(m_forceSensor, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_forceSensor = value;
            }
        }

        /// <remarks />
        public SensorState TorqueSensor
        {
            get
            {
                return m_torqueSensor;
            }

            set
            {
                if (!Object.ReferenceEquals(m_torqueSensor, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_torqueSensor = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_forceSensor != null)
            {
                children.Add(m_forceSensor);
            }

            if (m_torqueSensor != null)
            {
                children.Add(m_torqueSensor);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case fortiss_Device.BrowseNames.ForceSensor:
                {
                    if (createOrReplace)
                    {
                        if (ForceSensor == null)
                        {
                            if (replacement == null)
                            {
                                ForceSensor = new SensorState(this);
                            }
                            else
                            {
                                ForceSensor = (SensorState)replacement;
                            }
                        }
                    }

                    instance = ForceSensor;
                    break;
                }

                case fortiss_Device.BrowseNames.TorqueSensor:
                {
                    if (createOrReplace)
                    {
                        if (TorqueSensor == null)
                        {
                            if (replacement == null)
                            {
                                TorqueSensor = new SensorState(this);
                            }
                            else
                            {
                                TorqueSensor = (SensorState)replacement;
                            }
                        }
                    }

                    instance = TorqueSensor;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private SensorState m_forceSensor;
        private SensorState m_torqueSensor;
        #endregion
    }
    #endif
    #endregion

    #region SkillTransitionEventState Class
    #if (!OPCUA_EXCLUDE_SkillTransitionEventState)
    /// <summary>
    /// Stores an instance of the SkillTransitionEventType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class SkillTransitionEventState : ProgramTransitionEventState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public SkillTransitionEventState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Device.ObjectTypes.SkillTransitionEventType, fortiss_Device.Namespaces.fortissDevice, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAAB8AAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvREkvHgAAAGh0dHBzOi8vZm9ydGlzcy5v" +
           "cmcvVUEvRGV2aWNlL/////8EYIACAQAAAAIAIAAAAFNraWxsVHJhbnNpdGlvbkV2ZW50VHlwZUluc3Rh" +
           "bmNlAQLkPQEC5D3kPQAA/////wwAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAuU9AC4AROU9AAAAD///" +
           "//8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAuY9AC4AROY9AAAAEf////8BAf////8A" +
           "AAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQLnPQAuAETnPQAAABH/////AQH/////AAAAABVgiQoC" +
           "AAAAAAAKAAAAU291cmNlTmFtZQEC6D0ALgBE6D0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAA" +
           "AFRpbWUBAuk9AC4AROk9AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1l" +
           "AQLqPQAuAETqPQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQLsPQAuAETs" +
           "PQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAu09AC4ARO09AAAABf////8B" +
           "Af////8AAAAAFWCJCgIAAAAAAAoAAABUcmFuc2l0aW9uAQLuPQAvAQDKCu49AAAAFf////8BAf////8B" +
           "AAAAFWCJCgIAAAAAAAIAAABJZAEC7z0ALgBE7z0AAAAY/////wEB/////wAAAAAVYIkKAgAAAAAACQAA" +
           "AEZyb21TdGF0ZQEC9D0ALwEAwwr0PQAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAvU9" +
           "AC4ARPU9AAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABUb1N0YXRlAQL5PQAvAQDDCvk9AAAA" +
           "Ff////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEC+j0ALgBE+j0AAAAY/////wEB/////wAAAAAV" +
           "YIkKAgAAAAAAEgAAAEludGVybWVkaWF0ZVJlc3VsdAEC/j0ALwA//j0AAAAY/////wEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion
}