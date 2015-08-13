﻿/********************************************************
*                                                        *
*   © Copyright (C) Microsoft. All rights reserved.      *
*                                                        *
*********************************************************/

using System.Collections.Generic;
using System.Collections.Immutable;
using LanguageService.Shared;
using Validation;

namespace LanguageService.Classification
{
    public class Colourizer
    {
        internal Colourizer(ParseTreeCache parseTreeCache)
        {
            this.ParseTreeCache = parseTreeCache;
        }

        private ParseTreeCache ParseTreeCache { get; }

        public IEnumerable<TagInfo> Colourize(SourceText sourceText, List<Range> ranges)
        {
            foreach (Token token in GetTokens(this.ParseTreeCache.Get(sourceText).Root))
            {
                foreach (TagInfo tagInfo in GetTokenTagInfos(ranges, token))
                {
                    yield return tagInfo;
                }
            }
        }

        private static IEnumerable<TagInfo> GetTokenTagInfos(List<Range> ranges, Token token)
        {
            foreach (Range range in ranges)
            {
                int start = token.FullStart;
                foreach (Trivia trivia in token.LeadingTrivia)
                {
                    int triviaLength = trivia.Text.Length;
                    if (trivia.Type != SyntaxKind.Newline && trivia.Type != SyntaxKind.Whitespace)
                    {
                        int triviaEnd = start + triviaLength;
                        int tagStart = start > range.Start ? start : range.Start;
                        int tagEnd = triviaEnd < range.End ? triviaEnd : range.End;
                        if (tagStart < tagEnd)
                        {
                            yield return new TagInfo(tagStart, tagEnd - tagStart, SyntaxKindClassifications[trivia.Type]);
                        }
                    }

                    start += triviaLength;
                }

                int tokenStart = token.Start > range.Start ? start : range.Start;
                int tokenEnd = token.End < range.End ? token.End : range.End;
                if (tokenStart < tokenEnd)
                {
                    yield return new TagInfo(tokenStart, tokenEnd - tokenStart, SyntaxKindClassifications[token.Kind]);
                }
            }
        }

        private static IEnumerable<Token> GetTokens(SyntaxNodeOrToken currentRoot)
        {
            if (!SyntaxTree.IsLeafNode(currentRoot))
            {
                SyntaxNode syntaxNode = (SyntaxNode)currentRoot;
                foreach (SyntaxNodeOrToken node in syntaxNode.Children)
                {
                    foreach (Token token in GetTokens(node))
                    {
                        yield return token;
                    }
                }
            }
            else
            {
                Token token = currentRoot as Token;

                if (token != null)
                {
                    yield return token;
                }
            }
        }

        private static readonly ImmutableDictionary<SyntaxKind, Classification> SyntaxKindClassifications =
            new Dictionary<SyntaxKind, Classification>()
            {
                { SyntaxKind.AndBinop, Classification.Punctuation },
                { SyntaxKind.AssignmentOperator, Classification.Operator },
                { SyntaxKind.BitwiseAndOperator, Classification.Operator },
                { SyntaxKind.BitwiseLeftOperator, Classification.Operator },
                { SyntaxKind.BitwiseOrOperator, Classification.Operator },
                { SyntaxKind.BitwiseRightOperator, Classification.Operator },
                { SyntaxKind.BreakKeyword, Classification.Keyword },
                { SyntaxKind.CloseBracket, Classification.Bracket },
                { SyntaxKind.CloseCurlyBrace, Classification.Bracket },
                { SyntaxKind.CloseParen, Classification.Bracket },
                { SyntaxKind.Colon, Classification.Punctuation },
                { SyntaxKind.Comma, Classification.Punctuation },
                { SyntaxKind.Comment, Classification.Comment },
                { SyntaxKind.DivideOperator, Classification.Punctuation },
                { SyntaxKind.DoKeyword, Classification.Keyword },
                { SyntaxKind.Dot, Classification.Punctuation },
                { SyntaxKind.DoubleColon, Classification.Punctuation },
                { SyntaxKind.ElseIfKeyword, Classification.Keyword },
                { SyntaxKind.ElseKeyword, Classification.Keyword },
                { SyntaxKind.EndKeyword, Classification.Keyword },
                { SyntaxKind.EqualityOperator, Classification.Operator },
                { SyntaxKind.ExponentOperator, Classification.Operator },
                { SyntaxKind.FalseKeyValue, Classification.KeyValue },
                { SyntaxKind.FloorDivideOperator, Classification.Operator },
                { SyntaxKind.ForKeyword, Classification.Keyword },
                { SyntaxKind.FunctionKeyword, Classification.Keyword },
                { SyntaxKind.GotoKeyword, Classification.Keyword },
                { SyntaxKind.GreaterOrEqualOperator, Classification.Operator },
                { SyntaxKind.GreaterThanOperator, Classification.Operator },
                { SyntaxKind.IfKeyword, Classification.Keyword },
                { SyntaxKind.InKeyword, Classification.Keyword },
                { SyntaxKind.LengthUnop, Classification.Punctuation },
                { SyntaxKind.LessOrEqualOperator, Classification.Operator },
                { SyntaxKind.LessThanOperator, Classification.Operator },
                { SyntaxKind.LocalKeyword, Classification.Keyword },
                { SyntaxKind.MinusOperator, Classification.Punctuation },
                { SyntaxKind.ModulusOperator, Classification.Operator },
                { SyntaxKind.MultiplyOperator, Classification.Operator },
                { SyntaxKind.NilKeyValue, Classification.KeyValue },
                { SyntaxKind.NotEqualsOperator, Classification.Operator },
                { SyntaxKind.NotUnop, Classification.Punctuation },
                { SyntaxKind.Number, Classification.Number },
                { SyntaxKind.OpenBracket, Classification.Bracket },
                { SyntaxKind.OpenCurlyBrace, Classification.Bracket },
                { SyntaxKind.OpenParen, Classification.Bracket },
                { SyntaxKind.OrBinop, Classification.Punctuation },
                { SyntaxKind.PlusOperator, Classification.Operator },
                { SyntaxKind.RepeatKeyword, Classification.Keyword },
                { SyntaxKind.ReturnKeyword, Classification.Keyword },
                { SyntaxKind.Semicolon, Classification.Punctuation },
                { SyntaxKind.String, Classification.StringLiteral },
                { SyntaxKind.StringConcatOperator, Classification.Operator },
                { SyntaxKind.ThenKeyword, Classification.Keyword },
                { SyntaxKind.TildeUnOp, Classification.Punctuation },
                { SyntaxKind.TrueKeyValue, Classification.KeyValue },
                { SyntaxKind.UnterminatedString, Classification.StringLiteral },
                { SyntaxKind.UntilKeyword, Classification.Keyword },
                { SyntaxKind.WhileKeyword, Classification.Keyword },
            }

            .ToImmutableDictionary();
    }
}
