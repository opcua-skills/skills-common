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
using fortiss_Device;
using Opc.Ua;
using Opc.Ua.Di;
using Opc.Ua.Robotics;

namespace fortiss_Robotics
{
    #region MoveSkillState Class
    #if (!OPCUA_EXCLUDE_MoveSkillState)
    /// <summary>
    /// Stores an instance of the MoveSkillType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class MoveSkillState : SkillState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public MoveSkillState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Robotics.ObjectTypes.MoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics, namespaceUris);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////wRggAIBAAAAAQAVAAAATW92ZVNraWxsVHlw" +
           "ZUluc3RhbmNlAQG6OgEBujq6OgAA/////wwAAAAVYIkKAgAAAAAADAAAAEN1cnJlbnRTdGF0ZQEBuzoA" +
           "LwEAyAq7OgAAABX/////AQH/////AgAAABVgiQoCAAAAAAACAAAASWQBAbw6AC4ARLw6AAAAEf////8B" +
           "Af////8AAAAAFWCJCgIAAAAAAAYAAABOdW1iZXIBAb46AC4ARL46AAAAB/////8BAf////8AAAAAFWCJ" +
           "CgIAAAAAAA4AAABMYXN0VHJhbnNpdGlvbgEBwDoALwEAzwrAOgAAABX/////AQH/////AwAAABVgiQoC" +
           "AAAAAAACAAAASWQBAcE6AC4ARME6AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABOdW1iZXIB" +
           "AcM6AC4ARMM6AAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEBxDoA" +
           "LgBExDoAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAARGVsZXRhYmxlAQHJOgAuAETJOgAA" +
           "AAH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAQXV0b0RlbGV0ZQEByjoALgBEyjoAAAAB/////wEB" +
           "/////wAAAAAVYIkKAgAAAAAADAAAAFJlY3ljbGVDb3VudAEByzoALgBEyzoAAAAG/////wEB/////wAA" +
           "AAAVYIkKAgAAAAAAEAAAAE1heEluc3RhbmNlQ291bnQBAc06AC4ARM06AAAAB/////8BAf////8AAAAA" +
           "BGGCCgQAAAAAAAUAAABTdGFydAEB9zoALwEAegn3OgAAAQEBAAAAADUBAQHnOgAAAAAEYYIKBAAAAAAA" +
           "BwAAAFN1c3BlbmQBAfg6AC8BAHsJ+DoAAAEBAQAAAAA1AQEB7ToAAAAABGGCCgQAAAAAAAYAAABSZXN1" +
           "bWUBAfk6AC8BAHwJ+ToAAAEBAQAAAAA1AQEB7zoAAAAABGGCCgQAAAAAAAQAAABIYWx0AQH6OgAvAQB9" +
           "Cfo6AAABAQMAAAAANQEBAek6ADUBAQHxOgA1AQEB9ToAAAAABGGCCgQAAAAAAAUAAABSZXNldAEB+zoA" +
           "LwEAfgn7OgAAAQEBAAAAADUBAQHlOgAAAAAEYIAKAQAAAAMADAAAAFBhcmFtZXRlclNldAEB/ToALwA6" +
           "/ToAAP////8BAAAANWCJCgIAAAABAAkAAABUb29sRnJhbWUBAf46AwAAAAA0AAAAVGhlIG5hbWUgb2Yg" +
           "dGhlIHRvb2wgZnJhbWUgdG8gYmUgdXNlZCBmb3IgdGhlIG1vdGlvbgAvAD/+OgAAAAz/////AwP/////" +
           "AAAAAA==";
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

    #region LinearMoveSkillState Class
    #if (!OPCUA_EXCLUDE_LinearMoveSkillState)
    /// <summary>
    /// Stores an instance of the LinearMoveSkillType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class LinearMoveSkillState : MoveSkillState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public LinearMoveSkillState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Robotics.ObjectTypes.LinearMoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics, namespaceUris);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////wRggAIBAAAAAQAbAAAATGluZWFyTW92ZVNr" +
           "aWxsVHlwZUluc3RhbmNlAQH/OgEB/zr/OgAA/////wwAAAAVYIkKAgAAAAAADAAAAEN1cnJlbnRTdGF0" +
           "ZQEBADsALwEAyAoAOwAAABX/////AQH/////AgAAABVgiQoCAAAAAAACAAAASWQBAQE7AC4ARAE7AAAA" +
           "Ef////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABOdW1iZXIBAQM7AC4ARAM7AAAAB/////8BAf////8A" +
           "AAAAFWCJCgIAAAAAAA4AAABMYXN0VHJhbnNpdGlvbgEBBTsALwEAzwoFOwAAABX/////AQH/////AwAA" +
           "ABVgiQoCAAAAAAACAAAASWQBAQY7AC4ARAY7AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABO" +
           "dW1iZXIBAQg7AC4ARAg7AAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGlt" +
           "ZQEBCTsALgBECTsAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAARGVsZXRhYmxlAQEOOwAu" +
           "AEQOOwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAQXV0b0RlbGV0ZQEBDzsALgBEDzsAAAAB" +
           "/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFJlY3ljbGVDb3VudAEBEDsALgBEEDsAAAAG/////wEB" +
           "/////wAAAAAVYIkKAgAAAAAAEAAAAE1heEluc3RhbmNlQ291bnQBARI7AC4ARBI7AAAAB/////8BAf//" +
           "//8AAAAABGGCCgQAAAAAAAUAAABTdGFydAEBPDsALwEAegk8OwAAAQEBAAAAADUBAQEsOwAAAAAEYYIK" +
           "BAAAAAAABwAAAFN1c3BlbmQBAT07AC8BAHsJPTsAAAEBAQAAAAA1AQEBMjsAAAAABGGCCgQAAAAAAAYA" +
           "AABSZXN1bWUBAT47AC8BAHwJPjsAAAEBAQAAAAA1AQEBNDsAAAAABGGCCgQAAAAAAAQAAABIYWx0AQE/" +
           "OwAvAQB9CT87AAABAQMAAAAANQEBAS47ADUBAQE2OwA1AQEBOjsAAAAABGGCCgQAAAAAAAUAAABSZXNl" +
           "dAEBQDsALwEAfglAOwAAAQEBAAAAADUBAQEqOwAAAAAEYIAKAQAAAAMADAAAAFBhcmFtZXRlclNldAEB" +
           "QjsALwA6QjsAAP////8DAAAANWCJCgIAAAABAAkAAABUb29sRnJhbWUBAUM7AwAAAAA0AAAAVGhlIG5h" +
           "bWUgb2YgdGhlIHRvb2wgZnJhbWUgdG8gYmUgdXNlZCBmb3IgdGhlIG1vdGlvbgAvAD9DOwAAAAz/////" +
           "AwP/////AAAAADdgiQoCAAAAAQAPAAAATWF4QWNjZWxlcmF0aW9uAQFEOwMAAAAAhwAAAE1heGltdW0g" +
           "YWNjZWxlcmF0aW9uIG9mIHRoZSByb2JvdCBzaG91bGQgbW92ZS4gRmlyc3QgdGhyZWUgcGFyYW1ldGVy" +
           "cyBhcmUgZm9yIHgseSx6IGluIG0vc14yLiBUaGUgbmV4dCB0aHJlZSBmb3Igb3JpZW50YXRpb24gaW4g" +
           "cmFkL3NeMgAvAQBZREQ7AAAACwEAAAABAAAABgAAAAMD/////wEAAAAVYIkKAgAAAAAAEAAAAEVuZ2lu" +
           "ZWVyaW5nVW5pdHMBAUk7AC4AREk7AAABAHcD/////wEB/////wAAAAA3YIkKAgAAAAEACwAAAE1heFZl" +
           "bG9jaXR5AQFKOwMAAAAAfwAAAE1heGltdW0gdmVsb2NpdHkgb2YgdGhlIHJvYm90IHNob3VsZCBtb3Zl" +
           "LiBGaXJzdCB0aHJlZSBwYXJhbWV0ZXJzIGFyZSBmb3IgeCx5LHogaW4gbS9zLiBUaGUgbmV4dCB0aHJl" +
           "ZSBmb3Igb3JpZW50YXRpb24gaW4gcmFkL3MALwEAWURKOwAAAAsBAAAAAQAAAAYAAAADA/////8BAAAA" +
           "FWCJCgIAAAAAABAAAABFbmdpbmVlcmluZ1VuaXRzAQFPOwAuAERPOwAAAQB3A/////8BAf////8AAAAA";
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

    #region PtpMoveSkillState Class
    #if (!OPCUA_EXCLUDE_PtpMoveSkillState)
    /// <summary>
    /// Stores an instance of the PtpMoveSkillType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class PtpMoveSkillState : MoveSkillState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public PtpMoveSkillState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Robotics.ObjectTypes.PtpMoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics, namespaceUris);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////wRggAIBAAAAAQAYAAAAUHRwTW92ZVNraWxs" +
           "VHlwZUluc3RhbmNlAQFQOwEBUDtQOwAA/////wwAAAAVYIkKAgAAAAAADAAAAEN1cnJlbnRTdGF0ZQEB" +
           "UTsALwEAyApROwAAABX/////AQH/////AgAAABVgiQoCAAAAAAACAAAASWQBAVI7AC4ARFI7AAAAEf//" +
           "//8BAf////8AAAAAFWCJCgIAAAAAAAYAAABOdW1iZXIBAVQ7AC4ARFQ7AAAAB/////8BAf////8AAAAA" +
           "FWCJCgIAAAAAAA4AAABMYXN0VHJhbnNpdGlvbgEBVjsALwEAzwpWOwAAABX/////AQH/////AwAAABVg" +
           "iQoCAAAAAAACAAAASWQBAVc7AC4ARFc7AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABOdW1i" +
           "ZXIBAVk7AC4ARFk7AAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEB" +
           "WjsALgBEWjsAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAARGVsZXRhYmxlAQFfOwAuAERf" +
           "OwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAQXV0b0RlbGV0ZQEBYDsALgBEYDsAAAAB////" +
           "/wEB/////wAAAAAVYIkKAgAAAAAADAAAAFJlY3ljbGVDb3VudAEBYTsALgBEYTsAAAAG/////wEB////" +
           "/wAAAAAVYIkKAgAAAAAAEAAAAE1heEluc3RhbmNlQ291bnQBAWM7AC4ARGM7AAAAB/////8BAf////8A" +
           "AAAABGGCCgQAAAAAAAUAAABTdGFydAEBjTsALwEAegmNOwAAAQEBAAAAADUBAQF9OwAAAAAEYYIKBAAA" +
           "AAAABwAAAFN1c3BlbmQBAY47AC8BAHsJjjsAAAEBAQAAAAA1AQEBgzsAAAAABGGCCgQAAAAAAAYAAABS" +
           "ZXN1bWUBAY87AC8BAHwJjzsAAAEBAQAAAAA1AQEBhTsAAAAABGGCCgQAAAAAAAQAAABIYWx0AQGQOwAv" +
           "AQB9CZA7AAABAQMAAAAANQEBAX87ADUBAQGHOwA1AQEBizsAAAAABGGCCgQAAAAAAAUAAABSZXNldAEB" +
           "kTsALwEAfgmROwAAAQEBAAAAADUBAQF7OwAAAAAEYIAKAQAAAAMADAAAAFBhcmFtZXRlclNldAEBkzsA" +
           "LwA6kzsAAP////8DAAAANWCJCgIAAAABAAkAAABUb29sRnJhbWUBAZQ7AwAAAAA0AAAAVGhlIG5hbWUg" +
           "b2YgdGhlIHRvb2wgZnJhbWUgdG8gYmUgdXNlZCBmb3IgdGhlIG1vdGlvbgAvAD+UOwAAAAz/////AwP/" +
           "////AAAAADdgiQoCAAAAAQAPAAAATWF4QWNjZWxlcmF0aW9uAQGVOwMAAAAARAAAAE1heGltdW0gYWNj" +
           "ZWxlcmF0aW9uIHRoZSByb2JvdCBzaG91bGQgbW92ZSBpbiByYWQvc14yIGZvciBldmVyeSBheGlzAC8B" +
           "AFlElTsAAAALAQAAAAEAAAAAAAAAAwP/////AQAAABVgiQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0" +
           "cwEBmjsALgBEmjsAAAEAdwP/////AQH/////AAAAADdgiQoCAAAAAQALAAAATWF4VmVsb2NpdHkBAZs7" +
           "AwAAAAA+AAAATWF4aW11bSB2ZWxvY2l0eSB0aGUgcm9ib3Qgc2hvdWxkIG1vdmUgaW4gcmFkL3MgZm9y" +
           "IGV2ZXJ5IGF4aXMALwEAWUSbOwAAAAsBAAAAAQAAAAAAAAADA/////8BAAAAFWCJCgIAAAAAABAAAABF" +
           "bmdpbmVlcmluZ1VuaXRzAQGgOwAuAESgOwAAAQB3A/////8BAf////8AAAAA";
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

    #region ICartesianMoveSkillParameterState Class
    #if (!OPCUA_EXCLUDE_ICartesianMoveSkillParameterState)
    /// <summary>
    /// Stores an instance of the ICartesianMoveSkillParameterType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ICartesianMoveSkillParameterState : BaseInterfaceState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ICartesianMoveSkillParameterState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Robotics.ObjectTypes.ICartesianMoveSkillParameterType, fortiss_Robotics.Namespaces.fortissRobotics, namespaceUris);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////4RggAIBAAAAAQAoAAAASUNhcnRlc2lhbk1v" +
           "dmVTa2lsbFBhcmFtZXRlclR5cGVJbnN0YW5jZQEBoTsBAaE7oTsAAAH/////AgAAAARggAoBAAAAAAAP" +
           "AAAARmluYWxSZXN1bHREYXRhAQGiOwAvADqiOwAA/////wIAAAA1YIkKAgAAAAEADgAAAEZvcmNlc0V4" +
           "Y2VlZGVkAQGjOwMAAAAAMgAAAFRoZSBhbW91bnQgYnkgd2hpY2ggdGhlIGZvcmNlIGxpbWl0cyB3ZXJl" +
           "IGV4Y2VlZGVkAC8BADRFozsAAAEAeEn/////AQH/////AwAAABVgiQoCAAAAAAABAAAAWAEBpTsALwA/" +
           "pTsAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAFkBAaY7AC8AP6Y7AAAAC/////8BAf////8A" +
           "AAAAFWCJCgIAAAAAAAEAAABaAQGnOwAvAD+nOwAAAAv/////AQH/////AAAAADVgiQoCAAAAAQAJAAAA" +
           "Rm9yY2VzTWF4AQEhPwMAAAAANAAAAE1heGltdW0gZm9yY2UgbWVhc3VyZWQgZHVyaW5nIGV4ZWN1dGlv" +
           "biBvZiB0aGUgc2tpbGwALwEANEUhPwAAAQB4Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABYAQEj" +
           "PwAvAD8jPwAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAWQEBJD8ALwA/JD8AAAAL/////wEB" +
           "/////wAAAAAVYIkKAgAAAAAAAQAAAFoBASU/AC8APyU/AAAAC/////8BAf////8AAAAABGCACgEAAAAD" +
           "AAwAAABQYXJhbWV0ZXJTZXQBAag7AC8AOqg7AAD/////AgAAADVgiQoCAAAAAQAOAAAAVGFyZ2V0UG9z" +
           "aXRpb24BAak7AwAAAAApAAAAQWJzb2x1dGUgZ29hbCBwb3NpdGlvbiBpbiBjYXJ0ZXNpYW4gc3BhY2UA" +
           "LwEAZ0mpOwAAAQB+Sf////8DA/////8CAAAAFWCJCgIAAAAAABQAAABDYXJ0ZXNpYW5Db29yZGluYXRl" +
           "cwEBqjsALwEAVkmqOwAAAQB6Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABYAQGxOwAvAD+xOwAA" +
           "AAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAWQEBsjsALwA/sjsAAAAL/////wEB/////wAAAAAV" +
           "YIkKAgAAAAAAAQAAAFoBAbM7AC8AP7M7AAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABPcmll" +
           "bnRhdGlvbgEBrDsALwEAXUmsOwAAAQB8Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABBAQG0OwAv" +
           "AD+0OwAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAQgEBtTsALwA/tTsAAAAL/////wEB////" +
           "/wAAAAAVYIkKAgAAAAAAAQAAAEMBAbY7AC8AP7Y7AAAAC/////8BAf////8AAAAAN2CJCgIAAAABAAoA" +
           "AABBeGlzQm91bmRzAQG3OwMAAAAAigAAAERlZmluZSBhIHJhbmdlIHdpdGhpbiB3aGljaCB0aGUgam9p" +
           "bnRzIHNob3VsZCBlbmQgdXAgaW4uIFVzZWQgdG8gbGltaXQgdGhlIHNvbHV0aW9ucyBmb3IgdGhlCiAg" +
           "ICAgICAgICAgICAgaW52ZXJzZSBraW5lbWF0aWNzIGNhbGN1bGF0aW9uLgAvAD+3OwAAAQB0AwEAAAAB" +
           "AAAAAAAAAAMD/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseObjectState FinalResultData
        {
            get
            {
                return m_finalResultData;
            }

            set
            {
                if (!Object.ReferenceEquals(m_finalResultData, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_finalResultData = value;
            }
        }

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
            if (m_finalResultData != null)
            {
                children.Add(m_finalResultData);
            }

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
                case Opc.Ua.BrowseNames.FinalResultData:
                {
                    if (createOrReplace)
                    {
                        if (FinalResultData == null)
                        {
                            if (replacement == null)
                            {
                                FinalResultData = new BaseObjectState(this);
                            }
                            else
                            {
                                FinalResultData = (BaseObjectState)replacement;
                            }
                        }
                    }

                    instance = FinalResultData;
                    break;
                }

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
        private BaseObjectState m_finalResultData;
        private BaseObjectState m_parameterSet;
        #endregion
    }
    #endif
    #endregion

    #region IJointMoveSkillParameterState Class
    #if (!OPCUA_EXCLUDE_IJointMoveSkillParameterState)
    /// <summary>
    /// Stores an instance of the IJointMoveSkillParameterType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class IJointMoveSkillParameterState : BaseInterfaceState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public IJointMoveSkillParameterState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Robotics.ObjectTypes.IJointMoveSkillParameterType, fortiss_Robotics.Namespaces.fortissRobotics, namespaceUris);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////4RggAIBAAAAAQAkAAAASUpvaW50TW92ZVNr" +
           "aWxsUGFyYW1ldGVyVHlwZUluc3RhbmNlAQG4OwEBuDu4OwAAAf////8BAAAABGCACgEAAAADAAwAAABQ" +
           "YXJhbWV0ZXJTZXQBAbk7AC8AOrk7AAD/////AQAAADdgiQoCAAAAAQATAAAAVGFyZ2V0Sm9pbnRQb3Np" +
           "dGlvbgEBujsDAAAAADsAAABUaGUgbmV3IGF4aXMgcG9zaXRpb24gYXJyYXkgd2hlcmUgdGhlIGRldmlj" +
           "ZSBzaG91bGQgbW92ZSB0bwAvAQBACbo7AAAACwEAAAABAAAAAAAAAAMD/////wEAAAAVYIkKAgAAAAAA" +
           "BwAAAEVVUmFuZ2UBAb47AC4ARL47AAABAHQD/////wEB/////wAAAAA=";
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

    #region IForceMoveParameterState Class
    #if (!OPCUA_EXCLUDE_IForceMoveParameterState)
    /// <summary>
    /// Stores an instance of the IForceMoveParameterType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class IForceMoveParameterState : BaseInterfaceState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public IForceMoveParameterState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Robotics.ObjectTypes.IForceMoveParameterType, fortiss_Robotics.Namespaces.fortissRobotics, namespaceUris);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////4RggAIBAAAAAQAfAAAASUZvcmNlTW92ZVBh" +
           "cmFtZXRlclR5cGVJbnN0YW5jZQEBwDsBAcA7wDsAAAH/////AQAAAARggAoBAAAAAwAMAAAAUGFyYW1l" +
           "dGVyU2V0AQHBOwAvADrBOwAA/////wEAAAA1YIkKAgAAAAEACAAAAE1heEZvcmNlAQHCOwMAAAAARwAA" +
           "AFRoZSBtYXhpbXVtIGZvcmNlIGFtb3VudHMgd2hpY2ggc2hvdWxkIG5vdCBiZSBleGNlZWRlZCBieSB0" +
           "aGUgbW92ZW1lbnQuAC8BADRFwjsAAAEAeEn/////AwP/////AwAAABVgiQoCAAAAAAABAAAAWAEBxDsA" +
           "LwA/xDsAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAFkBAcU7AC8AP8U7AAAAC/////8BAf//" +
           "//8AAAAAFWCJCgIAAAAAAAEAAABaAQHGOwAvAD/GOwAAAAv/////AQH/////AAAAAA==";
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

    #region CartesianLinearMoveSkillState Class
    #if (!OPCUA_EXCLUDE_CartesianLinearMoveSkillState)
    /// <summary>
    /// Stores an instance of the CartesianLinearMoveSkillType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CartesianLinearMoveSkillState : LinearMoveSkillState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CartesianLinearMoveSkillState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Robotics.ObjectTypes.CartesianLinearMoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics, namespaceUris);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////wRggAIBAAAAAQAkAAAAQ2FydGVzaWFuTGlu" +
           "ZWFyTW92ZVNraWxsVHlwZUluc3RhbmNlAQHHOwEBxzvHOwAAAQAAAAEAw0QAAQGhOwwAAAAVYIkKAgAA" +
           "AAAADAAAAEN1cnJlbnRTdGF0ZQEByDsALwEAyArIOwAAABX/////AQH/////AgAAABVgiQoCAAAAAAAC" +
           "AAAASWQBAck7AC4ARMk7AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABOdW1iZXIBAcs7AC4A" +
           "RMs7AAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABMYXN0VHJhbnNpdGlvbgEBzTsALwEAzwrN" +
           "OwAAABX/////AQH/////AwAAABVgiQoCAAAAAAACAAAASWQBAc47AC4ARM47AAAAEf////8BAf////8A" +
           "AAAAFWCJCgIAAAAAAAYAAABOdW1iZXIBAdA7AC4ARNA7AAAAB/////8BAf////8AAAAAFWCJCgIAAAAA" +
           "AA4AAABUcmFuc2l0aW9uVGltZQEB0TsALgBE0TsAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAJ" +
           "AAAARGVsZXRhYmxlAQHWOwAuAETWOwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAQXV0b0Rl" +
           "bGV0ZQEB1zsALgBE1zsAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFJlY3ljbGVDb3VudAEB" +
           "2DsALgBE2DsAAAAG/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAE1heEluc3RhbmNlQ291bnQBAdo7" +
           "AC4ARNo7AAAAB/////8BAf////8AAAAABGGCCgQAAAAAAAUAAABTdGFydAEBBDwALwEAegkEPAAAAQEB" +
           "AAAAADUBAQH0OwAAAAAEYYIKBAAAAAAABwAAAFN1c3BlbmQBAQU8AC8BAHsJBTwAAAEBAQAAAAA1AQEB" +
           "+jsAAAAABGGCCgQAAAAAAAYAAABSZXN1bWUBAQY8AC8BAHwJBjwAAAEBAQAAAAA1AQEB/DsAAAAABGGC" +
           "CgQAAAAAAAQAAABIYWx0AQEHPAAvAQB9CQc8AAABAQMAAAAANQEBAfY7ADUBAQH+OwA1AQEBAjwAAAAA" +
           "BGGCCgQAAAAAAAUAAABSZXNldAEBCDwALwEAfgkIPAAAAQEBAAAAADUBAQHyOwAAAAAEYIAKAQAAAAMA" +
           "DAAAAFBhcmFtZXRlclNldAEBCjwALwA6CjwAAP////8DAAAANWCJCgIAAAABAAkAAABUb29sRnJhbWUB" +
           "AQs8AwAAAAA0AAAAVGhlIG5hbWUgb2YgdGhlIHRvb2wgZnJhbWUgdG8gYmUgdXNlZCBmb3IgdGhlIG1v" +
           "dGlvbgAvAD8LPAAAAAz/////AwP/////AAAAADdgiQoCAAAAAQAPAAAATWF4QWNjZWxlcmF0aW9uAQEM" +
           "PAMAAAAAhwAAAE1heGltdW0gYWNjZWxlcmF0aW9uIG9mIHRoZSByb2JvdCBzaG91bGQgbW92ZS4gRmly" +
           "c3QgdGhyZWUgcGFyYW1ldGVycyBhcmUgZm9yIHgseSx6IGluIG0vc14yLiBUaGUgbmV4dCB0aHJlZSBm" +
           "b3Igb3JpZW50YXRpb24gaW4gcmFkL3NeMgAvAQBZRAw8AAAACwEAAAABAAAABgAAAAMD/////wEAAAAV" +
           "YIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBARE8AC4ARBE8AAABAHcD/////wEB/////wAAAAA3" +
           "YIkKAgAAAAEACwAAAE1heFZlbG9jaXR5AQESPAMAAAAAfwAAAE1heGltdW0gdmVsb2NpdHkgb2YgdGhl" +
           "IHJvYm90IHNob3VsZCBtb3ZlLiBGaXJzdCB0aHJlZSBwYXJhbWV0ZXJzIGFyZSBmb3IgeCx5LHogaW4g" +
           "bS9zLiBUaGUgbmV4dCB0aHJlZSBmb3Igb3JpZW50YXRpb24gaW4gcmFkL3MALwEAWUQSPAAAAAsBAAAA" +
           "AQAAAAYAAAADA/////8BAAAAFWCJCgIAAAAAABAAAABFbmdpbmVlcmluZ1VuaXRzAQEXPAAuAEQXPAAA" +
           "AQB3A/////8BAf////8AAAAA";
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

    #region JointLinearMoveSkillState Class
    #if (!OPCUA_EXCLUDE_JointLinearMoveSkillState)
    /// <summary>
    /// Stores an instance of the JointLinearMoveSkillType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class JointLinearMoveSkillState : LinearMoveSkillState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public JointLinearMoveSkillState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Robotics.ObjectTypes.JointLinearMoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics, namespaceUris);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////wRggAIBAAAAAQAgAAAASm9pbnRMaW5lYXJN" +
           "b3ZlU2tpbGxUeXBlSW5zdGFuY2UBARg8AQEYPBg8AAABAAAAAQDDRAABAbg7DAAAABVgiQoCAAAAAAAM" +
           "AAAAQ3VycmVudFN0YXRlAQEZPAAvAQDIChk8AAAAFf////8BAf////8CAAAAFWCJCgIAAAAAAAIAAABJ" +
           "ZAEBGjwALgBEGjwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgEBHDwALgBEHDwA" +
           "AAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQEePAAvAQDPCh48AAAA" +
           "Ff////8BAf////8DAAAAFWCJCgIAAAAAAAIAAABJZAEBHzwALgBEHzwAAAAR/////wEB/////wAAAAAV" +
           "YIkKAgAAAAAABgAAAE51bWJlcgEBITwALgBEITwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAA" +
           "AFRyYW5zaXRpb25UaW1lAQEiPAAuAEQiPAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABE" +
           "ZWxldGFibGUBASc8AC4ARCc8AAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABBdXRvRGVsZXRl" +
           "AQEoPAAuAEQoPAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAUmVjeWNsZUNvdW50AQEpPAAu" +
           "AEQpPAAAAAb/////AQH/////AAAAABVgiQoCAAAAAAAQAAAATWF4SW5zdGFuY2VDb3VudAEBKzwALgBE" +
           "KzwAAAAH/////wEB/////wAAAAAEYYIKBAAAAAAABQAAAFN0YXJ0AQFVPAAvAQB6CVU8AAABAQEAAAAA" +
           "NQEBAUU8AAAAAARhggoEAAAAAAAHAAAAU3VzcGVuZAEBVjwALwEAewlWPAAAAQEBAAAAADUBAQFLPAAA" +
           "AAAEYYIKBAAAAAAABgAAAFJlc3VtZQEBVzwALwEAfAlXPAAAAQEBAAAAADUBAQFNPAAAAAAEYYIKBAAA" +
           "AAAABAAAAEhhbHQBAVg8AC8BAH0JWDwAAAEBAwAAAAA1AQEBRzwANQEBAU88ADUBAQFTPAAAAAAEYYIK" +
           "BAAAAAAABQAAAFJlc2V0AQFZPAAvAQB+CVk8AAABAQEAAAAANQEBAUM8AAAAAARggAoBAAAAAwAMAAAA" +
           "UGFyYW1ldGVyU2V0AQFbPAAvADpbPAAA/////wMAAAA1YIkKAgAAAAEACQAAAFRvb2xGcmFtZQEBXDwD" +
           "AAAAADQAAABUaGUgbmFtZSBvZiB0aGUgdG9vbCBmcmFtZSB0byBiZSB1c2VkIGZvciB0aGUgbW90aW9u" +
           "AC8AP1w8AAAADP////8DA/////8AAAAAN2CJCgIAAAABAA8AAABNYXhBY2NlbGVyYXRpb24BAV08AwAA" +
           "AACHAAAATWF4aW11bSBhY2NlbGVyYXRpb24gb2YgdGhlIHJvYm90IHNob3VsZCBtb3ZlLiBGaXJzdCB0" +
           "aHJlZSBwYXJhbWV0ZXJzIGFyZSBmb3IgeCx5LHogaW4gbS9zXjIuIFRoZSBuZXh0IHRocmVlIGZvciBv" +
           "cmllbnRhdGlvbiBpbiByYWQvc14yAC8BAFlEXTwAAAALAQAAAAEAAAAGAAAAAwP/////AQAAABVgiQoC" +
           "AAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEBYjwALgBEYjwAAAEAdwP/////AQH/////AAAAADdgiQoC" +
           "AAAAAQALAAAATWF4VmVsb2NpdHkBAWM8AwAAAAB/AAAATWF4aW11bSB2ZWxvY2l0eSBvZiB0aGUgcm9i" +
           "b3Qgc2hvdWxkIG1vdmUuIEZpcnN0IHRocmVlIHBhcmFtZXRlcnMgYXJlIGZvciB4LHkseiBpbiBtL3Mu" +
           "IFRoZSBuZXh0IHRocmVlIGZvciBvcmllbnRhdGlvbiBpbiByYWQvcwAvAQBZRGM8AAAACwEAAAABAAAA" +
           "BgAAAAMD/////wEAAAAVYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAWg8AC4ARGg8AAABAHcD" +
           "/////wEB/////wAAAAA=";
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

    #region CartesianPtpMoveSkillState Class
    #if (!OPCUA_EXCLUDE_CartesianPtpMoveSkillState)
    /// <summary>
    /// Stores an instance of the CartesianPtpMoveSkillType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CartesianPtpMoveSkillState : PtpMoveSkillState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CartesianPtpMoveSkillState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Robotics.ObjectTypes.CartesianPtpMoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics, namespaceUris);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////wRggAIBAAAAAQAhAAAAQ2FydGVzaWFuUHRw" +
           "TW92ZVNraWxsVHlwZUluc3RhbmNlAQFpPAEBaTxpPAAAAQAAAAEAw0QAAQGhOwwAAAAVYIkKAgAAAAAA" +
           "DAAAAEN1cnJlbnRTdGF0ZQEBajwALwEAyApqPAAAABX/////AQH/////AgAAABVgiQoCAAAAAAACAAAA" +
           "SWQBAWs8AC4ARGs8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABOdW1iZXIBAW08AC4ARG08" +
           "AAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABMYXN0VHJhbnNpdGlvbgEBbzwALwEAzwpvPAAA" +
           "ABX/////AQH/////AwAAABVgiQoCAAAAAAACAAAASWQBAXA8AC4ARHA8AAAAEf////8BAf////8AAAAA" +
           "FWCJCgIAAAAAAAYAAABOdW1iZXIBAXI8AC4ARHI8AAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA4A" +
           "AABUcmFuc2l0aW9uVGltZQEBczwALgBEczwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAJAAAA" +
           "RGVsZXRhYmxlAQF4PAAuAER4PAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAQXV0b0RlbGV0" +
           "ZQEBeTwALgBEeTwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFJlY3ljbGVDb3VudAEBejwA" +
           "LgBEejwAAAAG/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAE1heEluc3RhbmNlQ291bnQBAXw8AC4A" +
           "RHw8AAAAB/////8BAf////8AAAAABGGCCgQAAAAAAAUAAABTdGFydAEBpjwALwEAegmmPAAAAQEBAAAA" +
           "ADUBAQGWPAAAAAAEYYIKBAAAAAAABwAAAFN1c3BlbmQBAac8AC8BAHsJpzwAAAEBAQAAAAA1AQEBnDwA" +
           "AAAABGGCCgQAAAAAAAYAAABSZXN1bWUBAag8AC8BAHwJqDwAAAEBAQAAAAA1AQEBnjwAAAAABGGCCgQA" +
           "AAAAAAQAAABIYWx0AQGpPAAvAQB9Cak8AAABAQMAAAAANQEBAZg8ADUBAQGgPAA1AQEBpDwAAAAABGGC" +
           "CgQAAAAAAAUAAABSZXNldAEBqjwALwEAfgmqPAAAAQEBAAAAADUBAQGUPAAAAAAEYIAKAQAAAAMADAAA" +
           "AFBhcmFtZXRlclNldAEBrDwALwA6rDwAAP////8DAAAANWCJCgIAAAABAAkAAABUb29sRnJhbWUBAa08" +
           "AwAAAAA0AAAAVGhlIG5hbWUgb2YgdGhlIHRvb2wgZnJhbWUgdG8gYmUgdXNlZCBmb3IgdGhlIG1vdGlv" +
           "bgAvAD+tPAAAAAz/////AwP/////AAAAADdgiQoCAAAAAQAPAAAATWF4QWNjZWxlcmF0aW9uAQGuPAMA" +
           "AAAARAAAAE1heGltdW0gYWNjZWxlcmF0aW9uIHRoZSByb2JvdCBzaG91bGQgbW92ZSBpbiByYWQvc14y" +
           "IGZvciBldmVyeSBheGlzAC8BAFlErjwAAAALAQAAAAEAAAAAAAAAAwP/////AQAAABVgiQoCAAAAAAAQ" +
           "AAAARW5naW5lZXJpbmdVbml0cwEBszwALgBEszwAAAEAdwP/////AQH/////AAAAADdgiQoCAAAAAQAL" +
           "AAAATWF4VmVsb2NpdHkBAbQ8AwAAAAA+AAAATWF4aW11bSB2ZWxvY2l0eSB0aGUgcm9ib3Qgc2hvdWxk" +
           "IG1vdmUgaW4gcmFkL3MgZm9yIGV2ZXJ5IGF4aXMALwEAWUS0PAAAAAsBAAAAAQAAAAAAAAADA/////8B" +
           "AAAAFWCJCgIAAAAAABAAAABFbmdpbmVlcmluZ1VuaXRzAQG5PAAuAES5PAAAAQB3A/////8BAf////8A" +
           "AAAA";
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

    #region JointPtpMoveSkillState Class
    #if (!OPCUA_EXCLUDE_JointPtpMoveSkillState)
    /// <summary>
    /// Stores an instance of the JointPtpMoveSkillType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class JointPtpMoveSkillState : PtpMoveSkillState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public JointPtpMoveSkillState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Robotics.ObjectTypes.JointPtpMoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics, namespaceUris);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////wRggAIBAAAAAQAdAAAASm9pbnRQdHBNb3Zl" +
           "U2tpbGxUeXBlSW5zdGFuY2UBAbo8AQG6PLo8AAABAAAAAQDDRAABAbg7DAAAABVgiQoCAAAAAAAMAAAA" +
           "Q3VycmVudFN0YXRlAQG7PAAvAQDICrs8AAAAFf////8BAf////8CAAAAFWCJCgIAAAAAAAIAAABJZAEB" +
           "vDwALgBEvDwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgEBvjwALgBEvjwAAAAH" +
           "/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQHAPAAvAQDPCsA8AAAAFf//" +
           "//8BAf////8DAAAAFWCJCgIAAAAAAAIAAABJZAEBwTwALgBEwTwAAAAR/////wEB/////wAAAAAVYIkK" +
           "AgAAAAAABgAAAE51bWJlcgEBwzwALgBEwzwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRy" +
           "YW5zaXRpb25UaW1lAQHEPAAuAETEPAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABEZWxl" +
           "dGFibGUBAck8AC4ARMk8AAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABBdXRvRGVsZXRlAQHK" +
           "PAAuAETKPAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAUmVjeWNsZUNvdW50AQHLPAAuAETL" +
           "PAAAAAb/////AQH/////AAAAABVgiQoCAAAAAAAQAAAATWF4SW5zdGFuY2VDb3VudAEBzTwALgBEzTwA" +
           "AAAH/////wEB/////wAAAAAEYYIKBAAAAAAABQAAAFN0YXJ0AQH3PAAvAQB6Cfc8AAABAQEAAAAANQEB" +
           "Aec8AAAAAARhggoEAAAAAAAHAAAAU3VzcGVuZAEB+DwALwEAewn4PAAAAQEBAAAAADUBAQHtPAAAAAAE" +
           "YYIKBAAAAAAABgAAAFJlc3VtZQEB+TwALwEAfAn5PAAAAQEBAAAAADUBAQHvPAAAAAAEYYIKBAAAAAAA" +
           "BAAAAEhhbHQBAfo8AC8BAH0J+jwAAAEBAwAAAAA1AQEB6TwANQEBAfE8ADUBAQH1PAAAAAAEYYIKBAAA" +
           "AAAABQAAAFJlc2V0AQH7PAAvAQB+Cfs8AAABAQEAAAAANQEBAeU8AAAAAARggAoBAAAAAwAMAAAAUGFy" +
           "YW1ldGVyU2V0AQH9PAAvADr9PAAA/////wMAAAA1YIkKAgAAAAEACQAAAFRvb2xGcmFtZQEB/jwDAAAA" +
           "ADQAAABUaGUgbmFtZSBvZiB0aGUgdG9vbCBmcmFtZSB0byBiZSB1c2VkIGZvciB0aGUgbW90aW9uAC8A" +
           "P/48AAAADP////8DA/////8AAAAAN2CJCgIAAAABAA8AAABNYXhBY2NlbGVyYXRpb24BAf88AwAAAABE" +
           "AAAATWF4aW11bSBhY2NlbGVyYXRpb24gdGhlIHJvYm90IHNob3VsZCBtb3ZlIGluIHJhZC9zXjIgZm9y" +
           "IGV2ZXJ5IGF4aXMALwEAWUT/PAAAAAsBAAAAAQAAAAAAAAADA/////8BAAAAFWCJCgIAAAAAABAAAABF" +
           "bmdpbmVlcmluZ1VuaXRzAQEEPQAuAEQEPQAAAQB3A/////8BAf////8AAAAAN2CJCgIAAAABAAsAAABN" +
           "YXhWZWxvY2l0eQEBBT0DAAAAAD4AAABNYXhpbXVtIHZlbG9jaXR5IHRoZSByb2JvdCBzaG91bGQgbW92" +
           "ZSBpbiByYWQvcyBmb3IgZXZlcnkgYXhpcwAvAQBZRAU9AAAACwEAAAABAAAAAAAAAAMD/////wEAAAAV" +
           "YIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAQo9AC4ARAo9AAABAHcD/////wEB/////wAAAAA=";
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

    #region FinishStateMachineState Class
    #if (!OPCUA_EXCLUDE_FinishStateMachineState)
    /// <summary>
    /// Stores an instance of the FinishStateMachineType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class FinishStateMachineState : FiniteStateMachineState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public FinishStateMachineState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Robotics.ObjectTypes.FinishStateMachineType, fortiss_Robotics.Namespaces.fortissRobotics, namespaceUris);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////wRggAIBAAAAAQAeAAAARmluaXNoU3RhdGVN" +
           "YWNoaW5lVHlwZUluc3RhbmNlAQHnPgEB5z7nPgAA/////wEAAAAVYIkKAgAAAAAADAAAAEN1cnJlbnRT" +
           "dGF0ZQEB7T4ALwEAyArtPgAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAe4+AC4ARO4+" +
           "AAAAEf////8BAf////8AAAAA";
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

    #region CartesianLinearForceMoveSkillState Class
    #if (!OPCUA_EXCLUDE_CartesianLinearForceMoveSkillState)
    /// <summary>
    /// Stores an instance of the CartesianLinearForceMoveSkillType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CartesianLinearForceMoveSkillState : CartesianLinearMoveSkillState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CartesianLinearForceMoveSkillState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Robotics.ObjectTypes.CartesianLinearForceMoveSkillType, fortiss_Robotics.Namespaces.fortissRobotics, namespaceUris);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////wRggAIBAAAAAQApAAAAQ2FydGVzaWFuTGlu" +
           "ZWFyRm9yY2VNb3ZlU2tpbGxUeXBlSW5zdGFuY2UBAQs9AQELPQs9AAACAAAAAQDDRAABAcA7AQDDRAAB" +
           "AaE7DgAAABVgiQoCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQEMPQAvAQDICgw9AAAAFf////8BAf////8C" +
           "AAAAFWCJCgIAAAAAAAIAAABJZAEBDT0ALgBEDT0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAA" +
           "AE51bWJlcgEBDz0ALgBEDz0AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAExhc3RUcmFuc2l0" +
           "aW9uAQERPQAvAQDPChE9AAAAFf////8BAf////8DAAAAFWCJCgIAAAAAAAIAAABJZAEBEj0ALgBEEj0A" +
           "AAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgEBFD0ALgBEFD0AAAAH/////wEB////" +
           "/wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQEVPQAuAEQVPQAAAQAmAf////8BAf////8A" +
           "AAAAFWCJCgIAAAAAAAkAAABEZWxldGFibGUBARo9AC4ARBo9AAAAAf////8BAf////8AAAAAFWCJCgIA" +
           "AAAAAAoAAABBdXRvRGVsZXRlAQEbPQAuAEQbPQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAMAAAA" +
           "UmVjeWNsZUNvdW50AQEcPQAuAEQcPQAAAAb/////AQH/////AAAAABVgiQoCAAAAAAAQAAAATWF4SW5z" +
           "dGFuY2VDb3VudAEBHj0ALgBEHj0AAAAH/////wEB/////wAAAAAEYIAKAQAAAAAADwAAAEZpbmFsUmVz" +
           "dWx0RGF0YQEBLT0ALwA6LT0AAP////8AAAAABGGCCgQAAAAAAAUAAABTdGFydAEBSD0ALwEAeglIPQAA" +
           "AQEBAAAAADUBAQE4PQAAAAAEYYIKBAAAAAAABwAAAFN1c3BlbmQBAUk9AC8BAHsJST0AAAEBAQAAAAA1" +
           "AQEBPj0AAAAABGGCCgQAAAAAAAYAAABSZXN1bWUBAUo9AC8BAHwJSj0AAAEBAQAAAAA1AQEBQD0AAAAA" +
           "BGGCCgQAAAAAAAQAAABIYWx0AQFLPQAvAQB9CUs9AAABAQMAAAAANQEBATo9ADUBAQFCPQA1AQEBRj0A" +
           "AAAABGGCCgQAAAAAAAUAAABSZXNldAEBTD0ALwEAfglMPQAAAQEBAAAAADUBAQE2PQAAAAAEYIAKAQAA" +
           "AAMADAAAAFBhcmFtZXRlclNldAEBTj0ALwA6Tj0AAP////8DAAAANWCJCgIAAAABAAkAAABUb29sRnJh" +
           "bWUBAU89AwAAAAA0AAAAVGhlIG5hbWUgb2YgdGhlIHRvb2wgZnJhbWUgdG8gYmUgdXNlZCBmb3IgdGhl" +
           "IG1vdGlvbgAvAD9PPQAAAAz/////AwP/////AAAAADdgiQoCAAAAAQAPAAAATWF4QWNjZWxlcmF0aW9u" +
           "AQFQPQMAAAAAhwAAAE1heGltdW0gYWNjZWxlcmF0aW9uIG9mIHRoZSByb2JvdCBzaG91bGQgbW92ZS4g" +
           "Rmlyc3QgdGhyZWUgcGFyYW1ldGVycyBhcmUgZm9yIHgseSx6IGluIG0vc14yLiBUaGUgbmV4dCB0aHJl" +
           "ZSBmb3Igb3JpZW50YXRpb24gaW4gcmFkL3NeMgAvAQBZRFA9AAAACwEAAAABAAAABgAAAAMD/////wEA" +
           "AAAVYIkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAVU9AC4ARFU9AAABAHcD/////wEB/////wAA" +
           "AAA3YIkKAgAAAAEACwAAAE1heFZlbG9jaXR5AQFWPQMAAAAAfwAAAE1heGltdW0gdmVsb2NpdHkgb2Yg" +
           "dGhlIHJvYm90IHNob3VsZCBtb3ZlLiBGaXJzdCB0aHJlZSBwYXJhbWV0ZXJzIGFyZSBmb3IgeCx5LHog" +
           "aW4gbS9zLiBUaGUgbmV4dCB0aHJlZSBmb3Igb3JpZW50YXRpb24gaW4gcmFkL3MALwEAWURWPQAAAAsB" +
           "AAAAAQAAAAYAAAADA/////8BAAAAFWCJCgIAAAAAABAAAABFbmdpbmVlcmluZ1VuaXRzAQFbPQAuAERb" +
           "PQAAAQB3A/////8BAf////8AAAAABGCACgEAAAABABIAAABGaW5pc2hTdGF0ZU1hY2hpbmUBAf4+AC8B" +
           "Aec+/j4AAP////8BAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBAeg+AC8BAMgK6D4AAAAV////" +
           "/wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQH6PgAuAET6PgAAABH/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public FinishStateMachineState FinishStateMachine
        {
            get
            {
                return m_finishStateMachine;
            }

            set
            {
                if (!Object.ReferenceEquals(m_finishStateMachine, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_finishStateMachine = value;
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
            if (m_finishStateMachine != null)
            {
                children.Add(m_finishStateMachine);
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
                case fortiss_Robotics.BrowseNames.FinishStateMachine:
                {
                    if (createOrReplace)
                    {
                        if (FinishStateMachine == null)
                        {
                            if (replacement == null)
                            {
                                FinishStateMachine = new FinishStateMachineState(this);
                            }
                            else
                            {
                                FinishStateMachine = (FinishStateMachineState)replacement;
                            }
                        }
                    }

                    instance = FinishStateMachine;
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
        private FinishStateMachineState m_finishStateMachine;
        #endregion
    }
    #endif
    #endregion

    #region StreamSkillState Class
    #if (!OPCUA_EXCLUDE_StreamSkillState)
    /// <summary>
    /// Stores an instance of the StreamSkillType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class StreamSkillState : SkillState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public StreamSkillState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Robotics.ObjectTypes.StreamSkillType, fortiss_Robotics.Namespaces.fortissRobotics, namespaceUris);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////wRggAIBAAAAAQAXAAAAU3RyZWFtU2tpbGxU" +
           "eXBlSW5zdGFuY2UBAVw9AQFcPVw9AAD/////CwAAABVgiQoCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQFd" +
           "PQAvAQDICl09AAAAFf////8BAf////8CAAAAFWCJCgIAAAAAAAIAAABJZAEBXj0ALgBEXj0AAAAR////" +
           "/wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgEBYD0ALgBEYD0AAAAH/////wEB/////wAAAAAV" +
           "YIkKAgAAAAAADgAAAExhc3RUcmFuc2l0aW9uAQFiPQAvAQDPCmI9AAAAFf////8BAf////8DAAAAFWCJ" +
           "CgIAAAAAAAIAAABJZAEBYz0ALgBEYz0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJl" +
           "cgEBZT0ALgBEZT0AAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQFm" +
           "PQAuAERmPQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABEZWxldGFibGUBAWs9AC4ARGs9" +
           "AAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABBdXRvRGVsZXRlAQFsPQAuAERsPQAAAAH/////" +
           "AQH/////AAAAABVgiQoCAAAAAAAMAAAAUmVjeWNsZUNvdW50AQFtPQAuAERtPQAAAAb/////AQH/////" +
           "AAAAABVgiQoCAAAAAAAQAAAATWF4SW5zdGFuY2VDb3VudAEBbz0ALgBEbz0AAAAH/////wEB/////wAA" +
           "AAAEYYIKBAAAAAAABQAAAFN0YXJ0AQGZPQAvAQB6CZk9AAABAQEAAAAANQEBAYk9AAAAAARhggoEAAAA" +
           "AAAHAAAAU3VzcGVuZAEBmj0ALwEAewmaPQAAAQEBAAAAADUBAQGPPQAAAAAEYYIKBAAAAAAABgAAAFJl" +
           "c3VtZQEBmz0ALwEAfAmbPQAAAQEBAAAAADUBAQGRPQAAAAAEYYIKBAAAAAAABAAAAEhhbHQBAZw9AC8B" +
           "AH0JnD0AAAEBAwAAAAA1AQEBiz0ANQEBAZM9ADUBAQGXPQAAAAAEYYIKBAAAAAAABQAAAFJlc2V0AQGd" +
           "PQAvAQB+CZ09AAABAQEAAAAANQEBAYc9AAAAAA==";
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

    #region PositionStreamSkillState Class
    #if (!OPCUA_EXCLUDE_PositionStreamSkillState)
    /// <summary>
    /// Stores an instance of the PositionStreamSkillType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class PositionStreamSkillState : SkillState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public PositionStreamSkillState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Robotics.ObjectTypes.PositionStreamSkillType, fortiss_Robotics.Namespaces.fortissRobotics, namespaceUris);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////wRggAIBAAAAAQAfAAAAUG9zaXRpb25TdHJl" +
           "YW1Ta2lsbFR5cGVJbnN0YW5jZQEBnz0BAZ89nz0AAP////8MAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50" +
           "U3RhdGUBAaA9AC8BAMgKoD0AAAAV/////wEB/////wIAAAAVYIkKAgAAAAAAAgAAAElkAQGhPQAuAESh" +
           "PQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAATnVtYmVyAQGjPQAuAESjPQAAAAf/////AQH/" +
           "////AAAAABVgiQoCAAAAAAAOAAAATGFzdFRyYW5zaXRpb24BAaU9AC8BAM8KpT0AAAAV/////wEB////" +
           "/wMAAAAVYIkKAgAAAAAAAgAAAElkAQGmPQAuAESmPQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAG" +
           "AAAATnVtYmVyAQGoPQAuAESoPQAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlv" +
           "blRpbWUBAak9AC4ARKk9AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAERlbGV0YWJsZQEB" +
           "rj0ALgBErj0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAEF1dG9EZWxldGUBAa89AC4ARK89" +
           "AAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABSZWN5Y2xlQ291bnQBAbA9AC4ARLA9AAAABv//" +
           "//8BAf////8AAAAAFWCJCgIAAAAAABAAAABNYXhJbnN0YW5jZUNvdW50AQGyPQAuAESyPQAAAAf/////" +
           "AQH/////AAAAAARhggoEAAAAAAAFAAAAU3RhcnQBAdw9AC8BAHoJ3D0AAAEBAQAAAAA1AQEBzD0AAAAA" +
           "BGGCCgQAAAAAAAcAAABTdXNwZW5kAQHdPQAvAQB7Cd09AAABAQEAAAAANQEBAdI9AAAAAARhggoEAAAA" +
           "AAAGAAAAUmVzdW1lAQHePQAvAQB8Cd49AAABAQEAAAAANQEBAdQ9AAAAAARhggoEAAAAAAAEAAAASGFs" +
           "dAEB3z0ALwEAfQnfPQAAAQEDAAAAADUBAQHOPQA1AQEB1j0ANQEBAdo9AAAAAARhggoEAAAAAAAFAAAA" +
           "UmVzZXQBAeA9AC8BAH4J4D0AAAEBAQAAAAA1AQEByj0AAAAABGCACgEAAAADAAwAAABQYXJhbWV0ZXJT" +
           "ZXQBAeI9AC8AOuI9AAD/////AQAAADVgiQoCAAAAAQAOAAAAVGFyZ2V0UG9zaXRpb24BAeM9AwAAAADh" +
           "AAAAQWJzb2x1dGUgcG9zaXRpb24gaW4gY2FydGVzaWFuIHNwYWNlIHdoZXJlIHRoZSByb2JvdCBzaG91" +
           "bGQgbW92ZSB0by4KICAgICAgICAgICAgICBBcyBzb29uIGFzIHRoZXJlIGlzIGEgbmV3IHZhbHVlIHdy" +
           "aXR0ZW4gdG8gdGhpcyB2YXJpYWJsZSwgdGhlIHJvYm90IHdpbGwgbW92ZSB0byB0aGF0IHBvc2l0aW9u" +
           "IGlmIHRoZQogICAgICAgICAgICAgIHNraWxsIGlzIGluIHJ1bm5pbmcgc3RhdGUuAC8BAGdJ4z0AAAEA" +
           "fkn/////AwP/////AgAAABVgiQoCAAAAAAAUAAAAQ2FydGVzaWFuQ29vcmRpbmF0ZXMBAeQ9AC8BAFZJ" +
           "5D0AAAEAekn/////AQH/////AwAAABVgiQoCAAAAAAABAAAAWAEB6z0ALwA/6z0AAAAL/////wEB////" +
           "/wAAAAAVYIkKAgAAAAAAAQAAAFkBAew9AC8AP+w9AAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAEA" +
           "AABaAQHtPQAvAD/tPQAAAAv/////AQH/////AAAAABVgiQoCAAAAAAALAAAAT3JpZW50YXRpb24BAeY9" +
           "AC8BAF1J5j0AAAEAfEn/////AQH/////AwAAABVgiQoCAAAAAAABAAAAQQEB7j0ALwA/7j0AAAAL////" +
           "/wEB/////wAAAAAVYIkKAgAAAAAAAQAAAEIBAe89AC8AP+89AAAAC/////8BAf////8AAAAAFWCJCgIA" +
           "AAAAAAEAAABDAQHwPQAvAD/wPQAAAAv/////AQH/////AAAAAA==";
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

    #region FortissMotionDeviceState Class
    #if (!OPCUA_EXCLUDE_FortissMotionDeviceState)
    /// <summary>
    /// Stores an instance of the FortissMotionDeviceType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class FortissMotionDeviceState : MotionDeviceState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public FortissMotionDeviceState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(fortiss_Robotics.ObjectTypes.FortissMotionDeviceType, fortiss_Robotics.Namespaces.fortissRobotics, namespaceUris);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////wRggAIBAAAAAQAfAAAARm9ydGlzc01vdGlv" +
           "bkRldmljZVR5cGVJbnN0YW5jZQEB8T0BAfE98T0AAP////8MAAAAJGCACgEAAAADAAwAAABQYXJhbWV0" +
           "ZXJTZXQBAfI9AwAAAAAXAAAARmxhdCBsaXN0IG9mIFBhcmFtZXRlcnMALwA68j0AAP////8FAAAANWCJ" +
           "CgIAAAAEAA0AAABTcGVlZE92ZXJyaWRlAQEZPgMAAAAAWwAAAFNwZWVkT3ZlcnJpZGUgcHJvdmlkZXMg" +
           "dGhlIGN1cnJlbnQgc3BlZWQgc2V0dGluZyBpbiBwZXJjZW50IG9mIHByb2dyYW1tZWQgc3BlZWQgKDAg" +
           "LSAxMDAlKS4ALwA/GT4AAAAL/////wEB/////wAAAAA1YKkKAgAAAAEAEAAAAFdvcmxkVG9Sb2JvdEJh" +
           "c2UBARM/AwAAAADMAAAAVHJhbnNmb3JtYXRpb24gZnJhbWUgZnJvbSB0aGUgd29ybGQgZnJhbWUgdG8g" +
           "dGhlIHJvYm90IGJhc2UgZnJhbWUuIFRoaXMgdHJhbnNmb3JtYXRpb24gY2FuIGJlIHVzZWQgYnkKICAg" +
           "ICAgICAgICAgICBvdGhlciBjb21wb25lbnRzIHRvIHRyYW5zZm9ybSB3b3JsZCBjb29yZGluYXRlcyB0" +
           "byBjYXJ0ZXNpYW4gY29vcmRpbmF0ZXMgaW4gcm9ib3QgZnJhbWUuAC8BAGdJEz8AABYBAIdJATAAAAAA" +
           "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAH5J/////wMD////" +
           "/wIAAAAVYIkKAgAAAAAAFAAAAENhcnRlc2lhbkNvb3JkaW5hdGVzAQEUPwAvAQBWSRQ/AAABAHpJ////" +
           "/wEB/////wMAAAAVYIkKAgAAAAAAAQAAAFgBARs/AC8APxs/AAAAC/////8BAf////8AAAAAFWCJCgIA" +
           "AAAAAAEAAABZAQEcPwAvAD8cPwAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAWgEBHT8ALwA/" +
           "HT8AAAAL/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAE9yaWVudGF0aW9uAQEWPwAvAQBdSRY/AAAB" +
           "AHxJ/////wEB/////wMAAAAVYIkKAgAAAAAAAQAAAEEBAR4/AC8APx4/AAAAC/////8BAf////8AAAAA" +
           "FWCJCgIAAAAAAAEAAABCAQEfPwAvAD8fPwAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAQwEB" +
           "ID8ALwA/ID8AAAAL/////wEB/////wAAAAA1YIkKAgAAAAQADAAAAERldmljZU9uUGF0aAEB4T4DAAAA" +
           "AOEAAABUaGUgRGV2aWNlT25QYXRoIGluZGljYXRlcyB3aGV0aGVyIHRoZSBtb3Rpb24gZGV2aWNlIGlz" +
           "IG9uIHRoZSBwbGFubmVkIHByb2dyYW0KICAgICAgICAgICAgICBwYXRoOiJ0cnVlIi5cbklmIHRoZSBN" +
           "b3Rpb25EZXZpY2UgbGVhdmVzIHRoaXMgcGF0aCBpbiB0aGUgZmFpbHVyZSBjYXNlIG9yIGluIGFuIGVt" +
           "ZXJnZW5jeQogICAgICAgICAgICAgIHN0b3AsIHRoaXMgdmFsdWUgaXMgImZhbHNlIi4ALwA/4T4AAAAB" +
           "/////wEB/////wAAAAA1YIkKAgAAAAQAFQAAAFByb2dyYW1tZWREZXZpY2VTcGVlZAEB4j4DAAAAAEUA" +
           "AABQcm9ncmFtbWVkRGV2aWNlU3BlZWQgaXMgdGhlIHByb2dyYW1tZWQgbW90aW9uIGRldmljZSBzcGVl" +
           "ZCAoMC0xMDAlKS4ALwA/4j4AAAAG/////wEB/////wAAAAA1YIkKAgAAAAQADAAAAFVuZGVyQ29udHJv" +
           "bAEB4z4DAAAAAKYAAABBeGlzVW5kZXJDb250cm9sIGluZGljYXRlcyB3aGV0aGVyIHRoZSBhY3R1YXRv" +
           "cnMgb2YgdGhlIE1vdGlvbkRldmljZSBhcmUgdW5kZXIKICAgICAgICAgICAgICBwb3dlciBhbmQgY29u" +
           "dHJvbDoidHJ1ZSIuXG5UaGUgTW90aW9uRGV2aWNlIGNhbiBob3dldmVyIGJlIGF0IHN0YW5kc3RpbGwu" +
           "AC8AP+M+AAAAAf////8BAf////8AAAAAFWCJCgIAAAADAAwAAABNYW51ZmFjdHVyZXIBAQg+AC4ARAg+" +
           "AAAAFf////8BAf////8AAAAAFWCJCgIAAAADAAUAAABNb2RlbAEBCj4ALgBECj4AAAAV/////wEB////" +
           "/wAAAAAVYIkKAgAAAAMACwAAAFByb2R1Y3RDb2RlAQEOPgAuAEQOPgAAAAz/////AQH/////AAAAABVg" +
           "iQoCAAAAAwAMAAAAU2VyaWFsTnVtYmVyAQERPgAuAEQRPgAAAAz/////AQH/////AAAAADVgiQoCAAAA" +
           "BAAUAAAATW90aW9uRGV2aWNlQ2F0ZWdvcnkBARY+AwAAAACCAAAAVGhlIHZhcmlhYmxlIE1vdGlvbkRl" +
           "dmljZUNhdGVnb3J5IHByb3ZpZGVzIHRoZSBraW5kIG9mIG1vdGlvbiBkZXZpY2UgZGVmaW5lZCBieSBN" +
           "b3Rpb25EZXZpY2VDYXRlZ29yeUVudW1lcmF0aW9uIGJhc2VkIG9uIElTTyA4MzczLgAuAEQWPgAAAQQR" +
           "R/////8BAf////8AAAAAJGCACgEAAAAEAAQAAABBeGVzAQEaPgMAAAAAPgAAAEF4ZXMgaXMgYSBjb250" +
           "YWluZXIgZm9yIG9uZSBvciBtb3JlIGluc3RhbmNlcyBvZiB0aGUgQXhpc1R5cGUuAC8APRo+AAD/////" +
           "AAAAACRggAoBAAAABAALAAAAUG93ZXJUcmFpbnMBAWs+AwAAAABLAAAAUG93ZXJUcmFpbnMgaXMgYSBj" +
           "b250YWluZXIgZm9yIG9uZSBvciBtb3JlIGluc3RhbmNlcyBvZiB0aGUgUG93ZXJUcmFpblR5cGUuAC8A" +
           "PWs+AAD/////AAAAACRggAoBAAAABAAKAAAARmxhbmdlTG9hZAEBjz4DAAAAAJMAAABUaGUgRmxhbmdl" +
           "TG9hZCBpcyB0aGUgbG9hZCBvbiB0aGUgZmxhbmdlIG9yIGF0IHRoZSBtb3VudGluZyBwb2ludCBvZiB0" +
           "aGUKICAgICAgICAgIE1vdGlvbkRldmljZS5cblRoaXMgY2FuIGJlIHRoZSBtYXhpbXVtIGxvYWQgb2Yg" +
           "dGhlIE1vdGlvbkRldmljZS4ALwEE+gOPPgAA/////wMAAAA1YIkKAgAAAAQABAAAAE1hc3MBAZA+AwAA" +
           "AAA1AAAAVGhlIHdlaWdodCBvZiB0aGUgbG9hZCBtb3VudGVkIG9uIG9uZSBtb3VudGluZyBwb2ludC4A" +
           "LwEAWUSQPgAAAAv/////AQH/////AQAAABVgiQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEBlT4A" +
           "LgBElT4AAAEAdwP/////AQH/////AAAAADVgiQoCAAAABAAMAAAAQ2VudGVyT2ZNYXNzAQGWPgMAAAAA" +
           "jAEAAFRoZSBwb3NpdGlvbiBhbmQgb3JpZW50YXRpb24gb2YgdGhlIGNlbnRlciBvZiB0aGUgbWFzcyBy" +
           "ZWxhdGVkIHRvIHRoZSBtb3VudGluZyBwb2ludCB1c2luZyBhIEZyYW1lVHlwZS4gWCwgWSwgWiBkZWZp" +
           "bmUgdGhlIHBvc2l0aW9uIG9mIHRoZSBjZW50ZXIgb2YgZ3Jhdml0eSByZWxhdGl2ZSB0byB0aGUgbW91" +
           "bnRpbmcgcG9pbnQgY29vcmRpbmF0ZSBzeXN0ZW0uIEEsIEIsIEMgZGVmaW5lIHRoZSBvcmllbnRhdGlv" +
           "biBvZiB0aGUgcHJpbmNpcGFsIGF4ZXMgb2YgaW5lcnRpYSByZWxhdGl2ZSB0byB0aGUgbW91bnRpbmcg" +
           "cG9pbnQgY29vcmRpbmF0ZSBzeXN0ZW0uIE9yaWVudGF0aW9uIEEsIEIsIEMgY2FuIGJlICIwIiBmb3Ig" +
           "c3lzdGVtcyB3aGljaCBkbyBub3QgbmVlZCB0aGVzZSAgdmFsdWVzLgAvAQBnSZY+AAABAH5J/////wEB" +
           "/////wIAAAAVYIkKAgAAAAAAFAAAAENhcnRlc2lhbkNvb3JkaW5hdGVzAQGXPgAvAQBWSZc+AAABAHpJ" +
           "/////wEB/////wMAAAAVYIkKAgAAAAAAAQAAAFgBAZ4+AC8AP54+AAAAC/////8BAf////8AAAAAFWCJ" +
           "CgIAAAAAAAEAAABZAQGfPgAvAD+fPgAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAWgEBoD4A" +
           "LwA/oD4AAAAL/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAE9yaWVudGF0aW9uAQGZPgAvAQBdSZk+" +
           "AAABAHxJ/////wEB/////wMAAAAVYIkKAgAAAAAAAQAAAEEBAaE+AC8AP6E+AAAAC/////8BAf////8A" +
           "AAAAFWCJCgIAAAAAAAEAAABCAQGiPgAvAD+iPgAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAA" +
           "QwEBoz4ALwA/oz4AAAAL/////wEB/////wAAAAA1YIkKAgAAAAQABwAAAEluZXJ0aWEBAaQ+AwAAAAD6" +
           "AAAAVGhlIEluZXJ0aWEgdXNlcyB0aGUgVmVjdG9yVHlwZSB0byBkZXNjcmliZSB0aGUgdGhyZWUgdmFs" +
           "dWVzIG9mIHRoZSBwcmluY2lwYWwgbW9tZW50cyBvZiBpbmVydGlhIHdpdGggcmVzcGVjdCB0byB0aGUg" +
           "bW91bnRpbmcgcG9pbnQgY29vcmRpbmF0ZSBzeXN0ZW0uIElmIGluZXJ0aWEgdmFsdWVzIGFyZSBwcm92" +
           "aWRlZCBmb3Igcm90YXJ5IGF4aXMgdGhlIENlbnRlck9mTWFzcyBzaGFsbCBiZSBjb21wbGV0ZWx5IGZp" +
           "bGxlZCBhcyB3ZWxsLgAvAQA0RaQ+AAABAHhJ/////wEB/////wMAAAAVYIkKAgAAAAAAAQAAAFgBAaY+" +
           "AC8AP6Y+AAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAEAAABZAQGnPgAvAD+nPgAAAAv/////AQH/" +
           "////AAAAABVgiQoCAAAAAAABAAAAWgEBqD4ALwA/qD4AAAAL/////wEB/////wAAAAAEYYIKBAAAAAEA" +
           "DQAAAEZsYW5nZVRvb2xTZXQBAc0+AC8BAc0+zT4AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0" +
           "QXJndW1lbnRzAQHOPgAuAETOPgAAlgUAAAABACoBARMAAAAEAAAATmFtZQAM/////wAAAAAAAQAqAQEW" +
           "AAAABQAAAEZyYW1lAQB+Sf////8AAAAAAAEAKgEBEwAAAAQAAABNYXNzAAv/////AAAAAAABACoBAR0A" +
           "AAAMAAAAQ2VudGVyT2ZNYXNzAQB+Sf////8AAAAAAAEAKgEBGAAAAAcAAABJbmVydGlhAQB4Sf////8A" +
           "AAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAABAA8AAABGbGFuZ2VUb29sQ2xlYXIB" +
           "Ac8+AC8BAc8+zz4AAAEB/////wAAAAAEYIAKAQAAAAEACgAAAEZsYW5nZVRvb2wBAdE+AC8AOtE+AAD/" +
           "////AgAAABVgiQoCAAAABAAEAAAATmFtZQEB0j4ALgBE0j4AAAAM/////wEB/////wAAAAAVYMkKAgAA" +
           "AAsAAABUaHJlZURGcmFtZQAABwAAADNERnJhbWUBAdM+AC8BAGdJ0z4AAAEAfkn/////AQH/////AgAA" +
           "ABVgiQoCAAAAAAAUAAAAQ2FydGVzaWFuQ29vcmRpbmF0ZXMBAdQ+AC8BAFZJ1D4AAAEAekn/////AQH/" +
           "////AwAAABVgiQoCAAAAAAABAAAAWAEB2z4ALwA/2z4AAAAL/////wEB/////wAAAAAVYIkKAgAAAAAA" +
           "AQAAAFkBAdw+AC8AP9w+AAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAEAAABaAQHdPgAvAD/dPgAA" +
           "AAv/////AQH/////AAAAABVgiQoCAAAAAAALAAAAT3JpZW50YXRpb24BAdY+AC8BAF1J1j4AAAEAfEn/" +
           "////AQH/////AwAAABVgiQoCAAAAAAABAAAAQQEB3j4ALwA/3j4AAAAL/////wEB/////wAAAAAVYIkK" +
           "AgAAAAAAAQAAAEIBAd8+AC8AP98+AAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAEAAABDAQHgPgAv" +
           "AD/gPgAAAAv/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public FlangeToolSetMethodState FlangeToolSet
        {
            get
            {
                return m_flangeToolSetMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_flangeToolSetMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_flangeToolSetMethod = value;
            }
        }

        /// <remarks />
        public MethodState FlangeToolClear
        {
            get
            {
                return m_flangeToolClearMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_flangeToolClearMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_flangeToolClearMethod = value;
            }
        }

        /// <remarks />
        public BaseObjectState FlangeTool
        {
            get
            {
                return m_flangeTool;
            }

            set
            {
                if (!Object.ReferenceEquals(m_flangeTool, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_flangeTool = value;
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
            if (m_flangeToolSetMethod != null)
            {
                children.Add(m_flangeToolSetMethod);
            }

            if (m_flangeToolClearMethod != null)
            {
                children.Add(m_flangeToolClearMethod);
            }

            if (m_flangeTool != null)
            {
                children.Add(m_flangeTool);
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
                case fortiss_Robotics.BrowseNames.FlangeToolSet:
                {
                    if (createOrReplace)
                    {
                        if (FlangeToolSet == null)
                        {
                            if (replacement == null)
                            {
                                FlangeToolSet = new FlangeToolSetMethodState(this);
                            }
                            else
                            {
                                FlangeToolSet = (FlangeToolSetMethodState)replacement;
                            }
                        }
                    }

                    instance = FlangeToolSet;
                    break;
                }

                case fortiss_Robotics.BrowseNames.FlangeToolClear:
                {
                    if (createOrReplace)
                    {
                        if (FlangeToolClear == null)
                        {
                            if (replacement == null)
                            {
                                FlangeToolClear = new MethodState(this);
                            }
                            else
                            {
                                FlangeToolClear = (MethodState)replacement;
                            }
                        }
                    }

                    instance = FlangeToolClear;
                    break;
                }

                case fortiss_Robotics.BrowseNames.FlangeTool:
                {
                    if (createOrReplace)
                    {
                        if (FlangeTool == null)
                        {
                            if (replacement == null)
                            {
                                FlangeTool = new BaseObjectState(this);
                            }
                            else
                            {
                                FlangeTool = (BaseObjectState)replacement;
                            }
                        }
                    }

                    instance = FlangeTool;
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
        private FlangeToolSetMethodState m_flangeToolSetMethod;
        private MethodState m_flangeToolClearMethod;
        private BaseObjectState m_flangeTool;
        #endregion
    }
    #endif
    #endregion

    #region FlangeToolSetMethodState Class
    #if (!OPCUA_EXCLUDE_FlangeToolSetMethodState)
    /// <summary>
    /// Stores an instance of the FlangeToolSetMethodType Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class FlangeToolSetMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public FlangeToolSetMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new FlangeToolSetMethodState(parent);
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
           "BAAAACAAAABodHRwczovL2ZvcnRpc3Mub3JnL1VBL1JvYm90aWNzLx4AAABodHRwczovL2ZvcnRpc3Mu" +
           "b3JnL1VBL0RldmljZS8fAAAAaHR0cDovL29wY2ZvdW5kYXRpb24ub3JnL1VBL0RJLyUAAABodHRwOi8v" +
           "b3BjZm91bmRhdGlvbi5vcmcvVUEvUm9ib3RpY3Mv/////wRhggoEAAAAAQAXAAAARmxhbmdlVG9vbFNl" +
           "dE1ldGhvZFR5cGUBAeQ+AC8BAeQ+5D4AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1l" +
           "bnRzAQHlPgAuAETlPgAAlgUAAAABACoBARMAAAAEAAAATmFtZQAM/////wAAAAAAAQAqAQEWAAAABQAA" +
           "AEZyYW1lAQB+Sf////8AAAAAAAEAKgEBEwAAAAQAAABNYXNzAAv/////AAAAAAABACoBAR0AAAAMAAAA" +
           "Q2VudGVyT2ZNYXNzAQB+Sf////8AAAAAAAEAKgEBGAAAAAcAAABJbmVydGlhAQB4Sf////8AAAAAAAEA" +
           "KAEBAAAAAQAAAAAAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public FlangeToolSetMethodStateMethodCallHandler OnCall;
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

            string name = (string)_inputArguments[0];
            ThreeDFrame frame = (ThreeDFrame)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[1]);
            double mass = (double)_inputArguments[2];
            ThreeDFrame centerOfMass = (ThreeDFrame)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[3]);
            ThreeDVector inertia = (ThreeDVector)ExtensionObject.ToEncodeable((ExtensionObject)_inputArguments[4]);

            if (OnCall != null)
            {
                result = OnCall(
                    _context,
                    this,
                    _objectId,
                    name,
                    frame,
                    mass,
                    centerOfMass,
                    inertia);
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
    public delegate ServiceResult FlangeToolSetMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        string name,
        ThreeDFrame frame,
        double mass,
        ThreeDFrame centerOfMass,
        ThreeDVector inertia);
    #endif
    #endregion
}