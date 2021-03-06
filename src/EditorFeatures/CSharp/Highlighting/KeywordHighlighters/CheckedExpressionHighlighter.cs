﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editor.Implementation.Highlighting;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.Editor.CSharp.KeywordHighlighting.KeywordHighlighters
{
    [ExportHighlighter(LanguageNames.CSharp)]
    internal class CheckedExpressionHighlighter : AbstractKeywordHighlighter<CheckedExpressionSyntax>
    {
        [ImportingConstructor]
        public CheckedExpressionHighlighter()
        {
        }

        protected override void AddHighlights(CheckedExpressionSyntax checkedExpressionSyntax, List<TextSpan> highlights, CancellationToken cancellationToken)
            => highlights.Add(checkedExpressionSyntax.Keyword.Span);
    }
}
