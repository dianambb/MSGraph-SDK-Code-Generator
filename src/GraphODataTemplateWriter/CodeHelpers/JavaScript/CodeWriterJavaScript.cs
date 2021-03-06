// Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.

namespace Microsoft.Graph.ODataTemplateWriter.CodeHelpers.JavaScript
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Vipr.Core.CodeModel;

    public class CodeWriterJavaScript : CodeWriterBase
    {
        public CodeWriterJavaScript() : base() { }

        public CodeWriterJavaScript(OdcmModel model) : base(model) { }

        public override String WriteOpeningCommentLine()
        {
            return "# ------------------------------------------------------------------------------" + this.NewLineCharacter;
        }

        public override String WriteClosingCommentLine()
        {
            return "# ------------------------------------------------------------------------------" + this.NewLineCharacter;
        }

        public override string WriteInlineCommentChar()
        {
            return "# ";
        }

        public override String NewLineCharacter
        {
            get { return "\n"; }
        }

        public IEnumerable<OdcmProperty> EntityProperties(OdcmClass obj)
        {
            return obj.Properties.Where(prop => !prop.IsLink).ToList();
        }

        public IEnumerable<OdcmProperty> EntityNavigationProperties(OdcmClass obj)
        {
            return obj.Properties.Where(prop => prop.IsLink).ToList();
        }

        public String FullTypeName(OdcmProperty prop)
        {
            var fullName = prop.Projection.Type.FullName;
            return (prop.IsCollection) ? "Collection(" + fullName + ")" : fullName;
        }
    }

}
