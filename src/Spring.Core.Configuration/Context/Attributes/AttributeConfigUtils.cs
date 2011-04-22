#region License

/*
 * Copyright � 2010-2011 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using System.Collections.ObjectModel;
using System.Reflection;
using Spring.Objects.Factory.Attributes;
using Spring.Objects.Factory.Config;
using Spring.Objects.Factory.Support;

namespace Spring.Context.Attributes
{
    /// <summary>
    /// Utility class that allows for convenient registration of common <see cref="IObjectPostProcessor"/>
    /// and <see cref="IObjectFactoryPostProcessor"/> definitions for attribute based configuration
    /// </summary>
    /// <seealso cref="ConfigurationClassObjectDefinitionReader"/>
    /// <seealso cref="RequiredAttributeObjectPostProcessor"/>
    /// 
    /// <author>Mark Pollack (.NET)</author>
    /// <author>Mark Fisher</author>
    /// <author>Juergen Hoeller</author>
    /// <author>Chris Beams</author>
    public class AttributeConfigUtils
    {

        /// <summary>
        ///  The object name of the internally managed Configuration attribute processor.
        /// </summary>
        public static readonly string CONFIGURATION_ATTRIBUTE_PROCESSOR_OBJECT_NAME = "Spring.Context.Attributes.InternalConfigurationClassPostProcessor";


        /// <summary>
        /// Registers the attribute config processors.
        /// </summary>
        /// <param name="registry">The registry.</param>
        public static void RegisterAttributeConfigProcessors(IObjectDefinitionRegistry registry)
        {
            if (!registry.ContainsObjectDefinition(CONFIGURATION_ATTRIBUTE_PROCESSOR_OBJECT_NAME))
            {
                RootObjectDefinition objectDefinition = new RootObjectDefinition(typeof(ConfigurationClassPostProcessor));
                RegisterPostProcessor(registry, objectDefinition, CONFIGURATION_ATTRIBUTE_PROCESSOR_OBJECT_NAME);             
            }

            //AUTOWIRED_ATTRIBUTE_PROCESSOR_OBJECT_NAME

            //REQUIRED_ATTRIBUTE_PROCESSOR_OBJECT_NAME

        }

        private static void RegisterPostProcessor(IObjectDefinitionRegistry registry, IConfigurableObjectDefinition objectDefinition, string objectName)
        {
            objectDefinition.Role = ObjectRole.ROLE_INFRASTRUCTURE;
            registry.RegisterObjectDefinition(objectName, objectDefinition);
        }
    }

}