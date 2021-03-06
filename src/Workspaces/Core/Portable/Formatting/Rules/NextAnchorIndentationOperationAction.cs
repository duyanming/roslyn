﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;

#if !CODE_STYLE
using Microsoft.CodeAnalysis.Options;
#endif

namespace Microsoft.CodeAnalysis.Formatting.Rules
{
    internal readonly struct NextAnchorIndentationOperationAction
    {
        private readonly ImmutableArray<AbstractFormattingRule> _formattingRules;
        private readonly int _index;
        private readonly SyntaxNode _node;
        private readonly OptionSet _optionSet;
        private readonly List<AnchorIndentationOperation> _list;

        public NextAnchorIndentationOperationAction(
            ImmutableArray<AbstractFormattingRule> formattingRules,
            int index,
            SyntaxNode node,
            OptionSet optionSet,
            List<AnchorIndentationOperation> list)
        {
            _formattingRules = formattingRules;
            _index = index;
            _node = node;
            _optionSet = optionSet;
            _list = list;
        }

        private NextAnchorIndentationOperationAction NextAction
            => new NextAnchorIndentationOperationAction(_formattingRules, _index + 1, _node, _optionSet, _list);

        public void Invoke()
        {
            // If we have no remaining handlers to execute, then we'll execute our last handler
            if (_index >= _formattingRules.Length)
            {
                return;
            }
            else
            {
                // Call the handler at the index, passing a continuation that will come back to here with index + 1
                _formattingRules[_index].AddAnchorIndentationOperations(_list, _node, _optionSet, NextAction);
                return;
            }
        }
    }
}
